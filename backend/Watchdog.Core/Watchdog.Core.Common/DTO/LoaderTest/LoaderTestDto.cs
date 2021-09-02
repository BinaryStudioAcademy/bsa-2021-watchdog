using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Watchdog.Core.Common.DTO.LoaderTest.LoadTestSetting;

namespace Watchdog.Core.Common.DTO.LoaderTest
{
    public class LoaderTestDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TestType Type { get; set; }
        public int Clients { get; set; }
        public TimeSpan Duration { get; set; }
        [JsonProperty("projectId")]
        public int? ApplicationId { get; set; }
        public int OrganizationId { get; set; }
        public ICollection<LoaderRequestDto> Requests { get; set; }
    }
}
