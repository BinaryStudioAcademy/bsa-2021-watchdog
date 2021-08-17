using System.Threading.Tasks;
using Watchdog.Notifier.Common.Models.Issue;

namespace Watchdog.Notifier.BLL.Hubs.Interfaces
{
    public interface IIssuesHubClient
    {
        Task SendIssue(IssueMessage message);
        Task AddToGroup(int[] projects);
    }
}
