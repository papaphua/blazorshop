namespace BlazorShop.Client.Services.PaymentService;

public interface IPaymentService
{
    Task<string> GeneratePaymentLink();
}