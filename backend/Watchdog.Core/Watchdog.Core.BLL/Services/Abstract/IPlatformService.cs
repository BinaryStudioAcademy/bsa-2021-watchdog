using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watchdog.Core.Common.DTO.Platform;

namespace Watchdog.Core.BLL.Services.Abstract
{
    public interface IPlatformService
    {
        Task<IEnumerable<PlatformDto>> GetAllPlatformsAsync();
        Task<IEnumerable<string>> GetAllPlatformTypeNames();

    }
}
