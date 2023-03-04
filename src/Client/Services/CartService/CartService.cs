using Blazored.LocalStorage;
using BlazorShop.Client.Pages;
using BlazorShop.Shared.Dtos;
using BlazorShop.Shared.Models;

namespace BlazorShop.Client.Services.CartService;

public sealed class CartService : ICartService
{
    private readonly HttpClient _http;
    private readonly ILocalStorageService _localStorage;

    public CartService(ILocalStorageService localStorage, HttpClient http)
    {
        _localStorage = localStorage;
        _http = http;
    }

    public async Task<List<CartItem>> GetAllItems()
    {
        return await _localStorage.ContainKeyAsync(nameof(Cart))
            ? await _localStorage.GetItemAsync<List<CartItem>>(nameof(Cart))
            : new List<CartItem>();
    }

    public decimal GetCartPrice(List<CartItem> cart)
    {
        return cart.Sum(item => item.TotalPrice);
    }

    public async Task AddToCart(ProductDto product)
    {
        var cart = await GetAllItems();

        var productUris = cart.Select(item => item.Product.Uri);

        if (productUris.Contains(product.Uri))
        {
            var itemToUpdate = cart.Single(item => item.Product.Uri == product.Uri);

            itemToUpdate.Quantity++;
            itemToUpdate.TotalPrice = itemToUpdate.Quantity * itemToUpdate.Product.Price;
        }
        else
        {
            cart.Add(new CartItem(product));
        }

        await SaveCart(cart);
    }

    public async Task RemoveFromCart(CartItem item, List<CartItem> cart)
    {
        cart.Remove(item);

        await SaveCart(cart);
    }

    public async Task SaveCart(List<CartItem> cart)
    {
        await _localStorage.SetItemAsync(nameof(Cart), cart);
    }

    public async Task ClearCart(List<CartItem> cart)
    {
        cart.Clear();
        await SaveCart(new List<CartItem>());
    }
}