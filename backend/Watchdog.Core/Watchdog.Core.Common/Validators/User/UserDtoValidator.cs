using FluentValidation;
using Watchdog.Core.Common.DTO.User;

namespace Watchdog.Core.Common.Validators.User
{
    public class UserDtoValidator : AbstractValidator<UserDto>
    {
        public UserDtoValidator()
        {
            RuleFor(u => u.Uid).NotEmpty();
            RuleFor(u => u.FirstName).NotNull();
            RuleFor(u => u.LastName).NotNull();
            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.AvatarUrl).NotNull();
        }
    }
}
