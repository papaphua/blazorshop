using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BlazorShop.Server.Common.Options;
using BlazorShop.Server.Data.Entities;
using BlazorShop.Server.Data.Repositories.PermissionRepository;
using BlazorShop.Server.Exceptions;
using BlazorShop.Shared.Auth;
using Microsoft.IdentityModel.Tokens;

namespace BlazorShop.Server.Common.Providers;

public sealed class TokenProvider
{
    private readonly JwtOptions _jwtOptions;
    private readonly IPermissionRepository _permissionRepository;

    public TokenProvider(JwtOptions jwtOptions, IPermissionRepository permissionRepository)
    {
        _jwtOptions = jwtOptions;
        _permissionRepository = permissionRepository;
    }

    public async Task<string> GenerateAccessTokenAsync(User user)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(CustomClaims.PaymentProfileId, user.PaymentProfileId),
            new(ClaimTypes.Name, user.Username),
            new(ClaimTypes.Email, user.Email)
        };

        var permissions = await _permissionRepository.GetUserPermissionsAsync(user.Id);

        claims.AddRange(
            permissions.Select(permission => new Claim(CustomClaims.Permissions, permission)));

        return CreateToken(claims);
    }

    public string GenerateRefreshToken(User user)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString())
        };
        
        return CreateToken(claims);
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
    
    private string CreateToken(IEnumerable<Claim> claims)
    {
        var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.JwtSecretKey));
        var credentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _jwtOptions.Issuer,
            audience: _jwtOptions.Audience,
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: DateTime.UtcNow.AddMinutes(_jwtOptions.AccessTokenExpiryInMinutes),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}