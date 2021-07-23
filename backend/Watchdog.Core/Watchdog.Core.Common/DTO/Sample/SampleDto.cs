using System;

namespace Watchdog.Core.Common.DTO.Sample
{
    public class SampleDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
