using Watchdog.Loader.BLL.Services.Abstract;
using Watchdog.RabbitMQ.Shared.Interfaces;

namespace Watchdog.Loader.BLL.Services
{
    public class LoaderProducerService : ILoaderProducerService
    {
        private readonly IProducer _producer;

        public LoaderProducerService(IProducer producer)
        {
            _producer = producer;
        }
        public void ProduceMessage(string test)
        {
            _producer.Send(test, test.GetType().Name);
        }
    }
}
