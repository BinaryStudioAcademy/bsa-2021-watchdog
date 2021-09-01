using System.Collections.Generic;
using System.Threading.Tasks;
using Watchdog.Core.Common.DTO.Avatar;
using Watchdog.Core.Common.DTO.Organization;

namespace Watchdog.Core.BLL.Services.Abstract
{
    public interface IOrganizationService
    {
        Task<OrganizationDto> GetOrganizationAsync(int organizationId);
        Task<OrganizationDto> GetDafaultOrganizationByUserIdAsync(int userId);
        Task<ICollection<OrganizationDto>> GetAllOrganizationsAsync();
        Task<OrganizationDto> CreateOrganizationAsync(NewOrganizationDto organizationDto);
        Task<OrganizationDto> UpdateOrganizationAsync(int organizationId, NewOrganizationDto organizationDto);
        Task<OrganizationDto> UpdateSettingsAsync(int organizationId, SettingsOrganizationDto settingsDto);
        Task DeleteOrganizationAsync(int organizationId);
        Task<ICollection<OrganizationDto>> GetUserOrganizationsAsync(int userId);
        Task<bool> IsOrganizationSlugValid(string organizationSlug);
        Task<OrganizationDto> UpdateOrganizationAvatarAsync(AvatarDto data);
    }
}
