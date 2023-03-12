using BlazorShop.Client.Services.NotificationService;
using Microsoft.AspNetCore.Components;

namespace BlazorShop.Client.Shared.SiderPanels;

public partial class NotificationPanel
{
    [Inject] private INotificationService NotificationService { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        await NotificationService.GetAllNotifications();
        
        NotificationService.NotificationAdded += StateHasChanged;
    }
}