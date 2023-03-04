namespace BlazorShop.Client.Services.NotificationService;

public interface INotificationService
{
    List<string> Notifications { get; set; }
    event Action? NotificationAdded;
    Task GetAllNotifications();
    Task AddNotification(string message);
}