using AutoMapper;
using Watchdog.Core.Common.DTO.Organization;
using Watchdog.Core.DAL.Entities;

namespace Watchdog.Core.BLL.MappingProfiles
{
    public class OrganizationProfile : Profile
    {
        public OrganizationProfile()
        {
            CreateMap<Organization, OrganizationDto>();

            CreateMap<OrganizationDto, Organization>();
            CreateMap<NewOrganizationDto, Organization>();

            CreateMap<RegOrganizationDto, Organization>();
            CreateMap<Organization, RegOrganizationDto>();

            CreateMap<SettingsOrganizationDto, Organization>()
                .ForMember(m => m.OpenMembership, o => o.Condition(s => s.OpenMembership != null))
                .ForMember(m => m.DefaultRoleId, o => o.Condition(s => s.DefaultRoleId != null))
                .ForMember(m => m.OrganizationSlug, o => o.Condition(s => s.OrganizationSlug != null))
                .ForMember(m => m.Name, o => o.Condition(s => s.Name != null));
        }
    }
}
