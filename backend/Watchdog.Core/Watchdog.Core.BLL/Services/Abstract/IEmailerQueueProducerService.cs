using System.Collections.Generic;
using Watchdog.Models.Shared.Emailer;
using Watchdog.Models.Shared.Emailer.TemplateData;

namespace Watchdog.Core.BLL.Services.Abstract
{
    public interface IEmailerQueueProducerService
    {
        void SendAlert(IssueTemplate issueTemplate, ICollection<Recipient> recipients);
        void SendMemberInvitation(MemberTemplate userTemplate, ICollection<Recipient> recipients);
    }
}
