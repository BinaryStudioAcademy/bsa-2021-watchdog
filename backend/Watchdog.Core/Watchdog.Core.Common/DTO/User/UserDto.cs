using System;

namespace Watchdog.Core.Common.DTO.User
{
    public class UserDto
    {
        public string Uid { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string AvatarUrl { get; set; }

        public DateTime RegisteredAt { get; set; }
    }
}
