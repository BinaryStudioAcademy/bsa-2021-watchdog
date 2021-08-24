using System.Threading.Tasks;
using Watchdog.Collector.Common.DTO.Issue;
using Watchdog.NetCore.Common.Messages;

namespace Watchdog.Collector.BLL.Services.Abstract
{
    public interface IElasticWriteService
    {
        Task AddIssueMessageAsync(IssueMessageDto message);

        Task AddIssueAsync(WatchdogMessage message);
    }
}