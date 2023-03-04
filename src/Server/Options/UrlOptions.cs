namespace BlazorShop.Server.Options;

public class UrlOptions
{
    public string EmailConfirmationUrl { get; set; } = null!;
    
    public string PasswordResetUrl { get; set; } = null!;
    
    public string DefaultLoginUrl { get; set; } = null!;
    
    public string TwoAuthLoginUrl { get; set; } = null!;
    
    public string DeleteProfileUrl { get; set; } = null!;

    public string OrderSuccessUrl { get; set; } = null!;
    
    public string OrderCancelUrl { get; set; } = null!;
}