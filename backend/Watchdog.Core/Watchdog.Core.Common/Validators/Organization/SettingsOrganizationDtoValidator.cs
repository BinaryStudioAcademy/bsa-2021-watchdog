using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watchdog.Core.Common.DTO.Organization;

namespace Watchdog.Core.Common.Validators.Organization
{
    class SettingsOrganizationDtoValidator : AbstractValidator<SettingsOrganizationDto>
    {
        public SettingsOrganizationDtoValidator()
        {
            RuleFor(o => o.Name)
                .MinimumLength(3)
                .MaximumLength(50)
                .Matches(@"^[\w\s-!#$%&'*+—/=?^`{|}~]+$");

            RuleFor(o => o.OrganizationSlug)
                .MinimumLength(3)
                .MaximumLength(50)
                .Matches(@"^[\w\-]+$");
        }
    }
}
