using System;

namespace Watchdog.NetCore.Common.Messages
{
    public class WatchdogMessage
    {
        public WatchdogMessage()
        {
            OccurredOn = DateTime.UtcNow;
            Details = new WatchdogMessageDetails();
        }

        public string ApiKey { get; set; }
        public DateTime OccurredOn { get; set; }

        public WatchdogMessageDetails Details { get; set; }
    }
}
