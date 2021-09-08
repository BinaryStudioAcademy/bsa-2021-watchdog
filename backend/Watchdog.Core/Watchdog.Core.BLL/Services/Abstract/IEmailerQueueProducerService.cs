using System.Collections.Generic;
using Watchdog.Models.Shared.Emailer;
using Watchdog.Models.Shared.Issues;

namespace Watchdog.Core.BLL.Services.Abstract
{
    public interface IEmailerQueueProducerService
    {
        void SendAlert(IssueMessage issueMessage, ICollection<Recipient> recipients);
        void SendMemberInvitation(IssueMessage issueMessage, ICollection<Recipient> recipients);
    }
}
