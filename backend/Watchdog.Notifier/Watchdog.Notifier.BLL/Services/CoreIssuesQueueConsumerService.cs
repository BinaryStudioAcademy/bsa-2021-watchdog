using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Watchdog.Notifier.BLL.Hubs;
using Watchdog.Notifier.BLL.Hubs.Interfaces;
using Watchdog.Notifier.Common.DTO;
using Watchdog.RabbitMQ.Shared.Models;
using Watchdog.RabbitMQ.Shared.Services;

namespace Watchdog.Notifier.BLL.Services
{
    public class CoreIssuesQueueConsumerService : BackgroundService
    {
        private readonly Consumer _consumer;
        private readonly ConsumerSettings _settings;

        private readonly IHubContext<IssuesHub, IIssuesHubClient> _hub;
        private readonly ILogger<CoreIssuesQueueConsumerService> _logger;

        public CoreIssuesQueueConsumerService(
            IConnection connection,
            ConsumerSettings settings,
            IHubContext<IssuesHub, IIssuesHubClient> hub,
            ILogger<CoreIssuesQueueConsumerService> logger)
        {
            _consumer = new Consumer(connection);
            _settings = settings;
            _hub = hub;
            _logger = logger;
        }

        private async void Received(object sender, BasicDeliverEventArgs arg)
        {
            // десереалізуємо повідомлення
            var messageString = Encoding.UTF8.GetString(arg.Body.Span);
            var queueMessage = JsonConvert.DeserializeObject<IssueQueueMessageDto>(messageString);

            _consumer.SetAcknowledge(arg.DeliveryTag, true);

            _logger.LogInformation("Processing issue from core: {0}, {1}",
                queueMessage.Issue.IssueDetails.ClassName,
                queueMessage.Issue.IssueDetails.ErrorMessage);
            // відправляємо повідомлення на хаб вказаним отримувачам
            await _hub.Clients
                .Groups(queueMessage.MembersIds.Select(i => i.ToString()).ToList())
                .SendIssue(queueMessage.Issue);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _consumer.Connect(_settings, Received);

            return Task.CompletedTask;
        }
    }
}

