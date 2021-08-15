using System;

namespace Watchdog.Core.Common.DTO.Issue
{
    public class IssueInfoDto
    {
        public string ErrorMessage { get; set; }
        public string ErrorClass { get; set; }
        public int EventsCount { get; set; }
        public DateTime Newest { get; set; }
        public DateTime Oldest { get; set; }
    }
}