using System.Security.Cryptography;
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

    public SecurityRepository(AppDbContext context, IOptions<SecurityOptions> options)
        : base(context)
    {
        _options = options.Value;
    }

    public async Task CreateSecurityForUserAsync(Guid userId)
    {
        var security = new Security { UserId = userId };

        await Context.AddAsync(security);
        await Context.SaveChangesAsync();
    }

    public async Task<string> GenerateConfirmationCode(Guid userId)
    {
        var security = await FindSecurityAsync(userId);
        
        if(security is null) throw new NotFoundException(ExceptionMessages.NotRegistered);

        security.ConfirmationCode = GenerateCode();
        security.ConfirmationCodeExpiry = DateTime.Now.AddMinutes(_options.SecurityCodeExpiryInMinutes);
        
        await Context.SaveChangesAsync();
     
        return security.ConfirmationCode;
    }

    public async Task<bool> VerifyConfirmationCode(User user, string code)
    {
        var security = await FindSecurityAsync(user.Id);

        if (security is null) throw new NotFoundException(ExceptionMessages.NotRegistered);

        if(security.ConfirmationCode is null || security.ConfirmationCodeExpiry is null) 
            throw new BusinessException(ExceptionMessages.ExpiredCode);
        
        if (DateTime.Now > security.ConfirmationCodeExpiry)
            throw new BusinessException(ExceptionMessages.ExpiredCode);

        if (!security.ConfirmationCode.Equals(code))
            throw new BusinessException(ExceptionMessages.WrongCode);

        return true;
    }

    public async Task RemoveVerificationCode(Guid userId)
    {
        var security = await FindSecurityAsync(userId);

        if (security is null) throw new NotFoundException(ExceptionMessages.NotRegistered);

        security.ConfirmationCode = null;
        security.ConfirmationCodeExpiry = null;

        await Context.SaveChangesAsync();
    }

    private async Task<Security?> FindSecurityAsync(Guid userId)
    {
        return await Context.Set<Security>()
            .FirstOrDefaultAsync(security => security.UserId == userId);
    }

    private string GenerateCode()
    {
        var randomNumber = new byte[6];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }
}