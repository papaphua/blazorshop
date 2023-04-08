using Microsoft.Extensions.Options;

namespace BlazorShop.Server.Common.Options.Setups;

public sealed class PaymentOptionsSetup : IConfigureOptions<PaymentOptions>
{
    private const string StripePrivateKeyName = "STRIPE_PRIVATE_KEY";
    private const string StripeWebhookSecretName = "STRIPE_WEBHOOK_SECRET";

    public void Configure(PaymentOptions options)
    {
        options.StripePrivateKey = DotNetEnv.Env.GetString(StripePrivateKeyName);
        options.StripeWebhookSecret = DotNetEnv.Env.GetString(StripeWebhookSecretName);
    }
}