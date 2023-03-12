using BlazorShop.Client.Auth.PermissionHandler;
using BlazorShop.Client.Services.CartService;
using BlazorShop.Client.Services.HttpInterceptorService;
using BlazorShop.Client.Services.PaymentService;
using BlazorShop.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorShop.Client.Pages.Order;

[HasPermission(Permissions.CustomerPermission)]
public sealed partial class Order : IDisposable
{
    [Inject] private ICartService CartService { get; set; } = null!;
    [Inject] private IPaymentService PaymentService { get; set; } = null!;
    [Inject] private NavigationManager Navigation { get; set; } = null!;
    [Inject] private HttpInterceptorService HttpInterceptorService { get; set; } = null!;

    private List<CartItem> Cart { get; set; } = new();

    public void Dispose()
    {
        HttpInterceptorService.DisposeEvent();
    }

    protected override async Task OnInitializedAsync()
    {
        HttpInterceptorService.RegisterEvent();
        Cart = await CartService.GetAllItems();
    }

    private async Task ConfirmAction()
    {
        var paymentUrl = await PaymentService.GeneratePaymentLink();

        Navigation.NavigateTo(paymentUrl);

        await CartService.ClearCart(Cart);
    }

    private void ViewAction(CartItem item)
    {
        Navigation.NavigateTo($"/product/{item.Product.Uri}");
    }
}