using Newtonsoft.Json;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Models.Shared.Loader;
using Watchdog.RabbitMQ.Shared.Interfaces;

namespace Watchdog.Core.BLL.Services.Queue
{
    public class NotifyLoaderQueueProducerService : INotifyLoaderQueueProducerService
    {
        private readonly IProducer _producer;

        public NotifyLoaderQueueProducerService(IProducer producer)
        {
            _producer = producer;
        }

        public void SendMessage(LoaderMessage message)
        {
            _producer.Send(JsonConvert.SerializeObject(message), message.GetType().Name);
        }
    }
}
