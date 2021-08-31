using System;

namespace Watchdog.Models.Shared.Issues
{
    public class Breadcrumb
    {
        public string Type { get; set; }
        public string Category { get; set; }
        public string Level { get; set; }
        public DateTime Time { get; set; }
        public string Body { get; set; }
    }
}
