namespace BlazorShop.Server.Common.Options;

public sealed class SecurityOptions
{
    public int ConfirmationCodeExpiryInMinutes { get; set; }
    public int ConfirmationTokenExpiryInMinutes { get; set; }
}