namespace Watchdog.Core.Common.Models.Issue
{
    public class StackTrace
    {
        public string File { get; set; }
        public string MethodName { get; set; }
        public string[] Arguments { get; set; }
        public int LineNumber { get; set; }
        public int Column { get; set; }
    }
}