using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace Watchdog.AspNetCore
{
    public class WatchdogAspNetMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly WatchdogMiddlewareSettings _middlewareSettings;
        private readonly WatchdogSettings _settings;

        public WatchdogAspNetMiddleware(RequestDelegate next, IOptions<WatchdogSettings> settings, WatchdogMiddlewareSettings middlewareSettings)
        {
            _next = next;
            _middlewareSettings = middlewareSettings;
            _settings = _middlewareSettings.ClientProvider.GetWatchdogSettings(settings.Value ?? new WatchdogSettings());
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch(Exception e)
            {
                var client = _middlewareSettings.ClientProvider.GetClient(_settings, httpContext);
                await client.SendInBackground(e);
                throw;
            }
        }
    }

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
