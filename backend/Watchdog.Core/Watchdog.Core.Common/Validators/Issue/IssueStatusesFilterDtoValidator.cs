using FluentValidation;
using Watchdog.Core.Common.DTO.Issue;

namespace Watchdog.Core.Common.Validators.Issue
{
    public class IssueStatusesFilterDtoValidator : AbstractValidator<IssueStatusesFilterDto>
    {
        public IssueStatusesFilterDtoValidator()
        {
            RuleForEach(dto => dto.IssueStatuses)
                .IsInEnum();
        }
    }
}