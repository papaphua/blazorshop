using System.Net;
using BlazorShop.Server.Data.Entities;
using BlazorShop.Shared.Models;

namespace BlazorShop.Server.Services.PaymentService;

public interface IPaymentService
{
    Stripe.Checkout.Session CreateCheckoutSession(HttpContext context, List<CartItem> cart);
    Task<HttpStatusCode> CreateWebHookAsync(HttpContext context);
    Task AddPaymentProfileAsync(User user);
    Task UpdatePaymentProfileAsync(Guid userId);
    Task DeletePaymentProfileAsync(Guid userId);
}