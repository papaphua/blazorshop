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

    public async Task CreateSecurityForUser(Guid userId)
    {
        var security = new Security { UserId = userId };

        await Context.AddAsync(security);
        await Context.SaveChangesAsync();
    }

    public async Task GenerateEmailConfirmationCode(Guid userId)
    {
        var security = await FindSecurityAsync(userId);

        if (security is null) throw new NotFoundException(ExceptionMessages.NotRegistered);

        security.EmailConfirmationCode = GenerateCode();
        security.EmailConfirmationCodeExpiry =
            DateTime.Now + TimeSpan.FromMinutes(_options.SecurityCodeExpiryInMinutes);

        await Context.SaveChangesAsync();
    }

    public async Task VerifyEmailConfirmationCode(User user, string code)
    {
        var security = await FindSecurityAsync(user.Id);

        if (security is null) throw new NotFoundException(ExceptionMessages.NotRegistered);

        if (security.EmailConfirmationCode is null) await GenerateEmailConfirmationCode(user.Id);

        if (DateTime.Now > security.EmailConfirmationCodeExpiry)
            throw new BusinessException(ExceptionMessages.ExpiredCode);

        if (!security.EmailConfirmationCode.Equals(code))
            throw new BusinessException(ExceptionMessages.WrongCode);

        user.IsEmailConfirmed = true;
        
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