using BlazorShop.Server.Data.Entities;

namespace BlazorShop.Server.Services.TokenService;

public interface ITokenService
{
    Task<string> GenerateAuthTokenAsync(User user);
}