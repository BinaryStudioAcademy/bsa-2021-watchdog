using Watchdog.Core.BLL.Services.Abstract;

namespace Watchdog.Core.BLL.Services
{
    public class EmailSendService : IEmailSendService
    {
        private readonly string _key;

        public EmailSendService(string key)
        {
            _key = key;
        }
        public string Test()
        {
            return _key;
        }
    }
}
