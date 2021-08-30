using System.Collections.Generic;
using Watchdog.Core.Common.Enums.Issues;

namespace Watchdog.Core.Common.DTO.Issue
{
    public class IssueStatusesFilterDto
    {
        public ICollection<IssueStatus> IssueStatuses { get; set; }
    }
}