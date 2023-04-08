namespace BlazorShop.Server.Common.Options;

public sealed class MailOptions
{
    public string SendGridApiKey { get; set; } = null!;
    
    public string SenderEmail { get; set; } = null!;
    
    public string SenderName { get; set; } = null!;
    
    public string Subject { get; set; } = null!;
}