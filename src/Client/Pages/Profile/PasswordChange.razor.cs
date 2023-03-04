using BlazorShop.Client.Auth.PermissionHandler;
using BlazorShop.Client.Services.HttpInterceptorService;
using BlazorShop.Client.Services.ProfileService;
using BlazorShop.Shared.Dtos;
using Microsoft.AspNetCore.Components;

namespace BlazorShop.Client.Pages.Profile;

[HasPermission(Permissions.CustomerPermission)]
public sealed partial class PasswordChange : IDisposable
{
    [Inject] private IProfileService ProfileService { get; set; } = null!;
    [Inject] private HttpInterceptorService HttpInterceptorService { get; set; } = null!;
    
    private PasswordChangeDto PasswordChangeDto { get; } = new();

    protected override void OnInitialized()
    {
        HttpInterceptorService.RegisterEvent();
    }

    private async Task ChangePasswordAction()
    {
        await ProfileService.ChangePassword(PasswordChangeDto);
    }

    public void Dispose()
    {
        HttpInterceptorService.DisposeEvent();
    }
}