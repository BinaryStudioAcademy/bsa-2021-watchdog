using System;
using System.Collections.Generic;
using Watchdog.Core.DAL.Entities.Common;

namespace Watchdog.Core.DAL.Entities
{
    public class User : Entity<int>
    {
        public User()
        {
            Members = new List<Member>();
            CreatedMembers = new List<Member>();
            Organizations = new List<Organization>();
            Teams = new List<Team>();
            Applications = new List<Application>();
            Dashboards = new List<Dashboard>();
            Tiles = new List<Tile>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public DateTime RegisteredAt { get; set; }

        public string AvatarUrl { get; set; }

        public ICollection<Member> Members { get; set; }

        public ICollection<Member> CreatedMembers { get; set; }

        public ICollection<Organization> Organizations { get; set; }

        public ICollection<Team> Teams { get; set; }

        public ICollection<Application> Applications { get; set; }

        public ICollection<Dashboard> Dashboards { get; set; }

        public ICollection<Tile> Tiles { get; set; }
    }
}
