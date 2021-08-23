namespace Watchdog.NetCore.Common.Messages
{
    public class WatchdogErrorMessage
    {
        public WatchdogErrorMessage InnerError { get; set; }

        public WatchdogErrorMessage[] InnerErrors { get; set; }

        public string ClassName { get; set; }

        public string Message { get; set; }

        public WatchdogErrorStackTraceLineMessage[] StackTrace { get; set; }
    }
}
