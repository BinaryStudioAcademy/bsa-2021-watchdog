using System.Collections.Generic;
using Watchdog.Models.Shared.Issues;

namespace Watchdog.Core.BLL.Services.Abstract
{
    public interface INotifyQueueProducerService
    {
        void NotifyUsers(ICollection<int> membersIds, IssueMessage message);
    }
}
