using FluentValidation;
using Watchdog.Core.Common.DTO.Registration;

namespace Watchdog.Core.Common.Validators.Registration
{
    public class FullRegistrationDtoValidator: AbstractValidator<FullRegistrationDto>
    {
        public FullRegistrationDtoValidator()
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

            RuleFor(x => x.User.Uid)
                .NotEmpty();

            RuleFor(x => x.User.FirstName)
                .MinimumLength(2)
                .MaximumLength(20)
                .Matches("^[a-zA-Z-]*$");

            RuleFor(x => x.User.LastName)
                .MinimumLength(2)
                .MaximumLength(20)
                .Matches("[a-zA-Z- ]*$");


            RuleFor(x => x.User.Email)
                .NotEmpty()
                .MinimumLength(5)
                .Matches(@"^(([^<>()[\]\\.,;:\s@""]+(\.[^<>()[\]\\.,;:\s@""]+)*)|("".+""))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$");

        }
    }
}
