namespace Watchdog.Core.DAL.Entities.AlertSettings
{
    public class SpecialAlertSetting
    {
        public int AlertsCount { get; set; }
        public SpecialAlertType SpecialAlertType { get; set; }
        public AlertTimeInterval AlertTimeInterval { get; set; }
    }
}