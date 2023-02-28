using Microsoft.Extensions.Options;

namespace BlazorShop.Server.Options.OptionSetups;

public sealed class SecretOptionsSetup : IConfigureOptions<SecretOptions>
{
    private const string SecretsSection = "Secrets";

    private readonly IConfiguration _configuration;

    public SecretOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(SecretOptions options)
    {
        _configuration.GetSection(SecretsSection).Bind(options);
    }
}