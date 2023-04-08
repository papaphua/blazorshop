using BlazorShop.Server.Common;
using BlazorShop.Server.Common.Exceptions;
using BlazorShop.Server.Common.Options;
using BlazorShop.Server.Common.Providers.TokenProvider;
using BlazorShop.Server.Data;
using BlazorShop.Server.Data.Entities;
using BlazorShop.Server.Services.UserService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BlazorShop.Server.Services.SecurityService;

public sealed class SecurityService : ISecurityService
{
    private const int CodeLength = 5;

    private readonly AppDbContext _db;
    private readonly ITokenProvider _tokenProvider;
    private readonly IUserService _userService;
    private readonly SecurityOptions _securityOptions;

    public SecurityService(AppDbContext db, ITokenProvider tokenProvider, IUserService userService,
        IOptions<SecurityOptions> securityOptions)
    {
        _db = db;
        _tokenProvider = tokenProvider;
        _userService = userService;
        _securityOptions = securityOptions.Value;
    }

    public async Task<Security> CreateSecurityForUserAsync(Guid userId)
    {
        var security = new Security { UserId = userId };

        await _db.Securities.AddAsync(security);
        await _db.SaveChangesAsync();

        return security;
    }

    public async Task<string> GenerateConfirmationTokenAsync(Guid userId)
    {
        var user = await _userService.GetUserByIdAsync(userId);

        if (user is null) throw new NotFoundException(ExceptionMessages.UserNotFound);

        var security = await GetSecurityByUserIdAsync(userId);

        if (security is null) throw new NotFoundException(ExceptionMessages.UserNotFound);

        security.ConfirmationToken = _tokenProvider.GenerateConfirmationToken(user);
        security.ConfirmationTokenExpiry = DateTime.UtcNow.AddMinutes(_securityOptions.ConfirmationTokenExpiryInMinutes);

        await _db.SaveChangesAsync();

        return security.ConfirmationToken;
    }

    public async Task<string> GenerateConfirmationCodeAsync(Guid userId)
    {
        var security = await GetSecurityByUserIdAsync(userId);

        if (security is null) throw new NotFoundException(ExceptionMessages.NotRegistered);

        security.ConfirmationCode = GenerateCode(CodeLength);
        security.ConfirmationCodeExpiry = DateTime.UtcNow.AddMinutes(_securityOptions.ConfirmationCodeExpiryInMinutes);

        await _db.SaveChangesAsync();

        return security.ConfirmationCode;
    }

    public async Task<string> GenerateNewEmailConfirmationCodeAsync(Guid userId)
    {
        var security = await GetSecurityByUserIdAsync(userId);
        
        if(security is null) throw new NotFoundException(ExceptionMessages.NotRegistered);

        security.NewEmailConfirmationCode = GenerateCode(CodeLength);

        await _db.SaveChangesAsync();
     
        return security.NewEmailConfirmationCode;
    }

    public async Task<bool> IsConfirmationTokenValidAsync(Guid userId, string token)
    {
        var security = await GetSecurityByUserIdAsync(userId);
        
        if (security is null) throw new NotFoundException(ExceptionMessages.NotRegistered);
        
        if(security.ConfirmationToken is null || 
           security.ConfirmationTokenExpiry is null ||
           DateTime.UtcNow > security.ConfirmationTokenExpiry) 
            throw new BusinessException(ExceptionMessages.ExpiredLink);
        

        if (!security.ConfirmationToken.Equals(token))
            throw new BusinessException(ExceptionMessages.WrongLink);

        return true;
    }

    public async Task<bool> IsConfirmationCodeValidAsync(Guid userId, string code)
    {
        var security = await GetSecurityByUserIdAsync(userId);

        if (security is null) throw new NotFoundException(ExceptionMessages.NotRegistered);

        if(security.ConfirmationCode is null || 
           security.ConfirmationCodeExpiry is null || 
           DateTime.UtcNow > security.ConfirmationCodeExpiry) 
            throw new BusinessException(ExceptionMessages.ExpiredCode);

        if (!security.ConfirmationCode.Equals(code))
            throw new BusinessException(ExceptionMessages.WrongCode);

        return true;
    }

    public async Task<bool> IsNewEmailConfirmationCodeValidAsync(Guid userId, string code)
    {
        var security = await GetSecurityByUserIdAsync(userId);

        if (security is null) throw new NotFoundException(ExceptionMessages.NotRegistered);

        if(security.NewEmailConfirmationCode is null || 
           security.ConfirmationCodeExpiry is null || 
           DateTime.UtcNow > security.ConfirmationCodeExpiry) 
            throw new BusinessException(ExceptionMessages.ExpiredCode);

        if (!security.NewEmailConfirmationCode.Equals(code))
            throw new BusinessException(ExceptionMessages.WrongCode);

        return true;
    }

    public async Task RemoveConfirmationTokenAsync(Guid userId)
    {
        var security = await GetSecurityByUserIdAsync(userId);

        if (security is null) throw new NotFoundException(ExceptionMessages.NotRegistered);

        security.ConfirmationToken = null;
        security.ConfirmationTokenExpiry = null;

        await _db.SaveChangesAsync();
    }

    public async Task RemoveConfirmationCodesAsync(Guid userId)
    {
        var security = await GetSecurityByUserIdAsync(userId);

        if (security is null) throw new NotFoundException(ExceptionMessages.NotRegistered);

        security.ConfirmationCode = null;
        security.NewEmailConfirmationCode = null;
        security.ConfirmationCodeExpiry = null;

        await _db.SaveChangesAsync();
    }

    private async Task<Security?> GetSecurityByUserIdAsync(Guid userId)
    {
        var security = await _db.Securities
            .FirstOrDefaultAsync(security => security.UserId.Equals(userId));
        
        if (security is null) throw new NotFoundException(ExceptionMessages.NotRegistered);
        
        return security;    
    }

    private static string GenerateCode(int length)
    {
        var random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}