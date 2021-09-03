using System;
using System.Collections.Generic;
using Watchdog.Core.DAL.Entities.Common;
using Watchdog.Core.DAL.Entities.LoadTestSetting;

namespace Watchdog.Core.DAL.Entities
{
    public class LoaderTest: Entity<int>
    {
        public LoaderTest()
        {
            Requests = new List<LoaderRequest>();
        }
        public string Name { get; set; }
        public TestType Type { get; set; }
        public int Clients { get; set; }
        public TimeSpan Duration { get; set; }
        public int? ApplicationId { get; set; }
        public Application Application { get; set; }
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }
        public ICollection<LoaderRequest> Requests { get; set; }
    }
}
