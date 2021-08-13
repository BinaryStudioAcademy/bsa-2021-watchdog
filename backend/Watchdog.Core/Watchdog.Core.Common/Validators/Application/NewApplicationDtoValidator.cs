using FluentValidation;
using Watchdog.Core.Common.DTO.Application;
namespace Watchdog.Core.Common.Validators.Application
{
    public class NewApplicationDtoValidator : AbstractValidator<NewApplicationDto>
    {
        public NewApplicationDtoValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(50)
                .Matches("^[a-zA-Z0-9-_ ]+$");

            RuleFor(a => a.OrganizationId)
                .NotEmpty();

            RuleFor(a => a.PlatformId)
                .NotEmpty();

            RuleFor(a => a.TeamId)
                .NotEmpty();

            RuleFor(a => a.CreatedBy)
                .NotEmpty();

            RuleFor(a => a.Description)
                .MaximumLength(1000);
        }
    }
}
