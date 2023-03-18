using System.Net.Http.Json;
using Blazorise;
using BlazorShop.Client.Services.AuthService;
using BlazorShop.Shared.Dtos;
using Toolbelt.Blazor;

namespace BlazorShop.Client.Services.HttpInterceptorService;

public sealed class HttpInterceptorService
{
    private readonly HttpClientInterceptor _interceptor;
    private readonly IAuthService _authService;
    private readonly INotificationService _notification;

    public HttpInterceptorService(HttpClientInterceptor interceptor,
        IAuthService authService, INotificationService notification)
    {
        _interceptor = interceptor;
        _authService = authService;
        _notification = notification;
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

            await _notification.Error(exceptionMessage.Message);
        }
    }

    public void DisposeEvent() => _interceptor.AfterSendAsync -= InterceptAfterHttpAsync;
}