using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using Watchdog.Core.BLL.Models;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.BLL.Services.Options;

namespace Watchdog.Core.BLL.Services
{
    public class EmailSendService : IEmailSendService
    {
        private readonly SendGridClient _client;
        private readonly EmailAddress _sender;
        private readonly string _templateId;

        public EmailSendService(EmailSendOptions options)
        {
            _client = new SendGridClient(options.ApiKey);
            _sender = new EmailAddress(options.SenderEmail, options.SenderName);
            _templateId = options.TemplateId;
        }

        public Task<Response> SendAsync(string recipientEmail, ExampleTemplateData data)
        {
            var message = new SendGridMessage();

            message.SetFrom(_sender);
            message.AddTo(new EmailAddress(recipientEmail));
            message.SetTemplateId(_templateId);
            message.SetTemplateData(data);

            return _client.SendEmailAsync(message);
        }

    }
}
