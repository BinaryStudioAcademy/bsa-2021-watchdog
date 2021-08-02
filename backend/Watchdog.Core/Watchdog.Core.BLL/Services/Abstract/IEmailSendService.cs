using SendGrid;
using System.Threading.Tasks;
using Watchdog.Core.BLL.Models;

namespace Watchdog.Core.BLL.Services.Abstract
{
    public interface IEmailSendService
    {
        public Task<Response> SendAsync(string recipientEmail, ExampleTemplateData data);
    }
}
