using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Watchdog.AspNetCore
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseWatchdog(this IApplicationBuilder app)
        {
            return app.UseMiddleware<WatchdogAspNetMiddleware>();
        }

        public static IServiceCollection AddWatchdog(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<WatchdogSettings>(configuration.GetSection("WatchdogSettings"));

            services.AddTransient<IWatchdogAspNetCoreClientProvider>(_ => new DefaultWatchdogAspNetCoreClientProvider());
            services.AddSingleton<WatchdogMiddlewareSettings>();

            return services;
        }

        public static IServiceCollection AddWatchdog(this IServiceCollection services, IConfiguration configuration, WatchdogMiddlewareSettings middlewareSettings)
        {
            services.Configure<WatchdogSettings>(configuration.GetSection("WatchdogSettings"));

            services.AddTransient(_ => middlewareSettings.ClientProvider ?? new DefaultWatchdogAspNetCoreClientProvider());
            services.AddTransient(_ => middlewareSettings);

            return services;
        }
    }
}
