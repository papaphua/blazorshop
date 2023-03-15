using Microsoft.Extensions.Options;

namespace BlazorShop.Server.Options.OptionSetups;

public sealed class SecretOptionsSetup : IConfigureOptions<SecretOptions>
{
    public SecretOptionsSetup()
    {
        DotNetEnv.Env.Load();
    }

    public void Configure(SecretOptions options)
    {
        options.JwtSecretKey = DotNetEnv.Env.GetString(nameof(options.JwtSecretKey));
        options.StripePrivateKey = DotNetEnv.Env.GetString(nameof(options.StripePrivateKey));
        options.StripeWebHookSecret = DotNetEnv.Env.GetString(nameof(options.StripeWebHookSecret));
        options.SendGridApiKey = DotNetEnv.Env.GetString(nameof(options.SendGridApiKey));
    }
}