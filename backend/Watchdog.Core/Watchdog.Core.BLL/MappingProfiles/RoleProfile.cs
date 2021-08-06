using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watchdog.Core.Common.DTO.Role;
using Watchdog.Core.DAL.Entities;

namespace Watchdog.Core.BLL.MappingProfiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<Role, RoleDto>();
            CreateMap<RoleDto, Role>();
        }
    }
}
