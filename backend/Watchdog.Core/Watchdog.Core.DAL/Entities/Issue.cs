using System.Collections.Generic;

namespace Watchdog.Core.DAL.Entities
{
    public class Issue
    {
        public int Id { get; set; }
        public string ErrorClass { get; set; }
        public string ErrorMessage { get; set; }
        public ICollection<EventMessage> EventMessages { get; set; }
    }
}