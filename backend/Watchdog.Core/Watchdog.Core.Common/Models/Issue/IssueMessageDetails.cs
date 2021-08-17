using System.Collections.Generic;

namespace Watchdog.Core.Common.Models.Issue
{
    public class IssueMessageDetails
    {
        public string Url { get; set; }
        public string ErrorMessage { get; set; }
        public string ClassName { get; set; }
        public ICollection<StackTrace> StackTrace { get; set; }
        public HttpResponseErrorMessage ResponseErrorMessage { get; set; }
        public IssueEnvironment EnvironmentMessage { get; set; }
    }
}