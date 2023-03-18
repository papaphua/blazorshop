using System.ComponentModel.DataAnnotations;
using Blazorise;
using BlazorShop.Client.Services.AuthService;
using BlazorShop.Client.Services.HttpInterceptorService;
using BlazorShop.Shared.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;

namespace BlazorShop.Client.Pages.Accounts;

[AllowAnonymous]
public sealed partial class PasswordReset : IDisposable
{
    [Inject] private IAuthService AuthService { get; set; } = null!;
    [Inject] private HttpInterceptorService HttpInterceptorService { get; set; } = null!;
    
    private EmailDto EmailDto { get; set; } = new();
    private Validations _validations = new();

    protected override void OnInitialized()
    {
        HttpInterceptorService.RegisterEvent();
    }

    public void Dispose()
    {
        HttpInterceptorService.DisposeEvent();
    }

    private async Task SendLinkAction()
    {
        if (await _validations.ValidateAll())
        {
            await AuthService.GetPasswordResetLink(EmailDto);
        }
    }
}