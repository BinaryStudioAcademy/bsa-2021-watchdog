using Watchdog.Core.Common.DTO.LoaderTest.LoadTestSetting;

namespace Watchdog.Core.Common.DTO.LoaderTest.Request
{
    public class NewLoaderRequestDto
    {
        public TestMethod Method { get; set; }
        public TestProtocol Protocol { get; set; }
        public string Host { get; set; }
        public string Path { get; set; }
        public string Body { get; set; }
        public string Headers { get; set; }
        public string Parameters { get; set; }
    }
}
