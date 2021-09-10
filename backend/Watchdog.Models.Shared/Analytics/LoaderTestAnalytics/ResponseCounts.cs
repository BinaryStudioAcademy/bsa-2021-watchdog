namespace Watchdog.Models.Shared.Analytics.LoaderTestAnalytics
{
    public class ResponseCounts
    {
        public int Information { get; set; } // 1xx codes
        public int Success { get; set; } // 2xx 
        public int Redirection { get; set; } // 3xx 
        public int ClientError { get; set; } // 4xx 
        public int ServerError { get; set; } // 5xx 
        public int RequestFailed { get; set; } // isFailed count
    }
}
