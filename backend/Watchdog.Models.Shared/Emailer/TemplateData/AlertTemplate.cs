using Newtonsoft.Json;
using Watchdog.Models.Shared.Issues;

namespace Watchdog.Models.Shared.Emailer.TemplateData
{
    public class AlertTemplate
    {
        [JsonConstructor]
        public AlertTemplate()
        {
        }

        // For demonstration purposes only.
        // Models must be implemented based on the SendGrid template.

        public AlertTemplate(IssueMessage issue)
        {
            Subject = $"Watchdog - {issue.IssueDetails.ClassName} - {issue.IssueDetails.ErrorMessage}";
            Name = $"{issue.IssueDetails.EnvironmentMessage.Platform}";
            Location = new Location
            {
                City = $"{issue.IssueDetails.ResponseErrorMessage.StatusText}",
                Country = "asdf"
            };
        }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }
    }

    public class Location
    {
        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }
    }
}
