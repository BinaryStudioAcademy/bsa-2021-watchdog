using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Watchdog.Core.Common.DTO.LoaderTest.LoadTestSetting;

namespace Watchdog.Core.Common.DTO.LoaderTest
{
    public class NewLoaderTestDto
    {
        public string Name { get; set; }
        public TestType Type { get; set; }
        public int Clients { get; set; }
        public TimeSpan Duration { get; set; }
        [JsonProperty("projectId")]
        public int? ApplicationId { get; set; }
        public int OrganizationId { get; set; }
        public ICollection<NewLoaderRequestDto> Requests { get; set; }
    }
}
