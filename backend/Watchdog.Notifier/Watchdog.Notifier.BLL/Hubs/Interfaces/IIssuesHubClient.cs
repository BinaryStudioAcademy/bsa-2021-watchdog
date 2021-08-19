using System.Threading.Tasks;
using Watchdog.Notifier.Common.Models;

namespace Watchdog.Notifier.BLL.Hubs.Interfaces
{
    public interface IIssuesHubClient
    {
        Task SendIssue(IssueMessage message);
    }
}
