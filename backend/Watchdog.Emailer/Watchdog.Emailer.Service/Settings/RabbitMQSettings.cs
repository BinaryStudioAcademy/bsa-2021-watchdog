using Watchdog.RabbitMQ.Shared.Models;

namespace Watchdog.Emailer.Service.Settings
{
    public class RabbitMQSettings
    {
        public string Uri { get; set; }
        public QueueSettings Queues { get; set; }
    }

    public class QueueSettings
    {
        public ConsumerSettings EmailerQueueConsumer { get; set; }
    }
}
