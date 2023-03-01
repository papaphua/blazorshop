namespace BlazorShop.Server.Options;

public class UrlOptions
{
    public string EmailConfirmationUrl { get; set; } = null!;
    
    public string PasswordResetUrl { get; set; } = null!;
}