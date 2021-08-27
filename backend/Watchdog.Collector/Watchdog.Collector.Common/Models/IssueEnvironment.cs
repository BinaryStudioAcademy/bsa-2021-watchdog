namespace Watchdog.Collector.Common.Models
{
    public class IssueEnvironment
    {
        public string Browser { get; set; }
        public string BrowserName { get; set; }
        public string BrowserVersion { get; set; }
        public string Platform { get; set; }
        public string SystemType { get; set; }
        public double UtcOffset { get; set; }
        public string Locale { get; set; }
    }
}
