using System.Collections.Generic;
using Watchdog.Core.DAL.Entities.Common;

namespace Watchdog.Core.DAL.Entities
{
    public class Issue : Entity<int>
    {
        public Issue()
        {
            EventMessages = new List<EventMessage>();
        }

        public string ErrorClass { get; set; }
        public string ErrorMessage { get; set; }
        public Application Application { get; set; }
        public int ApplicationId { get; set; }
        public ICollection<EventMessage> EventMessages { get; set; }
    }
}