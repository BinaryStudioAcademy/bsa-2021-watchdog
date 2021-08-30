using System.Collections.Generic;
using Watchdog.Core.Common.Models.Issue;

namespace Watchdog.Core.BLL.Services.Abstract
{
    public interface INotifyQueueProducerService
    {
        void NotifyUsers(ICollection<int> membersIds, IssueMessage message);
    }
}
