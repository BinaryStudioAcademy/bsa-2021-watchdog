namespace Watchdog.RabbitMQ.Shared.Models
{
    public class ProducerSettings
    {
        public string ExchangeName { get; set; }
        public string ExchangeType { get; set; }
        public string RoutingKey { get; set; }
        public string QueueName { get; set; } = string.Empty;
    }
}