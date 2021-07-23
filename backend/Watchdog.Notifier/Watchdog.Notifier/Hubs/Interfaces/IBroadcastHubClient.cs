using System.Threading.Tasks;

namespace Watchdog.Notifier.Hubs.Interfaces
{
    public interface IBroadcastHubClient
    {
        Task BroadcastMessage(string msg);
    }
}
