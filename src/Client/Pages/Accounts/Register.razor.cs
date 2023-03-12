using BlazorShop.Client.Services.AuthService;
using BlazorShop.Client.Services.HttpInterceptorService;
using BlazorShop.Shared.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;

namespace BlazorShop.Client.Pages.Accounts;

[AllowAnonymous]
public sealed partial class Register : IDisposable
{
    [Inject] private IAuthService AuthService { get; set; } = null!;
    [Inject] private HttpInterceptorService HttpInterceptorService { get; set; } = null!;

    private RegisterDto RegisterDto { get; } = new();

    protected override void OnInitialized()
    {
        HttpInterceptorService.RegisterEvent();
    }
    public void Dispose()
    {
        HttpInterceptorService.DisposeEvent();
    }
    
    private async Task RegisterAction()
    {
        await AuthService.Register(RegisterDto);
    }
}