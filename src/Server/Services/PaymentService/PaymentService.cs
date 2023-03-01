using System.Net;
using BlazorShop.Server.Data.Entities;
using BlazorShop.Server.Data.Repositories.UserRepository;
using BlazorShop.Server.Exceptions;
using BlazorShop.Server.Options;
using BlazorShop.Shared.Models;
using Microsoft.Extensions.Options;
using Stripe;
using Stripe.Checkout;
using Session = Stripe.Checkout.Session;

namespace BlazorShop.Server.Services.PaymentService;

public sealed class PaymentService : IPaymentService
{
    private const string Usd = "usd";
    private const string Card = "card";
    private const string Payment = "payment";
    private const string StripeSignature = "stripe-signature";
    private const string OrderSuccessUrl = "localhost:7017/order/success";
    private const string OrderCancelUrl = "localhost:7017/order/cancel";

    private readonly SecretOptions _secrets;
    private readonly IUserRepository _userRepository;

    public PaymentService(IOptions<SecretOptions> secrets, IUserRepository userRepository)
    {
        _userRepository = userRepository;
        _secrets = secrets.Value;
        StripeConfiguration.ApiKey = _secrets.StripePrivateKey;
    }

    public Session CreateCheckoutSessionAsync(string customerId, List<CartItem> cart)
    {
        var lineItems = new List<SessionLineItemOptions>();

        cart.ForEach(cartItem => lineItems.Add(new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    UnitAmountDecimal = cartItem.Product.Price * 100,
                    Currency = Usd,
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = cartItem.Product.Name,
                        Images = new List<string> { cartItem.Product.ImageUrl }
                    }
                },
                Quantity = cartItem.Quantity
            }
        ));

        if (string.IsNullOrEmpty(customerId)) throw new BusinessException(ExceptionMessages.Unauthorized);

        var options = new SessionCreateOptions
        {
            Customer = customerId,
            PaymentMethodTypes = new List<string>
            {
                Card
            },
            LineItems = lineItems,
            Mode = Payment,
            SuccessUrl = OrderSuccessUrl,
            CancelUrl = OrderCancelUrl
        };

        var service = new SessionService();
        var session = service.Create(options);

        return session;
    }

    public async Task<HttpStatusCode> CreateWebHookAsync(HttpContext context)
    {
        var json = await new StreamReader(context.Request.Body).ReadToEndAsync();

        var stripeEvent = EventUtility.ConstructEvent(
            json,
            context.Request.Headers[StripeSignature],
            _secrets.StripeWebHookSecret);

        try
        {
            switch (stripeEvent.Type)
            {
                case Events.CustomerCreated:
                {
                    var customer = stripeEvent.Data.Object as Customer;

                    if (customer is null) throw new BusinessException(ExceptionMessages.InternalError);
                    
                    await SaveCustomerIdAsUserPaymentProfileId(customer);

                    return HttpStatusCode.OK;
                }
            }
        }
        catch (StripeException)
        {
            return HttpStatusCode.BadRequest;
        }
        
        return HttpStatusCode.OK;
    }

    public async Task AddPaymentProfileAsync(User user)
    {
        var options = new CustomerCreateOptions
        {
            Email = user.Email,
            Description = user.Username
        };

        var service = new CustomerService();
        await service.CreateAsync(options);
    }

    public async Task UpdatePaymentProfileAsync(Guid userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);

        if (user is null) throw new NotFoundException(ExceptionMessages.NotRegistered);

        var options = new CustomerUpdateOptions
        {
            Email = user.Email,
            Description = user.Username
        };

        var service = new CustomerService();
        await service.UpdateAsync(user.PaymentProfileId, options);
    }

    public async Task DeletePaymentProfileAsync(Guid userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);

        if (user is null) throw new NotFoundException(ExceptionMessages.NotRegistered);

        var service = new CustomerService();

        await service.DeleteAsync(user.PaymentProfileId);
    }

    private async Task SaveCustomerIdAsUserPaymentProfileId(Customer customer)
    {
        var user = await _userRepository.GetByEmailAsync(customer.Email);

        if (user is null) throw new NotFoundException(ExceptionMessages.NotRegistered);

        if (user.PaymentProfileId is not null) return;
        
        user.PaymentProfileId = customer.Id;

        await _userRepository.SaveAsync();
    }
}