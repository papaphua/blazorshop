using Microsoft.Extensions.Options;

namespace BlazorShop.Server.Options.OptionSetups;

public sealed class MailingOptionsSetup : IConfigureOptions<MailingOptions>
{
    private const string MailingSection = "Mailing";
    
    private readonly IConfiguration _configuration;

    public MailingOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(MailingOptions options)
    {
        _configuration.GetSection(MailingSection).Bind(options);
    }
}