using System.Threading.Tasks;

namespace Watchdog.Notifier.BLL.Hubs.Interfaces
{
    public interface IBroadcastHubClient
    {
        Task BroadcastMessage(string msg);
    }
}
