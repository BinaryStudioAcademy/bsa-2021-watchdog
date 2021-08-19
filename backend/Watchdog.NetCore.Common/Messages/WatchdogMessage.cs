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

        public DateTime OccurredOn { get; set; }

        public WatchdogMessageDetails Details { get; set; }
    }
}
