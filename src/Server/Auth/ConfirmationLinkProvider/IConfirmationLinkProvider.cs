using BlazorShop.Shared.Models;

namespace BlazorShop.Server.Auth.ConfirmationLinkProvider;

public interface IConfirmationLinkProvider
{
    string GenerateConfirmationLink(string url, ConfirmationParameters parameters);
}