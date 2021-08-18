using System.Threading.Tasks;
using Watchdog.Collector.Common.DTO.Issue;

namespace Watchdog.Collector.BLL.Services.Abstract
{
    public interface IElasticWriteService
    {
        Task AddIssueMessageAsync(IssueMessageDto message);
    }
}