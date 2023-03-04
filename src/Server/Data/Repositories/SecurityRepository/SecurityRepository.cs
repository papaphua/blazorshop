using System.Security.Claims;
using System.Security.Cryptography;
using BlazorShop.Server.Auth.AuthTokenProvider;
using BlazorShop.Server.Data.Entities;
using BlazorShop.Server.Data.Repositories.BaseRepository;
using BlazorShop.Server.Exceptions;
using BlazorShop.Server.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BlazorShop.Server.Data.Repositories.SecurityRepository;

public sealed class SecurityRepository : BaseRepository<Security>, ISecurityRepository
{
    private readonly SecurityOptions _options;
    private readonly IAuthTokenProvider _authTokenProvider;

    public SecurityRepository(AppDbContext context, IOptions<SecurityOptions> options, IAuthTokenProvider authTokenProvider)
        : base(context)
    {
        _authTokenProvider = authTokenProvider;
        _options = options.Value;
    }

    public async Task CreateSecurityForUserAsync(Guid userId)
    {
        var security = new Security { UserId = userId };

        await Context.AddAsync(security);
        await Context.SaveChangesAsync();
    }

    public async Task<string> GenerateConfirmationToken(Guid userId)
    {
        var security = await FindSecurityAsync(userId);
        
        if(security is null) throw new NotFoundException(ExceptionMessages.NotRegistered);

        security.ConfirmationToken = _authTokenProvider.CreateToken(new List<Claim>());
        security.ConfirmationTokenExpiry = DateTime.Now.AddMinutes(_options.ConfirmationTokenExpiryInMinutes);

        await Context.SaveChangesAsync();
     
        return security.ConfirmationToken;
    }

    public async Task<string> GenerateConfirmationCode(Guid userId)
    {
        var security = await FindSecurityAsync(userId);
        
        if(security is null) throw new NotFoundException(ExceptionMessages.NotRegistered);

        security.ConfirmationCode = GenerateCode(6);
        security.ConfirmationCodeExpiry = DateTime.Now.AddMinutes(_options.ConfirmationCodeExpiryInMinutes);
        
        await Context.SaveChangesAsync();
     
        return security.ConfirmationCode;
    }

    public async Task<string> GenerateNewEmailConfirmationCode(Guid userId)
    {
        var security = await FindSecurityAsync(userId);
        
        if(security is null) throw new NotFoundException(ExceptionMessages.NotRegistered);

        security.NewEmailConfirmationCode = GenerateCode(6);

        await Context.SaveChangesAsync();
     
        return security.NewEmailConfirmationCode;
    }

    public async Task<bool> VerifyConfirmationCode(Guid userId, string code)
    {
        var security = await FindSecurityAsync(userId);

        if (security is null) throw new NotFoundException(ExceptionMessages.NotRegistered);

        if(security.ConfirmationCode is null || 
           security.ConfirmationCodeExpiry is null || 
           DateTime.Now > security.ConfirmationCodeExpiry) 
            throw new BusinessException(ExceptionMessages.ExpiredCode);

        if (!security.ConfirmationCode.Equals(code))
            throw new BusinessException(ExceptionMessages.WrongCode);

        return true;
    }

    public async Task<bool> VerifyNewEmailConfirmationCode(Guid userId, string code)
    {
        var security = await FindSecurityAsync(userId);

        if (security is null) throw new NotFoundException(ExceptionMessages.NotRegistered);

        if(security.NewEmailConfirmationCode is null || 
           security.ConfirmationCodeExpiry is null || 
           DateTime.Now > security.ConfirmationCodeExpiry) 
            throw new BusinessException(ExceptionMessages.ExpiredCode);

        if (!security.NewEmailConfirmationCode.Equals(code))
            throw new BusinessException(ExceptionMessages.WrongCode);

        return true;
    }

    public async Task<bool> VerifyConfirmationToken(Guid userId, string token)
    {
        var security = await FindSecurityAsync(userId);
        
        if (security is null) throw new NotFoundException(ExceptionMessages.NotRegistered);
        
        if(security.ConfirmationToken is null || 
           security.ConfirmationTokenExpiry is null ||
           DateTime.Now > security.ConfirmationTokenExpiry) 
            throw new BusinessException(ExceptionMessages.ExpiredLink);
        

        if (!security.ConfirmationToken.Equals(token))
            throw new BusinessException(ExceptionMessages.WrongLink);

        return true;
    }

    public async Task RemoveConfirmationCodes(Guid userId)
    {
        var security = await FindSecurityAsync(userId);

        if (security is null) throw new NotFoundException(ExceptionMessages.NotRegistered);

        security.ConfirmationCode = null;
        security.NewEmailConfirmationCode = null;
        security.ConfirmationCodeExpiry = null;

        await Context.SaveChangesAsync();
    }

    public async Task RemoveConfirmationToken(Guid userId)
    {
        var security = await FindSecurityAsync(userId);

        if (security is null) throw new NotFoundException(ExceptionMessages.NotRegistered);

        security.ConfirmationToken = null;
        security.ConfirmationTokenExpiry = null;

        await Context.SaveChangesAsync();
    }

    private async Task<Security?> FindSecurityAsync(Guid userId)
    {
        return await Context.Set<Security>()
            .FirstOrDefaultAsync(security => security.UserId == userId);
    }

    private static string GenerateCode(int length)
    {
        var randomNumber = new byte[length];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }
}