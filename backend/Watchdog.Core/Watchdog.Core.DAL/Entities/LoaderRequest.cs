using Watchdog.Core.DAL.Entities.Common;
using Watchdog.Core.DAL.Entities.LoadTestSetting;

namespace Watchdog.Core.DAL.Entities
{
    public class LoaderRequest : Entity<int>
    {
        public TestMethod Method { get; set; }
        public TestProtocol Protocol { get; set; }
        public string Host { get; set; }
        public string Path { get; set; }
        public string Body { get; set; }
        public string Headers { get; set; }
        public string Parameters { get; set; }
        public int TestId { get; set; }
        public LoaderTest Test { get; set; }
    }
}
