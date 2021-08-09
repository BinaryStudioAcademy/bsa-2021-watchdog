using AutoMapper;
using Watchdog.Core.Common.DTO.User;
using Watchdog.Core.DAL.Entities;

namespace Watchdog.Core.BLL.MappingProfiles
{
    public sealed class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();

            CreateMap<NewUserDto, User>();
        }
    }
}
