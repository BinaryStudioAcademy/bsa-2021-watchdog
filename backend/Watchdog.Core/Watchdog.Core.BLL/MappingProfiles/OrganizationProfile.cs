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

            CreateMap<SettingsOrganizationDto, Organization>();
        }
    }
}
