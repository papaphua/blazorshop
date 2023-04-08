using System.Security.Claims;
using AutoMapper;
using BlazorShop.Server.Common;
using BlazorShop.Server.Common.Exceptions;
using BlazorShop.Server.Common.Options;
using BlazorShop.Server.Common.Providers.LinkProvider;
using BlazorShop.Server.Common.Providers.PasswordProvider;
using BlazorShop.Server.Common.Providers.TokenProvider;
using BlazorShop.Server.Data.Entities;
using BlazorShop.Server.Data.Repositories.SecurityRepository;
using BlazorShop.Server.Data.Repositories.SessionRepository;
using BlazorShop.Server.Data.Repositories.UserRepository;
using BlazorShop.Server.Services.MailService;
using BlazorShop.Server.Services.PaymentService;
using BlazorShop.Server.Services.RoleService;
using BlazorShop.Shared.Dtos;
using BlazorShop.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace BlazorShop.Server.Services.AuthService;

public sealed class AuthService : IAuthService
{
    private readonly IPasswordProvider _passwordProvider;
    private readonly IUserRepository _userRepository;
    private readonly IRoleService _roleService;
    private readonly ITokenProvider _tokenProvider;
    private readonly IMapper _mapper;
    private readonly IPaymentService _paymentService;
    private readonly ISessionRepository _sessionRepository;
    private readonly ISecurityRepository _securityRepository;
    private readonly IMailService _mailService;
    private readonly UrlOptions _urlOptions;
    private readonly ILinkProvider _linkProvider;

    public AuthService(
        IUserRepository userRepository,
        IRoleService roleService,
        IPasswordProvider passwordProvider,
        IMapper mapper,
        ITokenProvider tokenProvider,
        IPaymentService paymentService,
        ISessionRepository sessionRepository,
        ISecurityRepository securityRepository,
        IMailService mailService,
        IOptions<UrlOptions> urlOptions,
        ILinkProvider linkProvider)
    {
        _userRepository = userRepository;
        _roleService = roleService;
        _passwordProvider = passwordProvider;
        _mapper = mapper;
        _tokenProvider = tokenProvider;
        _paymentService = paymentService;
        _sessionRepository = sessionRepository;
        _securityRepository = securityRepository;
        _mailService = mailService;
        _linkProvider = linkProvider;
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
            await _roleService.AddUserToRoleAsync(user, Roles.Admin);
        else
            await _roleService.AddUserToRoleAsync(user, Roles.Customer);

        await _paymentService.AddPaymentProfileAsync(user);

        await _securityRepository.CreateSecurityForUserAsync(user.Id);

        await GetEmailConfirmationLinkAsync(user.Id);
    }

    public async Task<string> FindLoginInfoAsync(LoginDto loginDto)
    {
        var userByUsername = await _userRepository.GetByUsernameAsync(loginDto.Login);
        var userByEmail = await _userRepository.GetByEmailAsync(loginDto.Login);
        var user = userByUsername ?? userByEmail;

        if (user is null) throw new NotFoundException(ExceptionMessages.NotRegistered);

        if (!user.IsEmailConfirmed) throw new BusinessException(ExceptionMessages.EmailNotConfirmed(user.Email));

        if (!user.IsTwoAuth) return _linkProvider.GenerateLoginLink(_urlOptions.DefaultLoginUrl, loginDto.Login);

        await _securityRepository.GenerateConfirmationCode(user.Id);
        await GetConfirmationCodeAsync(user.Id);
        return _linkProvider.GenerateLoginLink(_urlOptions.TwoAuthLoginUrl, loginDto.Login);
    }

    public async Task<AuthDto> DefaultLoginAsync(DefaultLoginDto defaultLoginDto)
    {
        var userByUsername = await _userRepository.GetByUsernameAsync(defaultLoginDto.Login);
        var userByEmail = await _userRepository.GetByEmailAsync(defaultLoginDto.Login);
        var user = userByUsername ?? userByEmail;

        if (user is null) throw new NotFoundException(ExceptionMessages.NotRegistered);

        if (user.IsTwoAuth)
        {
            return new AuthDto
            {
                IsSucceeded = false,
                Url = _linkProvider.GenerateLoginLink(_urlOptions.TwoAuthLoginUrl, defaultLoginDto.Login),
                Tokens = null
            };
        }

        if (!_passwordProvider.VerifyPassword(defaultLoginDto.Password, user.PasswordHash))
            throw new NotFoundException(ExceptionMessages.WrongPassword);

        if (!user.IsEmailConfirmed) throw new BusinessException(ExceptionMessages.EmailNotConfirmed(user.Email));

        var accessToken = await _tokenProvider.GenerateAccessTokenAsync(user);
        var refreshToken = _tokenProvider.GenerateRefreshToken(user);

        await _sessionRepository.CreateSessionAsync(user.Id, accessToken, refreshToken);

        return new AuthDto
        {
            IsSucceeded = true,
            Url = null,
            Tokens = new TokenDto(accessToken, refreshToken)
        };
    }

    public async Task<AuthDto> TwoAuthLoginAsync(TwoAuthLoginDto twoAuthLoginDto)
    {
        var userByUsername = await _userRepository.GetByUsernameAsync(twoAuthLoginDto.Login);
        var userByEmail = await _userRepository.GetByEmailAsync(twoAuthLoginDto.Login);
        var user = userByUsername ?? userByEmail;

        if (user is null) throw new NotFoundException(ExceptionMessages.NotRegistered);

        if (!user.IsTwoAuth)
        {
            return new AuthDto
            {
                IsSucceeded = false,
                Url = _linkProvider.GenerateLoginLink(_urlOptions.DefaultLoginUrl, twoAuthLoginDto.Login),
                Tokens = null
            };
        }

        if (!_passwordProvider.VerifyPassword(twoAuthLoginDto.Password, user.PasswordHash))
            throw new NotFoundException(ExceptionMessages.WrongPassword);

        await _securityRepository.VerifyConfirmationCode(user.Id, twoAuthLoginDto.ConfirmationCode);

        var accessToken = await _tokenProvider.GenerateAccessTokenAsync(user);
        var refreshToken = _tokenProvider.GenerateRefreshToken(user);

        await _sessionRepository.CreateSessionAsync(user.Id, accessToken, refreshToken);

        await _securityRepository.RemoveConfirmationCodes(user.Id);

        return new AuthDto
        {
            IsSucceeded = true,
            Url = null,
            Tokens = new TokenDto(accessToken, refreshToken)
        };
    }

    public async Task<AuthDto> RefreshAsync([FromBody] TokenDto tokenDto)
    {
        var principal = _tokenProvider.GetPrincipalFromExpiredToken(tokenDto.AccessToken);

        var userId = Guid.Parse(principal.FindFirstValue(ClaimTypes.NameIdentifier));

        var user = await _userRepository.GetByIdAsync(userId);

        if (user is null) throw new NotFoundException(ExceptionMessages.NotRegistered);

        var session = await _sessionRepository.GetSessionInfoAsync(userId);

        if (session is null) return new AuthDto { IsSucceeded = false };

        if (session.RefreshToken != tokenDto.RefreshToken ||
            session.RefreshTokenExpiryTime <= DateTime.UtcNow)
        {
            await _sessionRepository.DeleteAndSaveAsync(session);
            return new AuthDto { IsSucceeded = false };
        }

        var accessToken = await _tokenProvider.GenerateAccessTokenAsync(user);
        var refreshToken = _tokenProvider.GenerateRefreshToken(user);

        await _sessionRepository.UpdateSessionAsync(user.Id, accessToken, refreshToken);

        return new AuthDto { IsSucceeded = true, Tokens = new TokenDto(accessToken, refreshToken) };
    }

    public async Task GetConfirmationCodeAsync(Guid userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);

        if (user is null) throw new NotFoundException(ExceptionMessages.NotRegistered);

        var code = await _securityRepository.GenerateConfirmationCode(user.Id);

        await _mailService.SendEmailAsync(user.Email, EmailMessages.ConfirmationCode(code));
    }

    public async Task GetNewEmailConfirmationCodesAsync(Guid userId, string email)
    {
        var user = await _userRepository.GetByIdAsync(userId);

        if (user is null) throw new NotFoundException(ExceptionMessages.NotRegistered);

        var code = await _securityRepository.GenerateNewEmailConfirmationCode(userId);

        await _mailService.SendEmailAsync(email, EmailMessages.ConfirmationCode(code));
    }

    public async Task GetEmailConfirmationLinkAsync(Guid userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);

        if (user is null) throw new NotFoundException(ExceptionMessages.NotRegistered);

        if (user.IsEmailConfirmed) throw new BusinessException(ExceptionMessages.EmailAlreadyConfirmed);

        var token = await _securityRepository.GenerateConfirmationToken(user.Id);

        var parameters = new ConfirmationParameters(token, user.Email);

        var link = _linkProvider.GenerateConfirmationLink(_urlOptions.EmailConfirmationUrl, parameters);

        await _mailService.SendEmailAsync(user.Email, EmailMessages.EmailConfirmation(link));
    }

    public async Task GetPasswordResetLinkAsync(EmailDto emailDto)
    {
        var user = await _userRepository.GetByEmailAsync(emailDto.Email);

        if (user is null) throw new NotFoundException(ExceptionMessages.NotRegistered);

        var token = await _securityRepository.GenerateConfirmationToken(user.Id);

        var parameters = new ConfirmationParameters(token, user.Email);

        var link = _linkProvider.GenerateConfirmationLink(_urlOptions.PasswordResetUrl, parameters);

        await _mailService.SendEmailAsync(user.Email, EmailMessages.PasswordReset(link));
    }

    public async Task<ResponseDto> ConfirmEmailAsync(ConfirmationParameters parameters)
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
        
        return new ResponseDto("Email confirmed");
    }

    public async Task ResetPasswordAsync(PasswordResetDto passwordResetDto)
    {
        var user = await _userRepository.GetByEmailAsync(passwordResetDto.ConfirmationParameters.Email);

        if (user is null) throw new NotFoundException(ExceptionMessages.NotRegistered);

        if (!passwordResetDto.NewPassword.Equals(passwordResetDto.ConfirmPassword))
            throw new BusinessException(ExceptionMessages.PasswordsNotMatch);

        if (await _securityRepository.VerifyConfirmationToken(user.Id, passwordResetDto.ConfirmationParameters.Token))
        {
            user.PasswordHash = _passwordProvider.GetPasswordHash(passwordResetDto.NewPassword);
            await _securityRepository.RemoveConfirmationToken(user.Id);
            await _userRepository.SaveAsync();
        }
    }
}