using Watchdog.Models.Shared.Loader;

namespace Watchdog.Core.BLL.Services.Abstract
{
    public interface INotifyLoaderQueueProducerService
    {
        void SendMessage(LoaderMessage message);
    }
}
