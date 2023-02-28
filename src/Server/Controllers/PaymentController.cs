using BlazorShop.Server.Services.PaymentService;
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
    
    [AllowAnonymous]
    [HttpPost("webhook")]
    public async Task<IActionResult> WebHook()
    {
        var statusCode = await _paymentService.CreateWebHookAsync(HttpContext);

        return StatusCode((int)statusCode);
    }
}