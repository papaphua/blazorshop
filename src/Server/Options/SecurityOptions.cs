namespace BlazorShop.Server.Options;

public class SecurityOptions
{
    public int ConfirmationCodeExpiryInMinutes { get; set; }
    public int ConfirmationTokenExpiryInMinutes { get; set; }
}