using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nest;
using Watchdog.Core.BLL.Services.Abstract;
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
    }
}