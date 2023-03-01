using System.Net;
using BlazorShop.Server.Data.Entities;
using BlazorShop.Shared.Models;
using Stripe.Checkout;
using Session = Stripe.Checkout.Session;

namespace BlazorShop.Server.Services.PaymentService;

public interface IPaymentService
{
    Session CreateCheckoutSessionAsync(string customerId, List<CartItem> cart);
    Task<HttpStatusCode> CreateWebHookAsync(HttpContext context);
    Task AddPaymentProfileAsync(User user);
    Task UpdatePaymentProfileAsync(Guid userId);
    Task DeletePaymentProfileAsync(Guid userId);
}