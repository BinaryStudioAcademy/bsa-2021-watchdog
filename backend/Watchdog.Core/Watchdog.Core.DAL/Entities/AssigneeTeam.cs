using Watchdog.Core.DAL.Entities.Common;

namespace Watchdog.Core.DAL.Entities
{
    public class AssigneeTeam : Entity<int>
    {
        public string IssueId { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}
