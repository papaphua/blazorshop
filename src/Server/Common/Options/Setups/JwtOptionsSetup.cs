using Microsoft.Extensions.Options;

namespace BlazorShop.Server.Common.Options.Setups;

public sealed class JwtOptionsSetup : IConfigureOptions<JwtOptions>
{
    private const string JwtSection = "Jwt";
    private const string JwtSecretKeyName = "JWT_SECRET_KEY";
    
    private readonly IConfiguration _configuration;

    public JwtOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(JwtOptions options)
    {
        _configuration.GetSection(JwtSection).Bind(options);

        options.JwtSecretKey = DotNetEnv.Env.GetString(JwtSecretKeyName);
    }
}