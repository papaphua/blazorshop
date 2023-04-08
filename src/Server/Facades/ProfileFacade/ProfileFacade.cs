using AutoMapper;
using BlazorShop.Server.Common;
using BlazorShop.Server.Common.Exceptions;
using BlazorShop.Server.Common.Options;
using BlazorShop.Server.Common.Providers.LinkProvider;
using BlazorShop.Server.Common.Providers.PasswordProvider;
using BlazorShop.Server.Common.Providers.TokenProvider;
using BlazorShop.Server.Data;
using BlazorShop.Server.Services.MailService;
using BlazorShop.Server.Services.PaymentService;
using BlazorShop.Server.Services.SecurityService;
using BlazorShop.Server.Services.SessionService;
using BlazorShop.Server.Services.UserService;
using BlazorShop.Shared.Dtos;
using BlazorShop.Shared.Models;
using Microsoft.Extensions.Options;

namespace BlazorShop.Server.Facades.ProfileFacade;

public sealed class ProfileFacade : IProfileFacade
{
    private readonly IMapper _mapper;
    private readonly IUserService _userService;
    private readonly IPaymentService _paymentService;
    private readonly ITokenProvider _tokenProvider;
    private readonly ISessionService _sessionService;
    private readonly ISecurityService _securityService;
    private readonly IPasswordProvider _passwordProvider;
    private readonly IMailService _mailService;
    private readonly UrlOptions _urlOptions;
    private readonly ILinkProvider _linkProvider;
    private readonly AppDbContext _db;

    public ProfileFacade(IMapper mapper, IUserService userService, IPaymentService paymentService,
        ITokenProvider tokenProvider, ISessionService sessionService, ISecurityService securityService,
        IPasswordProvider passwordProvider, IMailService mailService,
        ILinkProvider linkProvider, IOptions<UrlOptions> urlOptions, AppDbContext db)
    {
        _mapper = mapper;
        _userService = userService;
        _paymentService = paymentService;
        _tokenProvider = tokenProvider;
        _sessionService = sessionService;
        _securityService = securityService;
        _passwordProvider = passwordProvider;
        _mailService = mailService;
        _linkProvider = linkProvider;
        _db = db;
        _urlOptions = urlOptions.Value;
    }

    public async Task<ProfileDto> GetUserProfileAsync(Guid userId)
    {
        var user = await _userService.GetUserByIdAsync(userId);

        return _mapper.Map<ProfileDto>(user);
    }

    public async Task<TokenDto> UpdateUserProfileAsync(Guid userId, ProfileDto newProfileDto)
    {
        var userByUsername = await _userService.GetUserByUsernameAsync(newProfileDto.Username);

        if (userByUsername is not null && userByUsername.Id != userId)
            throw new AlreadyExistException(ExceptionMessages.UsernameAlreadyExist(newProfileDto.Username));

        var user = await _userService.GetUserByIdAsync(userId);

        if (user is null)
            throw new NotFoundException(ExceptionMessages.NotRegistered);

        var updatedUser = _mapper.Map(newProfileDto, user);

        _db.Users.Update(updatedUser);

        await _paymentService.UpdatePaymentProfileAsync(updatedUser.Id);

        var accessToken = await _tokenProvider.GenerateAccessTokenAsync(updatedUser);
        var refreshToken = _tokenProvider.GenerateRefreshToken(updatedUser);

        await _sessionService.UpdateSessionAsync(user.Id, accessToken, refreshToken);

        return new TokenDto(accessToken, refreshToken);
    }

    public async Task<TokenDto> ChangeEmailAsync(Guid userId, EmailChangeDto emailChangeDto)
    {
        var userByEmail = await _userService.GetUserByEmailAsync(emailChangeDto.NewEmail);

        if (userByEmail is not null && userByEmail.Id != userId)
            throw new AlreadyExistException(ExceptionMessages.EmailAlreadyExist(emailChangeDto.NewEmail));

        var user = await _userService.GetUserByIdAsync(userId);

        if (user is null)
            throw new NotFoundException(ExceptionMessages.NotRegistered);

        await _securityService.IsConfirmationCodeValidAsync(userId, emailChangeDto.CurrentConfirmationCode);
        await _securityService.IsNewEmailConfirmationCodeValidAsync(userId, emailChangeDto.NewConfirmationCode);

        user.Email = emailChangeDto.NewEmail;

        await _db.SaveChangesAsync();

        await _paymentService.UpdatePaymentProfileAsync(user.Id);

        var accessToken = await _tokenProvider.GenerateAccessTokenAsync(user);
        var refreshToken = _tokenProvider.GenerateRefreshToken(user);

        await _sessionService.UpdateSessionAsync(user.Id, accessToken, refreshToken);

        await _securityService.RemoveConfirmationCodesAsync(userId);

        return new TokenDto(accessToken, refreshToken);
    }

    public async Task ChangePasswordAsync(Guid userId, PasswordChangeDto passwordChangeDto)
    {
        var user = await _userService.GetUserByIdAsync(userId);

        if (user is null)
            throw new NotFoundException(ExceptionMessages.NotRegistered);

        await _securityService.IsConfirmationCodeValidAsync(userId, passwordChangeDto.ConfirmationCode);

        user.PasswordHash = _passwordProvider.GetPasswordHash(passwordChangeDto.NewPassword);

        await _db.SaveChangesAsync();

        await _securityService.RemoveConfirmationCodesAsync(userId);
    }

    public async Task GetDeleteProfileLinkAsync(Guid userId)
    {
        var user = await _userService.GetUserByIdAsync(userId);

        if (user is null) throw new NotFoundException(ExceptionMessages.NotRegistered);

        var token = await _securityService.GenerateConfirmationCodeAsync(user.Id);

        var parameters = new ConfirmationParameters(token, user.Email);

        var link = _linkProvider.GenerateConfirmationLink(_urlOptions.DeleteProfileUrl, parameters);
        
        await _mailService.SendEmailAsync(user.Email, EmailMessages.DeleteProfile(link));
        
    }

    public async Task DeleteProfileAsync(ConfirmationParameters parameters)
    {
        var user = await _userService.GetUserByEmailAsync(parameters.Email);

        if (user is null) throw new NotFoundException(ExceptionMessages.NotRegistered);
        
        await _securityService.IsConfirmationCodeValidAsync(user.Id, parameters.Token);

        await _paymentService.DeletePaymentProfileAsync(user.Id);

        _db.Users.Remove(user);
        await _db.SaveChangesAsync();
    }
}