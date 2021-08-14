using Watchdog.Core.DAL.Entities.Common;

namespace Watchdog.Core.DAL.Entities
{
    public class TeamMember : Entity<int>
    {
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public int MemberId { get; set; }

        public Member Member { get; set; }
    }
}
