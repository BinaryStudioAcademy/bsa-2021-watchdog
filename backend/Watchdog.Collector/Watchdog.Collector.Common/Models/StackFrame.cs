namespace Watchdog.Collector.Common.Models
{
    public class StackFrame
    {
        public string File { get; set; }
        public string MethodName { get; set; }
        public string ClassName { get; set; }
        public string[] Arguments { get; set; }
        public int LineNumber { get; set; }
        public int Column { get; set; }
    }
}