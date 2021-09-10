namespace Watchdog.Models.Shared.Analytics.LoaderTestAnalytics
{
    public class LoaderTestAnalytics
    {
        public int TestId { get; set; }
        public int RequestId { get; set; }
        public ResponseTimes ResponseTimes { get; set; }
        public ResponseCounts ResponseCounts { get; set; }
        public Bandwidth Bandwidth { get; set; }
    }
}
