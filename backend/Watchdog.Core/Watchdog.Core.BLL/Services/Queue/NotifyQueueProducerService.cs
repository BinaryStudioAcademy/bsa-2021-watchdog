using Newtonsoft.Json;
using System.Collections.Generic;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.DTO.Issue;
using Watchdog.Core.Common.Models.Issue;
using Watchdog.RabbitMQ.Shared.Interfaces;

namespace Watchdog.Core.BLL.Services.Queue
{
    public class NotifyQueueProducerService : INotifyQueueProducerService
    {
        private readonly IProducer _producer;

        public NotifyQueueProducerService(IProducer producer)
        {
            _producer = producer;
        }

        public void NotifyUsers(ICollection<string> userIds, IssueMessage message)
        {
            var body = JsonConvert.SerializeObject(new IssueQueueMessageDto
            {
                Issue = message,
                UserIds = userIds
            });

            _producer.Send(body, "JSON");
        }
    }
}
