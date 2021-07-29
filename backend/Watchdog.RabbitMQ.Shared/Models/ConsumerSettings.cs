namespace Watchdog.RabbitMQ.Shared.Models
{
    public class ConsumerSettings
    {
        public string ExchangeName { get; set; }
        public string ExchangeType { get; set; }
        public string RoutingKey { get; set; }
        public string QueueName { get; set; }
        public bool SequentialFetch { get; set; } = true;
        public bool AutoAcknowledge { get; set; } = false;
    }
}