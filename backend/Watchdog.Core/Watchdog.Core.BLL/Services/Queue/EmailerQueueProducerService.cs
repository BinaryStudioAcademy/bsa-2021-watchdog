using Newtonsoft.Json;
using System.Collections.Generic;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Models.Shared.Emailer;
using Watchdog.Models.Shared.Emailer.Emails;
using Watchdog.Models.Shared.Emailer.TemplateData;
using Watchdog.RabbitMQ.Shared.Services;

namespace Watchdog.Core.BLL.Services.Queue
{
    public class EmailerQueueProducerService : IEmailerQueueProducerService
    {
        private readonly Producer _producer;

        public EmailerQueueProducerService(Producer producer)
        {
            _producer = producer;
        }

        public void SendAlert(IssueTemplate issueTemplate, ICollection<Recipient> recipients)
        {
            var email = new Alert
            {
                TemplateData = new AlertTemplate(issueTemplate),
                Recipients = recipients,
                Settings = new EmailSettings()
            };
            string message = JsonConvert.SerializeObject(email, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            });
            _producer.Send(message, null);
        }

        public void SendMemberInvitation(MemberTemplate memberTemplate, ICollection<Recipient> recipients)
        {
            var email = new MemberInvitation
            {
                TemplateData = new MemberInvitationTemplate(memberTemplate),
                Recipients = recipients,
                Settings = new EmailSettings()
            };
            string message = JsonConvert.SerializeObject(email, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            });
            _producer.Send(message, null);
        }
    }
}
