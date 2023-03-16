using BlazorShop.Client.Services.AuthService;
using Microsoft.AspNetCore.Components;

namespace BlazorShop.Client.Shared;

public partial class TopMenu
{
    [Inject] private IAuthService AuthService { get; set; } = null!;
}