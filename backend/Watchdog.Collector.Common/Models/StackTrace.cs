using System.Collections.Generic;

namespace Watchdog.Collector.Common.Models
{
    public class StackTrace
    {
        public string File { get; set; }
        public string MethodName { get; set; }
        public ICollection<string> Arguments { get; set; }
        public string LineNumber { get; set; }
        public string Column { get; set; }
    }
}