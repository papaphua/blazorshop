using Blazorise;
using BlazorShop.Client.Auth.PermissionHandler;
using BlazorShop.Client.Services.AuthService;
using BlazorShop.Client.Services.HttpInterceptorService;
using BlazorShop.Shared.Dtos;
using Microsoft.AspNetCore.Components;

namespace BlazorShop.Client.Pages.Profile;

[HasPermission(Permissions.CustomerPermission)]
public sealed partial class EmailChange : IDisposable
{
    [Inject] private HttpInterceptorService HttpInterceptorService { get; set; } = null!;
    [Inject] private NavigationManager NavigationManager { get; set; } = null!;
    [Inject] private IAuthService AuthService { get; set; } = null!;

    private const string ConfirmationUrl = "/profile/email/change/confirmation";
    
    private EmailDto EmailDto { get; } = new();
    private Validations _validations = new();
    
    protected override void OnInitialized()
    {
        HttpInterceptorService.RegisterEvent();
    }

    private async Task SendCodesAction()
    {
        if (await _validations.ValidateAll())
        {
            await AuthService.GetConfirmationCode();
            await AuthService.GetNewEmailConfirmationCode(EmailDto);
        
            var url = ConfirmationUrl + $"?email={EmailDto.Email}";
            NavigationManager.NavigateTo(url);
        }
    }

    public void Dispose()
    {
        HttpInterceptorService.DisposeEvent();
    }
}