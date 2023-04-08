using BlazorShop.Shared.Models;

namespace BlazorShop.Server.Common.Providers.LinkProvider;

public sealed class LinkProvider : ILinkProvider
{
    public string GenerateConfirmationLink(string url, ConfirmationParameters parameters)
    {
        return $"https://{url}?token={parameters.Token}&email={parameters.Email}";
    }
    
    public string GenerateLoginLink(string url, string login)
    {
        return $"https://{url}?login={login}";
    }
}