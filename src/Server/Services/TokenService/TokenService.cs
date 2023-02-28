using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BlazorShop.Server.Data.Entities;
using BlazorShop.Server.Options;
using BlazorShop.Server.Services.PermissionService;
using BlazorShop.Shared.Auth;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BlazorShop.Server.Services.TokenService;

public sealed class TokenService : ITokenService
{
    private readonly JwtOptions _options;
    private readonly SecretOptions _secrets;
    private readonly IPermissionService _permissionService;

    public TokenService(IOptions<JwtOptions> options, IOptions<SecretOptions> secrets,
        IPermissionService permissionService)
    {
        _options = options.Value;
        _secrets = secrets.Value;
        _permissionService = permissionService;
    }

    public async Task<string> GenerateAuthTokenAsync(User user)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.Username),
            new(ClaimTypes.Email, user.Email)
        };

        var permissions = await _permissionService.GetUserPermissionsAsync(user.Id);

        claims.AddRange(
            permissions.Select(permission => new Claim(CustomClaims.Permissions, permission)));

        return CreateToken(claims);
    }

    private string CreateToken(IEnumerable<Claim> claims)
    {
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secrets.JwtSecretKey));

        var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _options.Issuer,
            audience: _options.Audience,
            claims: claims,
            notBefore: DateTime.Now,
            expires: DateTime.Now.AddMinutes(_options.AccessTokenExpiryInMinutes),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}