namespace BlazorShop.Server.Options;

public sealed class MailingOptions
{
    public string SenderEmail { get; set; } = null!;
    
    public string SenderName { get; set; } = null!;
    
    public string Subject { get; set; } = null!;
}