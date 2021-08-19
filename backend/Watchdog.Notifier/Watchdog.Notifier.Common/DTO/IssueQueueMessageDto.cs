using Watchdog.Notifier.Common.Models.Issue;

namespace Watchdog.Notifier.Common.DTO
{
    public class IssueQueueMessageDto
    {
        public IssueMessage Issue { get; set; }
        public string[] UserIds { get; set; }
    }
}
