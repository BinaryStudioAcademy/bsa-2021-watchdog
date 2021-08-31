using Newtonsoft.Json;
using Watchdog.Collector.BLL.Services.Abstract;
using Watchdog.Models.Shared.Issues;
using Watchdog.RabbitMQ.Shared.Interfaces;

namespace Watchdog.Collector.BLL.Services
{
    public class IssueQueueProducerService : IIssueQueueProducerService
    {
        private readonly IProducer _producer;

        public IssueQueueProducerService(IProducer producer)
        {
            _producer = producer;
        }

        public void ProduceMessage(IssueMessage message)
        {
            string jsonMessage = JsonConvert.SerializeObject(message);
            _producer.Send(jsonMessage, "JSON");
        }
    }
}
