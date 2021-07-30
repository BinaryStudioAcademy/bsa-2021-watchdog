using System.Collections.Generic;
using Watchdog.Core.DAL.Entities.Common;

namespace Watchdog.Core.DAL.Entities
{
    public class Role : Entity<int>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Member> Members { get; set; }
    }
}
