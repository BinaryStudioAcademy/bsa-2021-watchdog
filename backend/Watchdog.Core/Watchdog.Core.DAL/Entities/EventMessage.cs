using System;

namespace Watchdog.Core.DAL.Entities
{
    public class EventMessage
    {
        public int Id { get; set; }
        public string EventId { get; set; }
        public int IssueId { get; set; }
        public Issue Issue { get; set; }
        public DateTime OccurredOn { get; set; }
    }
}