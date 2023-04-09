using Blazorise;
using BlazorShop.Client.Services.HttpInterceptorService;
using BlazorShop.Client.Services.ProfileService;
using BlazorShop.Shared.Dtos;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;

namespace BlazorShop.Client.Pages.Profile;

public sealed partial class EmailChangeConfirmation : IDisposable
{
    private const string Email = "email";
    private Validations _validations = new();
    [Inject] private IProfileService ProfileService { get; set; } = null!;
    [Inject] private HttpInterceptorService HttpInterceptorService { get; set; } = null!;
    [Inject] private NavigationManager NavigationManager { get; set; } = null!;

    private EmailChangeDto EmailChangeDto { get; } = new();

    public void Dispose()
    {
        HttpInterceptorService.DisposeEvent();
    }

    protected override void OnInitialized()
    {
        HttpInterceptorService.RegisterEvent();

        var query = NavigationManager.ToAbsoluteUri(NavigationManager.Uri).Query;

        QueryHelpers.ParseQuery(query).TryGetValue(Email, out var email);

        EmailChangeDto.NewEmail = email;
    }

    private async Task ChangeEmailAction()
    {
        if (await _validations.ValidateAll()) await ProfileService.ChangeEmail(EmailChangeDto);
    }
}