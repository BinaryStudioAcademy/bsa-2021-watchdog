using FluentValidation;
using Watchdog.Core.Common.DTO.Organization;
using Watchdog.Core.Common.DTO.Sample;

namespace Watchdog.Core.Common.Validators.Sample
{
    public class NewOrganizationDtoValidator : AbstractValidator<NewOrganizationDto>
    {
        public NewOrganizationDtoValidator()
        {
            RuleFor(o => o.Name)
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(50)
                .Matches(@"^[\w\s-!#$%&'*+—/=?^`{|}~]+$");

            RuleFor(o => o.OrganizationSlug)
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(50)
                .Matches(@"^[\w\-]+$");

            RuleFor(o => o.DefaultRoleId)
                .NotEmpty();

            RuleFor(o => o.CreatedBy).NotEmpty();
        }
    }
}
