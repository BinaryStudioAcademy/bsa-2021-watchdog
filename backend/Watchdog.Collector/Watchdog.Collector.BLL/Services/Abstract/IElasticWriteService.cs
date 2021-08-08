using System.Threading.Tasks;
using Watchdog.Collector.BLL.Entities;

namespace Watchdog.Collector.BLL.Services.Abstract
{
    public interface IElasticWriteService
    {
        Task AddIssueAsync(IssueMessage message);
    }
}