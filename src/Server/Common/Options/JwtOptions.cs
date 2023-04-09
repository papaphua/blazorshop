namespace BlazorShop.Server.Common.Options;

public sealed class JwtOptions
{
    public string JwtSecretKey { get; set; } = null!;

    public string Issuer { get; set; } = null!;

    public string Audience { get; set; } = null!;

    public int AccessTokenExpiryInMinutes { get; set; }

    public int RefreshTokenExpiryInMinutes { get; set; }
}