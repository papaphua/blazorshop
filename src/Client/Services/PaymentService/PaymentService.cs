using System.Net.Http.Json;
using BlazorShop.Client.Services.CartService;

namespace BlazorShop.Client.Services.PaymentService;

public sealed class PaymentService : IPaymentService
{
    private readonly HttpClient _http;
    private readonly ICartService _cartService;

    public PaymentService(HttpClient http, ICartService cartService)
    {
        _http = http;
        _cartService = cartService;
    }

    public async Task<string> GeneratePaymentLink()
    {
        var cart = await _cartService.GetAllItems();

        var response = await _http.PostAsJsonAsync("api/payments/checkout", cart);

        var url = await response.Content.ReadAsStringAsync();

        return url;
    }
}