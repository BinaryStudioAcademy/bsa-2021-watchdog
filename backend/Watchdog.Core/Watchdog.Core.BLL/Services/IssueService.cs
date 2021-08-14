using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nest;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.DTO.Issue;
using Watchdog.Core.Common.Models.Issue;

namespace Watchdog.Core.BLL.Services
{
    public class IssueService : IIssueService
    {
        private readonly IElasticClient _client;
        
        public IssueService(IElasticClient client)
        {
            _client = client;
        }
        
        public async Task<ICollection<IssueMessage>> GetIssuesAsync()
        {
            var result = await _client.SearchAsync<IssueMessage>(s => s
                    .From(0)
                    .Size(200)
                    .MatchAll()
                    .Sort(sorter => sorter.Descending(issue => issue.OccurredOn))
            );
            
            return result.Documents.ToList();
        }

        public async Task<ICollection<IssueInfo>> GetIssuesInfoAsync()
        {
            var issues = await GetIssuesAsync();

            var issuesInfo = issues
                .GroupBy(issue => issue.IssueDetails.ClassName)
                .Select((grouped) => new IssueInfo()
                {
                    ClassName = grouped.Key,
                    Events = issues.Count(i => i.IssueDetails.ClassName == grouped.Key)
                })
                .OrderByDescending(i => i.Events)
                .ToList();
            
            return issuesInfo;
        }
    }
}