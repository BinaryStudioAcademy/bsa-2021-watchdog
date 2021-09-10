using System.Threading.Tasks;
using Watchdog.Core.Common.DTO.Members;
using Watchdog.Core.Common.DTO.Registration;
using Watchdog.Core.Common.DTO.User;

namespace Watchdog.Core.BLL.Services.Abstract
{
    public interface IRegistrationService
    {
        Task<UserDto> FullRegistrationAsync(FullRegistrationDto fullRegistrationDto);
        Task<UserDto> PartialRegistrationAsync(PartialRegistrationDto partialRegistrationDto);
        Task<UserDto> FullRegistrationWithJoinAsync(FullRegistrationWithJoinDto fullRegistrationWithJoinDto);
        Task<UserDto> PartialRegistrationWithJoinAsync(PartialRegistrationWithJoinDto partialRegistrationWithJoinDto);
        Task<UserDto> JoinToOrganization(JoinToOrganizationDto joinToOrganizationDto);
    }
}
