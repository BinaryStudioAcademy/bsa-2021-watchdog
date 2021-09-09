using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Watchdog.Models.Shared.Emailer.TemplateData
{
    public class AlertTemplate
    {
        [JsonConstructor]
        public AlertTemplate()
        {
        }

        public AlertTemplate(IssueTemplate template)
        {
            Issue = template;
            Subject = $"Watchdog - {template.IssueDetails.ClassName} - {template.IssueDetails.ErrorMessage}";
        }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("issue")]
        public IssueTemplate Issue { get; set; }
    }

    public class IssueTemplate
    {
        [JsonProperty("occurredOn")]
        public DateTime OccurredOn { get; set; }

        [JsonProperty("issueDetails")]
        public IssueDetailsTemplate IssueDetails { get; set; }
    }

    public class IssueDetailsTemplate
    {
        [JsonProperty("className")]
        public string ClassName { get; set; }

        [JsonProperty("errorMessage")]
        public string ErrorMessage { get; set; }

        [JsonProperty("stackTrace")]
        public ICollection<StackFrameTemplate> StackTrace { get; set; }

        [JsonProperty("response")]
        public ResponseErrorMessageTemplate ResponseErrorMessage { get; set; }

        [JsonProperty("environment")]
        public IssueEnvironmentTemplate EnvironmentMessage { get; set; }
    }

    public class StackFrameTemplate
    {
        [JsonProperty("className")]
        public string ClassName { get; set; }

        [JsonProperty("methodName")]
        public string MethodName { get; set; }
    }

    public class ResponseErrorMessageTemplate
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("hostName")]
        public string HostName { get; set; }

        [JsonProperty("httpMethod")]
        public string HttpMethod { get; set; }

        [JsonProperty("iPAddress")]
        public string IPAddress { get; set; }
    }

    public class IssueEnvironmentTemplate
    {
        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonProperty("systemType")]
        public string SystemType { get; set; }
    }
}
