using System.Collections.Generic;
using System.Threading.Tasks;
using Watchdog.Core.Common.DTO.Organization;

namespace Watchdog.Core.BLL.Services.Abstract
{
    public interface IOrganizationService
    {
        Task<OrganizationDto> GetOrganizationAsync(int organizationId);
        Task<ICollection<OrganizationDto>> GetAllOrganizationsAsync();
        Task<OrganizationDto> UpdateOrganizationAsync(int organizationId, NewOrganizationDto organizationDto);
        Task<OrganizationDto> UpdateSettingsAsync(int organizationId, SettingsOrganizationDto settingsDto);
        Task<ICollection<OrganizationDto>> GetUserOrganizationsAsync(int userId);
        Task<bool> IsOrganizationSlugValid(string organizationSlug);
    }
}
