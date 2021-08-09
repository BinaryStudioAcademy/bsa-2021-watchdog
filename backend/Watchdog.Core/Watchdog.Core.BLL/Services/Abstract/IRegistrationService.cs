using System;
using System.Threading.Tasks;
using Watchdog.Core.Common.DTO.Registration;

namespace Watchdog.Core.BLL.Services.Abstract
{
    public interface IRegistrationService
    {
        Task<DateTime> FullRegistrationAsync(FullRegistrationDto fullRegistrationDto);
        Task<DateTime> PartialRegistrationAsync(PartialRegistrationDto partialRegistrationDto);
    }
}
