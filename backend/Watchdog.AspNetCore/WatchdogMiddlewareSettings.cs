namespace Watchdog.AspNetCore
{
    public class WatchdogMiddlewareSettings
    {
        public IWatchdogAspNetCoreClientProvider ClientProvider { get; set; }

        public WatchdogMiddlewareSettings()
        {
            ClientProvider = new DefaultWatchdogAspNetCoreClientProvider();
        }
    }
}
