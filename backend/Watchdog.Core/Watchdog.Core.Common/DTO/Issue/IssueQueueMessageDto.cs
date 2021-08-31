using System.Collections.Generic;
using Watchdog.Core.Common.Models.Issue;

namespace Watchdog.Core.Common.DTO.Issue
{
    public class IssueQueueMessageDto
    {
        public IssueMessage Issue { get; set; }
        public ICollection<int> MembersIds { get; set; }
    }
}
