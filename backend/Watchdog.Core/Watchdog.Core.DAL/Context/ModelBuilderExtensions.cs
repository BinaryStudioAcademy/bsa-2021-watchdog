using Bogus;
using Bogus.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Watchdog.Core.Common.Enums.Tiles;
using Watchdog.Core.DAL.Context.EntityConfigurations;
using Watchdog.Core.DAL.Entities;

namespace Watchdog.Core.DAL.Context
{
    public static class ModelBuilderExtensions
    {
        private const int _numberOfApplications = 15;
        private const int _numberOfApplicationTeams = 20;
        private const int _numberOfDashboards = 15;
        private const int _numberOfEnvironments = 5;
        private const int _numberOfMembers = 30;
        private const int _numberOfOrganizations = 5;
        private const int _numberOfPlatforms = 7;
        private const int _numberOfTeams = 5;
        private const int _numberOfTeamMembers = 25;
        private const int _numberOfTiles = 35;
        private const int _numberOfUsers = 20;
        private static readonly List<string> _icons = new List<string>() { "pi-chart-line", "pi-chart-bar" };

        private static readonly string[] _roles = {"Owner", "Manager", "Viewer"};

        public static void Configure(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationConfig).Assembly);
        }

        public static void Seed(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Application>().HasData(GenerateApplications());
            modelBuilder.Entity<ApplicationTeam>().HasData(GenerateApplicationTeams());
            modelBuilder.Entity<Dashboard>().HasData(GenerateDashboards());
            modelBuilder.Entity<Entities.Environment>().HasData(GenerateEnvironments());
            modelBuilder.Entity<Member>().HasData(GenerateMembers());
            modelBuilder.Entity<Organization>().HasData(GenerateOrganizations());
            modelBuilder.Entity<Platform>().HasData(GeneratePlatforms());
            modelBuilder.Entity<Role>().HasData(GenerateRoles());
            modelBuilder.Entity<Team>().HasData(GenerateTeams());
            modelBuilder.Entity<TeamMember>().HasData(GenerateTeamMembers());
            modelBuilder.Entity<Tile>().HasData(GenerateTiles());
            modelBuilder.Entity<User>().HasData(GenerateUsers());

        }

        private static IList<Application> GenerateApplications(int count = _numberOfApplications)
        {
            return new Faker<Application>()
                .UseSeed(9326)
                .RuleFor(a => a.Id, f => ++f.IndexVariable)
                .RuleFor(a => a.Name, f => f.Company.CompanyName())
                .RuleFor(a => a.Description, f => f.Company.Bs())
                .RuleFor(a => a.OrganizationId, f => f.Random.Number(1, _numberOfOrganizations))
                .RuleFor(a => a.PlatformId, f => f.Random.Number(1, _numberOfPlatforms))
                .RuleFor(a => a.CreatedBy, f => f.Random.Number(1, _numberOfUsers))
                .RuleFor(a => a.CreatedAt, f => f.Date.Past(2, new DateTime(2021, 7, 20)))
                .RuleFor(a => a.ApiKey, f => f.Random.Guid().ToString().ToUpper())
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

        private static IList<Member> GenerateMembers(int count = _numberOfMembers)
        {
            return new Faker<Member>()
                .UseSeed(1125)
                .RuleFor(m => m.Id, f => ++f.IndexVariable)
                .RuleFor(m => m.RoleId, f => f.Random.Number(1, _roles.Length))
                .RuleFor(m => m.OrganizationId, f => f.Random.Number(1, _numberOfOrganizations))
                .RuleFor(m => m.CreatedBy, f => f.Random.Number(1, _numberOfUsers))
                .RuleFor(m => m.CreatedAt, f => f.Date.Past(2, new DateTime(2021, 7, 20)))
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
        private static IList<Platform> GeneratePlatforms()
        {
            var platforms = new List<Platform>()
            {
                new Platform
                {
                    Name = ".NET",
                    PlatformTypes = PlatformTypes.Server | PlatformTypes.Desktop,
                    AvatarUrl = "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdCb3g9IjAgMCA4MCA4MCI+PHBhdGggZmlsbD0iIzUxMmJkNCIgZD0iTTAgMGg4MHY4MEgweiIvPjxwYXRoIGQ9Ik0xNC4yNiA1MS4xMWEyIDIgMCAwMS0xLjQ0LS41NiAxLjkgMS45IDAgMDEwLTIuNzcgMiAyIDAgMDExLjQ0LS41OCAyIDIgMCAwMTEuNDUuNTggMS44OCAxLjg4IDAgMDEwIDIuNzcgMiAyIDAgMDEtMS40NS41NnptMjIuNjEtLjMyaC0zLjY4bC05LjY4LTE1LjI4YTYuNzggNi43OCAwIDAxLS42MS0xLjJoLS4wOWEyMC41MyAyMC41MyAwIDAxLjEyIDIuODV2MTMuNjNoLTMuMjZWMzBoMy45MkwzMyA0NC45MmMuNC42Mi42NSAxIC43NyAxLjI4aC4wNWExOS42OCAxOS42OCAwIDAxLS4xNC0yLjhWMzBoMy4yNHptMTUuODQgMEg0MS4zM1YzMGgxMC45M3YyLjkzaC03LjU3djUuODloN3YyLjkxaC03djYuMTVoOHptMTYuMTgtMTcuODZoLTUuODN2MTcuODZoLTMuMzdWMzIuOTNoLTUuODFWMzBoMTV6IiBmaWxsPSIjZmZmIi8+PC9zdmc+"
                },
                new Platform
                {
                    Name = "ASP.NET Core",
                    PlatformTypes = PlatformTypes.Server,
                    AvatarUrl = "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdCb3g9IjAgMCA4MCA4MCI+PHBhdGggZmlsbD0iIzUxMmJkNCIgZD0iTTAgMGg4MHY4MEgweiIvPjxwYXRoIGQ9Ik0xNC4yNiA1MS4xMWEyIDIgMCAwMS0xLjQ0LS41NiAxLjkgMS45IDAgMDEwLTIuNzcgMiAyIDAgMDExLjQ0LS41OCAyIDIgMCAwMTEuNDUuNTggMS44OCAxLjg4IDAgMDEwIDIuNzcgMiAyIDAgMDEtMS40NS41NnptMjIuNjEtLjMyaC0zLjY4bC05LjY4LTE1LjI4YTYuNzggNi43OCAwIDAxLS42MS0xLjJoLS4wOWEyMC41MyAyMC41MyAwIDAxLjEyIDIuODV2MTMuNjNoLTMuMjZWMzBoMy45MkwzMyA0NC45MmMuNC42Mi42NSAxIC43NyAxLjI4aC4wNWExOS42OCAxOS42OCAwIDAxLS4xNC0yLjhWMzBoMy4yNHptMTUuODQgMEg0MS4zM1YzMGgxMC45M3YyLjkzaC03LjU3djUuODloN3YyLjkxaC03djYuMTVoOHptMTYuMTgtMTcuODZoLTUuODN2MTcuODZoLTMuMzdWMzIuOTNoLTUuODFWMzBoMTV6IiBmaWxsPSIjZmZmIi8+PC9zdmc+"
                },
                new Platform
                {
                    Name = "JavaScript",
                    PlatformTypes = PlatformTypes.Browser,
                    AvatarUrl = "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdCb3g9IjAgMCA4MCA4MCI+PHBhdGggZD0iTTAgMGg4MHY4MEgwem00Ny42OCA2NmExMi43MiAxMi43MiAwIDAwNi4xNiA2LjEyIDE3LjYyIDE3LjYyIDAgMDAxMi41MS44OCA5LjU1IDkuNTUgMCAwMDcuMzktOC45MUExMCAxMCAwIDAwNzAuMDggNTUgMjIuNzcgMjIuNzcgMCAwMDY1IDUyYy0xLjY0LS43NC0zLjMtMS40My00LjkyLTIuMjJhNy4xMSA3LjExIDAgMDEtMi0xLjM4IDMuMjQgMy4yNCAwIDAxMS43MS01LjQgNC42OCA0LjY4IDAgMDE1LjA5IDEuODFjLjMuNC41Ny44MS44OCAxLjI1bDUuODEtMy43NGExMC44MSAxMC44MSAwIDAwLTctNS42MSAxNC45IDE0LjkgMCAwMC02LjItLjE5Yy00Ljc3Ljg1LTguMDkgNC4xOC04LjQ0IDguODZhMTAuMTcgMTAuMTcgMCAwMDMuMzUgOC44NCAyMS41NSAyMS41NSAwIDAwNS44NSAzLjQ0YzEuNS42NiAzIDEuMzIgNC40NiAyYTYuNTcgNi41NyAwIDAxMS41MSAxIDMuMzcgMy4zNyAwIDAxLS40OSA1LjQ3IDUgNSAwIDAxLTEuNTIuNjQgNy44NSA3Ljg1IDAgMDEtOC4zNy0yLjkyYy0uMzQtLjQ0LS42NS0uOS0xLTEuMzl6bS0yNi42LjgzYTExLjIzIDExLjIzIDAgMDA1IDUuNDMgMTQgMTQgMCAwMDEwLjIxLjkyIDkgOSAwIDAwNi43My02LjcgMTUuODIgMTUuODIgMCAwMC41MS00LjI4VjM3LjM5YTUuODggNS44OCAwIDAwLS4wNy0uNjdIMzZ2MjQuODNhMTMuMjYgMTMuMjYgMCAwMTAgMS42NyA5IDkgMCAwMS0uNDMgMS44NSAyLjY2IDIuNjYgMCAwMS0yIDEuNzFBNC41IDQuNSAwIDAxMjguMzEgNjVjLS4zOS0uNTctLjc1LTEuMTUtMS4xNi0xLjc4eiIgZmlsbD0iI2Y2ZGUxZSIvPjxwYXRoIGQ9Ik00Ny42OCA2Nmw2LTMuNTFjLjM0LjQ5LjY1IDEgMSAxLjM5YTcuODUgNy44NSAwIDAwOC4zNyAyLjkyIDUgNSAwIDAwMS41Mi0uNjQgMy4zNyAzLjM3IDAgMDAuNDktNS40NyA2LjU3IDYuNTcgMCAwMC0xLjUxLTFjLTEuNDctLjcxLTMtMS4zNy00LjQ2LTJhMjEuNTUgMjEuNTUgMCAwMS01Ljg1LTMuNDQgMTAuMTcgMTAuMTcgMCAwMS0zLjM1LTguODRjLjM1LTQuNjggMy42Ny04IDguNDQtOC44NmExNC45IDE0LjkgMCAwMTYuMi4xOSAxMC44MSAxMC44MSAwIDAxNyA1LjYxbC01LjgxIDMuNzRjLS4zMS0uNDQtLjU4LS44NS0uODgtMS4yNUE0LjY4IDQuNjggMCAwMDU5Ljc5IDQzYTMuMjQgMy4yNCAwIDAwLTEuNjUgNS4zOSA3LjExIDcuMTEgMCAwMDIgMS4zOGMxLjYyLjc5IDMuMjggMS40OCA0LjkyIDIuMjJhMjIuNzcgMjIuNzcgMCAwMTUuMDcgMyAxMCAxMCAwIDAxMy42NiA5LjFBOS41NSA5LjU1IDAgMDE2Ni4zNSA3M2ExNy42MiAxNy42MiAwIDAxLTEyLjUxLS44N0ExMi43MiAxMi43MiAwIDAxNDcuNjggNjZ6bS0yNi42Ljg1bDYuMDctMy42OGMuNDEuNjMuNzcgMS4yMSAxLjE2IDEuNzhhNC41IDQuNSAwIDAwNS4yNSAxLjg4IDIuNjYgMi42NiAwIDAwMi0xLjcxIDkgOSAwIDAwLjQ0LTEuODUgMTMuMjYgMTMuMjYgMCAwMDAtMS42N1YzNi43N2MyLjUtLjA4IDQuOTUgMCA3LjQ2IDBhNS44OCA1Ljg4IDAgMDEuMDcuNjd2MjQuNzhhMTUuODIgMTUuODIgMCAwMS0uNTEgNC4yOCA5IDkgMCAwMS02LjczIDYuNyAxNCAxNCAwIDAxLTEwLjIxLS45MiAxMS4yMyAxMS4yMyAwIDAxLTUtNS40M3oiIGZpbGw9IiMwMTAxMDAiLz48L3N2Zz4="
                },
                new Platform
                {
                    Name = "Angular",
                    PlatformTypes = PlatformTypes.Browser,
                    AvatarUrl = "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdCb3g9IjAgMCA4MCA4MCI+PHBhdGggZmlsbD0iI2RkMDAzMSIgZD0iTTQwIDBMMi43NiAxMy4yOGw1LjY4IDQ5LjI0TDQwIDgwbDMxLjU2LTE3LjQ4IDUuNjgtNDkuMjRMNDAgMHoiLz48cGF0aCBmaWxsPSIjYzMwMDJmIiBkPSJNNDAgMHY4Ljg4LS4wNFY4MGwzMS41Ni0xNy40OCA1LjY4LTQ5LjI0TDQwIDB6Ii8+PHBhdGggZD0iTTQwIDguODRMMTYuNzIgNjFoOC42OGw0LjY4LTExLjY4aDE5Ljc2TDU0LjUyIDYxaDguNjhMNDAgOC44NHptNi44IDMzLjMySDMzLjJMNDAgMjUuOHoiIGZpbGw9IiNmZmYiLz48L3N2Zz4="
                },
                new Platform
                {
                    Name = "AngularJs",
                    PlatformTypes = PlatformTypes.Browser,
                    AvatarUrl = "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdCb3g9IjAgMCA4MCA4MCI+PHBhdGggZmlsbD0iI2RkMDAzMSIgZD0iTTQwIDBMMi43NiAxMy4yOGw1LjY4IDQ5LjI0TDQwIDgwbDMxLjU2LTE3LjQ4IDUuNjgtNDkuMjRMNDAgMHoiLz48cGF0aCBmaWxsPSIjYzMwMDJmIiBkPSJNNDAgMHY4Ljg4LS4wNFY4MGwzMS41Ni0xNy40OCA1LjY4LTQ5LjI0TDQwIDB6Ii8+PHBhdGggZD0iTTQwIDguODRMMTYuNzIgNjFoOC42OGw0LjY4LTExLjY4aDE5Ljc2TDU0LjUyIDYxaDguNjhMNDAgOC44NHptNi44IDMzLjMySDMzLjJMNDAgMjUuOHoiIGZpbGw9IiNmZmYiLz48L3N2Zz4="
                },
                new Platform
                {
                    Name = "React",
                    PlatformTypes = PlatformTypes.Browser,
                    AvatarUrl = "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdCb3g9IjAgMCA4MCA4MCI+PGRlZnM+PHN0eWxlPi5ie2ZpbGw6IzYxZGFmYn08L3N0eWxlPjwvZGVmcz48cGF0aCBmaWxsPSIjMjAyMzJhIiBkPSJNMCAwaDgwdjgwSDB6Ii8+PGNpcmNsZSBjbGFzcz0iYiIgY3g9IjQwIiBjeT0iNDAiIHI9IjYuNTMiLz48cGF0aCBjbGFzcz0iYiIgZD0iTTQwIDU1QzE5LjQ3IDU1IDMuMzggNDguMzkgMy4zOCA0MFMxOS40NyAyNSA0MCAyNXMzNi42MiA2LjU3IDM2LjYyIDE1UzYwLjUzIDU1IDQwIDU1em0wLTI2Ljc1QzIwLjMgMjguMjIgNi41NyAzNC40MyA2LjU3IDQwUzIwLjMgNTEuNzggNDAgNTEuNzggNzMuNDMgNDUuNTcgNzMuNDMgNDAgNTkuNyAyOC4yMiA0MCAyOC4yMnoiLz48cGF0aCBjbGFzcz0iYiIgZD0iTTU0LjYyIDcyLjY2Yy0zLjI1IDAtNy4xNy0xLjc4LTExLjQzLTUuMjRDMzcuNTUgNjIuODMgMzEuODEgNTUuNzUgMjcgNDcuNDhjLTEwLjI3LTE3Ljc4LTEyLjYyLTM1LTUuMzUtMzkuMTkgMy43LTIuMTQgOS4wNy0uNjIgMTUuMTIgNC4zQzQyLjQ1IDE3LjE3IDQ4LjE5IDI0LjI1IDUzIDMyLjUyYzEwLjI3IDE3Ljc4IDEyLjYyIDM1IDUuMzUgMzkuMTlhNy4yNyA3LjI3IDAgMDEtMy43My45NXpNMjUuNDMgMTAuNTJhNC4xNiA0LjE2IDAgMDAtMi4xNS41M0MxOC40NiAxMy44MyAyMCAyOC44MyAyOS44IDQ1Ljg5YzQuNTggNy45NCAxMC4wNSAxNC43MSAxNS40IDE5IDQuODcgNCA5LjA3IDUuNDMgMTEuNTIgNCA0LjgyLTIuNzkgMy4zMy0xNy43OS02LjUyLTM0Ljg1LTQuNTgtNy45NC0xMC4wNS0xNC43LTE1LjQtMTktMy42Ni0yLjk1LTYuOTMtNC41Mi05LjM3LTQuNTJ6Ii8+PHBhdGggY2xhc3M9ImIiIGQ9Ik0yNS4zOCA3Mi42NmE3LjE3IDcuMTcgMCAwMS0zLjY5LTFDMTQuNDIgNjcuNTIgMTYuNzcgNTAuMyAyNyAzMi41MmM0Ljc3LTguMjcgMTAuNTEtMTUuMzUgMTYuMTUtMTkuOTMgNi4wNS00LjkyIDExLjQyLTYuNDUgMTUuMTItNC4zIDcuMjcgNC4yIDQuOTIgMjEuNDEtNS4zNSAzOS4xOS00Ljc3IDguMjctMTAuNTEgMTUuMzUtMTYuMTUgMTkuOTQtNC4yMiAzLjQ2LTguMTQgNS4yNC0xMS4zOSA1LjI0em0yOS4xOS02Mi4xNGMtMi40NCAwLTUuNzEgMS41Ny05LjM3IDQuNTQtNS4zNSA0LjM1LTEwLjgyIDExLjExLTE1LjQgMTlDMjAgNTEuMTcgMTguNDYgNjYuMTcgMjMuMjggNjljMi40NSAxLjQgNi42NS0uMDYgMTEuNTItNCA1LjM1LTQuMzQgMTAuODItMTEuMTEgMTUuNC0xOSA5Ljg1LTE3LjA2IDExLjM0LTMyLjA2IDYuNTItMzQuODRhNC4xNiA0LjE2IDAgMDAtMi4xNS0uNjR6Ii8+PC9zdmc+"
                },
                new Platform
                {
                    Name = "Windows Presentation Foundation",
                    PlatformTypes = PlatformTypes.Desktop,
                    AvatarUrl = "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdCb3g9IjAgMCA4MCA4MCI+PHBhdGggZmlsbD0iIzUxMmJkNCIgZD0iTTAgMGg4MHY4MEgweiIvPjxwYXRoIGQ9Ik0xNC4yNiA1MS4xMWEyIDIgMCAwMS0xLjQ0LS41NiAxLjkgMS45IDAgMDEwLTIuNzcgMiAyIDAgMDExLjQ0LS41OCAyIDIgMCAwMTEuNDUuNTggMS44OCAxLjg4IDAgMDEwIDIuNzcgMiAyIDAgMDEtMS40NS41NnptMjIuNjEtLjMyaC0zLjY4bC05LjY4LTE1LjI4YTYuNzggNi43OCAwIDAxLS42MS0xLjJoLS4wOWEyMC41MyAyMC41MyAwIDAxLjEyIDIuODV2MTMuNjNoLTMuMjZWMzBoMy45MkwzMyA0NC45MmMuNC42Mi42NSAxIC43NyAxLjI4aC4wNWExOS42OCAxOS42OCAwIDAxLS4xNC0yLjhWMzBoMy4yNHptMTUuODQgMEg0MS4zM1YzMGgxMC45M3YyLjkzaC03LjU3djUuODloN3YyLjkxaC03djYuMTVoOHptMTYuMTgtMTcuODZoLTUuODN2MTcuODZoLTMuMzdWMzIuOTNoLTUuODFWMzBoMTV6IiBmaWxsPSIjZmZmIi8+PC9zdmc+"
                },

            };


            for (int i = 1; i <= platforms.Count; i++)
            {
                platforms[i - 1].Id = i;
            }
            return platforms;
        }

        private static IList<Role> GenerateRoles()
        {
            return new Faker<Role>()
                .UseSeed(1804)
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

        private static IList<TeamMember> GenerateTeamMembers(int count = _numberOfTeamMembers)
        {
            return new Faker<TeamMember>()
                .UseSeed(4197)
                .RuleFor(tm => tm.Id, f => ++f.IndexVariable)
                .RuleFor(tm => tm.TeamId, f => f.Random.Number(1, _numberOfTeams))
                .RuleFor(tm => tm.MemberId, f => f.Random.Number(1, _numberOfMembers))
                .Generate(count);
        }

        private static IList<Tile> GenerateTiles(int count = _numberOfTiles)
        {
            return new Faker<Tile>()
                .UseSeed(2246)
                .RuleFor(t => t.Id, f => ++f.IndexVariable)
                .RuleFor(t => t.Name, f => f.Commerce.ProductName().ClampLength(3, 50, ' '))
                .RuleFor(t => t.DashboardId, f => f.Random.Number(1, _numberOfDashboards))
                .RuleFor(t => t.Type, f => f.PickRandom<TileType>())
                .RuleFor(t => t.Category,
                    (f, tile) => tile.Type == TileType.TopActiveIssues
                        ? TileCategory.List
                        : f.PickRandom<TileCategory>())
                .RuleFor(t => t.CreatedBy, f => f.Random.Number(1, _numberOfUsers))
                .RuleFor(t => t.CreatedAt, f => f.Date.Past(2, new DateTime(2021, 7, 20)))
                .RuleFor(t => t.Settings, f =>
                    "{" +
                    $"\"sourceProjects\": [{f.Random.Number(1, _numberOfApplications)}]," +
                    $"\"dateRange\": {f.Random.Number(0, 4)}," +
                    $"\"issuesCount\": {f.Random.Number(1, 1000)}" +
                    "}")
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
