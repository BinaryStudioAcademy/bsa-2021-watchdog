using Bogus;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
        private const int _numberOfRoles = 5;
        private const int _numberOfTeams = 5;
        private const int _numberOfTeamMembers = 25;
        private const int _numberOfTiles = 25;
        private const int _numberOfUsers = 20;

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
            modelBuilder.Entity<Member>().HasData(GenerateMembers());
            modelBuilder.Entity<Organization>().HasData(GenerateOrganizations());
            modelBuilder.Entity<Platform>().HasData(GeneratePlatforms());
            modelBuilder.Entity<Role>().HasData(GenerateRoles());
            modelBuilder.Entity<Team>().HasData(GenerateTeams());
            modelBuilder.Entity<TeamMember>().HasData(GenerateTeamMembers());
            modelBuilder.Entity<Tile>().HasData(GenerateTiles());
            modelBuilder.Entity<User>().HasData(GenerateUsers());
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
                .UseSeed(1129)
                .RuleFor(m => m.Id, f => ++f.IndexVariable)
                .RuleFor(m => m.RoleId, f => f.Random.Number(1, _numberOfRoles))
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
                .RuleFor(o => o.Name, f => f.Company.CompanyName())
                .RuleFor(o => o.AvatarUrl, f => f.Image.PicsumUrl(250, 250))
                .RuleFor(o => o.CreatedBy, f => f.Random.Number(1, _numberOfUsers))
                .RuleFor(o => o.CreatedAt, f => f.Date.Past(2, new DateTime(2021, 7, 20)))
                .Generate(count);
        }
        private static IList<Platform> GeneratePlatforms(int count = _numberOfPlatforms)
        {
            var platforms = new List<Platform>()
            {
                new Platform 
                { 
                    Name = "Android",
                    PlatformTypes = PlatformTypes.Mobile,
                    AvatarUrl = "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdCb3g9IjAgMCA4MCA4MCI+PHBhdGggZD0iTTU4LjM3IDQ4Ljk0YTMuMzMgMy4zMyAwIDExMy4zMi0zLjMyIDMuMzMgMy4zMyAwIDAxLTMuMzIgMy4zMm0tMzYuNzQgMEEzLjMzIDMuMzMgMCAxMTI1IDQ1LjYyYTMuMzIgMy4zMiAwIDAxLTMuMzIgMy4zMm0zNy45My0yMGw2LjY0LTExLjVBMS4zOCAxLjM4IDAgMDA2My44MSAxNmwtNi43MyAxMS42OGE0MS43OSA0MS43OSAwIDAwLTM0LjE2IDBMMTYuMTkgMTZhMS4zOCAxLjM4IDAgMDAtMi4zOSAxLjM4bDYuNjQgMTEuNTFBMzkuMiAzOS4yIDAgMDAuMDkgNjAuMzJoNzkuODJhMzkuMiAzOS4yIDAgMDAtMjAuMzUtMzEuNCIgZmlsbD0iIzNkZGM4NCIvPjwvc3ZnPg=="
                },
                new Platform
                {
                    Name = "IOS",
                    PlatformTypes = PlatformTypes.Mobile,
                    AvatarUrl = "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdCb3g9IjAgMCA4MCA4MCI+PHBhdGggZD0iTTcyLjUxIDU4LjQzYTQxLjc0IDQxLjc0IDAgMDEtMy4yOSA3LjggNTAuNTkgNTAuNTkgMCAwMS02LjU4IDkuNDUgMTEuODMgMTEuODMgMCAwMS02LjE0IDMuOTUgMTEuMzQgMTEuMzQgMCAwMS02LjczLS42MyA0NC44NyA0NC44NyAwIDAwLTQuOTItMS44MyAxNC43MiAxNC43MiAwIDAwLTkuNDcuODcgMzguNzMgMzguNzMgMCAwMS01IDEuNzMgOC40MyA4LjQzIDAgMDEtNy4zNC0xLjYxIDI0LjUxIDI0LjUxIDAgMDEtNC41OC00LjY5QTUwLjI3IDUwLjI3IDAgMDE4LjEyIDUwLjE2Yy0xLTUuOC0xLTExLjU3IDEuMTQtMTcuMTYgMi41OC02LjggNy4yOC0xMS4zNSAxNC40Ni0xMy4xM2ExNi40MiAxNi40MiAwIDAxMTAuMy45NGMxLjQ0LjU4IDIuOSAxLjExIDQuMzYgMS42NmE1LjggNS44IDAgMDA0LjIgMGMyLjE1LS44IDQuMjgtMS42MyA2LjQ1LTIuMzcgNy4wNi0yLjM5IDE2LjMzIDAgMjEgNi43MmwuNDMuNjNjLTUuNzUgMy44NS05IDkuMDYtOC41NyAxNi4xNXM0LjM1IDExLjgxIDEwLjYyIDE0LjgzeiIvPjxwYXRoIGQ9Ik01NS45MiAwYzEuMzYgOS4wNy02LjgzIDE5Ljc1LTE2LjMyIDE4Ljg2YTE2LjIzIDE2LjIzIDAgMDE0LjE5LTEyLjU4QTE3LjQ5IDE3LjQ5IDAgMDE1NS45MiAweiIvPjwvc3ZnPg=="
                },
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
                    Name = "Flutter",
                    PlatformTypes = PlatformTypes.Mobile,
                    AvatarUrl = "https://s1.sentry-cdn.com/_static/dist/sentry/assets/flutter.e45027e743d56859f384.svg"
                },
                new Platform
                {
                    Name = "Go",
                    PlatformTypes = PlatformTypes.Server,
                    AvatarUrl = "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdCb3g9IjAgMCA4MCA4MCI+PGRlZnM+PHN0eWxlPi5he2ZpbGw6IzJkYmNhZn08L3N0eWxlPjwvZGVmcz48cGF0aCBjbGFzcz0iYSIgZD0iTTYgMzQuMTFjLS4xNiAwLS4yLS4wOC0uMTItLjJsLjgyLTFhLjU1LjU1IDAgMDEuNDMtLjJoMTMuOWMuMTYgMCAuMi4xMi4xMi4yNGwtLjY2IDFhLjYuNiAwIDAxLS4zOS4yM3pNLjE2IDM3LjY5Yy0uMTYgMC0uMi0uMDgtLjEyLS4ybC44Mi0xLjA1YS41Ni41NiAwIDAxLjQzLS4xOWgxNy43NmMuMTUgMCAuMjMuMTEuMTkuMjNsLS4zMS45NGEuMzQuMzQgMCAwMS0uMzUuMjN6bTkuNDIgMy41OGMtLjE1IDAtLjE5LS4xMS0uMTEtLjIzbC41NC0xYS41MS41MSAwIDAxLjM5LS4yNGg3Ljc5Yy4xNiAwIC4yMy4xMi4yMy4yN2wtLjA3Ljk0YS4zLjMgMCAwMS0uMjguMjd6TTUwIDMzLjRjLTIuNDUuNjMtNC4xMyAxLjEtNi41NCAxLjcyLS41OS4xNS0uNjIuMTktMS4xMy0uMzlhNS4xOCA1LjE4IDAgMDAtMS44My0xLjQ4IDYuNzcgNi43NyAwIDAwLTcgLjU4IDguMjkgOC4yOSAwIDAwLTQgNy40IDYuMSA2LjEgMCAwMDUuMjUgNi4xMiA3LjIyIDcuMjIgMCAwMDYuNjMtMi41N2MuMzUtLjQzLjY2LS45IDEuMDUtMS40NEgzNC45Yy0uODIgMC0xLS41MS0uNzQtMS4xNy41MS0xLjIxIDEuNDQtMy4yMyAyLTQuMjVhMSAxIDAgMDExLS42Mkg1MS4zYy0uMDggMS4wNS0uMDggMi4xLS4yNCAzLjE1YTE2LjU2IDE2LjU2IDAgMDEtMy4xOSA3LjY0IDE2LjIxIDE2LjIxIDAgMDEtMTEuMSA2LjYyIDEzLjc4IDEzLjc4IDAgMDEtMTAuNDgtMi41NyAxMi4yNCAxMi4yNCAwIDAxLTQuOTUtOC42NSAxNS4zMyAxNS4zMyAwIDAxMy4zMi0xMS40MSAxNy4yOCAxNy4yOCAwIDAxMTAuOS02Ljc0IDEzLjQzIDEzLjQzIDAgMDExMC4zMiAxLjkxIDEyLjEzIDEyLjEzIDAgMDE0LjUyIDUuNDljLjI0LjM1LjA4LjU1LS40LjY2eiIvPjxwYXRoIGNsYXNzPSJhIiBkPSJNNjIuOTEgNTQuOTRhMTQuNjEgMTQuNjEgMCAwMS05LjUxLTMuNDJBMTIuMjQgMTIuMjQgMCAwMTQ5LjE5IDQ0YTE0Ljg2IDE0Ljg2IDAgMDEzLjE2LTExLjc2IDE2LjMzIDE2LjMzIDAgMDExMC45MS02LjUxYzQtLjcgNy43MS0uMzEgMTEuMSAyYTEyLjE0IDEyLjE0IDAgMDE1LjQ5IDguNjggMTUuMDYgMTUuMDYgMCAwMS00LjQ4IDEzLjIxIDE3Ljg1IDE3Ljg1IDAgMDEtOS4zNSA1Yy0xLjAyLjE3LTIuMS4yMS0zLjExLjMyem05LjI3LTE1LjczYTEwLjk0IDEwLjk0IDAgMDAtLjEyLTEuMjkgNi40MyA2LjQzIDAgMDAtOC01LjE4IDguNSA4LjUgMCAwMC02LjgxIDYuNzggNi40MSA2LjQxIDAgMDAzLjU4IDcuMzYgNy4xMyA3LjEzIDAgMDA2LjM1LS4yMyA4LjU0IDguNTQgMCAwMDUtNy40NHoiLz48L3N2Zz4="
                },
                new Platform
                {
                    Name = "Java",
                    PlatformTypes = PlatformTypes.Server | PlatformTypes.Desktop,
                    AvatarUrl = "https://s1.sentry-cdn.com/_static/dist/sentry/assets/java.bed4fe4c69a3e913f854.svg"
                },
                new Platform
                {
                    Name = "Spring boot",
                    PlatformTypes = PlatformTypes.Server,
                    AvatarUrl = "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdCb3g9IjAgMCA4MCA4MCI+PGRlZnM+PHN0eWxlPi5ie2ZpbGw6I2ZmZn08L3N0eWxlPjwvZGVmcz48cGF0aCBkPSJNNTcuMTcgNC42SDIyLjgzYTUuNjYgNS42NiAwIDAwLTQuOSAyLjgzTC43NiAzNy4xN2E1LjY3IDUuNjcgMCAwMDAgNS42NmwxNy4xNyAyOS43NGE1LjY2IDUuNjYgMCAwMDQuOSAyLjgzaDM0LjM0YTUuNjYgNS42NiAwIDAwNC45LTIuODNsMTcuMTctMjkuNzRhNS42NyA1LjY3IDAgMDAwLTUuNjZMNjIuMDcgNy40M2E1LjY2IDUuNjYgMCAwMC00LjktMi44M3oiIGZpbGw9IiM2NWE3NDEiLz48cGF0aCBjbGFzcz0iYiIgZD0iTTQwIDQxLjY2YTIuMjYgMi4yNiAwIDAxLTIuMjYtMi4yNlYxNy41N2EyLjI2IDIuMjYgMCAxMTQuNTIgMFYzOS40QTIuMjYgMi4yNiAwIDAxNDAgNDEuNjZ6Ii8+PHBhdGggY2xhc3M9ImIiIGQ9Ik00MCA2MGEyMS4xNSAyMS4xNSAwIDAxLTkuOTUtMzkuODEgMi4yNiAyLjI2IDAgMTEyLjE0IDQgMTYuNjIgMTYuNjIgMCAxMDE1LjYyIDAgMi4yNiAyLjI2IDAgMTEyLjE0LTRBMjEuMTUgMjEuMTUgMCAwMTQwIDYweiIvPjwvc3ZnPg=="
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
                    Name = "Node.js",
                    PlatformTypes = PlatformTypes.Server,
                    AvatarUrl = "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHhtbG5zOnhsaW5rPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5L3hsaW5rIiB2aWV3Qm94PSIwIDAgODAgODAiPjxkZWZzPjxsaW5lYXJHcmFkaWVudCBpZD0iYSIgeDE9IjMyLjYyIiB5MT0iMzAuMSIgeDI9IjI1Ljc0IiB5Mj0iNDQuMTQiIGdyYWRpZW50VW5pdHM9InVzZXJTcGFjZU9uVXNlIj48c3RvcCBvZmZzZXQ9IjAiIHN0b3AtY29sb3I9IiMzZjg3M2YiLz48c3RvcCBvZmZzZXQ9Ii4zMyIgc3RvcC1jb2xvcj0iIzNmOGIzZCIvPjxzdG9wIG9mZnNldD0iLjY0IiBzdG9wLWNvbG9yPSIjM2U5NjM3Ii8+PHN0b3Agb2Zmc2V0PSIuOTMiIHN0b3AtY29sb3I9IiMzZGE5MmUiLz48c3RvcCBvZmZzZXQ9IjEiIHN0b3AtY29sb3I9IiMzZGFlMmIiLz48L2xpbmVhckdyYWRpZW50PjxsaW5lYXJHcmFkaWVudCBpZD0iZCIgeDE9IjI4LjM3IiB5MT0iMzcuNDUiIHgyPSI0Ny42OCIgeTI9IjIzLjE3IiBncmFkaWVudFVuaXRzPSJ1c2VyU3BhY2VPblVzZSI+PHN0b3Agb2Zmc2V0PSIuMTQiIHN0b3AtY29sb3I9IiMzZjg3M2YiLz48c3RvcCBvZmZzZXQ9Ii40IiBzdG9wLWNvbG9yPSIjNTI5ZjQ0Ii8+PHN0b3Agb2Zmc2V0PSIuNzEiIHN0b3AtY29sb3I9IiM2M2I2NDkiLz48c3RvcCBvZmZzZXQ9Ii45MSIgc3RvcC1jb2xvcj0iIzZhYmY0YiIvPjwvbGluZWFyR3JhZGllbnQ+PGxpbmVhckdyYWRpZW50IGlkPSJlIiB4MT0iMjAuNzIiIHkxPSIyNS4yMyIgeDI9IjM4LjMzIiB5Mj0iMjUuMjMiIGdyYWRpZW50VW5pdHM9InVzZXJTcGFjZU9uVXNlIj48c3RvcCBvZmZzZXQ9Ii4wOSIgc3RvcC1jb2xvcj0iIzZhYmY0YiIvPjxzdG9wIG9mZnNldD0iLjI5IiBzdG9wLWNvbG9yPSIjNjNiNjQ5Ii8+PHN0b3Agb2Zmc2V0PSIuNiIgc3RvcC1jb2xvcj0iIzUyOWY0NCIvPjxzdG9wIG9mZnNldD0iLjg2IiBzdG9wLWNvbG9yPSIjM2Y4NzNmIi8+PC9saW5lYXJHcmFkaWVudD48bGluZWFyR3JhZGllbnQgaWQ9ImYiIHgxPSIyMC43MiIgeTE9IjM2LjQxIiB4Mj0iMzguMzMiIHkyPSIzNi40MSIgeGxpbms6aHJlZj0iI2UiLz48bGluZWFyR3JhZGllbnQgaWQ9ImciIHgxPSIyMC43MiIgeTE9IjQxLjQ0IiB4Mj0iMzguMzMiIHkyPSI0MS40NCIgeGxpbms6aHJlZj0iI2UiLz48bGluZWFyR3JhZGllbnQgaWQ9ImgiIHgxPSIyMC43MiIgeTE9IjQzLjcyIiB4Mj0iMzguMzMiIHkyPSI0My43MiIgeGxpbms6aHJlZj0iI2UiLz48bGluZWFyR3JhZGllbnQgaWQ9ImkiIHgxPSI0MC45IiB5MT0iMjkuNjgiIHgyPSIzMC4wNCIgeTI9IjUxLjg0IiB4bGluazpocmVmPSIjYSIvPjxjbGlwUGF0aCBpZD0iYyI+PHBhdGggZD0iTTMwIDI2LjgyYS45NC45NCAwIDAwLS45MiAwbC03LjYyIDQuNEEuOTEuOTEgMCAwMDIxIDMydjguOGEuODkuODkgMCAwMC40Ni43OUwyOS4wNyA0NmEuODkuODkgMCAwMC45MyAwbDcuNjEtNC40YS44OS44OSAwIDAwLjQ2LS43OVYzMmEuOTEuOTEgMCAwMC0uNDYtLjh6IiBjbGlwLXJ1bGU9ImV2ZW5vZGQiIGZpbGw9InVybCgjYSkiLz48L2NsaXBQYXRoPjxzdHlsZT4uYntmaWxsOiM2NzllNjN9Lmd7ZmlsbDpub25lfTwvc3R5bGU+PC9kZWZzPjxwYXRoIGNsYXNzPSJiIiBkPSJNMzkuNTQgNjQuNWExLjQ4IDEuNDggMCAwMS0uNzYtLjIxbC0yLjQxLTEuNDJjLS4zNi0uMi0uMTgtLjI4LS4wNi0uMzJhNC42NiA0LjY2IDAgMDAxLjA5LS40OS4xOS4xOSAwIDAxLjE4IDBsMS44NSAxLjFhLjIyLjIyIDAgMDAuMjIgMEw0Ni44OCA1OWEuMjQuMjQgMCAwMC4xMS0uMTl2LTguMzRhLjI2LjI2IDAgMDAtLjExLS4ybC03LjIzLTQuMTdhLjIyLjIyIDAgMDAtLjIyIDBsLTcuMjIgNC4xN2EuMjMuMjMgMCAwMC0uMTEuMnY4LjM0YS4yMS4yMSAwIDAwLjExLjE5bDIgMS4xNGMxLjA3LjU0IDEuNzMtLjA5IDEuNzMtLjczdi04LjIzYS4yMS4yMSAwIDAxLjIxLS4yMWguOTJhLjIxLjIxIDAgMDEuMjEuMjF2OC4yM2EyIDIgMCAwMS0yLjE0IDIuMjYgMy4wNyAzLjA3IDAgMDEtMS42Ny0uNDZsLTEuODktMS4wOWExLjUxIDEuNTEgMCAwMS0uNzYtMS4zMXYtOC4zNGExLjUzIDEuNTMgMCAwMS43Ni0xLjMybDcuMi00LjE1YTEuNTggMS41OCAwIDAxMS41MiAwbDcuMjMgNC4xN2ExLjU0IDEuNTQgMCAwMS43NSAxLjMydjguMzRhMS41MiAxLjUyIDAgMDEtLjc1IDEuMzFsLTcuMjMgNC4xNWExLjQ1IDEuNDUgMCAwMS0uNzYuMjF6Ii8+PHBhdGggY2xhc3M9ImIiIGQ9Ik00MS43NyA1OC43NWMtMy4xNiAwLTMuODItMS40NS0zLjgyLTIuNjZhLjIxLjIxIDAgMDEuMjEtLjIxaC45M2EuMjEuMjEgMCAwMS4yMS4xN2MuMTQgMSAuNTYgMS40MyAyLjQ3IDEuNDMgMS41MiAwIDIuMTctLjM0IDIuMTctMS4xNSAwLS40Ni0uMTgtLjgxLTIuNTUtMS0yLS4yLTMuMi0uNjMtMy4yLTIuMjFzMS4yMy0yLjMzIDMuMjktMi4zM2MyLjMyIDAgMy40Ni44IDMuNjEgMi41M2EuMjUuMjUgMCAwMS0uMDYuMTYuMi4yIDAgMDEtLjE1LjA2aC0uOTRhLjIuMiAwIDAxLS4yLS4xNmMtLjIzLTEtLjc3LTEuMzItMi4yNi0xLjMyLTEuNjYgMC0xLjg1LjU4LTEuODUgMXMuMjMuNjggMi40NyAxIDMuMjcuNzEgMy4yNyAyLjI3LTEuMzEgMi40Mi0zLjYgMi40MnpNNTIuMTkgNTBhMS4zOSAxLjM5IDAgMTEtMS4zOS0xLjM5QTEuMzkgMS4zOSAwIDAxNTIuMTkgNTB6bS0yLjU2IDBhMS4xNyAxLjE3IDAgMDAxLjE2IDEuMTdBMS4xOSAxLjE5IDAgMDA1MiA1MGExLjE3IDEuMTcgMCAxMC0yLjM0IDB6bS42NC0uNzhoLjU0Yy4xOSAwIC41NSAwIC41NS40MWEuMzUuMzUgMCAwMS0uMy4zOGMuMjIgMCAuMjMuMTYuMjYuMzZhMiAyIDAgMDAuMDguNDFoLS4zM2MwLS4wNy0uMDYtLjQ3LS4wNi0uNDlzMC0uMTQtLjE2LS4xNGgtLjI3di42M2gtLjMxem0uMy42OGguMjRhLjIxLjIxIDAgMDAuMjQtLjIyYzAtLjIxLS4xNS0uMjEtLjIzLS4yMWgtLjI1eiIvPjxwYXRoIGQ9Ik0xNy4xNyAzMS44OGEuOTQuOTQgMCAwMC0uNDYtLjgxbC03LjY2LTQuNGEuOTQuOTQgMCAwMC0uNDMtLjEzaC0uMDdhLjk0Ljk0IDAgMDAtLjQzLjEzbC03LjY2IDQuNGEuOTQuOTQgMCAwMC0uNDYuODF2MTEuODdhLjQ1LjQ1IDAgMDAuMjMuNC40Ny40NyAwIDAwLjQ2IDBsNC41NS0yLjYxYS45Mi45MiAwIDAwLjQ2LS44di01LjU1YS45NC45NCAwIDAxLjQ2LS44bDEuOTQtMS4xMmExIDEgMCAwMS40Ny0uMTIgMSAxIDAgMDEuNDYuMTJMMTEgMzQuMzlhLjkzLjkzIDAgMDEuNDcuOHY1LjU1YS45Mi45MiAwIDAwLjQ2LjhsNC41NSAyLjYxYS40Ni40NiAwIDAwLjY5LS40ek01NCAxNS41NmEuNDYuNDYgMCAwMC0uNjguNHYxMS43NmEuMzMuMzMgMCAwMS0uMTcuMjguMzEuMzEgMCAwMS0uMzIgMGwtMS45Mi0xLjExYS45Mi45MiAwIDAwLS45MiAwbC03LjY3IDQuNDJhLjkzLjkzIDAgMDAtLjQ2LjhWNDFhLjk0Ljk0IDAgMDAuNDYuODFMNTAgNDYuMTlhLjg5Ljg5IDAgMDAuOTIgMGw3LjY3LTQuNDJhLjk0Ljk0IDAgMDAuNDYtLjgxdi0yMmEuOTEuOTEgMCAwMC0uNDgtLjh6bS0uNzEgMjIuNWEuMjMuMjMgMCAwMS0uMTEuMmwtMi42MyAxLjUxYS4yLjIgMCAwMS0uMjMgMGwtMi42Mi0xLjUxYS4yMy4yMyAwIDAxLS4xMS0uMlYzNWEuMjMuMjMgMCAwMS4xMS0uMmwyLjY0LTEuNTJhLjI0LjI0IDAgMDEuMjMgMGwyLjYzIDEuNTJhLjIzLjIzIDAgMDEuMTEuMnptMjYuMjUtMy4xMmEuOTMuOTMgMCAwMC40Ni0uOFYzMmEuOTMuOTMgMCAwMC0uNDYtLjhsLTcuNjEtNC40MmEuOTEuOTEgMCAwMC0uOTMgMGwtNy42NiA0LjQyYS45MS45MSAwIDAwLS40Ni44djguODRhLjk0Ljk0IDAgMDAuNDYuODFMNzEgNDZhLjkuOSAwIDAwLjkgMGw0LjYxLTIuNTZhLjQ5LjQ5IDAgMDAuMjQtLjQuNDcuNDcgMCAwMC0uMjQtLjQxbC03Ljc1LTQuNDNhLjQ3LjQ3IDAgMDEtLjIzLS40VjM1YS40Ni40NiAwIDAxLjIzLS40bDIuNC0xLjM5YS40Ny40NyAwIDAxLjQ2IDBMNzQgMzQuNjNhLjQ1LjQ1IDAgMDEuMjQuNHYyLjE4YS40Ni40NiAwIDAwLjY5LjR6IiBmaWxsPSIjMzMzIiBmaWxsLXJ1bGU9ImV2ZW5vZGQiLz48cGF0aCBkPSJNNzEuMzUgMzQuNTNhLjE1LjE1IDAgMDEuMTggMGwxLjQ3Ljg0YS4yMi4yMiAwIDAxLjA5LjE2djEuN2EuMTkuMTkgMCAwMS0uMDkuMTVsLTEuNDcuODVhLjE5LjE5IDAgMDEtLjE4IDBsLTEuNDctLjg1YS4xOS4xOSAwIDAxLS4wOS0uMTV2LTEuN2EuMjIuMjIgMCAwMS4wOS0uMTZ6IiBmaWxsLXJ1bGU9ImV2ZW5vZGQiIGZpbGw9IiM2NzllNjMiLz48cGF0aCBkPSJNMzAgMjYuODJhLjk0Ljk0IDAgMDAtLjkyIDBsLTcuNjIgNC40QS45MS45MSAwIDAwMjEgMzJ2OC44YS44OS44OSAwIDAwLjQ2Ljc5TDI5LjA3IDQ2YS44OS44OSAwIDAwLjkzIDBsNy42MS00LjRhLjg5Ljg5IDAgMDAuNDYtLjc5VjMyYS45MS45MSAwIDAwLS40Ni0uOHoiIGZpbGwtcnVsZT0iZXZlbm9kZCIgZmlsbD0idXJsKCNhKSIvPjxnIGNsaXAtcGF0aD0idXJsKCNjKSI+PHBhdGggY2xhc3M9ImciIGQ9Ik0yOS4wNSAyNi44MmwtNy42NCA0LjRhMSAxIDAgMDAtLjQ5Ljh2OC44YS45MS45MSAwIDAwLjI0LjU4bDguNTgtMTQuNjdhLjkzLjkzIDAgMDAtLjY5LjA5em0uNzMgMTkuMjhBLjg1Ljg1IDAgMDAzMCA0Nmw3LjYyLTQuNGEuOTEuOTEgMCAwMC40OC0uNzlWMzJhLjkuOSAwIDAwLS4yOC0uNjR6Ii8+PHBhdGggZD0iTTM3LjYyIDMxLjIyTDMwIDI2LjgyYTEuMTcgMS4xNyAwIDAwLS4yNC0uMDlsLTguNiAxNC42N2EuNzUuNzUgMCAwMC4yNi4yMUwyOS4wNyA0NmEuODkuODkgMCAwMC43MS4wOWw4LTE0LjcyYTEgMSAwIDAwLS4xNi0uMTV6IiBmaWxsPSJ1cmwoI2QpIi8+PHBhdGggY2xhc3M9ImciIGQ9Ik0zOC4xIDQwLjgyVjMyYTEgMSAwIDAwLS40OC0uOEwzMCAyNi44MmEuOTQuOTQgMCAwMC0uMjgtLjFMMzguMDcgNDFhLjc2Ljc2IDAgMDAuMDMtLjE4em0tMTYuNjktOS42YTEgMSAwIDAwLS40OS44djguOGEuOTMuOTMgMCAwMC41Ljc5TDI5LjA3IDQ2YS44OC44OCAwIDAwLjU5LjEybC04LjItMTQuOTR6Ii8+PHBhdGggZmlsbD0idXJsKCNlKSIgZD0iTTI4LjgxIDI1LjJsLS4xLjA3aC4xNGwtLjA0LS4wN3oiLz48cGF0aCBkPSJNMzcuNjIgNDEuNjFhLjkuOSAwIDAwLjQ1LS41OEwyOS43IDI2LjcyYS45Mi45MiAwIDAwLS42NS4xbC03LjU5IDQuMzcgOC4yIDE0Ljk0QTEuMDYgMS4wNiAwIDAwMzAgNDZ6IiBmaWxsPSJ1cmwoI2YpIi8+PHBhdGggZmlsbD0idXJsKCNnKSIgZD0iTTM4LjMzIDQxLjQ3bC0uMDUtLjA4di4xMWwuMDUtLjAzeiIvPjxwYXRoIGQ9Ik0zNy42MiA0MS42MUwzMCA0NmExLjA2IDEuMDYgMCAwMS0uMzQuMTJsLjE1LjI4IDguNDctNC45MXYtLjExbC0uMjEtLjM4YS45LjkgMCAwMS0uNDUuNjF6IiBmaWxsPSJ1cmwoI2gpIi8+PHBhdGggZD0iTTM3LjYyIDQxLjYxTDMwIDQ2YTEuMDYgMS4wNiAwIDAxLS4zNC4xMmwuMTUuMjggOC40Ny00Ljkxdi0uMTFsLS4yMS0uMzhhLjkuOSAwIDAxLS40NS42MXoiIGZpbGw9InVybCgjaSkiLz48L2c+PC9zdmc+"
                },
                new Platform
                {
                    Name = "php",
                    PlatformTypes = PlatformTypes.Server,
                    AvatarUrl = "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdCb3g9IjAgMCA4MCA4MCI+PHBhdGggZmlsbD0iIzg4OTJiZiIgZD0iTTAgMGg4MHY4MEgweiIvPjxwYXRoIGQ9Ik0xMy43MyAyOS40MWg5LjQ5cTQuMTkgMCA2LjA2IDIuMzl0MS4yNCA2LjQ1YTEyLjM4IDEyLjM4IDAgMDEtMS4xIDMuNjcgMTAuNzQgMTAuNzQgMCAwMS0yLjI3IDMuMjQgNy45MiA3LjkyIDAgMDEtMy43OSAyLjMzIDE3LjQ2IDE3LjQ2IDAgMDEtNC4xOC40OWgtNC4yNWwtMS4zNCA2LjdIOC42Nmw1LjA3LTI1LjI3bTQuMTQgNEwxNS43NSA0NGEzIDMgMCAwMC40MiAwaC41YTE4LjU1IDE4LjU1IDAgMDA1LjY3LS42N2MxLjUxLS40OSAyLjUyLTIuMjEgMy01LjE0LjQzLTIuNDcgMC0zLjg5LTEuMjctNC4yN2ExNi4zNCAxNi4zNCAwIDAwLTQuNzEtLjUzIDcuODggNy44OCAwIDAxLS44MiAwaC0uNzRtMTguMzMtMTAuNzFINDFsLTEuMzggNi43M0g0NGE4LjgyIDguODIgMCAwMTUuMzkgMS40OGMxLjIuOTQgMS41NiAyLjcyIDEuMDYgNS4zNkw0OC4xIDQ4aC01bDIuMjctMTEuMjFhMy4xNyAzLjE3IDAgMDAtLjIyLTIuNSAzIDMgMCAwMC0yLjQ0LS43NGgtMy45M0wzNS45MSA0OEgzMWw1LjEtMjUuM20xOS42MiA2LjcxaDkuNDlxNC4xOSAwIDYuMDYgMi4zOXQxLjI0IDYuNDVhMTIuMzggMTIuMzggMCAwMS0xLjEgMy42NyAxMC43NCAxMC43NCAwIDAxLTIuMjcgMy4yNCA3LjkyIDcuOTIgMCAwMS0zLjc5IDIuMzMgMTcuNDYgMTcuNDYgMCAwMS00LjE4LjQ5aC00LjI1bC0xLjM0IDYuN2gtNC45M2w1LjA3LTI1LjI3bTQuMTQgNEw1Ny43NCA0NGEzIDMgMCAwMC40MiAwaC41YTE4LjU1IDE4LjU1IDAgMDA1LjY3LS42N2MxLjUxLS40OSAyLjUyLTIuMjEgMy01LjE0LjQzLTIuNDcgMC0zLjg5LTEuMjctNC4yN2ExNi4yNSAxNi4yNSAwIDAwLTQuNzEtLjUzIDcuODggNy44OCAwIDAxLS44MiAwaC0uNzQiIGZpbGw9IiNmZmYiLz48L3N2Zz4="
                },
                new Platform
                {
                    Name = "python",
                    PlatformTypes = PlatformTypes.Server,
                    AvatarUrl = "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdCb3g9IjAgMCA4MCA4MCI+PGRlZnM+PGxpbmVhckdyYWRpZW50IGlkPSJhIiB4MT0iMTM2LjEzIiB5MT0iLTIzMy44OCIgeDI9IjIxMy43MyIgeTI9Ii0zMDAuNjQiIGdyYWRpZW50VHJhbnNmb3JtPSJtYXRyaXgoLjU2IDAgMCAtLjU3IC03OC4wOCAtMTMwLjU2KSIgZ3JhZGllbnRVbml0cz0idXNlclNwYWNlT25Vc2UiPjxzdG9wIG9mZnNldD0iMCIgc3RvcC1jb2xvcj0iIzVhOWZkNCIvPjxzdG9wIG9mZnNldD0iMSIgc3RvcC1jb2xvcj0iIzMwNjk5OCIvPjwvbGluZWFyR3JhZGllbnQ+PGxpbmVhckdyYWRpZW50IGlkPSJiIiB4MT0iMjQzLjczIiB5MT0iLTM0MS4wNSIgeDI9IjIxNi4wMiIgeTI9Ii0zMDEuODUiIGdyYWRpZW50VHJhbnNmb3JtPSJtYXRyaXgoLjU2IDAgMCAtLjU3IC03OC4wOCAtMTMwLjU2KSIgZ3JhZGllbnRVbml0cz0idXNlclNwYWNlT25Vc2UiPjxzdG9wIG9mZnNldD0iMCIgc3RvcC1jb2xvcj0iI2ZmZDQzYiIvPjxzdG9wIG9mZnNldD0iMSIgc3RvcC1jb2xvcj0iI2ZmZTg3MyIvPjwvbGluZWFyR3JhZGllbnQ+PC9kZWZzPjxwYXRoIGQ9Ik0zOS41MyAwYTU0LjQ5IDU0LjQ5IDAgMDAtOS4xMi43OGMtOC4wOCAxLjQzLTkuNTQgNC40MS05LjU0IDkuOTJWMThINDB2Mi40SDEzLjdjLTUuNTQgMC0xMC40IDMuMzMtMTEuOTIgOS42N0MwIDM3LjM0IDAgNDEuODggMS43OCA0OS40N2MxLjM2IDUuNjUgNC42IDkuNjggMTAuMTQgOS42OGg2LjU3di04LjcyYTEyLjEzIDEyLjEzIDAgMDExMS45Mi0xMS44NmgxOS4wNmE5LjYxIDkuNjEgMCAwMDkuNTMtOS43VjEwLjdjMC01LjE3LTQuMzYtOS4wNi05LjU0LTkuOTJBNTkuNjMgNTkuNjMgMCAwMDM5LjUzIDB6TTI5LjIxIDUuODVhMy42NCAzLjY0IDAgMTEtMy41OCAzLjY1IDMuNjIgMy42MiAwIDAxMy41OC0zLjY1eiIgZmlsbD0idXJsKCNhKSIvPjxwYXRoIGQ9Ik02MS4zOSAyMC40djguNDdBMTIuMjQgMTIuMjQgMCAwMTQ5LjQ3IDQxSDMwLjQxYTkuNzQgOS43NCAwIDAwLTkuNTQgOS43djE4LjE1YzAgNS4xNyA0LjQ5IDguMjEgOS41NCA5LjY5YTMxLjg3IDMxLjg3IDAgMDAxOS4wNiAwYzQuODEtMS4zOSA5LjUzLTQuMTkgOS41My05LjY5di03LjI4SDQwdi0yLjQyaDI4LjU2YzUuNTQgMCA3LjYxLTMuODcgOS41NC05LjY4IDItNiAxLjkxLTExLjczIDAtMTkuNC0xLjM3LTUuNTItNC05LjY3LTkuNTQtOS42N3ptLTEwLjcyIDQ2YTMuNjQgMy42NCAwIDExLTMuNTggMy42MyAzLjYgMy42IDAgMDEzLjU4LTMuNjF6IiBmaWxsPSJ1cmwoI2IpIi8+PC9zdmc+"
                },
                new Platform
                {
                    Name = "django",
                    PlatformTypes = PlatformTypes.Server,
                    AvatarUrl = "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdCb3g9IjAgMCA4MCA4MCI+PGRlZnM+PHN0eWxlPi5ie2ZpbGw6I2ZmZn08L3N0eWxlPjwvZGVmcz48cGF0aCBmaWxsPSIjMDkyZTIwIiBkPSJNMC0uMTFoODAuMTFWODBIMHoiLz48cGF0aCBjbGFzcz0iYiIgZD0iTTEzLjggMjguMjRoMy43OXYxNy41NGEyNSAyNSAwIDAxLTQuOTIuNTJjLTQuNjMgMC03LTIuMDktNy02LjFzMi41Ni02LjM4IDYuNTItNi4zOGE2IDYgMCAwMTEuNjUuMnYtNS43OHptMCA4LjgzYTMuNjkgMy42OSAwIDAwLTEuMjgtLjJjLTEuOTIgMC0zIDEuMTgtMyAzLjI1czEuMDYgMy4xMyAzIDMuMTNhOS40NSA5LjQ1IDAgMDAxLjMxLS4xeiIvPjxwYXRoIGNsYXNzPSJiIiBkPSJNMjMuNjEgMzQuMDl2OC43OWMwIDMtLjIyIDQuNDctLjg4IDUuNzNhNi4wOCA2LjA4IDAgMDEtMy4xIDIuOGwtMy41Mi0xLjY3YTUuNSA1LjUgMCAwMDMtMi41M2MuNTQtMS4wOS43Mi0yLjM0LjcyLTUuNjR2LTcuNDh6bS0zLjc4LTUuODNoMy43OHYzLjg5aC0zLjc4ek0yNS45IDM1YTExLjM4IDExLjM4IDAgMDE1LTEuMTRjMS45NCAwIDMuMjIuNTIgMy43OSAxLjUzYTUuODEgNS44MSAwIDAxLjQyIDIuODh2Ny43YTQyLjg0IDQyLjg0IDAgMDEtNS40MS40MmMtMy4xOCAwLTQuNjEtMS4xMS00LjYxLTMuNTcgMC0yLjY2IDEuOS0zLjg5IDYuNTUtNC4yOHYtLjg0YzAtLjY5LS4zNS0uOTMtMS4zMS0uOTNhMTAgMTAgMCAwMC00LjQ1IDEuMTVWMzV6bTUuOTMgNmMtMi41MS4yNS0zLjMyLjY0LTMuMzIgMS42MyAwIC43My40NyAxLjA4IDEuNSAxLjA4YTEwLjcgMTAuNyAwIDAwMS44Mi0uMTdWNDF6TTM3IDM0LjY4YTIyLjc5IDIyLjc5IDAgMDE2LS44NiA1LjY4IDUuNjggMCAwMTQuMTggMS4zMWMuNzkuODEgMSAxLjY5IDEgMy41OXY3LjQzaC0zLjgzdi03LjI4YzAtMS40NS0uNDktMi0xLjg0LTJhNS43NCA1Ljc0IDAgMDAtMS43NS4yN3Y5SDM3VjM0LjY4em0xMi42MSAxMy41NGE4LjczIDguNzMgMCAwMDQuMDYgMWMyLjQ5IDAgMy41NS0xIDMuNTUtMy40MnYtLjA3YTUuMTkgNS4xOSAwIDAxLTIuNDYuNTJjLTMuMzMgMC01LjQ0LTIuMTktNS40NC01LjY2IDAtNC4zMSAzLjEyLTYuNzQgOC42Ni02Ljc0YTIzLjgyIDIzLjgyIDAgMDE0Ljk0LjU0bC0xLjI5IDIuNzNjLTEtLjE5LS4wOSAwLS44NS0uMXY2LjYxYzAgMy4yNS0uMjggNC43OC0xLjA5IDYtMS4xOCAxLjg1LTMuMjIgMi43Ni02LjEyIDIuNzZhMTEgMTEgMCAwMS00LjA5LS43NHYtMy40M3ptNy41My0xMS4zMmgtLjM5YTQuMDggNC4wOCAwIDAwLTIuMTkuNTQgMi45NCAyLjk0IDAgMDAtMS4zOCAyLjc4YzAgMS44OS45NCAzIDIuNjEgM2E0LjY3IDQuNjcgMCAwMDEuNDMtLjIydi02LjF6bTExLjY2LTMuMTNjMy43OSAwIDYuMTEgMi4zOSA2LjExIDYuMjVzLTIuNDIgNi40NS02LjI1IDYuNDUtNi4xMy0yLjM5LTYuMTMtNi4yMyAyLjQxLTYuNDcgNi4yNy02LjQ3em0tLjA3IDkuNjVjMS40NSAwIDIuMzEtMS4yMSAyLjMxLTMuM3MtLjgzLTMuMy0yLjI4LTMuMy0yLjM3IDEuMjEtMi4zNyAzLjMuODYgMy4zIDIuMzQgMy4zeiIvPjwvc3ZnPg=="
                },
                new Platform
                {
                    Name = "Native",
                    PlatformTypes =  PlatformTypes.Server | PlatformTypes.Desktop,
                    AvatarUrl = "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdCb3g9IjAgMCA4MCA4MCI+PGRlZnM+PHN0eWxlPi5ke2ZpbGw6I2ZmZn08L3N0eWxlPjwvZGVmcz48cGF0aCBkPSJNNzYuMjUgMjZ2MjhhMTIgMTIgMCAwMS0xLjY0IDZMNDAgNDBsMzQuNjItMjBhMTEuOTQgMTEuOTQgMCAwMTEuNjMgNnoiIGZpbGw9IiMwMDU5OWMiLz48cGF0aCBkPSJNNzQuNjIgMjBMNDAgNDAgNS40MSA2MGExMS45MiAxMS45MiAwIDAxLTEuNjYtNlYyNmExMiAxMiAwIDAxNi0xMC4zOUwzNCAxLjYxYTEyIDEyIDAgMDExMiAwbDI0LjI1IDE0QTExLjgyIDExLjgyIDAgMDE3NC42MiAyMHoiIGZpbGw9IiM2NTlhZDIiLz48cGF0aCBkPSJNNDAgNDBsMzQuNjEgMjBhMTIgMTIgMCAwMS00LjM2IDQuMzRMNDYgNzguMzlhMTIgMTIgMCAwMS0xMiAwbC0yNC4yNS0xNGExMiAxMiAwIDAxLTQuMzQtNC4zMnoiIGZpbGw9IiMwMDQ0ODIiLz48cGF0aCBjbGFzcz0iZCIgZD0iTTYxLjc5IDM4LjVoMi41MXYzLjA0aC0yLjUxdjIuNTFoLTMuMDV2LTIuNTFoLTIuNVYzOC41aDIuNXYtMi41MWgzLjA1djIuNTF6bTkuODEgMGgyLjV2My4wNGgtMi41djIuNTFoLTMuMDV2LTIuNTFoLTIuNVYzOC41aDIuNXYtMi41MWgzLjA1djIuNTF6Ii8+PHBhdGggY2xhc3M9ImQiIGQ9Ik02MSA1Mi4xNWEyNC4yMiAyNC4yMiAwIDExMC0yNC4yNkw1MC4zOCAzNHEtLjIxLS4zNy0uNDUtLjcyQTEyIDEyIDAgMTA1MC4zNiA0NnoiLz48L3N2Zz4="
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
        private static IList<Role> GenerateRoles(int count = _numberOfRoles)
        {
            return new Faker<Role>()
                .UseSeed(3517)
                .RuleFor(r => r.Id, f => ++f.IndexVariable)
                .RuleFor(r => r.Name, f => f.Lorem.Word())
                .RuleFor(r => r.Description, f => f.Lorem.Sentences(separator: " "))
                .Generate(count);
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
                .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                .RuleFor(u => u.LastName, f => f.Name.LastName())
                .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName).ToLower())
                .RuleFor(u => u.PasswordHash, f => f.Random.Hash(32))
                .RuleFor(u => u.RegisteredAt, f => f.Date.Past(2, new DateTime(2021, 7, 20)))
                .RuleFor(u => u.AvatarUrl, f => f.Internet.Avatar())
                .Generate(count);
        }
    }
}
