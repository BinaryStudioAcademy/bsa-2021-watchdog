using Newtonsoft.Json;
using RabbitMQ.Client.Events;
using System.Text;
using Watchdog.RabbitMQ.Shared.Services;
using Watchdog.RabbitMQ.Shared.Models;
using Watchdog.Notifier.Common.DTO;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using System.Threading;
using Watchdog.Notifier.BLL.Hubs;
using Microsoft.AspNetCore.SignalR;
using Watchdog.Notifier.BLL.Hubs.Interfaces;
using RabbitMQ.Client;
using Microsoft.Extensions.Logging;

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
            var messageString = Encoding.UTF8.GetString(arg.Body.Span);
            var issueMessage = JsonConvert.DeserializeObject<IssueQueueMessageDto>(messageString);

            _consumer.SetAcknowledge(arg.DeliveryTag, true);

            _logger.LogInformation("Processing issue from core: {0}, {1}", issueMessage.Issue.IssueDetails.ClassName, issueMessage.Issue.IssueDetails.ErrorMessage);

            await _hub.Clients.Users(issueMessage.UserIds).SendIssue(issueMessage.Issue);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _consumer.Connect(_settings, Received);

            return Task.CompletedTask;
        }
    }
}

