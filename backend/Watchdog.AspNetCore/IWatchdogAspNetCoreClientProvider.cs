using Microsoft.AspNetCore.Http;

namespace Watchdog.AspNetCore
{
    public interface IWatchdogAspNetCoreClientProvider
    {
        WatchdogClient GetClient(WatchdogSettings settings);
        WatchdogClient GetClient(WatchdogSettings settings, HttpContext context);
        WatchdogSettings GetWatchdogSettings(WatchdogSettings baseSettings);
    }
}
