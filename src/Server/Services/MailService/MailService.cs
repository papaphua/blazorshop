using BlazorShop.Server.Common.Options;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace BlazorShop.Server.Services.MailService;

public sealed class MailService : IMailService
{
    private readonly MailOptions _options;
    private readonly SendGridClient _client;

    public MailService(IOptions<MailOptions> options)
    {
        _options = options.Value;
        _client = new SendGridClient(_options.SendGridApiKey);
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