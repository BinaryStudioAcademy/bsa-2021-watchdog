using Watchdog.Notifier.Common.Models;

namespace Watchdog.Notifier.Common.DTO
{
    public class IssueQueueMessageDto
    {
        public IssueMessage Issue { get; set; }
        public int[] MembersIds { get; set; }
    }
}
