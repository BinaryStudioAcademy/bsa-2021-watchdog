namespace Watchdog.Core.Common.DTO.Application.AlertSettings
{
    public class SpecialAlertSettingDto
    {
        public int AlertsCount { get; set; }
        public SpecialAlertType SpecialAlertType { get; set; }
        public AlertTimeInterval AlertTimeInterval { get; set; }
    }
}