using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using Watchdog.Collector.BLL.Services;
using Watchdog.Collector.BLL.Services.Abstract;
using Watchdog.Collector.Common.Models;

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
                .DefaultIndex("default_index")
                .DefaultMappingFor<IssueMessage>(m => m .IndexName("issues"));
            
            services.AddSingleton<IElasticClient>(new ElasticClient(settings));
        }
    }
}