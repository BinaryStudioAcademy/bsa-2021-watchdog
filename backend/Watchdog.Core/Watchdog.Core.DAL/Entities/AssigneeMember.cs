using Watchdog.Core.DAL.Entities.Common;

namespace Watchdog.Core.DAL.Entities
{
    public class AssigneeMember : Entity<int>
    {
        public string IssueId { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }
    }
}
