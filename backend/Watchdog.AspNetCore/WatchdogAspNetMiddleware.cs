using Microsoft.AspNetCore.Http;
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
                await client.SendInBackgroundAsync(e);
                throw;
            }
        }
    }
}
