using RabbitMQ.Client;
using Watchdog.RabbitMQ.Shared.Interfaces;
using Watchdog.RabbitMQ.Shared.Models;

namespace Watchdog.Core.BLL.Services
{
    public class QueueService
    {
        private readonly IProducer _messageProducer;

        public QueueService(IProducer messageProducer)
        {
            _messageProducer = messageProducer;
        }

        public void Send(string message)
        {
            _messageProducer.Send(
                message,
                new ProducerSettings
                {
                    ExchangeName = "test_exchange",
                    ExchangeType = ExchangeType.Direct,
                    RoutingKey = "watchdog",
                    QueueName = "test_queue"
                },
                null
            );
        }
    }
}