using System.Net.Http.Json;
using BlazorShop.Client.Services.NotificationService;
using BlazorShop.Shared.Dtos;
using Toolbelt.Blazor;

namespace BlazorShop.Client.Services.HttpInterceptorService;

public sealed class HttpInterceptorService
{
    private readonly HttpClientInterceptor _interceptor;
    private readonly INotificationService _notificationService;

    public HttpInterceptorService(HttpClientInterceptor interceptor, INotificationService notificationService)
    {
        _interceptor = interceptor;
        _notificationService = notificationService;
    }

    public void RegisterEvent() => _interceptor.AfterSendAsync += InterceptBeforeHttpAsync;

    private async Task InterceptBeforeHttpAsync(object sender, HttpClientInterceptorEventArgs e)
    {
        if (!e.Response.IsSuccessStatusCode)
        {
            var content = await e.GetCapturedContentAsync();

            if (content is null) return;

            var exceptionMessage = await content.ReadFromJsonAsync<ExceptionDto>();

            if (exceptionMessage is null ) return;
            
            await _notificationService.AddNotification(exceptionMessage.Message);
        }
    }

    public void DisposeEvent() => _interceptor.BeforeSendAsync -= InterceptBeforeHttpAsync;
    }