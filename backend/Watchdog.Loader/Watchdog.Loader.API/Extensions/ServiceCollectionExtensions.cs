using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Nest;
using RabbitMQ.Client;
using System;
using Watchdog.Loader.BLL.Services;
using Watchdog.Loader.BLL.Services.Abstract;
using Watchdog.Models.Shared.Loader;
using Watchdog.RabbitMQ.Shared.Models;
using Watchdog.RabbitMQ.Shared.Services;

namespace Watchdog.Loader.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterCustomServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IStartService, StartService>();
            services.AddScoped<IElasticService, ElasticService>();
            services.AddElasticSearch(configuration);
            services.AddRabbitMQ(configuration);
        }

        public static void AddElasticSearch(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["ElasticConfiguration:Uri"];

            var settings = new ConnectionSettings(new Uri(connectionString))
                .DefaultIndex(configuration["ElasticConfiguration:DefaultIndex"])
                .DefaultMappingFor<TestResult>(m =>
                    m.IndexName(configuration["ElasticConfiguration:LoaderMessagesIndex"])
                        .IdProperty(x => x.Id));

            services.AddSingleton<IElasticClient>(new ElasticClient(settings));
        }

        public static void AddRabbitMQ(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(x =>
            {
                var amqpConnection = new Uri(configuration.GetSection("RabbitMQConfiguration:Uri").Value);
                var connectionFactory = new ConnectionFactory { Uri = amqpConnection };
                return connectionFactory.CreateConnection();
            });
            services.AddRabbitMQQueues(configuration);
        }

        private static void AddRabbitMQQueues(this IServiceCollection services, IConfiguration configuration)
        {
            var consumerSettings = new ConsumerSettings();

            configuration
                .GetSection("RabbitMQConfiguration:Queues:LoaderQueueConsumer")
                .Bind(consumerSettings);

            services.AddHostedService(provider =>
                new LoaderConsumerService(
                    provider,
                    new Consumer(
                        provider.GetRequiredService<IConnection>()),
                        consumerSettings,
                    provider.GetRequiredService<ILogger<LoaderConsumerService>>()));

        }
    }
}