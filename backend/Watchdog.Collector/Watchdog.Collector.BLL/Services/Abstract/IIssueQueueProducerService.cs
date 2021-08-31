using Watchdog.Models.Shared.Issues;

namespace Watchdog.Collector.BLL.Services.Abstract
{
    public interface IIssueQueueProducerService
    {
        void ProduceMessage(IssueMessage message);
    }
}
