using AutoMapper;
using Watchdog.Core.Common.DTO.Application;
using Watchdog.Core.Common.DTO.Application.AlertSettings;
using Watchdog.Core.DAL.Entities;
using Watchdog.Core.DAL.Entities.AlertSettings;

namespace Watchdog.Core.BLL.MappingProfiles
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Application, ApplicationDto>();
            CreateMap<NewApplicationDto, Application>();

            CreateMap<SpecialAlertSettingDto, SpecialAlertSetting>();
            CreateMap<AlertSettingsDto, AlertSetting>()
                .ForMember(s => s.SpecialAlertSetting, conf => conf.MapFrom(
                    s => s.AlertCategory == Common.DTO.Application.AlertSettings.AlertCategory.Special 
                    ? s.SpecialAlertSetting 
                    : null));
        }
    }
}
