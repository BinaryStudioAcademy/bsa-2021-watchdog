using System;
using Watchdog.Notifier.Common.Models.Issue;

namespace Watchdog.Notifier.BLL.Services.Abstract
{
    public interface IIssueConsumerService
    {
        void Connect(EventHandler<IssueMessage> received);

    }
}
