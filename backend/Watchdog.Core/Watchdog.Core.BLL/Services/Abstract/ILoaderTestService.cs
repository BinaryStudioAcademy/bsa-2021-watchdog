using System.Collections.Generic;
using System.Threading.Tasks;
using Watchdog.Core.Common.DTO.LoaderTest.Analytics;
using Watchdog.Core.Common.DTO.LoaderTest.Test;

namespace Watchdog.Core.BLL.Services.Abstract
{
    public interface ILoaderTestService
    {
        Task<LoaderTestDto> AddNewLoaderTestAsync(NewLoaderTestDto dto, bool start);
        Task<ICollection<LoaderTestDto>> GetLoaderTestsByOrganizationIdAsync(int organizationId);
        Task<LoaderTestDto> GetLoaderTestById(int id);
        Task<LoaderTestDto> UpdateLoaderTestAsync(UpdateLoaderTestDto dto, bool start);
        Task StartTestAsync(int testId);
        Task<ICollection<LoaderTestAnalyticsDto>> GetLoaderTestResultsAnalyticsByTestIdAsync(int testId);
        Task<LoaderTestAnalyticsDto> GetLoaderTestResultsAnalyticsByRequestIdAsync(int requestId);
        Task DeleteLoaderTestByIdAsync(int id);
    }
}
