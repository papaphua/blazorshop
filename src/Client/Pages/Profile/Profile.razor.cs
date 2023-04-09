using Blazorise;
using BlazorShop.Client.Auth.PermissionHandler;
using BlazorShop.Client.Services.HttpInterceptorService;
using BlazorShop.Client.Services.ProfileService;
using BlazorShop.Shared.Dtos;
using Microsoft.AspNetCore.Components;

namespace BlazorShop.Client.Pages.Profile;

[HasPermission(Permissions.CustomerPermission)]
public sealed partial class Profile : IDisposable
{
    private Validations _validations = new();
    [Inject] private IProfileService ProfileService { get; set; } = null!;
    [Inject] private HttpInterceptorService HttpInterceptorService { get; set; } = null!;

    private ProfileDto UserProfile { get; set; } = new();

    public void Dispose()
    {
        HttpInterceptorService.RegisterEvent();
    }

    protected override async Task OnInitializedAsync()
    {
        HttpInterceptorService.RegisterEvent();
        UserProfile = await ProfileService.GetUserProfile();
    }

    private async Task SaveAction()
    {
        if (await _validations.ValidateAll()) await ProfileService.UpdateUserProfile(UserProfile);
    }
}