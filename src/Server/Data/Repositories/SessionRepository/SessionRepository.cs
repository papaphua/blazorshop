﻿using BlazorShop.Server.Common.Options;
using BlazorShop.Server.Data.Entities;
using BlazorShop.Server.Data.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BlazorShop.Server.Data.Repositories.SessionRepository;

public sealed class SessionRepository : BaseRepository<Session>, ISessionRepository
{
    private readonly JwtOptions _options;

    public SessionRepository(AppDbContext context, IOptions<JwtOptions> options)
        : base(context)
    {
        _options = options.Value;
    }

    public async Task<Session?> GetSessionInfoAsync(Guid userId)
    {
        return await Context.Set<Session>()
            .FirstOrDefaultAsync(session => session.UserId == userId);
    }

    public async Task CreateSessionAsync(Guid userId, string accessToken, string refreshToken)
    {
        if (await FindSessionsAsync(userId) is not null)
        {
            await UpdateSessionAsync(userId, accessToken, refreshToken);
            return;
        }
        
        var session = new Session
        {
            UserId = userId, AccessToken = accessToken, RefreshToken = refreshToken,
            RefreshTokenExpiryTime = DateTime.UtcNow.AddMinutes(_options.RefreshTokenExpiryInMinutes)
        };
        
        await Context.AddAsync(session);
        await Context.SaveChangesAsync();
    }

    public async Task UpdateSessionAsync(Guid userId, string accessToken, string refreshToken)
    {
        var session = await FindSessionsAsync(userId);

        if (session is null) return; //Logout
        
        session.AccessToken = accessToken;
        session.RefreshToken = refreshToken;
        session.RefreshTokenExpiryTime = DateTime.UtcNow.AddMinutes(_options.RefreshTokenExpiryInMinutes);
        
        await Context.SaveChangesAsync();
    }

    private async Task<Session?> FindSessionsAsync(Guid userId)
    {
        return await Context.Set<Session>()
            .FirstOrDefaultAsync(session => session.UserId == userId);
    }
}