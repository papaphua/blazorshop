using Blazorise;
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
    private Validations _validations = new();
    [Inject] private IProfileService ProfileService { get; set; } = null!;
    [Inject] private HttpInterceptorService HttpInterceptorService { get; set; } = null!;
    [Inject] private IAuthService AuthService { get; set; } = null!;

    private PasswordChangeDto PasswordChangeDto { get; } = new();

    public void Dispose()
    {
        HttpInterceptorService.DisposeEvent();
    }

    protected override async Task OnInitializedAsync()
    {
        HttpInterceptorService.RegisterEvent();
        await AuthService.GetConfirmationCode();
    }

    private async Task ChangePasswordAction()
    {
        if (await _validations.ValidateAll()) await ProfileService.ChangePassword(PasswordChangeDto);
    }
}