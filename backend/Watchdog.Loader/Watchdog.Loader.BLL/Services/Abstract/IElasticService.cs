using System.Threading.Tasks;
using Watchdog.Models.Shared.Loader;

namespace Watchdog.Loader.BLL.Services.Abstract
{
    public interface IElasticService
    {
        Task AddTestResultAsync(TestResult result);
        Task ClearAsync(int testId);
    }
}
