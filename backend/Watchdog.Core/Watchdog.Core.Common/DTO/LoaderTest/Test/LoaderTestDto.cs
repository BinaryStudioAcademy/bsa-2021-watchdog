using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Watchdog.Core.Common.DTO.Application;
using Watchdog.Core.Common.DTO.LoaderTest.LoadTestSetting;
using Watchdog.Core.Common.DTO.LoaderTest.Request;

namespace Watchdog.Core.Common.DTO.LoaderTest.Test
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
        [JsonProperty("project")]
        public ApplicationDto Application { get; set; }
        public int OrganizationId { get; set; }
        public ICollection<LoaderRequestDto> Requests { get; set; }
    }
}
