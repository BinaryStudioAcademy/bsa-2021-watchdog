using Bogus;
using Bogus.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Watchdog.Core.DAL.Context.EntityConfigurations;
using Watchdog.Core.DAL.Entities;

namespace Watchdog.Core.DAL.Context
{
    public static class ModelBuilderExtensions
    {
        private const int _numberOfApplications = 10;
        private const int _numberOfApplicationTeams = 20;
        private const int _numberOfDashboards = 15;
        private const int _numberOfEnvironments = 5;
        private const int _numberOfMembers = 30;
        private const int _numberOfOrganizations = 5;
        private const int _numberOfPlatforms = 10;
        private const int _numberOfTeams = 5;
        private const int _numberOfTeamMembers = 25;
        private const int _numberOfTiles = 25;
        private const int _numberOfUsers = 20;
        private static readonly List<string> _icons  = new List<string>() { "pi-chart-line", "pi-chart-bar" };

        private static readonly string[] _roles = { "Owner", "Manager", "Viewer" };

        public static void Configure(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SampleConfig).Assembly);
        }

        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sample>().HasData(GenerateSamples());

            modelBuilder.Entity<Application>().HasData(GenerateApplications());
            modelBuilder.Entity<ApplicationTeam>().HasData(GenerateApplicationTeams());
            modelBuilder.Entity<Dashboard>().HasData(GenerateDashboards());
            modelBuilder.Entity<Entities.Environment>().HasData(GenerateEnvironments());
            IList<User> users = GenerateUsers();
            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<Member>().HasData(GenerateMembers(users.Select(u => u.Email).ToArray()));
            modelBuilder.Entity<Organization>().HasData(GenerateOrganizations());
            modelBuilder.Entity<Platform>().HasData(GeneratePlatforms());
            modelBuilder.Entity<Role>().HasData(GenerateRoles());
            modelBuilder.Entity<Team>().HasData(GenerateTeams());
            modelBuilder.Entity<Tile>().HasData(GenerateTiles());

        }

        private static IList<Sample> GenerateSamples(int count = 10)
        {
            Faker.GlobalUniqueIndex = 1;

            return new Faker<Sample>()
                .UseSeed(10)
                .RuleFor(e => e.Id, f => f.IndexGlobal)
                .RuleFor(e => e.Title, f => f.Lorem.Word())
                .RuleFor(e => e.Body, f => f.Lorem.Paragraph())
                .RuleFor(e => e.CreatedBy, f => f.Random.Number(1, 5))
                .RuleFor(e => e.CreatedAt, f => f.Date.Past(2, new DateTime(2021, 7, 20)))
                .Generate(count);
        }

        private static IList<Application> GenerateApplications(int count = _numberOfApplications)
        {
            return new Faker<Application>()
                .UseSeed(9326)
                .RuleFor(a => a.Id, f => ++f.IndexVariable)
                .RuleFor(a => a.Name, f => f.Lorem.Word())
                .RuleFor(a => a.SecurityToken, f => f.Random.Hash(32))
                .RuleFor(a => a.OrganizationId, f => f.Random.Number(1, _numberOfOrganizations))
                .RuleFor(a => a.PlatformId, f => f.Random.Number(1, _numberOfPlatforms))
                .RuleFor(a => a.CreatedBy, f => f.Random.Number(1, _numberOfUsers))
                .RuleFor(a => a.CreatedAt, f => f.Date.Past(2, new DateTime(2021, 7, 20)))
                .Generate(count);
        }

        private static IList<ApplicationTeam> GenerateApplicationTeams(int count = _numberOfApplicationTeams)
        {
            return new Faker<ApplicationTeam>()
                .UseSeed(4683)
                .RuleFor(at => at.Id, f => ++f.IndexVariable)
                .RuleFor(at => at.ApplicationId, f => f.Random.Number(1, _numberOfApplications))
                .RuleFor(at => at.TeamId, f => f.Random.Number(1, _numberOfTeams))
                .Generate(count);
        }

        private static IList<Dashboard> GenerateDashboards(int count = _numberOfDashboards)
        {
            return new Faker<Dashboard>()
                .UseSeed(5291)
                .RuleFor(d => d.Id, f => ++f.IndexVariable)
                .RuleFor(d => d.Name, f => f.Lorem.Word())
                .RuleFor(d => d.Icon, f => f.PickRandom(_icons))
                .RuleFor(d => d.OrganizationId, f => f.Random.Number(1, _numberOfOrganizations))
                .RuleFor(d => d.CreatedBy, f => f.Random.Number(1, _numberOfUsers))
                .RuleFor(d => d.CreatedAt, f => f.Date.Past(2, new DateTime(2021, 7, 20)))
                .Generate(count);
        }

        private static IList<Entities.Environment> GenerateEnvironments(int count = _numberOfEnvironments)
        {
            return new Faker<Entities.Environment>()
                .UseSeed(8863)
                .RuleFor(e => e.Id, f => ++f.IndexVariable)
                .RuleFor(e => e.Name, f => f.Lorem.Word())
                .RuleFor(e => e.ApplicationId, f => f.Random.Number(1, _numberOfApplications))
                .Generate(count);
        }

        private static IList<Member> GenerateMembers(string[] emails, int count = _numberOfMembers)
        {
            return new Faker<Member>()
                .UseSeed(1125)
                .RuleFor(m => m.Id, f => ++f.IndexVariable)
                .RuleFor(m => m.RoleId, f => f.Random.Number(1, _roles.Length))
                .RuleFor(m => m.OrganizationId, f => f.Random.Number(1, _numberOfOrganizations))
                .RuleFor(m => m.CreatedBy, f => f.Random.Number(1, _numberOfUsers))
                .RuleFor(m => m.CreatedAt, f => f.Date.Past(2, new DateTime(2021, 7, 20)))
                .RuleFor(m => m.TeamId, f=> f.Random.Number(1, _numberOfTeams))
                .RuleFor(m => m.UserId, f=> f.Random.Number(1, _numberOfUsers))
                .RuleFor(m=> m.IsAccepted, f=> f.Random.Bool())
                .Generate(count);
                
        }

        private static IList<Organization> GenerateOrganizations(int count = _numberOfOrganizations)
        {
            return new Faker<Organization>()
                .UseSeed(7927)
                .RuleFor(o => o.Id, f => ++f.IndexVariable)
                .RuleFor(o => o.OrganizationSlug, f => f.Lorem.Word().ClampLength(3, 50, '-'))
                .RuleFor(o => o.Name, f => f.Company.CompanyName().ClampLength(3, 50, ' '))
                .RuleFor(o => o.OpenMembership, f => f.Random.Bool())
                .RuleFor(o => o.DefaultRoleId, f => f.Random.Number(1, _roles.Length))
                .RuleFor(o => o.AvatarUrl, f => f.Image.PicsumUrl(250, 250))
                .RuleFor(o => o.CreatedBy, f => f.Random.Number(1, _numberOfUsers))
                .RuleFor(o => o.CreatedAt, f => f.Date.Past(2, new DateTime(2021, 7, 20)))
                .Generate(count);
        }

        private static IList<Platform> GeneratePlatforms(int count = _numberOfPlatforms)
        {
            return new Faker<Platform>()
                .UseSeed(1805)
                .RuleFor(p => p.Id, f => ++f.IndexVariable)
                .RuleFor(p => p.Name, f => f.Lorem.Word())
                .RuleFor(p => p.AvatarUrl, f => f.Image.PicsumUrl(250, 250))
                .Generate(count);
        }

        private static IList<Role> GenerateRoles()
        {
            return new Faker<Role>()
                .RuleFor(r => r.Id, f => ++f.IndexVariable)
                .RuleFor(r => r.Name, f => _roles[f.IndexVariable - 1])
                .RuleFor(r => r.Description, f => f.Lorem.Paragraph())
                .Generate(_roles.Length);
        }

        private static IList<Team> GenerateTeams(int count = _numberOfTeams)
        {
            return new Faker<Team>()
                .UseSeed(2937)
                .RuleFor(t => t.Id, f => ++f.IndexVariable)
                .RuleFor(t => t.Name, f => f.Lorem.Word())
                .RuleFor(t => t.OrganizationId, f => f.Random.Number(1, _numberOfOrganizations))
                .RuleFor(t => t.CreatedBy, f => f.Random.Number(1, _numberOfUsers))
                .RuleFor(t => t.CreatedAt, f => f.Date.Past(2, new DateTime(2021, 7, 20)))
                .Generate(count);
        }

        private static IList<Tile> GenerateTiles(int count = _numberOfTiles)
        {
            return new Faker<Tile>()
                .UseSeed(2246)
                .RuleFor(t => t.Id, f => ++f.IndexVariable)
                .RuleFor(t => t.Name, f => f.Lorem.Word())
                .RuleFor(t => t.DashboardId, f => f.Random.Number(1, _numberOfDashboards))
                .RuleFor(t => t.CreatedBy, f => f.Random.Number(1, _numberOfUsers))
                .RuleFor(t => t.CreatedAt, f => f.Date.Past(2, new DateTime(2021, 7, 20)))
                .Generate(count);
        }

        private static IList<User> GenerateUsers(int count = _numberOfUsers)
        {
            return new Faker<User>()
                .UseSeed(1996)
                .RuleFor(u => u.Id, f => ++f.IndexVariable)
                .RuleFor(u => u.Uid, f => f.Random.Hash(28))
                .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                .RuleFor(u => u.LastName, f => f.Name.LastName())
                .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName).ToLower())
                .RuleFor(u => u.RegisteredAt, f => f.Date.Past(2, new DateTime(2021, 7, 20)))
                .RuleFor(u => u.AvatarUrl, f => f.Internet.Avatar())
                .Generate(count);
        }
  
    }
}
