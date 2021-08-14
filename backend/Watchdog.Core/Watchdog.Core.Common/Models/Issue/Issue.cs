using System;
using System.Collections.Generic;

namespace Watchdog.Core.Common.Models.Issue
{
    public class Issue
    {
        public string ErrorMessage { get; set; }
        public string ErrorClass { get; set; }
        public int EventCount { get; set; }
        public ICollection<IssueMessage> Events { get; set; }
        public DateTime Newest { get; set; }
        public DateTime Oldest { get; set; }
    }
}