using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watchdog.Core.Common.DTO.Members;

namespace Watchdog.Core.Common.Validators.Members
{
    public class NewMemberDtoValidator : AbstractValidator<NewMemberDto>
    {
        public NewMemberDtoValidator()
        {
            RuleFor(m => m.OrganizationId)
                        .NotNull();
            RuleFor(m => m.RoleId)
                        .NotNull();
            RuleFor(m => m.Email)
                        .EmailAddress()
                        .MinimumLength(5)
                        .MaximumLength(30);
            RuleFor(m => m.TeamId)
                        .NotNull();
        }
    }
}
