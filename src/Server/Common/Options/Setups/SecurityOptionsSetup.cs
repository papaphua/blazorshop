using Microsoft.Extensions.Options;

namespace BlazorShop.Server.Common.Options.Setups;

public sealed class SecurityOptionsSetup : IConfigureOptions<SecurityOptions>
{
    private const string SecuritySection = "Security";
    
    private readonly IConfiguration _configuration;

    public SecurityOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(SecurityOptions options)
    {
        _configuration.GetSection(SecuritySection).Bind(options);
    }
}