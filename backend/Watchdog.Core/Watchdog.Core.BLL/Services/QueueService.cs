using Watchdog.RabbitMQ.Shared.Interfaces;

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
                null
            );
        }
    }
}