using System;

namespace Watchdog.Core.Common.DTO.Issue
{
    public class TopActiveIssuesFilter
    {
        public int[] ProjectIds { get; set; }
        public DateTime Date { get; set; }
        public int Items { get; set; }

    }
}
