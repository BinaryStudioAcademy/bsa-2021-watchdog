using System;
using System.Text.Json.Serialization;
using Watchdog.Notifier.Common.DTO;

namespace Watchdog.Notifier.Common.Models
{
    public class IssueMessage
    {
        public string Id { get; set; }
        public int IssueId { get; set; }
        public ApplicationDto Project { get; set; }
        public DateTime OccurredOn { get; set; }
        public IssueMessageDetails IssueDetails { get; set; }
    }
}