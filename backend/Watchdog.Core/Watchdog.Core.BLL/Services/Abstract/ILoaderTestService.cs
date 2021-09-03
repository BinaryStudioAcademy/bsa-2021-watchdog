using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Watchdog.Core.Common.DTO.LoaderTest;

namespace Watchdog.Core.BLL.Services.Abstract
{
    public interface ILoaderTestService
    {
        Task<LoaderTestDto> AddNewLoaderTestAsync(NewLoaderTestDto dto);
        Task<ICollection<LoaderTestDto>> GetLoaderTestsByOrganizationIdAsync(int organizationId);
        Task<LoaderTestDto> GetLoaderTestById(int id);
        Task<LoaderTestDto> UpdateLoaderTestAsync(UpdateLoaderTestDto dto);
    }
}
