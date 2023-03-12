using BlazorShop.Client.Auth.PermissionHandler;
using BlazorShop.Client.Services.AuthService;
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
    [Inject] private IAuthService AuthService { get; set; } = null!;
    
    private PasswordChangeDto PasswordChangeDto { get; } = new();

    protected override async Task OnInitializedAsync()
    {
        HttpInterceptorService.RegisterEvent();
        await AuthService.GetConfirmationCode();
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