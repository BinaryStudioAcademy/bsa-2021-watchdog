using System;
using System.Net;

namespace Watchdog.Core.Common.DTO.LoaderTest.Result
{
    public class LoaderTestResultDto
    {
        public string Id { get; set; }
        public int RequestId { get; set; }
        public int TestId { get; set; }
        public TimeSpan ResponseTime { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public bool IsFailed { get; set; }
        public long SentSize { get; set; }
        public long ReceivedSize { get; set; }
    }
}
