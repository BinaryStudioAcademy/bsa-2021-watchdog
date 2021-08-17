using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using RabbitMQ.Client;
using Watchdog.Collector.BLL.Services;
using Watchdog.Collector.BLL.Services.Abstract;
using Watchdog.Collector.Common.Models;
using Watchdog.RabbitMQ.Shared.Services;

namespace Watchdog.Collector.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IElasticWriteService, ElasticWriteService>();
        }

        public static void AddElasticSearch(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["ElasticConfiguration:Uri"];

            var settings = new ConnectionSettings(new Uri(connectionString))
                .DefaultIndex(configuration["ElasticConfiguration:DefaultIndex"])
                .DefaultMappingFor<IssueMessage>(m =>
                    m.IndexName(configuration["ElasticConfiguration:IssueMessageIndex"]));

            services.AddSingleton<IElasticClient>(new ElasticClient(settings));
        }

        public static void AddRabbitMQIssueProducer(this IServiceCollection services, IConfiguration configuration)
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.HostName = configuration["RabbitMQConfiguration:Hostname"];
            factory.UserName = configuration["RabbitMQConfiguration:User"];
            factory.Password = configuration["RabbitMQConfiguration:Password"];

            IConnection conn = factory.CreateConnection();

            var producerSettings = new RabbitMQ.Shared.Models.ProducerSettings
            {
                ExchangeName = "IssueExchange",
                ExchangeType = ExchangeType.Direct,
                QueueName = "IssueNotifyQueue",
                RoutingKey = "Issue"
            };

            services.AddSingleton<IIssueProducerService>(new IssueProducerService(conn, producerSettings));
        }
    }
}