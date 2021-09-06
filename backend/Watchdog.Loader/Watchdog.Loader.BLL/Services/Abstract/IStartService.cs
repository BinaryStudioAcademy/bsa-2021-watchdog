using System.Threading.Tasks;
using Watchdog.Models.Shared.Loader;

namespace Watchdog.Loader.BLL.Services.Abstract
{
    public interface IStartService
    {
        Task StartTestAsync(LoaderMessage message);
    }
}
