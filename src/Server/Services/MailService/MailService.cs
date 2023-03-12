using BlazorShop.Server.Options;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace BlazorShop.Server.Services.MailService;

public sealed class MailService : IMailService
{
    private readonly MailingOptions _options;
    private readonly SendGridClient _client;

    public MailService(IOptions<MailingOptions> options, IOptions<SecretOptions> secrets)
    {
        _options = options.Value;
        _client = new SendGridClient(secrets.Value.SendGridApiKey);
    }

    public async Task SendEmailAsync(string receiver, string text)
    {
        var message = new SendGridMessage
        {
            From = new EmailAddress(_options.SenderEmail, _options.SenderName),
            Subject = _options.Subject,
            PlainTextContent = text
        };

        message.AddTo(new EmailAddress(receiver));

        await _client.SendEmailAsync(message);
    }
}