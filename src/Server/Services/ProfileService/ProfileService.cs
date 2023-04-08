using AutoMapper;
using BlazorShop.Server.Common;
using BlazorShop.Server.Common.Exceptions;
using BlazorShop.Server.Common.Options;
using BlazorShop.Server.Common.Providers;
using BlazorShop.Server.Common.Providers.LinkProvider;
using BlazorShop.Server.Common.Providers.PasswordProvider;
using BlazorShop.Server.Common.Providers.TokenProvider;
using BlazorShop.Server.Data.Repositories.SecurityRepository;
using BlazorShop.Server.Data.Repositories.SessionRepository;
using BlazorShop.Server.Data.Repositories.UserRepository;
using BlazorShop.Server.Services.MailService;
using BlazorShop.Server.Services.PaymentService;
using BlazorShop.Shared.Dtos;
using BlazorShop.Shared.Models;
using Microsoft.Extensions.Options;

namespace BlazorShop.Server.Services.ProfileService;

public sealed class ProfileService : IProfileService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly IPaymentService _paymentService;
    private readonly ITokenProvider _tokenProvider;
    private readonly ISessionRepository _sessionRepository;
    private readonly ISecurityRepository _securityRepository;
    private readonly IPasswordProvider _passwordProvider;
    private readonly IMailService _mailService;
    private readonly UrlOptions _urlOptions;
    private readonly ILinkProvider _linkProvider;

    public ProfileService(IMapper mapper, IUserRepository userRepository, IPaymentService paymentService,
        ITokenProvider tokenProvider, ISessionRepository sessionRepository, ISecurityRepository securityRepository,
        IPasswordProvider passwordProvider, IMailService mailService,
        ILinkProvider linkProvider, IOptions<UrlOptions> urlOptions)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _paymentService = paymentService;
        _tokenProvider = tokenProvider;
        _sessionRepository = sessionRepository;
        _securityRepository = securityRepository;
        _passwordProvider = passwordProvider;
        _mailService = mailService;
        _linkProvider = linkProvider;
        _urlOptions = urlOptions.Value;
    }

    public async Task<ProfileDto> GetUserProfileAsync(Guid userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);

        return _mapper.Map<ProfileDto>(user);
    }

    public async Task<TokenDto> UpdateUserProfileAsync(Guid userId, ProfileDto newProfileDto)
    {
        var userByUsername = await _userRepository.GetByUsernameAsync(newProfileDto.Username);

        if (userByUsername is not null && userByUsername.Id != userId)
            throw new AlreadyExistException(ExceptionMessages.UsernameAlreadyExist(newProfileDto.Username));

        var user = await _userRepository.GetByIdAsync(userId);

        if (user is null)
            throw new NotFoundException(ExceptionMessages.NotRegistered);

        var updatedUser = _mapper.Map(newProfileDto, user);

        await _userRepository.UpdateAndSaveAsync(updatedUser);

        await _paymentService.UpdatePaymentProfileAsync(updatedUser.Id);

        var accessToken = await _tokenProvider.GenerateAccessTokenAsync(updatedUser);
        var refreshToken = _tokenProvider.GenerateRefreshToken(updatedUser);

        await _sessionRepository.UpdateSessionAsync(user.Id, accessToken, refreshToken);

        return new TokenDto(accessToken, refreshToken);
    }

    public async Task<TokenDto> ChangeEmailAsync(Guid userId, EmailChangeDto emailChangeDto)
    {
        var userByEmail = await _userRepository.GetByEmailAsync(emailChangeDto.NewEmail);

        if (userByEmail is not null && userByEmail.Id != userId)
            throw new AlreadyExistException(ExceptionMessages.EmailAlreadyExist(emailChangeDto.NewEmail));

        var user = await _userRepository.GetByIdAsync(userId);

        if (user is null)
            throw new NotFoundException(ExceptionMessages.NotRegistered);

        await _securityRepository.VerifyConfirmationCode(userId, emailChangeDto.CurrentConfirmationCode);
        await _securityRepository.VerifyNewEmailConfirmationCode(userId, emailChangeDto.NewConfirmationCode);

        user.Email = emailChangeDto.NewEmail;

        await _userRepository.SaveAsync();

        await _paymentService.UpdatePaymentProfileAsync(user.Id);

        var accessToken = await _tokenProvider.GenerateAccessTokenAsync(user);
        var refreshToken = _tokenProvider.GenerateRefreshToken(user);

        await _sessionRepository.UpdateSessionAsync(user.Id, accessToken, refreshToken);

        await _securityRepository.RemoveConfirmationCodes(userId);

        return new TokenDto(accessToken, refreshToken);
    }

    public async Task ChangePasswordAsync(Guid userId, PasswordChangeDto passwordChangeDto)
    {
        var user = await _userRepository.GetByIdAsync(userId);

        if (user is null)
            throw new NotFoundException(ExceptionMessages.NotRegistered);

        await _securityRepository.VerifyConfirmationCode(userId, passwordChangeDto.ConfirmationCode);

        user.PasswordHash = _passwordProvider.GetPasswordHash(passwordChangeDto.NewPassword);

        await _userRepository.SaveAsync();

        await _securityRepository.RemoveConfirmationCodes(userId);
    }

    public async Task GetDeleteProfileLinkAsync(Guid userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);

        if (user is null) throw new NotFoundException(ExceptionMessages.NotRegistered);

        var token = await _securityRepository.GenerateConfirmationToken(user.Id);

        var parameters = new ConfirmationParameters(token, user.Email);

        var link = _linkProvider.GenerateConfirmationLink(_urlOptions.DeleteProfileUrl, parameters);
        
        await _mailService.SendEmailAsync(user.Email, EmailMessages.DeleteProfile(link));
        
    }

    public async Task DeleteProfileAsync(ConfirmationParameters parameters)
    {
        var user = await _userRepository.GetByEmailAsync(parameters.Email);

        if (user is null) throw new NotFoundException(ExceptionMessages.NotRegistered);
        
        await _securityRepository.VerifyConfirmationToken(user.Id, parameters.Token);

        await _paymentService.DeletePaymentProfileAsync(user.Id);
        
        await _userRepository.DeleteAndSaveAsync(user);
    }
}