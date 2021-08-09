using System.Collections.Generic;
using System.Threading.Tasks;
using Watchdog.Core.Common.DTO.Application;

namespace Watchdog.Core.BLL.Services.Abstract
{
    public interface IApplicationService
    {
        Task<IEnumerable<ApplicationDto>> GetApplicationsByApplicationIdAsync(int id);

        Task<ApplicationDto> CreateApplicationAsync(NewApplicationDto dto);
    }
}
