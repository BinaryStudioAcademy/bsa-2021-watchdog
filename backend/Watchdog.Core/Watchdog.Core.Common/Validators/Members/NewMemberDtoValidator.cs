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
                        .NotEmpty();
            RuleFor(m => m.RoleId)
                        .NotEmpty();
            RuleFor(m => m.UserId)
                        .NotEmpty();
        }
    }
}
