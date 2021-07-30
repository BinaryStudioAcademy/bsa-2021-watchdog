namespace Watchdog.RabbitMQ.Shared.Interfaces
{
    public interface IProducer
    {
        void Send(string message, string? type);
    }
}