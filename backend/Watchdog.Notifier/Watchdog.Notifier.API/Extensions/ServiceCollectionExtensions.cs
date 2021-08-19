using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System;
using Watchdog.Notifier.BLL.Hubs;
using Watchdog.Notifier.BLL.Hubs.Interfaces;
using Watchdog.Notifier.BLL.Services;

namespace Watchdog.Notifier.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRabbitMQIssueConsumer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(x =>
            {
                var amqpConnection = new Uri(configuration.GetSection("RabbitMQConfiguration:Uri").Value);
                var connectionFactory = new ConnectionFactory { Uri = amqpConnection };
                return connectionFactory.CreateConnection();
            });
            var consumerSettings = new RabbitMQ.Shared.Models.ConsumerSettings();
            configuration.GetSection("RabbitMQConfiguration:Queues:NotifyIssuesQueueConsumer").Bind(consumerSettings);

            services.AddHostedService(provider => new CoreIssuesQueueConsumerService(
                provider.GetRequiredService<IConnection>(),
                consumerSettings,
                provider.GetRequiredService<IHubContext<IssuesHub, IIssuesHubClient>>(),
                provider.GetRequiredService<ILogger<CoreIssuesQueueConsumerService>>()));
        }
    }
}