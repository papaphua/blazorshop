using BlazorShop.Client.Auth.PermissionHandler;
using BlazorShop.Client.Services.HttpInterceptorService;
using Microsoft.AspNetCore.Components;

namespace BlazorShop.Client.Pages.Management;

[HasPermission(Permissions.AdminPermission)]
public sealed partial class Management : IDisposable
{
    [Inject] private HttpInterceptorService HttpInterceptorService { get; set; } = null!;
    
    protected override void OnInitialized()
    {
        HttpInterceptorService.RegisterEvent();
    }

    public void Dispose()
    {
        HttpInterceptorService.RegisterEvent();
    }
}