using System;
using System.Collections.Generic;
using Watchdog.Core.Common.Enums.Issues;

namespace Watchdog.Core.Common.DTO.Issue
{
    public class IssueStatusesByDateRangeFilter
    {
        public ICollection<IssueStatus> IssueStatuses { get; set; }
        public DateTime DateRange { get; set; }
    }
}