using System;
using System.Collections.Generic;
using Watchdog.Core.Common.Models.Issue;

namespace Watchdog.Core.Common.DTO.Issue
{
    public class IssueDto
    {
        public string ErrorMessage { get; set; }
        public string ErrorClass { get; set; }
        public int EventsCount { get; set; }
        public ICollection<IssueMessage> Events { get; set; }
        public DateTime Newest { get; set; }
        public DateTime Oldest { get; set; }
    }
}