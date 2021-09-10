using System;

namespace Watchdog.Models.Shared.Analytics.LoaderTestAnalytics
{
    public class ResponseTimes
    {
        public TimeSpan Average { get; set; }
        public TimeSpan Min { get; set; }
        public TimeSpan Max { get; set; }
    }
}
