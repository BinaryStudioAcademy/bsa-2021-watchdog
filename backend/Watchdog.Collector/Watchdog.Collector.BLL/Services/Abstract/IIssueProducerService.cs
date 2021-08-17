using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watchdog.Collector.Common.Models;

namespace Watchdog.Collector.BLL.Services.Abstract
{
    public interface IIssueProducerService
    {
        void ProduceMessage(IssueMessage message);
    }
}
