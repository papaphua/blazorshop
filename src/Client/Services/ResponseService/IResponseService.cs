namespace BlazorShop.Client.Services.ResponseService;

public interface IResponseService
{
    List<string> Notifications { get; set; }
    event Action? NotificationAdded;
    Task GetAllNotifications();
    Task AddNotification(string message);
}