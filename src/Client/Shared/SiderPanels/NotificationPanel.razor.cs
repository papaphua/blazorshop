using BlazorShop.Client.Services.ResponseService;
using Microsoft.AspNetCore.Components;

namespace BlazorShop.Client.Shared.SiderPanels;

public partial class NotificationPanel
{
    [Inject] private IResponseService ResponseService { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        await ResponseService.GetAllNotifications();
        
        ResponseService.NotificationAdded += StateHasChanged;
    }
}