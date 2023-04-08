using Microsoft.Extensions.Options;

namespace BlazorShop.Server.Common.Options.Setups;

public sealed class UrlOptionsSetup : IConfigureOptions<UrlOptions>
{
    private const string UrlSection = "Url";
    
    private readonly IConfiguration _configuration;

    public UrlOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(UrlOptions options)
    {
        _configuration.GetSection(UrlSection).Bind(options);
    }
}