using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watchdog.Core.Common.DTO.Organization
{
    public class SettingsOrganizationDto
    {
        public string OrganizationSlug { get; set; }
        public string Name { get; set; }
        public bool? OpenMembership { get; set; }
        public int? DefaultRoleId { get; set; }
    }
}
