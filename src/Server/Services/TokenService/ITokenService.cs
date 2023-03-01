using System.Security.Claims;
using BlazorShop.Server.Data.Entities;

namespace BlazorShop.Server.Services.TokenService;

public interface ITokenService
{
    Task<string> GenerateAccessTokenAsync(User user);
    string GenerateRefreshToken();
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    Guid GetUserIdFromContext(HttpContext context);
    Task<User> GetUserFromContextAsync(HttpContext context);
}