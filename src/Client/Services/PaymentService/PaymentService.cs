namespace BlazorShop.Client.Services.PaymentService;

public sealed class PaymentService : IPaymentService
{
    private readonly HttpClient _http;

    public PaymentService(HttpClient http)
    {
        _http = http;
    }

    public async Task<string> GeneratePaymentLink()
    {
        throw new NotImplementedException();
    }
}