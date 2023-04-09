using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BlazorShop.Server.Common.Exceptions;
using BlazorShop.Server.Common.Options;
using BlazorShop.Server.Data.Entities;
using BlazorShop.Server.Services.PermissionService;
using BlazorShop.Shared.Auth;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BlazorShop.Server.Common.Providers.TokenProvider;

public sealed class TokenProvider : ITokenProvider
{
    private readonly JwtOptions _jwtOptions;
    private readonly IPermissionService _permissionService;
    private readonly SecurityOptions _securityOptions;

    public TokenProvider(IOptions<JwtOptions> jwtOptions, IPermissionService permissionService,
        IOptions<SecurityOptions> securityOptions)
    {
        _jwtOptions = jwtOptions.Value;
        _permissionService = permissionService;
        _securityOptions = securityOptions.Value;
    }

    public async Task<string> GenerateAccessTokenAsync(User user)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(CustomClaims.PaymentProfileId, user.CustomerId),
            new(ClaimTypes.Name, user.Username),
            new(ClaimTypes.Email, user.Email)
        };

        var permissions = await _permissionService.GetUserPermissionsAsync(user.Id);

        claims.AddRange(
            permissions.Select(permission => new Claim(CustomClaims.Permissions, permission)));

        return CreateToken(claims, _jwtOptions.AccessTokenExpiryInMinutes);
    }

    public string GenerateRefreshToken(User user)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString())
        };

        return CreateToken(claims, _jwtOptions.RefreshTokenExpiryInMinutes);
    }

    public string GenerateConfirmationToken(User user)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.Email, user.Id.ToString())
        };

        return CreateToken(claims, _securityOptions.ConfirmationTokenExpiryInMinutes);
    }

    public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
    {
        var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.JwtSecretKey));

        var validationParameters = new TokenValidationParameters
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = signingKey,
            ValidateLifetime = false,
            ValidIssuer = _jwtOptions.Issuer,
            ValidAudience = _jwtOptions.Audience
        };

        var principals = new JwtSecurityTokenHandler()
            .ValidateToken(token, validationParameters, out var securityToken);

        if (securityToken is not JwtSecurityToken jwtSecurityToken ||
            !jwtSecurityToken.Header.Alg.Equals(
                SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            throw new SecurityTokenException("Invalid token");

        return principals;
    }

    public Guid GetUserIdFromContext(HttpContext context)
    {
        var id = context.User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (id is null) throw new BusinessException(ExceptionMessages.Unauthorized);

        return Guid.Parse(id);
    }

    private string CreateToken(IEnumerable<Claim> claims, int expiryInMin)
    {
        var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.JwtSecretKey));
        var credentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            _jwtOptions.Issuer,
            _jwtOptions.Audience,
            claims,
            DateTime.UtcNow,
            DateTime.UtcNow.AddMinutes(expiryInMin),
            credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}