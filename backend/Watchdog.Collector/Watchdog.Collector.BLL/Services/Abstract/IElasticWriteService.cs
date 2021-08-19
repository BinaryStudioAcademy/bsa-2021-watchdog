using System.Threading.Tasks;
using Watchdog.Collector.Common.Models;
using Watchdog.NetCore.Common.Messages;

namespace Watchdog.Collector.BLL.Services.Abstract
{
    public interface IElasticWriteService
    {
        Task AddIssueAsync(IssueMessage message);

        Task AddIssueAsync(WatchdogMessage message);
    }
}