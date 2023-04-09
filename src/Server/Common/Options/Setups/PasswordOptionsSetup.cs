using Microsoft.Extensions.Options;

namespace BlazorShop.Server.Common.Options.Setups;

public sealed class PasswordOptionsSetup : IConfigureOptions<PasswordOptions>
{
    private const string PasswordSection = "Password";

    private readonly IConfiguration _configuration;

    public PasswordOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(PasswordOptions options)
    {
        _configuration.GetSection(PasswordSection).Bind(options);
    }
}