namespace Watchdog.Models.Shared.Issues
{
    public class IssueEnvironment
    {
        public string Browser { get; set; }
        public string BrowserName { get; set; }
        public string BrowserVersion { get; set; }
        public string Platform { get; set; }
        public double UtcOffset { get; set; }
        public string Locale { get; set; }
        public string SystemType { get; set; }
    }
}