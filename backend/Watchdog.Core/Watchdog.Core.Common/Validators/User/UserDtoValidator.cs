using FluentValidation;
using Watchdog.Core.Common.DTO.User;

namespace Watchdog.Core.Common.Validators.User
{
    public class UserDtoValidator : AbstractValidator<UserDto>
    {
        public UserDtoValidator()
        {
            RuleFor(x => x.Uid)
                .NotEmpty();

            RuleFor(x => x.FirstName)
                .MinimumLength(2)
                .MaximumLength(20)
                .Matches("^[a-zA-Z-]*$");

            RuleFor(x => x.LastName)
                .MinimumLength(2)
                .MaximumLength(20)
                .Matches("[a-zA-Z- ]*$");


            RuleFor(x => x.Email)
                .NotEmpty()
                .MinimumLength(5)
                .Matches(@"^(([^<>()[\]\\.,;:\s@""]+(\.[^<>()[\]\\.,;:\s@""]+)*)|("".+""))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$");

        }
    }
}
