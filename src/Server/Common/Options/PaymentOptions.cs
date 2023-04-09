namespace BlazorShop.Server.Common.Options;

public sealed class PaymentOptions
{
    public string StripePrivateKey { get; set; } = null!;

    public string StripeWebhookSecret { get; set; } = null!;
}