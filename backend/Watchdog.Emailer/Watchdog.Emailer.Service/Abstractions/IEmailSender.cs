using SendGrid;
using System.Threading.Tasks;
using Watchdog.Models.Shared.Emailer.Abstractions;

namespace Watchdog.Emailer.Service.Abstractions
{
    public interface IEmailSender
    {
        Task<Response> SendEmail(Email email);
    }
}