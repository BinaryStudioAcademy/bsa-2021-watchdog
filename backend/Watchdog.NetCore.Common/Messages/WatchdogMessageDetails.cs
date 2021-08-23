namespace Watchdog.NetCore.Common.Messages
{
    public class WatchdogMessageDetails
    {
        public string MachineName { get; set; }

        public WatchdogErrorMessage Error { get; set; }

        public WatchdogEnvironmentMessage Environment { get; set; }

        public WatchdogRequestMessage Request { get; set; }

        public WatchdogResponseMessage Response { get; set; }
    }
}
