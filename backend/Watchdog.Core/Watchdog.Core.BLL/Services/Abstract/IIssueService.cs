﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Watchdog.Core.Common.Models.Issue;

namespace Watchdog.Core.BLL.Services.Abstract
{
    public interface IIssueService
    {
        Task<ICollection<IssueMessage>> GetIssuesAsync();
    }
}