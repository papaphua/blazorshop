using System.Net.Http.Headers;
using Blazorise;
using BlazorShop.Client.Auth;
using BlazorShop.Client.Services.AuthService;
using BlazorShop.Client.Services.HttpInterceptorService;
using BlazorShop.Shared.Dtos;
using BlazorShop.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;

namespace BlazorShop.Client.Pages.Accounts;

[AllowAnonymous]
public sealed partial class PasswordResetConfirmation : IDisposable
{
    private Validations _validations = new();
    [Inject] private IAuthService AuthService { get; set; } = null!;
    [Inject] private HttpInterceptorService HttpInterceptorService { get; set; } = null!;
    [Inject] private HttpClient HttpClient { get; set; } = null!;
    [Inject] private NavigationManager NavigationManager { get; set; } = null!;

    private PasswordResetDto PasswordResetDto { get; } = new();

    public void Dispose()
    {
        HttpInterceptorService.DisposeEvent();
    }

    protected override void OnInitialized()
    {
        HttpInterceptorService.RegisterEvent();

        var query = NavigationManager.ToAbsoluteUri(NavigationManager.Uri).Query;

        StringValues token;
        StringValues email;

        QueryHelpers.ParseQuery(query).TryGetValue(nameof(token), out token);
        QueryHelpers.ParseQuery(query).TryGetValue(nameof(email), out email);

        HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(AuthNamings.Bearer, token);

        PasswordResetDto.ConfirmationParameters = new ConfirmationParameters(token!, email!);
    }

    private async Task ResetAction()
    {
        if (await _validations.ValidateAll()) await AuthService.ResetPassword(PasswordResetDto);
    }
}