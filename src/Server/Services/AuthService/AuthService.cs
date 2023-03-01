using System.Security.Claims;
using AutoMapper;
using BlazorShop.Server.Auth.PasswordProvider;
using BlazorShop.Server.Data;
using BlazorShop.Server.Data.Entities;
using BlazorShop.Server.Data.Repositories.SecurityRepository;
using BlazorShop.Server.Data.Repositories.SessionRepository;
using BlazorShop.Server.Data.Repositories.UserRepository;
using BlazorShop.Server.Exceptions;
using BlazorShop.Server.Options;
using BlazorShop.Server.Services.MailService;
using BlazorShop.Server.Services.PaymentService;
using BlazorShop.Server.Services.RoleService;
using BlazorShop.Server.Services.TokenService;
using BlazorShop.Shared.Dtos;
using BlazorShop.Shared.Models;
using Microsoft.Extensions.Options;

namespace BlazorShop.Server.Services.AuthService;

public sealed class AuthService : IAuthService
{
    private readonly IPasswordProvider _passwordProvider;
    private readonly IUserRepository _userRepository;
    private readonly IRoleService _roleService;
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;
    private readonly IPaymentService _paymentService;
    private readonly ISessionRepository _sessionRepository;
    private readonly ISecurityRepository _securityRepository;
    private readonly IMailService _mailService;
    private readonly UrlOptions _urlOptions;

    public AuthService(
        IUserRepository userRepository,
        IRoleService roleService,
        IPasswordProvider passwordProvider,
        IMapper mapper,
        ITokenService tokenService,
        IPaymentService paymentService,
        ISessionRepository sessionRepository, 
        ISecurityRepository securityRepository, 
        IMailService mailService, 
        IOptions<UrlOptions> urlOptions)
    {
        _userRepository = userRepository;
        _roleService = roleService;
        _passwordProvider = passwordProvider;
        _mapper = mapper;
        _tokenService = tokenService;
        _paymentService = paymentService;
        _sessionRepository = sessionRepository;
        _securityRepository = securityRepository;
        _mailService = mailService;
        _urlOptions = urlOptions.Value;
    }

    public async Task RegisterAsync(RegisterDto registerDto)
    {
        var userByUsername = await _userRepository.GetByUsernameAsync(registerDto.Username);
        var userByEmail = await _userRepository.GetByEmailAsync(registerDto.Email);

        if (userByUsername is not null && userByEmail is not null)
            throw new AlreadyExistException(
                ExceptionMessages.UsernameAndEmailAlreadyExist(registerDto.Username, registerDto.Email));

        if (userByUsername is not null)
            throw new AlreadyExistException(
                ExceptionMessages.UsernameAlreadyExist(registerDto.Username));

        if (userByEmail is not null)
            throw new AlreadyExistException(
                ExceptionMessages.EmailAlreadyExist(registerDto.Email));

        if (!registerDto.Password.Equals(registerDto.ConfirmPassword))
            throw new BusinessException(ExceptionMessages.PasswordsNotMatch);

        var user = _mapper.Map<User>(registerDto);

        user.PasswordHash = _passwordProvider.GetPasswordHash(registerDto.Password);

        await _userRepository.CreateAndSaveAsync(user);

        if (await _userRepository.IsEmptyAsync())
            await _roleService.AddUserToRoleAsync(user, Role.Admin);
        else
            await _roleService.AddUserToRoleAsync(user, Role.Customer);

        await _paymentService.AddPaymentProfileAsync(user);

        await _securityRepository.CreateSecurityForUserAsync(user.Id);

        await GetEmailConfirmationLinkAsync(user.Email);
    }

    public async Task<TokenDto> LoginAsync(LoginDto loginDto)
    {
        var userByUsername = await _userRepository.GetByUsernameAsync(loginDto.Login);
        var userByEmail = await _userRepository.GetByEmailAsync(loginDto.Login);
        var user = userByUsername ?? userByEmail;

        if (user is null) throw new NotFoundException(ExceptionMessages.NotRegistered);

        if (!_passwordProvider.VerifyPassword(loginDto.Password, user.PasswordHash))
            throw new NotFoundException(ExceptionMessages.WrongPassword);

        if (!user.IsEmailConfirmed) throw new BusinessException(ExceptionMessages.EmailNotConfirmed(user.Email));

        var accessToken = await _tokenService.GenerateAccessTokenAsync(user);
        var refreshToken = _tokenService.GenerateRefreshToken();

        await _sessionRepository.CreateSessionAsync(user.Id, accessToken, refreshToken);

        return new TokenDto(accessToken, refreshToken);
    }

    public async Task<TokenDto> RefreshAsync(TokenDto tokenDto)
    {
        var principal = _tokenService.GetPrincipalFromExpiredToken(tokenDto.AccessToken);
        
        var userId = Guid.Parse(principal.FindFirstValue(ClaimTypes.NameIdentifier));
        
        var user = await _userRepository.GetByIdAsync(userId);

        if (user is null) throw new NotFoundException(ExceptionMessages.NotRegistered);

        var accessToken = await _tokenService.GenerateAccessTokenAsync(user);
        var refreshToken = _tokenService.GenerateRefreshToken();

        await _sessionRepository.UpdateSessionAsync(user.Id, accessToken, refreshToken);

        return new TokenDto(accessToken, refreshToken);
    }

    public async Task GetConfirmationCodeAsync(string email)
    {
        var user = await _userRepository.GetByEmailAsync(email);

        if (user is null) throw new NotFoundException(ExceptionMessages.NotRegistered);

        var code = await _securityRepository.GenerateConfirmationCode(user.Id);

        await _mailService.SendEmailAsync(email, Emails.ConfirmationCode(code));
    }

    public async Task GetEmailConfirmationLinkAsync(string email)
    {
        var user = await _userRepository.GetByEmailAsync(email);

        if(user is null) throw new NotFoundException(ExceptionMessages.NotRegistered);
        
        if(user.IsEmailConfirmed) throw new BusinessException(ExceptionMessages.EmailAlreadyConfirmed);
        
        var token = await _securityRepository.GenerateConfirmationToken(user.Id);

        var parameters = new ConfirmationParameters(token, user.Email);
        
        var link = GenerateLink(parameters, _urlOptions.EmailConfirmationUrl);
        
        await _mailService.SendEmailAsync(user.Email, Emails.EmailConfirmation(link));
    }

    public async Task GetPasswordResetLinkAsync(string email)
    {
        var user = await _userRepository.GetByEmailAsync(email);

        if(user is null) throw new NotFoundException(ExceptionMessages.NotRegistered);
        
        var token = await _securityRepository.GenerateConfirmationToken(user.Id);

        var parameters = new ConfirmationParameters(token, user.Email);
        
        var link = GenerateLink(parameters, _urlOptions.PasswordResetUrl);
        
        await _mailService.SendEmailAsync(user.Email, Emails.PasswordReset(link));
    }

    public async Task ConfirmEmailAsync(ConfirmationParameters parameters)
    {
        var user = await _userRepository.GetByEmailAsync(parameters.Email);

        if (user is null) throw new NotFoundException(ExceptionMessages.NotRegistered);
        
        if (user.IsEmailConfirmed) throw new BusinessException(ExceptionMessages.EmailAlreadyConfirmed);

        if (await _securityRepository.VerifyConfirmationToken(user.Id, parameters.Token))
        {
            user.IsEmailConfirmed = true;
            await _securityRepository.RemoveConfirmationToken(user.Id);
            await _userRepository.SaveAsync();
        }
    }

    public async Task ResetPasswordAsync(PasswordResetDto passwordResetDto)
    {
        var user = await _userRepository.GetByEmailAsync(passwordResetDto.ConfirmationParameters.Email);
        
        if (user is null) throw new NotFoundException(ExceptionMessages.NotRegistered);
        
        if (!passwordResetDto.Password.Equals(passwordResetDto.ConfirmPassword))
            throw new BusinessException(ExceptionMessages.PasswordsNotMatch);

        if (await _securityRepository.VerifyConfirmationToken(user.Id, passwordResetDto.ConfirmationParameters.Token))
        {
            user.PasswordHash = _passwordProvider.GetPasswordHash(passwordResetDto.Password);
            await _securityRepository.RemoveConfirmationToken(user.Id);
            await _userRepository.SaveAsync();
        }
    }

    private static string GenerateLink(ConfirmationParameters parameters, string url)
    {
        return $"https://{url}?token={parameters.Token}&email={parameters.Email}";
    }
}