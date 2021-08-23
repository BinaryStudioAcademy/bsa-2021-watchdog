namespace Watchdog.NetCore.Common.Messages
{
    public class WatchdogEnvironmentMessage
    {

        public double UtcOffset { get; set; }

        public string Locale { get; set; }

        public string Platform { get; set; }
    }
}
