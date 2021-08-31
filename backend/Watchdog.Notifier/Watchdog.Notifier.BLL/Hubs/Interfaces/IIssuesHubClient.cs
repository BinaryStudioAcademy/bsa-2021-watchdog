using System.Threading.Tasks;
using Watchdog.Models.Shared.Issues;

namespace Watchdog.Notifier.BLL.Hubs.Interfaces
{
    public interface IIssuesHubClient
    {
        Task SendIssue(IssueMessage message);
    }
}
