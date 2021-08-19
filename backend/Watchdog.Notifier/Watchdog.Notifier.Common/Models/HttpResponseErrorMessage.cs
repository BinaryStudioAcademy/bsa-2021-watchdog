namespace Watchdog.Notifier.Common.Models
{
    public class HttpResponseErrorMessage
    {
        public string Message { get; set; }
        public string Url { get; set; }
        public int Status { get; set; }
        public string StatusText { get; set; }
    }
}