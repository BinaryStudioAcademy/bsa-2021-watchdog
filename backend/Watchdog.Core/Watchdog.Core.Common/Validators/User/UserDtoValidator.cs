using FluentValidation;
using System;
using Watchdog.Core.Common.DTO.User;

namespace Watchdog.Core.Common.Validators.User
{
    public class UserDtoValidator : AbstractValidator<UserDto>
    {
        public string Uid { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string AvatarUrl { get; set; }

        public DateTime RegisteredAt { get; set; }

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
