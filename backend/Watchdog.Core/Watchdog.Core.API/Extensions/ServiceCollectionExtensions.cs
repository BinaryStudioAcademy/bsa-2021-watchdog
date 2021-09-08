using System;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Nest;
using Watchdog.Core.BLL.MappingProfiles;
using Watchdog.Core.BLL.Services;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.Validators.Organization;
using Watchdog.Core.DAL.Context;
using RabbitMQ.Client;
using Watchdog.RabbitMQ.Shared.Models;
using Watchdog.RabbitMQ.Shared.Services;
using Watchdog.Core.BLL.Services.Queue;
using Microsoft.Extensions.Logging;
using Watchdog.Models.Shared.Analytics;
using Watchdog.Models.Shared.Issues;

namespace Watchdog.Core.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterCustomServices(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddControllers()
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IPlatformService, PlatformService>();
            services.AddTransient<IMemberService, MemberService>();
            services.AddTransient<IDashboardService, DashboardService>();
            services.AddTransient<IOrganizationService, OrganizationService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IApplicationService, ApplicationService>();
            services.AddTransient<ITeamService, TeamService>();
            services.AddTransient<IIssueService, IssueService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ITileService, TileService>();
            services.AddTransient<IRegistrationService, RegistrationService>();
            services.AddTransient<ILoaderTestService, LoaderTestService>();
            services.AddElasticSearch(configuration);
            services.AddRabbitMQ(configuration);
            
        }

        public static void AddElasticSearch(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["ElasticConfiguration:Uri"];

            var settings = new ConnectionSettings(new Uri(connectionString))
                .DefaultMappingFor<CountryInfo>(m => 
                        m.IndexName(configuration["ElasticConfiguration:CountriesInfoIndex"]))
                .DefaultMappingFor<IssueMessage>(m =>
                    m.IndexName(configuration["ElasticConfiguration:EventMessagesIndex"])
                        .IdProperty(em => em.Id).Ignore(em => em.ApiKey));
            
            services.AddSingleton<IElasticClient>(new ElasticClient(settings));
        }

        public static void AddAutoMapper(this IServiceCollection services)
        {

            services.AddAutoMapper(Assembly.GetAssembly(typeof(OrganizationProfile)));
        }

        public static void AddValidation(this IServiceCollection services)
        {
            services
                .AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<NewOrganizationDtoValidator>());
        }

        public static void AddWatchdogCoreContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionsString = configuration.GetConnectionString("WatchdogCoreDBConnection");
            services.AddDbContext<WatchdogCoreContext>(options =>
                options.UseSqlServer(
                    connectionsString,
                    opt => opt.MigrationsAssembly(typeof(WatchdogCoreContext).Assembly.GetName().Name)));
        }

        public static void AddRabbitMQ(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(x =>
            {
                var amqpConnection = new Uri(configuration.GetSection("RabbitMQConfiguration:Uri").Value);
                var connectionFactory = new ConnectionFactory { Uri = amqpConnection };
                return connectionFactory.CreateConnection();
            });

            services.AddRabbitMQIssueQueues(configuration);
            services.AddRabbitMQLoaderQueues(configuration);
            services.AddRabbitMQEmailerQueues(configuration);
        }

        private static void AddRabbitMQIssueQueues(this IServiceCollection services, IConfiguration configuration)
        {
            var producerSettings = new ProducerSettings();
            var consumerSettings = new ConsumerSettings();
            configuration
                .GetSection("RabbitMQConfiguration:Queues:NotifyIssuesQueueProducer")
                .Bind(producerSettings);

            configuration
                .GetSection("RabbitMQConfiguration:Queues:ReceivedIssuesQueueConsumer")
                .Bind(consumerSettings);

            services.AddScoped<INotifyQueueProducerService>(provider =>
                new NotifyQueueProducerService(
                    new Producer(
                        provider.GetRequiredService<IConnection>(),
                        producerSettings)));

            services.AddHostedService(provider =>
                new CollectorQueueConsumerService(
                    provider,
                    new Consumer(
                        provider.GetRequiredService<IConnection>()),
                        consumerSettings,
                        provider.GetRequiredService<ILogger<CollectorQueueConsumerService>>()));
        }

        private static void AddRabbitMQLoaderQueues(this IServiceCollection services, IConfiguration configuration)
        {
            var producerSettings = new ProducerSettings();
            configuration
                .GetSection("RabbitMQConfiguration:Queues:LoaderQueueProducer")
                .Bind(producerSettings);


            services.AddScoped<INotifyLoaderQueueProducerService>(provider =>
                new NotifyLoaderQueueProducerService(
                    new Producer(
                        provider.GetRequiredService<IConnection>(),
                        producerSettings)));

        }

        private static void AddRabbitMQEmailerQueues(this IServiceCollection services, IConfiguration configuration)
        {
            var producerSettings = configuration
                .GetSection("RabbitMQConfiguration:Queues:EmailerQueueProducer")
                .Get<ProducerSettings>();

            services.AddSingleton<IEmailerQueueProducerService>(provider =>
                new EmailerQueueProducerService(
                    new Producer(
                        provider.GetRequiredService<IConnection>(),
                        producerSettings)));
        }
    }
}
