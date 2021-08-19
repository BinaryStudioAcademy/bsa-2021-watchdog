using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Watchdog.Notifier.BLL.Hubs.Interfaces;

namespace Watchdog.Notifier.BLL.Hubs
{
    [Authorize]
    public class IssuesHub : Hub<IIssuesHubClient>
    {

    }
}
