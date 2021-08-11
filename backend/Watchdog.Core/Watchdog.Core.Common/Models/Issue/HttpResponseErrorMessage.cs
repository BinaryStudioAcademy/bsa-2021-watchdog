namespace Watchdog.Core.Common.Models.Issue
{
    public class HttpResponseErrorMessage
    {
        public string Message { get; set; }
        public string Url { get; set; }
        public int Status { get; set; }
        public string StatusText { get; set; }
    }
}