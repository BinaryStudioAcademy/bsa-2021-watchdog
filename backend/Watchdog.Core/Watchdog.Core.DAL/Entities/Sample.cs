using Watchdog.Core.DAL.Entities.Common;

namespace Watchdog.Core.DAL.Entities
{
    public class Sample : AuditEntity<int>
    {
        public string Title { get; set; }

        public string Body { get; set; }
    }
}
