using AutoMapper;
using BlazorShop.Server.Common;
using BlazorShop.Server.Common.Exceptions;
using BlazorShop.Server.Common.Options;
using BlazorShop.Server.Common.Providers.LinkProvider;
using BlazorShop.Server.Common.Providers.PasswordProvider;
using BlazorShop.Server.Common.Providers.TokenProvider;
using BlazorShop.Server.Data;
using BlazorShop.Server.Data.Entities;
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
    private readonly AppDbContext _db;
    private readonly ILinkProvider _linkProvider;
    private readonly IMailService _mailService;
    private readonly IMapper _mapper;
    private readonly IPasswordProvider _passwordProvider;
    private readonly IPaymentService _paymentService;
    private readonly ISecurityService _securityService;
    private readonly ISessionService _sessionService;
    private readonly ITokenProvider _tokenProvider;
    private readonly UrlOptions _urlOptions;
    private readonly IUserService _userService;

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

        if (user is null) throw new NotFoundException(ExceptionMessages.Unauthorized);
        
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

        string accessToken;
        string refreshToken;
        User updatedUser;
        
        var transaction = await _db.Database.BeginTransactionAsync();
        const string savepoint = nameof(UpdateUserProfileAsync);
        await transaction.CreateSavepointAsync(savepoint);
        
        try
        {
            updatedUser = _mapper.Map(newProfileDto, user);
            await _userService.UpdateUserAsync(updatedUser);
            
            accessToken = await _tokenProvider.GenerateAccessTokenAsync(updatedUser);
            refreshToken = _tokenProvider.GenerateRefreshToken(updatedUser);
            await _sessionService.UpdateSessionAsync(user.Id, accessToken, refreshToken);

            await transaction.CommitAsync();
        }
        catch (Exception)
        {
            await transaction.RollbackToSavepointAsync(savepoint);
            
            throw;
        }
        
        await _paymentService.UpdatePaymentProfileAsync(updatedUser.Id);

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

        string accessToken;
        string refreshToken;
        
        var transaction = await _db.Database.BeginTransactionAsync();
        const string savepoint = nameof(ChangeEmailAsync);
        await transaction.CreateSavepointAsync(savepoint);

        try
        {
            user.Email = emailChangeDto.NewEmail;
            await _db.SaveChangesAsync();
            
            accessToken = await _tokenProvider.GenerateAccessTokenAsync(user);
            refreshToken = _tokenProvider.GenerateRefreshToken(user);
            await _sessionService.UpdateSessionAsync(user.Id, accessToken, refreshToken);
            
            await _securityService.RemoveConfirmationCodesAsync(userId);

            await transaction.CommitAsync();
        }
        catch (Exception)
        {
            await transaction.RollbackToSavepointAsync(savepoint);
            
            throw;
        }
        
        await _paymentService.UpdatePaymentProfileAsync(user.Id);
        
        return new TokenDto(accessToken, refreshToken);
    }

    public async Task ChangePasswordAsync(Guid userId, PasswordChangeDto passwordChangeDto)
    {
        var user = await _userService.GetUserByIdAsync(userId);

        if (user is null)
            throw new NotFoundException(ExceptionMessages.NotRegistered);

        await _securityService.IsConfirmationCodeValidAsync(userId, passwordChangeDto.ConfirmationCode);

        var transaction = await _db.Database.BeginTransactionAsync();
        const string savepoint = nameof(ChangePasswordAsync);
        await transaction.CreateSavepointAsync(savepoint);

        try
        {
            user.PasswordHash = _passwordProvider.GetPasswordHash(passwordChangeDto.NewPassword);
            await _db.SaveChangesAsync();

            await _securityService.RemoveConfirmationCodesAsync(userId);
            
            await transaction.CommitAsync();
        }
        catch (Exception)
        {
            await transaction.RollbackToSavepointAsync(savepoint);
            
            throw;
        }
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

        await _userService.DeleteUserAsync(user.Id);
        
        await _db.SaveChangesAsync();
        
        await _paymentService.DeletePaymentProfileAsync(user.Id);
    }
}