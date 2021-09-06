using System.Threading.Tasks;
using Watchdog.Collector.Common.DTO.Issue;
using Watchdog.Common.Messages;
using Watchdog.Models.Shared.Analytics;

namespace Watchdog.Collector.BLL.Services.Abstract
{
    public interface IElasticWriteService
    {
        Task AddIssueMessageAsync(IssueMessageDto message);

        Task AddIssueAsync(WatchdogMessage message);

        Task AddProjectCountryInfoAsync(CountryInfo countryInfo);
    }
}