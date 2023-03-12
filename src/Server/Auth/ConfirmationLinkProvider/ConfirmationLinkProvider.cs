using BlazorShop.Shared.Models;

namespace BlazorShop.Server.Auth.ConfirmationLinkProvider;

public sealed class ConfirmationLinkProvider : IConfirmationLinkProvider
{
    public string GenerateConfirmationLink(string url, ConfirmationParameters parameters)
    {
        return $"https://{url}?token={parameters.Token}&email={parameters.Email}";
    }
}