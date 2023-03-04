using BlazorShop.Client.Auth.StateProvider;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorShop.Client;

public partial class App
{
    [Inject] private AuthenticationStateProvider AuthStateProvider { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        await (AuthStateProvider as CustomAuthStateProvider).RefreshAuthHeader();
    }
}