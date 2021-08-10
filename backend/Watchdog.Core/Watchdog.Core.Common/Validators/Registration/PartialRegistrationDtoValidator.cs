using FluentValidation;
using Watchdog.Core.Common.DTO.Registration;

namespace Watchdog.Core.Common.Validators.Registration
{
    public class PartialRegistrationDtoValidator : AbstractValidator<PartialRegistrationDto>
    {
        public PartialRegistrationDtoValidator()
        {
            RuleFor(x => x.Organization.Name)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(50)
                .Matches(@"^[\w\s-!#$%&'*+—/=?^`{|}~]+$");

            RuleFor(x => x.Organization.OrganizationSlug)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(50)
                .Matches(@"^[\w\-]+$");

            RuleFor(x => x.Organization.DefaultRoleId)
                .NotEmpty();

            RuleFor(x => x.Organization.OpenMembership)
                .NotEmpty();

            RuleFor(x => x.UserId)
                .NotEmpty();
        }
    }
}
