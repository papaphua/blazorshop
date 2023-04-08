using BlazorShop.Shared.Models;

namespace BlazorShop.Server.Common.Providers.LinkProvider;

public interface ILinkProvider
{
    string GenerateConfirmationLink(string url, ConfirmationParameters parameters);
    string GenerateLoginLink(string url, string login);
}