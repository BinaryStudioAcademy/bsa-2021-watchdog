namespace Watchdog.Core.Common.DTO.Dashboard
{
    public class NewDashboardDto
    {
        public string Name { get; set; }
        public string Icon { get; set; }

        public int OrganizationId { get; set; }
        public int CreatedBy { get; set; }
    }
}
