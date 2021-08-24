using Microsoft.AspNetCore.SignalR;
using Watchdog.Notifier.BLL.Hubs.Interfaces;

namespace Watchdog.Notifier.BLL.Hubs
{
    public class BroadcastHub : Hub<IBroadcastHubClient>
    {
    }
}
