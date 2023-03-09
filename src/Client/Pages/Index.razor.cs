using BlazorShop.Client.Services.HttpInterceptorService;
using Microsoft.AspNetCore.Components;

namespace BlazorShop.Client.Pages;

public sealed partial class Index : IDisposable
{
    [Inject] private HttpInterceptorService HttpInterceptorService { get; set; } = null!;
    
    protected override void OnInitialized()
    {
        HttpInterceptorService.RegisterEvent();
    }

    public void Dispose()
    {
        HttpInterceptorService.DisposeEvent();
    }
}