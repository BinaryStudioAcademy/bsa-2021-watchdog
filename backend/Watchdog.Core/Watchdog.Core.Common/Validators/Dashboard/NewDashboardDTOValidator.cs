using FluentValidation;
using Watchdog.Core.Common.DTO.Dashboard;

namespace Watchdog.Core.Common.Validators.Dashboard
{
    public class NewDashboardDTOValidator : AbstractValidator<NewDashboardDto>
    {
        public NewDashboardDTOValidator()
        {
            RuleFor(d => d.Name)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(50)
                .Matches(@"^[a-zA-Z0-9_. ]*$");
            RuleFor(d => d.CreatedBy).NotEmpty();
        }
    }
}
