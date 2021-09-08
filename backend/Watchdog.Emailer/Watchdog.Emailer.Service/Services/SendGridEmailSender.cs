using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Watchdog.Emailer.Service.Abstractions;
using Watchdog.Emailer.Service.Settings;
using Watchdog.Models.Shared.Emailer.Abstractions;

namespace Watchdog.Emailer.Service.Services
{
    public class SendGridEmailSender : IEmailSender
    {
        private readonly ILogger _logger;
        private readonly ISendGridClient _sendGridClient;
        private readonly SendGrigSettings _sendGridSettings;

        public SendGridEmailSender(ILogger<SendGridEmailSender> logger,
                                   ISendGridClient sendGridClient,
                                   IOptions<SendGrigSettings> sendGridSettings)
        {
            _logger = logger;
            _sendGridClient = sendGridClient;
            _sendGridSettings = sendGridSettings.Value;
        }

        public async Task<Response> SendEmail(Email email)
        {
            var emailAddresses = email.Recipients.Select(x => new EmailAddress
            {
                Name = $"{x.FirstName} {x.LastName}",
                Email = x.EmailAddress
            }).ToList();

            SendGridMessage message = CreateNewMessage(email, emailAddresses);

            var response = await _sendGridClient.SendEmailAsync(message);
            emailAddresses.ForEach(x => _logger.LogInformation($"{x.Email} - {response.StatusCode}"));

            return response;
        }

        private SendGridMessage CreateNewMessage(Email email, List<EmailAddress> emailAddresses)
        {
            var senderAddress = new EmailAddress(_sendGridSettings.SenderEmail, _sendGridSettings.SenderName);
            var message = new SendGridMessage();

            message.SetFrom(senderAddress);
            message.AddTos(emailAddresses);
            message.SetTemplateId(email.TemplateId);
            message.SetTemplateData(email.TemplateData);

            return message;
        }
    }
}
