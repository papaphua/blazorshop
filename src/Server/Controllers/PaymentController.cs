using BlazorShop.Server.Auth.PermissionHandler;
using BlazorShop.Server.Common;
using BlazorShop.Server.Services.PaymentService;
using BlazorShop.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlazorShop.Server.Controllers;

[Route("api/payments")]
[ApiController]
public sealed class PaymentController : ControllerBase
{
    private readonly IPaymentService _paymentService;

    public PaymentController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    [HasPermission(Permissions.CustomerPermission)]
    [HttpPost("checkout")]
    public ActionResult CheckoutSession(List<CartItem> cartItems)
    {
        var session = _paymentService.CreateCheckoutSession(HttpContext, cartItems);

        return Ok(session.Url);
    }

    [AllowAnonymous]
    [HttpPost("webhook")]
    public async Task<IActionResult> WebHook()
    {
        var statusCode = await _paymentService.CreateWebHookAsync(HttpContext);

        return StatusCode((int)statusCode);
    }
}