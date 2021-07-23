using Microsoft.AspNetCore.SignalR;
using Watchdog.Notifier.Hubs.Interfaces;

namespace Watchdog.Notifier.Hubs
{
    public class BroadcastHub : Hub<IBroadcastHubClient>
    {
    }
}
