using System;
using Watchdog.Core.DAL.Entities.Common;

namespace Watchdog.Core.DAL.Entities
{
    public class EventMessage : Entity<int>
    {
        public string EventId { get; set; }
        public Issue IssueLast { get; set; } // for relation for newest event
        public int IssueId { get; set; }
        public Issue Issue { get; set; }
        public DateTime OccurredOn { get; set; }
    }
}