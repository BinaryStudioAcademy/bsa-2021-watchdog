using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watchdog.Core.Common.DTO.Members;

namespace Watchdog.Core.Common.Validators.Members
{
    public class UpdateMemberDtoValidator : AbstractValidator<UpdateMemberDto>
    {
        public UpdateMemberDtoValidator() 
        {
            RuleFor(m => m.Id)
                        .NotNull();
            RuleFor(m => m.RoleId)
                        .NotNull();
            RuleFor(m => m.TeamId)
                        .NotNull();
        }
    }
}
