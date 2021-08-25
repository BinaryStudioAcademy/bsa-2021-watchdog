using System.Collections.Generic;
using System.Threading.Tasks;
using Watchdog.Core.Common.DTO.User;

namespace Watchdog.Core.BLL.Services.Abstract
{
    public interface IUserService
    {
        Task<UserDto> UpdateUserAsync(int userId, UpdateUserDto updateUserDto);

        Task<UserDto> GetUserByIdAsync(int id);

        Task<UserDto> GetUserByUidAsync(string uid);

        Task<UserDto> CreateUserAsync(NewUserDto userDto);

        Task<IEnumerable<UserDto>> SearchMembersNotInOrganizationAsync(int orgId, int count, string memberEmail);

        Task<bool> IsUserEmailValid(string userEmail);
        
        Task<ICollection<string>> GetUserUIdsByApplicationIdAsync(int applicationId);
    }
}
