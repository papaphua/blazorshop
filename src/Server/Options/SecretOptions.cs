namespace BlazorShop.Server.Options;

public sealed class SecretOptions
{
    public string JwtSecretKey { get; set; } = null!;
    
    public string StripePrivateKey { get; set; } = null!;
    
    public string StripeWebHookSecret { get; set; } = null!;

    public string SendGridApiKey { get; set; } = null!;
}