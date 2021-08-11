using System.Threading.Tasks;
using Watchdog.Core.Common.DTO.Registration;
using Watchdog.Core.Common.DTO.User;

namespace Watchdog.Core.BLL.Services.Abstract
{
    public interface IRegistrationService
    {
        Task<UserDto> FullRegistrationAsync(FullRegistrationDto fullRegistrationDto);
        Task<UserDto> PartialRegistrationAsync(PartialRegistrationDto partialRegistrationDto);
    }
}
