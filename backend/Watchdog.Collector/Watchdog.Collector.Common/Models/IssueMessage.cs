using System;
using System.Collections.Generic;

namespace Watchdog.Collector.Common.Models
{
    public class IssueMessage
    {
        public DateTime OccurredOn { get; set; }
        public string Url { get; set; }
        public string ErrorMessage { get; set; }
        public string ClassName { get; set; }
        public ICollection<StackFrame> StackTrace { get; set; }
        public HttpResponseErrorMessage ResponseErrorMessage { get; set; }
        public IssueEnvironment EnvironmentMessage { get; set; }
    }
}