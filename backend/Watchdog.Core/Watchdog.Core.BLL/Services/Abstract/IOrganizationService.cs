using System.Collections.Generic;
using System.Threading.Tasks;
using Watchdog.Core.Common.DTO.Organization;

namespace Watchdog.Core.BLL.Services.Abstract
{
    public interface IOrganizationService
    {
        Task<OrganizationDto> GetOrganizationAsync(int organizationId);
        Task<IEnumerable<OrganizationDto>> GetAllOrganizationsAsync();
        Task<OrganizationDto> UpdateOrganizationAsync(int organizationId, NewOrganizationDto organizationDto);
        Task<IEnumerable<OrganizationDto>> GetUserOrganizationsAsync(int userId);
    }
}
