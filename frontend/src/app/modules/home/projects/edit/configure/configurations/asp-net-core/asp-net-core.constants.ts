export const packageVersion = '1.0.3';
export const packageName = 'Watchdog.AspNetCore';

export const packageManagerInstallationCommand = `Install-Package ${packageName} -version ${packageVersion}`;
export const dotnetCliInstallationCommand = `dotnet add package ${packageName} --version ${packageVersion}`;

export const configureServices = `public IConfiguration Configuration { get; }

public void ConfigureServices(IServiceCollection services)
{
    services.AddControllers();

    services.AddWatchdog(Configuration);
}
`;

export const appsettings = (apiKey: string) => `{
    "WatchdogSettings": {
        "ApiKey": "${apiKey}"
    }
}
`;

export const sample = `using Microsoft.AspNetCore.Http;
using System;
using Watchdog.AspNetCore;

namespace WebApplication
{
    public class ExceptionObserver
    {
        private readonly IWatchdogAspNetCoreClientProvider _clientProvider;

        public ExceptionObserver(IWatchdogAspNetCoreClientProvider clientProvider)
        {
            _clientProvider = clientProvider;
        }

        public async Task HandleException(HttpContext httpContext, Exception exception)
        {
            // To immediately send an exception with the current request state
            await _clientProvider.GetClient(httpContext).SendAsync(exception);

            // To send an exception with the the handled request state
            _clientProvider.GetClient(httpContext).TrackException(exception);
        }
    }
}
`;
