namespace Watchdog.NetCore.Common.Messages
{
    public class WatchdogResponseMessage
    {
        public int StatusCode { get; set; }

        public string StatusDescription { get; set; }

        public string Content { get; set; }
    }
}
