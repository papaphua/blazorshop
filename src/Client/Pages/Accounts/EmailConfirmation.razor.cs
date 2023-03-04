using System.Net.Http.Headers;
using BlazorShop.Client.Auth;
using BlazorShop.Client.Services.AuthService;
using BlazorShop.Client.Services.HttpInterceptorService;
using BlazorShop.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;

namespace BlazorShop.Client.Pages.Accounts;

[AllowAnonymous]
public sealed partial class EmailConfirmation : IDisposable
{
    [Inject] private IAuthService AuthService { get; set; } = null!;
    [Inject] private HttpInterceptorService HttpInterceptorService { get; set; } = null!;
    [Inject] private NavigationManager NavigationManager { get; set; } = null!;
    [Inject] private HttpClient HttpClient { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        var query = NavigationManager.ToAbsoluteUri(NavigationManager.Uri).Query;

        StringValues token;
        StringValues email;

        QueryHelpers.ParseQuery(query).TryGetValue(nameof(token), out token);
        QueryHelpers.ParseQuery(query).TryGetValue(nameof(email), out email);

        HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(AuthNamings.Bearer, token);

        var accessParameters = new ConfirmationParameters(token!, email!);

        await AuthService.ConfirmEmail(accessParameters);
    }

    public void Dispose()
    {
        HttpInterceptorService.DisposeEvent();
    }
}