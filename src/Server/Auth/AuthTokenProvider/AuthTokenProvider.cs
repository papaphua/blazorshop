using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using BlazorShop.Server.Common.Options;
using BlazorShop.Server.Data.Entities;
using BlazorShop.Server.Data.Repositories.PermissionRepository;
using BlazorShop.Server.Data.Repositories.UserRepository;
using BlazorShop.Server.Exceptions;
using BlazorShop.Shared.Auth;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BlazorShop.Server.Auth.AuthTokenProvider;

public class AuthTokenProvider : IAuthTokenProvider
{
        private readonly JwtOptions _options;
    private readonly IPermissionRepository _permissionRepository;
    private readonly IUserRepository _userRepository;

    public AuthTokenProvider(IOptions<JwtOptions> options, IUserRepository userRepository,
        IPermissionRepository permissionRepository)
    {
        _options = options.Value;
        _userRepository = userRepository;
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

    public string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }

    public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_options.JwtSecretKey)),
            ValidateLifetime = false,
            ValidIssuer = _options.Issuer,
            ValidAudience = _options.Audience
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);

        if (securityToken is not JwtSecurityToken jwtSecurityToken
            || !jwtSecurityToken.Header.Alg.Equals(
                SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            throw new SecurityTokenException("Invalid token");

        return principal;
    }

    public Guid GetUserIdFromContext(HttpContext context)
    {
        var id = context.User.FindFirst(ClaimTypes.NameIdentifier).Value;

        Console.Write(id);
        
        if (id is null) throw new NotFoundException(ExceptionMessages.Unauthorized);

        return Guid.Parse(id);
    }

    public async Task<User> GetUserFromContextAsync(HttpContext context)
    {
        var id = GetUserIdFromContext(context);

        var user = await _userRepository.GetByIdAsync(id);

        if (user is null) throw new NotFoundException(ExceptionMessages.NotRegistered);

        return user;
    }

    public string CreateToken(IEnumerable<Claim> claims)
    {
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.JwtSecretKey));

        var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _options.Issuer,
            audience: _options.Audience,
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: DateTime.UtcNow.AddMinutes(_options.AccessTokenExpiryInMinutes),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}