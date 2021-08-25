using System.Collections;

namespace Watchdog.NetCore.Common.Messages
{
    public class WatchdogRequestMessage
    {
        public string HostName { get; set; }

        public string Url { get; set; }

        public string HttpMethod { get; set; }

        public string IPAddress { get; set; }

        public IDictionary QueryString { get; set; }

        public IDictionary Headers { get; set; }
    }
}
