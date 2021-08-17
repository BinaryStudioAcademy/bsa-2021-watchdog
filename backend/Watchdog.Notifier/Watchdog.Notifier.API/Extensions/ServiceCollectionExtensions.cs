using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using Watchdog.Notifier.BLL.Services;
using Watchdog.Notifier.BLL.Services.Abstract;

namespace Watchdog.Notifier.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRabbitMQIssueConsumer(this IServiceCollection services, IConfiguration configuration)
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.HostName = configuration["RabbitMQConfiguration:Hostname"];
            factory.UserName = configuration["RabbitMQConfiguration:User"];
            factory.Password = configuration["RabbitMQConfiguration:Password"];

            IConnection conn = factory.CreateConnection();

            var consumerSettings = new RabbitMQ.Shared.Models.ConsumerSettings
            {
                ExchangeName = "IssueExchange",
                ExchangeType = ExchangeType.Direct,
                QueueName = "IssueNotifyQueue",
                RoutingKey = "Issue"
            };

            services.AddSingleton<IIssueConsumerService>(new IssueConsumerService(conn, consumerSettings));
        }
    }
}