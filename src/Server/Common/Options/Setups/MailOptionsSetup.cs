using Microsoft.Extensions.Options;

namespace BlazorShop.Server.Common.Options.Setups;

public sealed class MailOptionsSetup : IConfigureOptions<MailOptions>
{
    private const string MailSection = "Mail";
    private const string SendGridApiKeyName = "SENDGRID_API_KEY";
    
    private readonly IConfiguration _configuration;

    public MailOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(MailOptions options)
    {
        _configuration.GetSection(MailSection).Bind(options);

        options.SendGridApiKey = DotNetEnv.Env.GetString(SendGridApiKeyName);
    }
}