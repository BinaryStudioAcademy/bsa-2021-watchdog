using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using RabbitMQ.Client;
using System;
using System.Reflection;
using Watchdog.Collector.BLL.MappingProfiles;
using Watchdog.Collector.BLL.Services;
using Watchdog.Collector.BLL.Services.Abstract;
using Watchdog.Models.Shared.Analytics;
using Watchdog.Models.Shared.Issues;
using Watchdog.RabbitMQ.Shared.Models;
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
                .DefaultMappingFor<ResponseInfo>(m =>
                    m.IndexName(configuration["ElasticConfiguration:ResponsesIndex"]))
                .DefaultMappingFor<IssueMessage>(m =>
                    m.IndexName(configuration["ElasticConfiguration:EventMessagesIndex"])
                        .IdProperty(em => em.Id).Ignore(em => em.ApiKey))
                .DefaultMappingFor<CountryInfo>(m =>
                    m.IndexName(configuration["ElasticConfiguration:CountriesInfoIndex"]));

            services.AddSingleton<IElasticClient>(new ElasticClient(settings));
        }

        public static void AddRabbitMQIssueProducer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(x =>
            {
                var amqpConnection = new Uri(configuration.GetSection("RabbitMQConfiguration:Uri").Value);
                var connectionFactory = new ConnectionFactory { Uri = amqpConnection };
                return connectionFactory.CreateConnection();
            });
            var producerSettings = new ProducerSettings();
            configuration.GetSection("RabbitMQConfiguration:Queues:ReceivedIssuesQueueProducer").Bind(producerSettings);

            services.AddScoped<IIssueQueueProducerService>(provider =>
                new IssueQueueProducerService(new Producer(provider.GetRequiredService<IConnection>(), producerSettings)));
        }

        public static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetAssembly(typeof(IssueMessageProfile)));
        }
    }
}