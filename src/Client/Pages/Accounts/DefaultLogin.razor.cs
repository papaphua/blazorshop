using Blazorise;
using BlazorShop.Client.Services.AuthService;
using BlazorShop.Client.Services.HttpInterceptorService;
using BlazorShop.Shared.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;

namespace BlazorShop.Client.Pages.Accounts;

[AllowAnonymous]
public partial class DefaultLogin : IDisposable
{
    [Inject] private IAuthService AuthService { get; set; } = null!;
    [Inject] private HttpInterceptorService HttpInterceptorService { get; set; } = null!;
    [Inject] private NavigationManager NavigationManager { get; set; } = null!;

    private DefaultLoginDto DefaultLoginDto { get; } = new();
    private Validations _validations = new();

    protected override void OnInitialized()
    {
        HttpInterceptorService.RegisterEvent();
        
        var query = NavigationManager.ToAbsoluteUri(NavigationManager.Uri).Query;

        QueryHelpers.ParseQuery(query).TryGetValue("login", out var login);

        DefaultLoginDto.Login = login;
    }

    public void Dispose()
    {
        HttpInterceptorService.DisposeEvent();
    }

    private async Task LoginAction()
    {
        if (await _validations.ValidateAll())
        {
            await AuthService.DefaultLogin(DefaultLoginDto);
        }
    }
}