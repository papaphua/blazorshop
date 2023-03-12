using BlazorShop.Client.Services.AuthService;
using BlazorShop.Client.Services.ProfileService;
using Microsoft.AspNetCore.Components;

namespace BlazorShop.Client.Shared.SiderPanels;

public partial class ProfilePanel
{
    [Inject] private IAuthService AuthService { get; set; } = null!;
    [Inject] private IProfileService ProfileService { get; set; } = null!;

    private async Task LogoutAction()
    {
        await AuthService.Logout();
    }
    
    private async Task DeleteAction()
    {
        await ProfileService.CreateDeleteProfileLink();
    }
}
