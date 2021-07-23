using FluentValidation;
using Watchdog.Core.Common.DTO.Sample;

namespace Watchdog.Core.Common.Validators.Sample
{
    public class NewSampleDtoValidator : AbstractValidator<SampleDto>
    {
        public NewSampleDtoValidator()
        {
            RuleFor(u => u.Title).NotNull().MaximumLength(30);
            RuleFor(u => u.CreatedBy).NotEmpty();
        }
    }
}
