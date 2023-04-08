using BlazorShop.Server.Common.Options;
using BlazorShop.Server.Data;
using BlazorShop.Server.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BlazorShop.Server.Services.SessionService;

public sealed class SessionService : ISessionService
{
    private readonly JwtOptions _jwtOptions;
    private readonly AppDbContext _db;

    public SessionService(IOptions<JwtOptions> jwtOptions, AppDbContext db)
    {
        _db = db;
        _jwtOptions = jwtOptions.Value;
    }

    public async Task<Session?> GetUserSessionAsync(Guid userId)
    {
        return await _db.Sessions
            .FirstOrDefaultAsync(session => session.UserId == userId);
    }

    public async Task CreateSessionAsync(Guid userId, string accessToken, string refreshToken)
    {
        if (await GetUserSessionAsync(userId) is not null)
        {
            await UpdateSessionAsync(userId, accessToken, refreshToken);
            return;
        }

        var session = new Session
        {
            UserId = userId, AccessToken = accessToken, RefreshToken = refreshToken,
            RefreshTokenExpiryTime = DateTime.UtcNow.AddMinutes(_jwtOptions.RefreshTokenExpiryInMinutes)
        };

        await _db.Sessions.AddAsync(session);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateSessionAsync(Guid userId, string accessToken, string refreshToken)
    {
        var session = await GetUserSessionAsync(userId);

        if (session is null) return; //Logout

        session.AccessToken = accessToken;
        session.RefreshToken = refreshToken;
        session.RefreshTokenExpiryTime = DateTime.UtcNow.AddMinutes(_jwtOptions.RefreshTokenExpiryInMinutes);

        _db.Sessions.Update(session);
        
        await _db.SaveChangesAsync();
    }
}