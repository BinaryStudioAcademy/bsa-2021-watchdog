namespace Watchdog.NetCore.Common.Messages
{
    public class WatchdogErrorStackTraceLineMessage
    {
        public int LineNumber { get; set; }

        public int ColumnNumber { get; set; }

        public string ClassName { get; set; }

        public string FileName { get; set; }

        public string MethodName { get; set; }
    }
}
