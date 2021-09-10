using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Watchdog.Core.Common.DTO.LoaderTest.LoadTestSetting;
using Watchdog.Core.Common.DTO.LoaderTest.Request;

namespace Watchdog.Core.Common.DTO.LoaderTest.Test
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
