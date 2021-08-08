using System.Threading.Tasks;
using Watchdog.Core.Common.DTO.User;

namespace Watchdog.Core.BLL.Services.Abstract
{
    public interface IUserService
    {
        Task<UserDto> GetUserByUidAsync(string uid);
        
        Task<UserDto> CreateUserAsync(UserDto userDto);
    }
}
