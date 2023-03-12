using System.Security.Claims;

namespace BlazorShop.Client.Auth.JwtProvider;

public interface IJwtProvider
{
    IEnumerable<Claim> Parse(string jwt);
}