using System.Collections.Generic;

namespace Watchdog.Core.Common.Models.Issue
{
    public class HttpResponseErrorMessage
    {
        public string Message { get; set; }
        public string Url { get; set; }
        public int Status { get; set; }
        public string StatusText { get; set; }
        public string HostName { get; set; }
        public string HttpMethod { get; set; }
        public string IPAddress { get; set; }
        public Dictionary<string, string> QueryString { get; set; }
        public Dictionary<string, string> Headers { get; set; }
    }
}