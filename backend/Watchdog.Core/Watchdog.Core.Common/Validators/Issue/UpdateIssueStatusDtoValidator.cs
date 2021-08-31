using FluentValidation;
using Watchdog.Core.Common.DTO.Issue;

namespace Watchdog.Core.Common.Validators.Issue
{
    public class UpdateIssueStatusDtoValidator : AbstractValidator<UpdateIssueStatusDto>
    {
        public UpdateIssueStatusDtoValidator()
        {
            RuleFor(dto => dto.IssueId)
                .NotEmpty();

            RuleFor(dto => dto.Status)
                .IsInEnum();
        }
    }
}