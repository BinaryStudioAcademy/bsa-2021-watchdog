using System;
using System.Collections.Generic;
using Watchdog.Models.Shared.Loader.LoadTestSetting;

namespace Watchdog.Models.Shared.Loader
{
    public class LoaderMessage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TestType Type { get; set; }
        public int Clients { get; set; }
        public TimeSpan Duration { get; set; }
        public int? ApplicationId { get; set; }
        public int OrganizationId { get; set; }
        public ICollection<Request> Requests { get; set; }
    }
}
