using BlazorShop.Client.Services.CartService;
using BlazorShop.Client.Services.HttpInterceptorService;
using BlazorShop.Client.Services.PaymentService;
using BlazorShop.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;

namespace BlazorShop.Client.Pages;

[AllowAnonymous]
public sealed partial class Cart : IDisposable
{
    [Inject] private ICartService CartService { get; set; } = null!;
    [Inject] private NavigationManager Navigation { get; set; } = null!;
    [Inject] private HttpInterceptorService HttpInterceptorService { get; set; } = null!;
    [Inject] private IPaymentService PaymentService { get; set; } = null!;

    private List<CartItem> CartItems { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        CartItems = await CartService.GetAllItems();
    }

    private async Task ConfirmAction()
    {
        if (CartItems.Any())
        {
            var paymentUrl = await PaymentService.GeneratePaymentLink();

            Navigation.NavigateTo(paymentUrl);

            await CartService.ClearCart(CartItems);
        }
    }
    
    private async Task DeleteAction(CartItem item)
    {
        await CartService.RemoveFromCart(item, CartItems);
    }

    private async Task ClearAction()
    {
        await CartService.ClearCart(CartItems);
    }

    private void ViewAction(CartItem item)
    {
        Navigation.NavigateTo($"/products/{item.Product.Uri}");
    }

    public void Dispose()
    {
        HttpInterceptorService.DisposeEvent();
    }
}