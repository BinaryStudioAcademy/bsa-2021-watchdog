using AutoMapper;
using Watchdog.Core.DAL.Entities.AlertSettings;
using Watchdog.Core.Common.DTO.Application.AlertSettings;

namespace Watchdog.Core.BLL.MappingProfiles
{
    class AlertProfile : Profile
    {
        public AlertProfile()
        {
            CreateMap<AlertSetting, AlertSettingsDto>();
            CreateMap<SpecialAlertSetting, SpecialAlertSettingDto>();
        }
    }
}
