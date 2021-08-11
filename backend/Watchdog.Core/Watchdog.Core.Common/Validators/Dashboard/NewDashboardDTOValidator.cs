using FluentValidation;
using Watchdog.Core.Common.DTO.Dashboard;

namespace Watchdog.Core.Common.Validators.Dashboard
{
    public class NewDashboardDtoValidator : AbstractValidator<NewDashboardDto>
    {
        public NewDashboardDtoValidator()
        {
            RuleFor(d => d.Name)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(50)
                .Matches(@"^[a-zA-Z0-9-_. ]*$");
            RuleFor(d => d.CreatedBy).NotEmpty();
        }
    }
}
