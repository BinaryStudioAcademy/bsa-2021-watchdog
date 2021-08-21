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
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.Models.Issue;
using Watchdog.Core.DAL.Context;
using Watchdog.Core.DAL.Entities;
using Watchdog.RabbitMQ.Shared.Interfaces;
using Watchdog.RabbitMQ.Shared.Models;

namespace Watchdog.Core.BLL.Services.Queue
{
    public class CollectorQueueConsumerService : BackgroundService
    {
        private readonly IConsumer _consumer;
        private readonly ConsumerSettings _settings;
        private readonly WatchdogCoreContext _context;
        private readonly IMapper _mapper;

        private readonly IServiceProvider _provider;
        private readonly ILogger<CollectorQueueConsumerService> _logger;

        public CollectorQueueConsumerService(
            IServiceProvider provider,
            IConsumer consumer,
            ConsumerSettings settings,
            WatchdogCoreContext context,
            ILogger<CollectorQueueConsumerService> logger,
            IMapper mapper)
        {
            _consumer = consumer;
            _provider = provider;
            _settings = settings;
            _context = context;
            _logger = logger;
            _mapper = mapper;
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

            var eventMessage = _mapper.Map<EventMessage>(issueMessageReceived);
            _context.EventMessages.Add(eventMessage);
            await _context.SaveChangesAsync();

            await _context.Issues.AnyAsync(i => i.ErrorMessage == issueMessageReceived.IssueDetails.ErrorMessage)
                

            _consumer.SetAcknowledge(args.DeliveryTag, true);

            _logger.LogInformation("Processing issue from collector: {0}, {1}", issueMessageReceived.IssueDetails.ClassName, issueMessageReceived.IssueDetails.ErrorMessage);

            //TODO: Change to future value from IssueMessage
            int applicationId = 16;

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
