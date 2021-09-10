using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client.Events;
using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Watchdog.Loader.BLL.Services.Abstract;
using Watchdog.Models.Shared.Loader;
using Watchdog.RabbitMQ.Shared.Interfaces;
using Watchdog.RabbitMQ.Shared.Models;

namespace Watchdog.Loader.BLL.Services
{
    public class LoaderConsumerService : BackgroundService
    {
        private readonly IConsumer _consumer;
        private readonly ConsumerSettings _settings;
        private readonly ILogger<LoaderConsumerService> _logger;
        private readonly IServiceProvider _provider;

        public LoaderConsumerService(
            IServiceProvider provider,
            IConsumer consumer,
            ConsumerSettings settings,
            ILogger<LoaderConsumerService> logger)
        {
            _consumer = consumer;
            _provider = provider;
            _settings = settings;
            _logger = logger;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _consumer.Connect(_settings, Received);
            return Task.CompletedTask;
        }

        private async void Received(object sender, BasicDeliverEventArgs args)
        {
            var messageString = Encoding.UTF8.GetString(args.Body.Span);
            var message = JsonConvert.DeserializeObject<LoaderMessage>(messageString);
            _logger.LogInformation($"Start test \"{message.Name}\" with id = {message.Id}");

            using var scope = _provider.CreateScope();
            var startService = scope.ServiceProvider.GetRequiredService<IStartService>();
            try
            {
                await startService.StartTestAsync(message);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            finally
            {
                _consumer.SetAcknowledge(args.DeliveryTag, true);
            }
        }

        public override void Dispose()
        {
            base.Dispose();
            _consumer.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
