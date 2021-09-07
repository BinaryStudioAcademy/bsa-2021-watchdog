using System;
using Watchdog.Core.Common.DTO.Application;

namespace Watchdog.Core.Common.DTO.Analytics
{
    public class ResponseInfoDto
    {
        public DateTime Date { get; set; }
        public int Time { get; set; }
        public string Url { get; set; }
        public int Status { get; set; }
        public string StatusText { get; set; }
        public double Size { get; set;  }
        public ApplicationDto Project { get; set; }
        public string ProjectKey { get; set; }
    }
}