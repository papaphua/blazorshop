using System.Net.Http.Json;
using BlazorShop.Client.Services.AuthService;
using BlazorShop.Client.Services.NotificationService;
using BlazorShop.Shared.Dtos;
using Toolbelt.Blazor;

namespace BlazorShop.Client.Services.HttpInterceptorService;

public sealed class HttpInterceptorService
{
    private readonly HttpClientInterceptor _interceptor;
    private readonly INotificationService _notificationService;
    private readonly IAuthService _authService;

    public HttpInterceptorService(HttpClientInterceptor interceptor, INotificationService notificationService,
        IAuthService authService)
    {
        _interceptor = interceptor;
        _notificationService = notificationService;
        _authService = authService;
    }

    public void RegisterEvent() => _interceptor.AfterSendAsync += InterceptAfterHttpAsync;

    private async Task InterceptAfterHttpAsync(object sender, HttpClientInterceptorEventArgs args)
    {
        if (!args.Request.RequestUri.AbsolutePath.Contains("refresh"))
        {
            await _authService.TryRefreshToken();
        }
        
        if (!args.Response.IsSuccessStatusCode)
        {
            var content = args.Response.Content;
            
            var exceptionMessage = await content.ReadFromJsonAsync<ExceptionDto>();

            await _notificationService.AddNotification(exceptionMessage.Message);
        }
    }

    public void DisposeEvent() => _interceptor.AfterSendAsync -= InterceptAfterHttpAsync;
}