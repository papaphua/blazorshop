using System.Security.Claims;
using BlazorShop.Server.Data.Entities;

namespace BlazorShop.Server.Auth.AuthTokenProvider;

public interface IAuthTokenProvider
{
    Task<string> GenerateAccessTokenAsync(User user);
    string GenerateRefreshToken();
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    Guid GetUserIdFromContext(HttpContext context);
    Task<User> GetUserFromContextAsync(HttpContext context);
}