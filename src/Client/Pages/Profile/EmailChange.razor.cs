using BlazorShop.Client.Auth.PermissionHandler;
using BlazorShop.Client.Services.HttpInterceptorService;
using BlazorShop.Client.Services.ProfileService;
using BlazorShop.Shared.Dtos;
using Microsoft.AspNetCore.Components;

namespace BlazorShop.Client.Pages.Profile;

[HasPermission(Permissions.CustomerPermission)]
public sealed partial class EmailChange : IDisposable
{
    [Inject] private IProfileService ProfileService { get; set; } = null!;
    [Inject] private HttpInterceptorService HttpInterceptorService { get; set; } = null!;

    private EmailChangeDto EmailChangeDto { get; } = new();
    
    protected override void OnInitialized()
    {
        HttpInterceptorService.RegisterEvent();
    }

    private async Task ChangeEmailAction()
    {
        await ProfileService.ChangeEmail(EmailChangeDto);
    }

    public void Dispose()
    {
        HttpInterceptorService.DisposeEvent();
    }
}