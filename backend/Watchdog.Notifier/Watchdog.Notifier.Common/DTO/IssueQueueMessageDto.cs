using Watchdog.Models.Shared.Issues;

namespace Watchdog.Notifier.Common.DTO
{
    public class IssueQueueMessageDto
    {
        public IssueMessage Issue { get; set; }
        public string[] UserUids { get; set; }
    }
}
