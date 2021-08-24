using System.Collections.Generic;

namespace Watchdog.Notifier.Common.Models
{
    public class IssueMessageDetails
    {
        public string Url { get; set; }
        public string ErrorMessage { get; set; }
        public string ClassName { get; set; }
        public ICollection<StackFrame> StackTrace { get; set; }
        public HttpResponseErrorMessage ResponseErrorMessage { get; set; }
        public IssueEnvironment EnvironmentMessage { get; set; }
        public ICollection<Breadcrumb> Breadcrumbs { get; set; }
    }
}