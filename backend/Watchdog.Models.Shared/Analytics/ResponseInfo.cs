using System;

namespace Watchdog.Models.Shared.Analytics
{
    public class ResponseInfo
    {
        public DateTime Date { get; set; }
        public int Time { get; set; }
        public string Url { get; set; }
        public int Status { get; set; }
        public string StatusText { get; set; }
        public double Size { get; set;  }
        public string ProjectKey { get; set; }
    }
}