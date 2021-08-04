namespace Watchdog.Core.Common.DTO.Dashboard
{
    public class NewDashboardDTO
    {
        public string Name { get; set; }

        public int User { get; set; }
        public string Icon { get; set; }

        public int OrganizationId { get; set; }
        public int CreatedBy { get; set; }
    }
}
