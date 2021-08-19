using Microsoft.AspNetCore.Http;

namespace Watchdog.AspNetCore
{
    public interface IWatchdogAspNetCoreClientProvider
    {
        WatchdogClient GetClient(WatchdogSettings settings);
        WatchdogClient GetClient(WatchdogSettings settings, HttpContext context);
        WatchdogSettings GetWatchdogSettings(WatchdogSettings baseSettings);
    }

    public class DefaultWatchdogAspNetCoreClientProvider : IWatchdogAspNetCoreClientProvider
    {
        public virtual WatchdogClient GetClient(WatchdogSettings settings)
        {
            return GetClient(settings, null);
        }

        public virtual WatchdogClient GetClient(WatchdogSettings settings, HttpContext context)
        {
            return new WatchdogClient(settings, context);
        }

        public virtual WatchdogSettings GetWatchdogSettings(WatchdogSettings baseSettings)
        {
            return baseSettings;
        }
    }
}
