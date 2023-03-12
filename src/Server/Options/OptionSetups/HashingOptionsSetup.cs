using Microsoft.Extensions.Options;

namespace BlazorShop.Server.Options.OptionSetups;

public sealed class HashingOptionsSetup : IConfigureOptions<HashingOptions>
{
    private const string HashingSection = "Hashing";
    
    private readonly IConfiguration _configuration;

    public HashingOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(HashingOptions options)
    {
        _configuration.GetSection(HashingSection).Bind(options);
    }
}