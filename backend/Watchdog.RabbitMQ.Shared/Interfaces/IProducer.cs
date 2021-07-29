using Watchdog.RabbitMQ.Shared.Models;

namespace Watchdog.RabbitMQ.Shared.Interfaces
{
    public interface IProducer
    {
        void Send(string message, ProducerSettings settings, string? type);
    }
}