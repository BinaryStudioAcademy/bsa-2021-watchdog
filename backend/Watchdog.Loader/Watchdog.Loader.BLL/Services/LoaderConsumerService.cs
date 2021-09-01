using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Watchdog.Models.Shared.Loader;
using Watchdog.RabbitMQ.Shared.Interfaces;
using Watchdog.RabbitMQ.Shared.Models;

namespace Watchdog.Loader.BLL.Services
{
    public class LoaderConsumerService : BackgroundService
    {
        private readonly IConsumer _consumer;
        private readonly ConsumerSettings _settings;
        private readonly IServiceProvider _provider;

        public LoaderConsumerService(
            IServiceProvider provider,
            IConsumer consumer,
            ConsumerSettings settings)
        {
            _consumer = consumer;
            _provider = provider;
            _settings = settings;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _consumer.Connect(_settings, Received);
            return Task.CompletedTask;
        }

        private void Received(object sender, BasicDeliverEventArgs args)
        {
            var messageString = Encoding.UTF8.GetString(args.Body.Span);
            var message = JsonConvert.DeserializeObject<LoaderMessage>(messageString);
            Console.WriteLine(message); // Temp
        }

        public override void Dispose()
        {
            base.Dispose();
            _consumer.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
