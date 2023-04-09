using System.Net;
using BlazorShop.Server.Data.Entities;
using BlazorShop.Shared.Models;
using Session = Stripe.Checkout.Session;

namespace BlazorShop.Server.Services.PaymentService;

public interface IPaymentService
{
    Session CreateCheckoutSession(HttpContext context, List<CartItem> cart);
    Task<HttpStatusCode> CreateWebHookAsync(HttpContext context);
    Task<string> AddPaymentProfileAsync(User user);
    Task UpdatePaymentProfileAsync(Guid userId);
    Task DeletePaymentProfileAsync(Guid userId);
}