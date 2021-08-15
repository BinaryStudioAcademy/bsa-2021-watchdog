using System.Collections.Generic;
using System.Threading.Tasks;
using Watchdog.Core.Common.DTO.Issue;

namespace Watchdog.Core.BLL.Services.Abstract
{
    public interface IIssueService
    {
        Task<IssueDto> GetIssueAsync(string errorMessage);
        Task<ICollection<IssueInfoDto>> GetIssuesInfoAsync();
        Task<ICollection<TileIssueInfoDto>> GetTileIssuesInfoAsync();
    }
}