using Blazored.LocalStorage;

namespace BlazorShop.Client.Services.NotificationService;

public sealed class NotificationService : INotificationService
{
    private const int MaxNotificationSize = 3;

    private readonly ILocalStorageService _localStorage;

    public NotificationService(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public event Action? NotificationAdded;

    public List<string> Notifications { get; set; } = new();

    public async Task GetAllNotifications()
    {
        Notifications = await _localStorage.ContainKeyAsync(nameof(Notifications))
            ? await _localStorage.GetItemAsync<List<string>>(nameof(Notifications))
            : new List<string>();
    }

    public async Task AddNotification(string message)
    {
        await GetAllNotifications();

        if (Notifications.Count >= MaxNotificationSize) Notifications.RemoveAt(MaxNotificationSize - 1);

        Notifications.Insert(0, message);

        await _localStorage.SetItemAsync(nameof(Notifications), Notifications);

        NotificationAdded?.Invoke();
    }
}