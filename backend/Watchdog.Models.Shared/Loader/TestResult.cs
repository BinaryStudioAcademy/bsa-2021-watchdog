using System;
using System.Net;

namespace Watchdog.Models.Shared.Loader
{
    public class TestResult
    {
        public string Id { get; set; }
        public int RequestId { get; set; }
        public int TestId { get; set; }
        public TimeSpan ResponseTime { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public bool IsFailed { get; set; } // if exception was catch
        public long SentSize { get; set; } // in bytes
        public long ReceivedSize { get; set; } // in bytes
    }
}

