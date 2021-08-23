using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client.Events;
using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.Models.Issue;
using Watchdog.RabbitMQ.Shared.Interfaces;
using Watchdog.RabbitMQ.Shared.Models;

namespace Watchdog.Core.BLL.Services.Queue
{
    public class CollectorQueueConsumerService : BackgroundService
    {
        private readonly IConsumer _consumer;
        private readonly ConsumerSettings _settings;

        private readonly IServiceProvider _provider;
        private readonly ILogger<CollectorQueueConsumerService> _logger;

        public CollectorQueueConsumerService(
            IServiceProvider provider,
            IConsumer consumer,
            ConsumerSettings settings,
            ILogger<CollectorQueueConsumerService> logger)
        {
            _consumer = consumer;
            _provider = provider;
            _settings = settings;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _consumer.Connect(_settings, Received);
            await Task.CompletedTask;
        }

        private async void Received(object sender, BasicDeliverEventArgs args)
        {
            var messageString = Encoding.UTF8.GetString(args.Body.Span);
            var issueMessageReceived = JsonConvert.DeserializeObject<IssueMessage>(messageString);

            _consumer.SetAcknowledge(args.DeliveryTag, true);

            _logger.LogInformation("Processing issue from collector: {0}, {1}", issueMessageReceived.IssueDetails.ClassName, issueMessageReceived.IssueDetails.ErrorMessage);

            //TODO: Change to future value from IssueMessage
            int applicationId = 36;

            using var scope = _provider.CreateScope();
            var userService = scope.ServiceProvider.GetRequiredService<IUserService>();
            var userIds = await userService.GetUserUIdsByApplicationIdAsync(applicationId);

            var issueService = scope.ServiceProvider.GetRequiredService<IIssueService>();
            var issueMessage = (await issueService.GetIssuesMessagesByParentIdAsync(issueMessageReceived.IssueId)).OrderByDescending(i => i.OccurredOn).FirstOrDefault();

            var notifyService = scope.ServiceProvider.GetRequiredService<INotifyQueueProducerService>();
            notifyService.NotifyUsers(userIds, issueMessage);
        }

        public override void Dispose()
        {
            base.Dispose();
            _consumer.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
