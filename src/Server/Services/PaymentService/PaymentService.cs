using System.Net;
using BlazorShop.Server.Data.Entities;
using BlazorShop.Server.Data.Repositories.UserRepository;
using BlazorShop.Server.Exceptions;
using BlazorShop.Server.Options;
using BlazorShop.Shared.Auth;
using BlazorShop.Shared.Models;
using Microsoft.Extensions.Options;
using Stripe;
using Stripe.Checkout;

namespace BlazorShop.Server.Services.PaymentService;

public sealed class PaymentService : IPaymentService
{
    private const string Usd = "usd";
    private const string Card = "card";
    private const string Payment = "payment";
    private const string StripeSignature = "Stripe-Signature";

    private readonly SecretOptions _secrets;
    private readonly IUserRepository _userRepository;
    private readonly UrlOptions _urlOptions;

    public PaymentService(IOptions<SecretOptions> secrets, IUserRepository userRepository, IOptions<UrlOptions> urlOptions)
    {
        _userRepository = userRepository;
        _urlOptions = urlOptions.Value;
        _secrets = secrets.Value;
        StripeConfiguration.ApiKey = _secrets.StripePrivateKey;
    }

    public Stripe.Checkout.Session CreateCheckoutSession(HttpContext context, List<CartItem> cart)
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

        var customerId = context.User.Claims.First(c => c.Type == CustomClaims.PaymentProfileId).Value;
        
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
            SuccessUrl = _urlOptions.OrderSuccessUrl,
            CancelUrl = _urlOptions.OrderCancelUrl
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
                    if (stripeEvent.Data.Object is not Customer customer) 
                        throw new BusinessException(ExceptionMessages.InternalError);
                    
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

        await _userRepository.UpdateAndSaveAsync(user);
    }
}