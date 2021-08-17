using System.Threading.Tasks;
using Watchdog.Collector.Common.Models;

namespace Watchdog.Collector.BLL.Services.Abstract
{
    public interface IElasticWriteService
    {
        Task AddIssueAsync(IssueMessage message);
    }
}