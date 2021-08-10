using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Watchdog.Core.DAL.Migrations
{
    public partial class ProjectUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AvatarUrl",
                table: "Platforms",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlatformTypes",
                table: "Platforms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ApplicationTeams",
                keyColumn: "Id",
                keyValue: 1,
                column: "ApplicationId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ApplicationTeams",
                keyColumn: "Id",
                keyValue: 3,
                column: "ApplicationId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "ApplicationTeams",
                keyColumn: "Id",
                keyValue: 4,
                column: "ApplicationId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ApplicationTeams",
                keyColumn: "Id",
                keyValue: 5,
                column: "ApplicationId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ApplicationTeams",
                keyColumn: "Id",
                keyValue: 6,
                column: "ApplicationId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ApplicationTeams",
                keyColumn: "Id",
                keyValue: 9,
                column: "ApplicationId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ApplicationTeams",
                keyColumn: "Id",
                keyValue: 10,
                column: "ApplicationId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ApplicationTeams",
                keyColumn: "Id",
                keyValue: 12,
                column: "ApplicationId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ApplicationTeams",
                keyColumn: "Id",
                keyValue: 13,
                column: "ApplicationId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ApplicationTeams",
                keyColumn: "Id",
                keyValue: 14,
                column: "ApplicationId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ApplicationTeams",
                keyColumn: "Id",
                keyValue: 17,
                column: "ApplicationId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ApplicationTeams",
                keyColumn: "Id",
                keyValue: 19,
                column: "ApplicationId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ApplicationTeams",
                keyColumn: "Id",
                keyValue: 20,
                column: "ApplicationId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "SecurityToken" },
                values: new object[] { new DateTime(2019, 8, 18, 22, 5, 24, 907, DateTimeKind.Unspecified).AddTicks(5351), 15, "unleash back-end supply-chains", "Fisher, Lehner and Champlin", 2, "2c306c5e42126fd20bd128d2f8c1e307" });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId", "SecurityToken" },
                values: new object[] { new DateTime(2020, 8, 3, 23, 52, 58, 240, DateTimeKind.Unspecified).AddTicks(6701), 8, "incentivize robust applications", "Muller Inc", 2, 3, "b98db018db344bc481419654e6fee6db" });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Description", "Name", "OrganizationId", "PlatformId", "SecurityToken" },
                values: new object[] { new DateTime(2020, 1, 25, 22, 41, 22, 327, DateTimeKind.Unspecified).AddTicks(9806), "drive clicks-and-mortar e-services", "Mohr, Rosenbaum and Balistreri", 4, 2, "ec3f03e051b5d6e399dc98eb83345815" });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "CreatedBy", "Description", "Name", "PlatformId", "SecurityToken" },
                values: new object[] { new DateTime(2021, 4, 21, 14, 16, 33, 196, DateTimeKind.Unspecified).AddTicks(986), 20, "architect sexy partnerships", "Conroy, Hane and Boyer", 8, "f94490637f3b5d86c09ad05bb62664b8" });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId", "SecurityToken" },
                values: new object[] { new DateTime(2019, 9, 25, 2, 56, 57, 323, DateTimeKind.Unspecified).AddTicks(3454), 9, "enhance holistic action-items", "Wiza LLC", 4, 9, "9655ae4c809e4e3983efc33bafd62d75" });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Description", "Name", "OrganizationId", "PlatformId", "SecurityToken" },
                values: new object[] { new DateTime(2020, 6, 28, 13, 18, 7, 643, DateTimeKind.Unspecified).AddTicks(9586), "architect innovative infomediaries", "Hintz - Runte", 5, 2, "baf221ea765f963abb1d9b933c75226a" });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId", "SecurityToken" },
                values: new object[] { new DateTime(2021, 3, 1, 22, 43, 39, 144, DateTimeKind.Unspecified).AddTicks(7803), 11, "deliver web-enabled portals", "Kutch, Schneider and Satterfield", 1, 6, "10aefaba124101bf59884fa27fbe3e44" });

            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId", "SecurityToken" },
                values: new object[,]
                {
                    { 13, new DateTime(2020, 8, 28, 1, 4, 9, 926, DateTimeKind.Unspecified).AddTicks(4139), 10, "extend plug-and-play relationships", "Hintz - Daniel", 1, 1, "97854c787524685abf92298ab776baac" },
                    { 14, new DateTime(2021, 5, 30, 7, 45, 50, 91, DateTimeKind.Unspecified).AddTicks(1381), 16, "optimize killer deliverables", "Runolfsson Inc", 4, 8, "c7988f7da32c60eeac50dca6261e7fc8" }
                });

            migrationBuilder.UpdateData(
                table: "Environments",
                keyColumn: "Id",
                keyValue: 1,
                column: "ApplicationId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Environments",
                keyColumn: "Id",
                keyValue: 2,
                column: "ApplicationId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Environments",
                keyColumn: "Id",
                keyValue: 5,
                column: "ApplicationId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvatarUrl", "Name", "PlatformTypes" },
                values: new object[] { "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdCb3g9IjAgMCA4MCA4MCI+PHBhdGggZD0iTTU4LjM3IDQ4Ljk0YTMuMzMgMy4zMyAwIDExMy4zMi0zLjMyIDMuMzMgMy4zMyAwIDAxLTMuMzIgMy4zMm0tMzYuNzQgMEEzLjMzIDMuMzMgMCAxMTI1IDQ1LjYyYTMuMzIgMy4zMiAwIDAxLTMuMzIgMy4zMm0zNy45My0yMGw2LjY0LTExLjVBMS4zOCAxLjM4IDAgMDA2My44MSAxNmwtNi43MyAxMS42OGE0MS43OSA0MS43OSAwIDAwLTM0LjE2IDBMMTYuMTkgMTZhMS4zOCAxLjM4IDAgMDAtMi4zOSAxLjM4bDYuNjQgMTEuNTFBMzkuMiAzOS4yIDAgMDAuMDkgNjAuMzJoNzkuODJhMzkuMiAzOS4yIDAgMDAtMjAuMzUtMzEuNCIgZmlsbD0iIzNkZGM4NCIvPjwvc3ZnPg==", "Android", 4 });

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AvatarUrl", "Name", "PlatformTypes" },
                values: new object[] { "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdCb3g9IjAgMCA4MCA4MCI+PHBhdGggZD0iTTcyLjUxIDU4LjQzYTQxLjc0IDQxLjc0IDAgMDEtMy4yOSA3LjggNTAuNTkgNTAuNTkgMCAwMS02LjU4IDkuNDUgMTEuODMgMTEuODMgMCAwMS02LjE0IDMuOTUgMTEuMzQgMTEuMzQgMCAwMS02LjczLS42MyA0NC44NyA0NC44NyAwIDAwLTQuOTItMS44MyAxNC43MiAxNC43MiAwIDAwLTkuNDcuODcgMzguNzMgMzguNzMgMCAwMS01IDEuNzMgOC40MyA4LjQzIDAgMDEtNy4zNC0xLjYxIDI0LjUxIDI0LjUxIDAgMDEtNC41OC00LjY5QTUwLjI3IDUwLjI3IDAgMDE4LjEyIDUwLjE2Yy0xLTUuOC0xLTExLjU3IDEuMTQtMTcuMTYgMi41OC02LjggNy4yOC0xMS4zNSAxNC40Ni0xMy4xM2ExNi40MiAxNi40MiAwIDAxMTAuMy45NGMxLjQ0LjU4IDIuOSAxLjExIDQuMzYgMS42NmE1LjggNS44IDAgMDA0LjIgMGMyLjE1LS44IDQuMjgtMS42MyA2LjQ1LTIuMzcgNy4wNi0yLjM5IDE2LjMzIDAgMjEgNi43MmwuNDMuNjNjLTUuNzUgMy44NS05IDkuMDYtOC41NyAxNi4xNXM0LjM1IDExLjgxIDEwLjYyIDE0LjgzeiIvPjxwYXRoIGQ9Ik01NS45MiAwYzEuMzYgOS4wNy02LjgzIDE5Ljc1LTE2LjMyIDE4Ljg2YTE2LjIzIDE2LjIzIDAgMDE0LjE5LTEyLjU4QTE3LjQ5IDE3LjQ5IDAgMDE1NS45MiAweiIvPjwvc3ZnPg==", "IOS", 4 });

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AvatarUrl", "Name", "PlatformTypes" },
                values: new object[] { "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdCb3g9IjAgMCA4MCA4MCI+PHBhdGggZmlsbD0iIzUxMmJkNCIgZD0iTTAgMGg4MHY4MEgweiIvPjxwYXRoIGQ9Ik0xNC4yNiA1MS4xMWEyIDIgMCAwMS0xLjQ0LS41NiAxLjkgMS45IDAgMDEwLTIuNzcgMiAyIDAgMDExLjQ0LS41OCAyIDIgMCAwMTEuNDUuNTggMS44OCAxLjg4IDAgMDEwIDIuNzcgMiAyIDAgMDEtMS40NS41NnptMjIuNjEtLjMyaC0zLjY4bC05LjY4LTE1LjI4YTYuNzggNi43OCAwIDAxLS42MS0xLjJoLS4wOWEyMC41MyAyMC41MyAwIDAxLjEyIDIuODV2MTMuNjNoLTMuMjZWMzBoMy45MkwzMyA0NC45MmMuNC42Mi42NSAxIC43NyAxLjI4aC4wNWExOS42OCAxOS42OCAwIDAxLS4xNC0yLjhWMzBoMy4yNHptMTUuODQgMEg0MS4zM1YzMGgxMC45M3YyLjkzaC03LjU3djUuODloN3YyLjkxaC03djYuMTVoOHptMTYuMTgtMTcuODZoLTUuODN2MTcuODZoLTMuMzdWMzIuOTNoLTUuODFWMzBoMTV6IiBmaWxsPSIjZmZmIi8+PC9zdmc+", ".NET", 10 });

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AvatarUrl", "Name", "PlatformTypes" },
                values: new object[] { "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdCb3g9IjAgMCA4MCA4MCI+PHBhdGggZmlsbD0iIzUxMmJkNCIgZD0iTTAgMGg4MHY4MEgweiIvPjxwYXRoIGQ9Ik0xNC4yNiA1MS4xMWEyIDIgMCAwMS0xLjQ0LS41NiAxLjkgMS45IDAgMDEwLTIuNzcgMiAyIDAgMDExLjQ0LS41OCAyIDIgMCAwMTEuNDUuNTggMS44OCAxLjg4IDAgMDEwIDIuNzcgMiAyIDAgMDEtMS40NS41NnptMjIuNjEtLjMyaC0zLjY4bC05LjY4LTE1LjI4YTYuNzggNi43OCAwIDAxLS42MS0xLjJoLS4wOWEyMC41MyAyMC41MyAwIDAxLjEyIDIuODV2MTMuNjNoLTMuMjZWMzBoMy45MkwzMyA0NC45MmMuNC42Mi42NSAxIC43NyAxLjI4aC4wNWExOS42OCAxOS42OCAwIDAxLS4xNC0yLjhWMzBoMy4yNHptMTUuODQgMEg0MS4zM1YzMGgxMC45M3YyLjkzaC03LjU3djUuODloN3YyLjkxaC03djYuMTVoOHptMTYuMTgtMTcuODZoLTUuODN2MTcuODZoLTMuMzdWMzIuOTNoLTUuODFWMzBoMTV6IiBmaWxsPSIjZmZmIi8+PC9zdmc+", "ASP.NET Core", 2 });

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AvatarUrl", "Name", "PlatformTypes" },
                values: new object[] { "https://s1.sentry-cdn.com/_static/dist/sentry/assets/flutter.e45027e743d56859f384.svg", "Flutter", 4 });

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AvatarUrl", "Name", "PlatformTypes" },
                values: new object[] { "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdCb3g9IjAgMCA4MCA4MCI+PGRlZnM+PHN0eWxlPi5he2ZpbGw6IzJkYmNhZn08L3N0eWxlPjwvZGVmcz48cGF0aCBjbGFzcz0iYSIgZD0iTTYgMzQuMTFjLS4xNiAwLS4yLS4wOC0uMTItLjJsLjgyLTFhLjU1LjU1IDAgMDEuNDMtLjJoMTMuOWMuMTYgMCAuMi4xMi4xMi4yNGwtLjY2IDFhLjYuNiAwIDAxLS4zOS4yM3pNLjE2IDM3LjY5Yy0uMTYgMC0uMi0uMDgtLjEyLS4ybC44Mi0xLjA1YS41Ni41NiAwIDAxLjQzLS4xOWgxNy43NmMuMTUgMCAuMjMuMTEuMTkuMjNsLS4zMS45NGEuMzQuMzQgMCAwMS0uMzUuMjN6bTkuNDIgMy41OGMtLjE1IDAtLjE5LS4xMS0uMTEtLjIzbC41NC0xYS41MS41MSAwIDAxLjM5LS4yNGg3Ljc5Yy4xNiAwIC4yMy4xMi4yMy4yN2wtLjA3Ljk0YS4zLjMgMCAwMS0uMjguMjd6TTUwIDMzLjRjLTIuNDUuNjMtNC4xMyAxLjEtNi41NCAxLjcyLS41OS4xNS0uNjIuMTktMS4xMy0uMzlhNS4xOCA1LjE4IDAgMDAtMS44My0xLjQ4IDYuNzcgNi43NyAwIDAwLTcgLjU4IDguMjkgOC4yOSAwIDAwLTQgNy40IDYuMSA2LjEgMCAwMDUuMjUgNi4xMiA3LjIyIDcuMjIgMCAwMDYuNjMtMi41N2MuMzUtLjQzLjY2LS45IDEuMDUtMS40NEgzNC45Yy0uODIgMC0xLS41MS0uNzQtMS4xNy41MS0xLjIxIDEuNDQtMy4yMyAyLTQuMjVhMSAxIDAgMDExLS42Mkg1MS4zYy0uMDggMS4wNS0uMDggMi4xLS4yNCAzLjE1YTE2LjU2IDE2LjU2IDAgMDEtMy4xOSA3LjY0IDE2LjIxIDE2LjIxIDAgMDEtMTEuMSA2LjYyIDEzLjc4IDEzLjc4IDAgMDEtMTAuNDgtMi41NyAxMi4yNCAxMi4yNCAwIDAxLTQuOTUtOC42NSAxNS4zMyAxNS4zMyAwIDAxMy4zMi0xMS40MSAxNy4yOCAxNy4yOCAwIDAxMTAuOS02Ljc0IDEzLjQzIDEzLjQzIDAgMDExMC4zMiAxLjkxIDEyLjEzIDEyLjEzIDAgMDE0LjUyIDUuNDljLjI0LjM1LjA4LjU1LS40LjY2eiIvPjxwYXRoIGNsYXNzPSJhIiBkPSJNNjIuOTEgNTQuOTRhMTQuNjEgMTQuNjEgMCAwMS05LjUxLTMuNDJBMTIuMjQgMTIuMjQgMCAwMTQ5LjE5IDQ0YTE0Ljg2IDE0Ljg2IDAgMDEzLjE2LTExLjc2IDE2LjMzIDE2LjMzIDAgMDExMC45MS02LjUxYzQtLjcgNy43MS0uMzEgMTEuMSAyYTEyLjE0IDEyLjE0IDAgMDE1LjQ5IDguNjggMTUuMDYgMTUuMDYgMCAwMS00LjQ4IDEzLjIxIDE3Ljg1IDE3Ljg1IDAgMDEtOS4zNSA1Yy0xLjAyLjE3LTIuMS4yMS0zLjExLjMyem05LjI3LTE1LjczYTEwLjk0IDEwLjk0IDAgMDAtLjEyLTEuMjkgNi40MyA2LjQzIDAgMDAtOC01LjE4IDguNSA4LjUgMCAwMC02LjgxIDYuNzggNi40MSA2LjQxIDAgMDAzLjU4IDcuMzYgNy4xMyA3LjEzIDAgMDA2LjM1LS4yMyA4LjU0IDguNTQgMCAwMDUtNy40NHoiLz48L3N2Zz4=", "Go", 2 });

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AvatarUrl", "Name", "PlatformTypes" },
                values: new object[] { "https://s1.sentry-cdn.com/_static/dist/sentry/assets/java.bed4fe4c69a3e913f854.svg", "Java", 10 });

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AvatarUrl", "Name", "PlatformTypes" },
                values: new object[] { "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdCb3g9IjAgMCA4MCA4MCI+PGRlZnM+PHN0eWxlPi5ie2ZpbGw6I2ZmZn08L3N0eWxlPjwvZGVmcz48cGF0aCBkPSJNNTcuMTcgNC42SDIyLjgzYTUuNjYgNS42NiAwIDAwLTQuOSAyLjgzTC43NiAzNy4xN2E1LjY3IDUuNjcgMCAwMDAgNS42NmwxNy4xNyAyOS43NGE1LjY2IDUuNjYgMCAwMDQuOSAyLjgzaDM0LjM0YTUuNjYgNS42NiAwIDAwNC45LTIuODNsMTcuMTctMjkuNzRhNS42NyA1LjY3IDAgMDAwLTUuNjZMNjIuMDcgNy40M2E1LjY2IDUuNjYgMCAwMC00LjktMi44M3oiIGZpbGw9IiM2NWE3NDEiLz48cGF0aCBjbGFzcz0iYiIgZD0iTTQwIDQxLjY2YTIuMjYgMi4yNiAwIDAxLTIuMjYtMi4yNlYxNy41N2EyLjI2IDIuMjYgMCAxMTQuNTIgMFYzOS40QTIuMjYgMi4yNiAwIDAxNDAgNDEuNjZ6Ii8+PHBhdGggY2xhc3M9ImIiIGQ9Ik00MCA2MGEyMS4xNSAyMS4xNSAwIDAxLTkuOTUtMzkuODEgMi4yNiAyLjI2IDAgMTEyLjE0IDQgMTYuNjIgMTYuNjIgMCAxMDE1LjYyIDAgMi4yNiAyLjI2IDAgMTEyLjE0LTRBMjEuMTUgMjEuMTUgMCAwMTQwIDYweiIvPjwvc3ZnPg==", "Spring boot", 2 });

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AvatarUrl", "Name", "PlatformTypes" },
                values: new object[] { "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdCb3g9IjAgMCA4MCA4MCI+PHBhdGggZD0iTTAgMGg4MHY4MEgwem00Ny42OCA2NmExMi43MiAxMi43MiAwIDAwNi4xNiA2LjEyIDE3LjYyIDE3LjYyIDAgMDAxMi41MS44OCA5LjU1IDkuNTUgMCAwMDcuMzktOC45MUExMCAxMCAwIDAwNzAuMDggNTUgMjIuNzcgMjIuNzcgMCAwMDY1IDUyYy0xLjY0LS43NC0zLjMtMS40My00LjkyLTIuMjJhNy4xMSA3LjExIDAgMDEtMi0xLjM4IDMuMjQgMy4yNCAwIDAxMS43MS01LjQgNC42OCA0LjY4IDAgMDE1LjA5IDEuODFjLjMuNC41Ny44MS44OCAxLjI1bDUuODEtMy43NGExMC44MSAxMC44MSAwIDAwLTctNS42MSAxNC45IDE0LjkgMCAwMC02LjItLjE5Yy00Ljc3Ljg1LTguMDkgNC4xOC04LjQ0IDguODZhMTAuMTcgMTAuMTcgMCAwMDMuMzUgOC44NCAyMS41NSAyMS41NSAwIDAwNS44NSAzLjQ0YzEuNS42NiAzIDEuMzIgNC40NiAyYTYuNTcgNi41NyAwIDAxMS41MSAxIDMuMzcgMy4zNyAwIDAxLS40OSA1LjQ3IDUgNSAwIDAxLTEuNTIuNjQgNy44NSA3Ljg1IDAgMDEtOC4zNy0yLjkyYy0uMzQtLjQ0LS42NS0uOS0xLTEuMzl6bS0yNi42LjgzYTExLjIzIDExLjIzIDAgMDA1IDUuNDMgMTQgMTQgMCAwMDEwLjIxLjkyIDkgOSAwIDAwNi43My02LjcgMTUuODIgMTUuODIgMCAwMC41MS00LjI4VjM3LjM5YTUuODggNS44OCAwIDAwLS4wNy0uNjdIMzZ2MjQuODNhMTMuMjYgMTMuMjYgMCAwMTAgMS42NyA5IDkgMCAwMS0uNDMgMS44NSAyLjY2IDIuNjYgMCAwMS0yIDEuNzFBNC41IDQuNSAwIDAxMjguMzEgNjVjLS4zOS0uNTctLjc1LTEuMTUtMS4xNi0xLjc4eiIgZmlsbD0iI2Y2ZGUxZSIvPjxwYXRoIGQ9Ik00Ny42OCA2Nmw2LTMuNTFjLjM0LjQ5LjY1IDEgMSAxLjM5YTcuODUgNy44NSAwIDAwOC4zNyAyLjkyIDUgNSAwIDAwMS41Mi0uNjQgMy4zNyAzLjM3IDAgMDAuNDktNS40NyA2LjU3IDYuNTcgMCAwMC0xLjUxLTFjLTEuNDctLjcxLTMtMS4zNy00LjQ2LTJhMjEuNTUgMjEuNTUgMCAwMS01Ljg1LTMuNDQgMTAuMTcgMTAuMTcgMCAwMS0zLjM1LTguODRjLjM1LTQuNjggMy42Ny04IDguNDQtOC44NmExNC45IDE0LjkgMCAwMTYuMi4xOSAxMC44MSAxMC44MSAwIDAxNyA1LjYxbC01LjgxIDMuNzRjLS4zMS0uNDQtLjU4LS44NS0uODgtMS4yNUE0LjY4IDQuNjggMCAwMDU5Ljc5IDQzYTMuMjQgMy4yNCAwIDAwLTEuNjUgNS4zOSA3LjExIDcuMTEgMCAwMDIgMS4zOGMxLjYyLjc5IDMuMjggMS40OCA0LjkyIDIuMjJhMjIuNzcgMjIuNzcgMCAwMTUuMDcgMyAxMCAxMCAwIDAxMy42NiA5LjFBOS41NSA5LjU1IDAgMDE2Ni4zNSA3M2ExNy42MiAxNy42MiAwIDAxLTEyLjUxLS44N0ExMi43MiAxMi43MiAwIDAxNDcuNjggNjZ6bS0yNi42Ljg1bDYuMDctMy42OGMuNDEuNjMuNzcgMS4yMSAxLjE2IDEuNzhhNC41IDQuNSAwIDAwNS4yNSAxLjg4IDIuNjYgMi42NiAwIDAwMi0xLjcxIDkgOSAwIDAwLjQ0LTEuODUgMTMuMjYgMTMuMjYgMCAwMDAtMS42N1YzNi43N2MyLjUtLjA4IDQuOTUgMCA3LjQ2IDBhNS44OCA1Ljg4IDAgMDEuMDcuNjd2MjQuNzhhMTUuODIgMTUuODIgMCAwMS0uNTEgNC4yOCA5IDkgMCAwMS02LjczIDYuNyAxNCAxNCAwIDAxLTEwLjIxLS45MiAxMS4yMyAxMS4yMyAwIDAxLTUtNS40M3oiIGZpbGw9IiMwMTAxMDAiLz48L3N2Zz4=", "JavaScript", 1 });

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AvatarUrl", "Name", "PlatformTypes" },
                values: new object[] { "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdCb3g9IjAgMCA4MCA4MCI+PHBhdGggZmlsbD0iI2RkMDAzMSIgZD0iTTQwIDBMMi43NiAxMy4yOGw1LjY4IDQ5LjI0TDQwIDgwbDMxLjU2LTE3LjQ4IDUuNjgtNDkuMjRMNDAgMHoiLz48cGF0aCBmaWxsPSIjYzMwMDJmIiBkPSJNNDAgMHY4Ljg4LS4wNFY4MGwzMS41Ni0xNy40OCA1LjY4LTQ5LjI0TDQwIDB6Ii8+PHBhdGggZD0iTTQwIDguODRMMTYuNzIgNjFoOC42OGw0LjY4LTExLjY4aDE5Ljc2TDU0LjUyIDYxaDguNjhMNDAgOC44NHptNi44IDMzLjMySDMzLjJMNDAgMjUuOHoiIGZpbGw9IiNmZmYiLz48L3N2Zz4=", "Angular", 1 });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "AvatarUrl", "Name", "PlatformTypes" },
                values: new object[,]
                {
                    { 17, "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdCb3g9IjAgMCA4MCA4MCI+PGRlZnM+PHN0eWxlPi5ke2ZpbGw6I2ZmZn08L3N0eWxlPjwvZGVmcz48cGF0aCBkPSJNNzYuMjUgMjZ2MjhhMTIgMTIgMCAwMS0xLjY0IDZMNDAgNDBsMzQuNjItMjBhMTEuOTQgMTEuOTQgMCAwMTEuNjMgNnoiIGZpbGw9IiMwMDU5OWMiLz48cGF0aCBkPSJNNzQuNjIgMjBMNDAgNDAgNS40MSA2MGExMS45MiAxMS45MiAwIDAxLTEuNjYtNlYyNmExMiAxMiAwIDAxNi0xMC4zOUwzNCAxLjYxYTEyIDEyIDAgMDExMiAwbDI0LjI1IDE0QTExLjgyIDExLjgyIDAgMDE3NC42MiAyMHoiIGZpbGw9IiM2NTlhZDIiLz48cGF0aCBkPSJNNDAgNDBsMzQuNjEgMjBhMTIgMTIgMCAwMS00LjM2IDQuMzRMNDYgNzguMzlhMTIgMTIgMCAwMS0xMiAwbC0yNC4yNS0xNGExMiAxMiAwIDAxLTQuMzQtNC4zMnoiIGZpbGw9IiMwMDQ0ODIiLz48cGF0aCBjbGFzcz0iZCIgZD0iTTYxLjc5IDM4LjVoMi41MXYzLjA0aC0yLjUxdjIuNTFoLTMuMDV2LTIuNTFoLTIuNVYzOC41aDIuNXYtMi41MWgzLjA1djIuNTF6bTkuODEgMGgyLjV2My4wNGgtMi41djIuNTFoLTMuMDV2LTIuNTFoLTIuNVYzOC41aDIuNXYtMi41MWgzLjA1djIuNTF6Ii8+PHBhdGggY2xhc3M9ImQiIGQ9Ik02MSA1Mi4xNWEyNC4yMiAyNC4yMiAwIDExMC0yNC4yNkw1MC4zOCAzNHEtLjIxLS4zNy0uNDUtLjcyQTEyIDEyIDAgMTA1MC4zNiA0NnoiLz48L3N2Zz4=", "Native", 10 },
                    { 11, "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdCb3g9IjAgMCA4MCA4MCI+PHBhdGggZmlsbD0iI2RkMDAzMSIgZD0iTTQwIDBMMi43NiAxMy4yOGw1LjY4IDQ5LjI0TDQwIDgwbDMxLjU2LTE3LjQ4IDUuNjgtNDkuMjRMNDAgMHoiLz48cGF0aCBmaWxsPSIjYzMwMDJmIiBkPSJNNDAgMHY4Ljg4LS4wNFY4MGwzMS41Ni0xNy40OCA1LjY4LTQ5LjI0TDQwIDB6Ii8+PHBhdGggZD0iTTQwIDguODRMMTYuNzIgNjFoOC42OGw0LjY4LTExLjY4aDE5Ljc2TDU0LjUyIDYxaDguNjhMNDAgOC44NHptNi44IDMzLjMySDMzLjJMNDAgMjUuOHoiIGZpbGw9IiNmZmYiLz48L3N2Zz4=", "AngularJs", 1 },
                    { 12, "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdCb3g9IjAgMCA4MCA4MCI+PGRlZnM+PHN0eWxlPi5ie2ZpbGw6IzYxZGFmYn08L3N0eWxlPjwvZGVmcz48cGF0aCBmaWxsPSIjMjAyMzJhIiBkPSJNMCAwaDgwdjgwSDB6Ii8+PGNpcmNsZSBjbGFzcz0iYiIgY3g9IjQwIiBjeT0iNDAiIHI9IjYuNTMiLz48cGF0aCBjbGFzcz0iYiIgZD0iTTQwIDU1QzE5LjQ3IDU1IDMuMzggNDguMzkgMy4zOCA0MFMxOS40NyAyNSA0MCAyNXMzNi42MiA2LjU3IDM2LjYyIDE1UzYwLjUzIDU1IDQwIDU1em0wLTI2Ljc1QzIwLjMgMjguMjIgNi41NyAzNC40MyA2LjU3IDQwUzIwLjMgNTEuNzggNDAgNTEuNzggNzMuNDMgNDUuNTcgNzMuNDMgNDAgNTkuNyAyOC4yMiA0MCAyOC4yMnoiLz48cGF0aCBjbGFzcz0iYiIgZD0iTTU0LjYyIDcyLjY2Yy0zLjI1IDAtNy4xNy0xLjc4LTExLjQzLTUuMjRDMzcuNTUgNjIuODMgMzEuODEgNTUuNzUgMjcgNDcuNDhjLTEwLjI3LTE3Ljc4LTEyLjYyLTM1LTUuMzUtMzkuMTkgMy43LTIuMTQgOS4wNy0uNjIgMTUuMTIgNC4zQzQyLjQ1IDE3LjE3IDQ4LjE5IDI0LjI1IDUzIDMyLjUyYzEwLjI3IDE3Ljc4IDEyLjYyIDM1IDUuMzUgMzkuMTlhNy4yNyA3LjI3IDAgMDEtMy43My45NXpNMjUuNDMgMTAuNTJhNC4xNiA0LjE2IDAgMDAtMi4xNS41M0MxOC40NiAxMy44MyAyMCAyOC44MyAyOS44IDQ1Ljg5YzQuNTggNy45NCAxMC4wNSAxNC43MSAxNS40IDE5IDQuODcgNCA5LjA3IDUuNDMgMTEuNTIgNCA0LjgyLTIuNzkgMy4zMy0xNy43OS02LjUyLTM0Ljg1LTQuNTgtNy45NC0xMC4wNS0xNC43LTE1LjQtMTktMy42Ni0yLjk1LTYuOTMtNC41Mi05LjM3LTQuNTJ6Ii8+PHBhdGggY2xhc3M9ImIiIGQ9Ik0yNS4zOCA3Mi42NmE3LjE3IDcuMTcgMCAwMS0zLjY5LTFDMTQuNDIgNjcuNTIgMTYuNzcgNTAuMyAyNyAzMi41MmM0Ljc3LTguMjcgMTAuNTEtMTUuMzUgMTYuMTUtMTkuOTMgNi4wNS00LjkyIDExLjQyLTYuNDUgMTUuMTItNC4zIDcuMjcgNC4yIDQuOTIgMjEuNDEtNS4zNSAzOS4xOS00Ljc3IDguMjctMTAuNTEgMTUuMzUtMTYuMTUgMTkuOTQtNC4yMiAzLjQ2LTguMTQgNS4yNC0xMS4zOSA1LjI0em0yOS4xOS02Mi4xNGMtMi40NCAwLTUuNzEgMS41Ny05LjM3IDQuNTQtNS4zNSA0LjM1LTEwLjgyIDExLjExLTE1LjQgMTlDMjAgNTEuMTcgMTguNDYgNjYuMTcgMjMuMjggNjljMi40NSAxLjQgNi42NS0uMDYgMTEuNTItNCA1LjM1LTQuMzQgMTAuODItMTEuMTEgMTUuNC0xOSA5Ljg1LTE3LjA2IDExLjM0LTMyLjA2IDYuNTItMzQuODRhNC4xNiA0LjE2IDAgMDAtMi4xNS0uNjR6Ii8+PC9zdmc+", "React", 1 },
                    { 13, "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHhtbG5zOnhsaW5rPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5L3hsaW5rIiB2aWV3Qm94PSIwIDAgODAgODAiPjxkZWZzPjxsaW5lYXJHcmFkaWVudCBpZD0iYSIgeDE9IjMyLjYyIiB5MT0iMzAuMSIgeDI9IjI1Ljc0IiB5Mj0iNDQuMTQiIGdyYWRpZW50VW5pdHM9InVzZXJTcGFjZU9uVXNlIj48c3RvcCBvZmZzZXQ9IjAiIHN0b3AtY29sb3I9IiMzZjg3M2YiLz48c3RvcCBvZmZzZXQ9Ii4zMyIgc3RvcC1jb2xvcj0iIzNmOGIzZCIvPjxzdG9wIG9mZnNldD0iLjY0IiBzdG9wLWNvbG9yPSIjM2U5NjM3Ii8+PHN0b3Agb2Zmc2V0PSIuOTMiIHN0b3AtY29sb3I9IiMzZGE5MmUiLz48c3RvcCBvZmZzZXQ9IjEiIHN0b3AtY29sb3I9IiMzZGFlMmIiLz48L2xpbmVhckdyYWRpZW50PjxsaW5lYXJHcmFkaWVudCBpZD0iZCIgeDE9IjI4LjM3IiB5MT0iMzcuNDUiIHgyPSI0Ny42OCIgeTI9IjIzLjE3IiBncmFkaWVudFVuaXRzPSJ1c2VyU3BhY2VPblVzZSI+PHN0b3Agb2Zmc2V0PSIuMTQiIHN0b3AtY29sb3I9IiMzZjg3M2YiLz48c3RvcCBvZmZzZXQ9Ii40IiBzdG9wLWNvbG9yPSIjNTI5ZjQ0Ii8+PHN0b3Agb2Zmc2V0PSIuNzEiIHN0b3AtY29sb3I9IiM2M2I2NDkiLz48c3RvcCBvZmZzZXQ9Ii45MSIgc3RvcC1jb2xvcj0iIzZhYmY0YiIvPjwvbGluZWFyR3JhZGllbnQ+PGxpbmVhckdyYWRpZW50IGlkPSJlIiB4MT0iMjAuNzIiIHkxPSIyNS4yMyIgeDI9IjM4LjMzIiB5Mj0iMjUuMjMiIGdyYWRpZW50VW5pdHM9InVzZXJTcGFjZU9uVXNlIj48c3RvcCBvZmZzZXQ9Ii4wOSIgc3RvcC1jb2xvcj0iIzZhYmY0YiIvPjxzdG9wIG9mZnNldD0iLjI5IiBzdG9wLWNvbG9yPSIjNjNiNjQ5Ii8+PHN0b3Agb2Zmc2V0PSIuNiIgc3RvcC1jb2xvcj0iIzUyOWY0NCIvPjxzdG9wIG9mZnNldD0iLjg2IiBzdG9wLWNvbG9yPSIjM2Y4NzNmIi8+PC9saW5lYXJHcmFkaWVudD48bGluZWFyR3JhZGllbnQgaWQ9ImYiIHgxPSIyMC43MiIgeTE9IjM2LjQxIiB4Mj0iMzguMzMiIHkyPSIzNi40MSIgeGxpbms6aHJlZj0iI2UiLz48bGluZWFyR3JhZGllbnQgaWQ9ImciIHgxPSIyMC43MiIgeTE9IjQxLjQ0IiB4Mj0iMzguMzMiIHkyPSI0MS40NCIgeGxpbms6aHJlZj0iI2UiLz48bGluZWFyR3JhZGllbnQgaWQ9ImgiIHgxPSIyMC43MiIgeTE9IjQzLjcyIiB4Mj0iMzguMzMiIHkyPSI0My43MiIgeGxpbms6aHJlZj0iI2UiLz48bGluZWFyR3JhZGllbnQgaWQ9ImkiIHgxPSI0MC45IiB5MT0iMjkuNjgiIHgyPSIzMC4wNCIgeTI9IjUxLjg0IiB4bGluazpocmVmPSIjYSIvPjxjbGlwUGF0aCBpZD0iYyI+PHBhdGggZD0iTTMwIDI2LjgyYS45NC45NCAwIDAwLS45MiAwbC03LjYyIDQuNEEuOTEuOTEgMCAwMDIxIDMydjguOGEuODkuODkgMCAwMC40Ni43OUwyOS4wNyA0NmEuODkuODkgMCAwMC45MyAwbDcuNjEtNC40YS44OS44OSAwIDAwLjQ2LS43OVYzMmEuOTEuOTEgMCAwMC0uNDYtLjh6IiBjbGlwLXJ1bGU9ImV2ZW5vZGQiIGZpbGw9InVybCgjYSkiLz48L2NsaXBQYXRoPjxzdHlsZT4uYntmaWxsOiM2NzllNjN9Lmd7ZmlsbDpub25lfTwvc3R5bGU+PC9kZWZzPjxwYXRoIGNsYXNzPSJiIiBkPSJNMzkuNTQgNjQuNWExLjQ4IDEuNDggMCAwMS0uNzYtLjIxbC0yLjQxLTEuNDJjLS4zNi0uMi0uMTgtLjI4LS4wNi0uMzJhNC42NiA0LjY2IDAgMDAxLjA5LS40OS4xOS4xOSAwIDAxLjE4IDBsMS44NSAxLjFhLjIyLjIyIDAgMDAuMjIgMEw0Ni44OCA1OWEuMjQuMjQgMCAwMC4xMS0uMTl2LTguMzRhLjI2LjI2IDAgMDAtLjExLS4ybC03LjIzLTQuMTdhLjIyLjIyIDAgMDAtLjIyIDBsLTcuMjIgNC4xN2EuMjMuMjMgMCAwMC0uMTEuMnY4LjM0YS4yMS4yMSAwIDAwLjExLjE5bDIgMS4xNGMxLjA3LjU0IDEuNzMtLjA5IDEuNzMtLjczdi04LjIzYS4yMS4yMSAwIDAxLjIxLS4yMWguOTJhLjIxLjIxIDAgMDEuMjEuMjF2OC4yM2EyIDIgMCAwMS0yLjE0IDIuMjYgMy4wNyAzLjA3IDAgMDEtMS42Ny0uNDZsLTEuODktMS4wOWExLjUxIDEuNTEgMCAwMS0uNzYtMS4zMXYtOC4zNGExLjUzIDEuNTMgMCAwMS43Ni0xLjMybDcuMi00LjE1YTEuNTggMS41OCAwIDAxMS41MiAwbDcuMjMgNC4xN2ExLjU0IDEuNTQgMCAwMS43NSAxLjMydjguMzRhMS41MiAxLjUyIDAgMDEtLjc1IDEuMzFsLTcuMjMgNC4xNWExLjQ1IDEuNDUgMCAwMS0uNzYuMjF6Ii8+PHBhdGggY2xhc3M9ImIiIGQ9Ik00MS43NyA1OC43NWMtMy4xNiAwLTMuODItMS40NS0zLjgyLTIuNjZhLjIxLjIxIDAgMDEuMjEtLjIxaC45M2EuMjEuMjEgMCAwMS4yMS4xN2MuMTQgMSAuNTYgMS40MyAyLjQ3IDEuNDMgMS41MiAwIDIuMTctLjM0IDIuMTctMS4xNSAwLS40Ni0uMTgtLjgxLTIuNTUtMS0yLS4yLTMuMi0uNjMtMy4yLTIuMjFzMS4yMy0yLjMzIDMuMjktMi4zM2MyLjMyIDAgMy40Ni44IDMuNjEgMi41M2EuMjUuMjUgMCAwMS0uMDYuMTYuMi4yIDAgMDEtLjE1LjA2aC0uOTRhLjIuMiAwIDAxLS4yLS4xNmMtLjIzLTEtLjc3LTEuMzItMi4yNi0xLjMyLTEuNjYgMC0xLjg1LjU4LTEuODUgMXMuMjMuNjggMi40NyAxIDMuMjcuNzEgMy4yNyAyLjI3LTEuMzEgMi40Mi0zLjYgMi40MnpNNTIuMTkgNTBhMS4zOSAxLjM5IDAgMTEtMS4zOS0xLjM5QTEuMzkgMS4zOSAwIDAxNTIuMTkgNTB6bS0yLjU2IDBhMS4xNyAxLjE3IDAgMDAxLjE2IDEuMTdBMS4xOSAxLjE5IDAgMDA1MiA1MGExLjE3IDEuMTcgMCAxMC0yLjM0IDB6bS42NC0uNzhoLjU0Yy4xOSAwIC41NSAwIC41NS40MWEuMzUuMzUgMCAwMS0uMy4zOGMuMjIgMCAuMjMuMTYuMjYuMzZhMiAyIDAgMDAuMDguNDFoLS4zM2MwLS4wNy0uMDYtLjQ3LS4wNi0uNDlzMC0uMTQtLjE2LS4xNGgtLjI3di42M2gtLjMxem0uMy42OGguMjRhLjIxLjIxIDAgMDAuMjQtLjIyYzAtLjIxLS4xNS0uMjEtLjIzLS4yMWgtLjI1eiIvPjxwYXRoIGQ9Ik0xNy4xNyAzMS44OGEuOTQuOTQgMCAwMC0uNDYtLjgxbC03LjY2LTQuNGEuOTQuOTQgMCAwMC0uNDMtLjEzaC0uMDdhLjk0Ljk0IDAgMDAtLjQzLjEzbC03LjY2IDQuNGEuOTQuOTQgMCAwMC0uNDYuODF2MTEuODdhLjQ1LjQ1IDAgMDAuMjMuNC40Ny40NyAwIDAwLjQ2IDBsNC41NS0yLjYxYS45Mi45MiAwIDAwLjQ2LS44di01LjU1YS45NC45NCAwIDAxLjQ2LS44bDEuOTQtMS4xMmExIDEgMCAwMS40Ny0uMTIgMSAxIDAgMDEuNDYuMTJMMTEgMzQuMzlhLjkzLjkzIDAgMDEuNDcuOHY1LjU1YS45Mi45MiAwIDAwLjQ2LjhsNC41NSAyLjYxYS40Ni40NiAwIDAwLjY5LS40ek01NCAxNS41NmEuNDYuNDYgMCAwMC0uNjguNHYxMS43NmEuMzMuMzMgMCAwMS0uMTcuMjguMzEuMzEgMCAwMS0uMzIgMGwtMS45Mi0xLjExYS45Mi45MiAwIDAwLS45MiAwbC03LjY3IDQuNDJhLjkzLjkzIDAgMDAtLjQ2LjhWNDFhLjk0Ljk0IDAgMDAuNDYuODFMNTAgNDYuMTlhLjg5Ljg5IDAgMDAuOTIgMGw3LjY3LTQuNDJhLjk0Ljk0IDAgMDAuNDYtLjgxdi0yMmEuOTEuOTEgMCAwMC0uNDgtLjh6bS0uNzEgMjIuNWEuMjMuMjMgMCAwMS0uMTEuMmwtMi42MyAxLjUxYS4yLjIgMCAwMS0uMjMgMGwtMi42Mi0xLjUxYS4yMy4yMyAwIDAxLS4xMS0uMlYzNWEuMjMuMjMgMCAwMS4xMS0uMmwyLjY0LTEuNTJhLjI0LjI0IDAgMDEuMjMgMGwyLjYzIDEuNTJhLjIzLjIzIDAgMDEuMTEuMnptMjYuMjUtMy4xMmEuOTMuOTMgMCAwMC40Ni0uOFYzMmEuOTMuOTMgMCAwMC0uNDYtLjhsLTcuNjEtNC40MmEuOTEuOTEgMCAwMC0uOTMgMGwtNy42NiA0LjQyYS45MS45MSAwIDAwLS40Ni44djguODRhLjk0Ljk0IDAgMDAuNDYuODFMNzEgNDZhLjkuOSAwIDAwLjkgMGw0LjYxLTIuNTZhLjQ5LjQ5IDAgMDAuMjQtLjQuNDcuNDcgMCAwMC0uMjQtLjQxbC03Ljc1LTQuNDNhLjQ3LjQ3IDAgMDEtLjIzLS40VjM1YS40Ni40NiAwIDAxLjIzLS40bDIuNC0xLjM5YS40Ny40NyAwIDAxLjQ2IDBMNzQgMzQuNjNhLjQ1LjQ1IDAgMDEuMjQuNHYyLjE4YS40Ni40NiAwIDAwLjY5LjR6IiBmaWxsPSIjMzMzIiBmaWxsLXJ1bGU9ImV2ZW5vZGQiLz48cGF0aCBkPSJNNzEuMzUgMzQuNTNhLjE1LjE1IDAgMDEuMTggMGwxLjQ3Ljg0YS4yMi4yMiAwIDAxLjA5LjE2djEuN2EuMTkuMTkgMCAwMS0uMDkuMTVsLTEuNDcuODVhLjE5LjE5IDAgMDEtLjE4IDBsLTEuNDctLjg1YS4xOS4xOSAwIDAxLS4wOS0uMTV2LTEuN2EuMjIuMjIgMCAwMS4wOS0uMTZ6IiBmaWxsLXJ1bGU9ImV2ZW5vZGQiIGZpbGw9IiM2NzllNjMiLz48cGF0aCBkPSJNMzAgMjYuODJhLjk0Ljk0IDAgMDAtLjkyIDBsLTcuNjIgNC40QS45MS45MSAwIDAwMjEgMzJ2OC44YS44OS44OSAwIDAwLjQ2Ljc5TDI5LjA3IDQ2YS44OS44OSAwIDAwLjkzIDBsNy42MS00LjRhLjg5Ljg5IDAgMDAuNDYtLjc5VjMyYS45MS45MSAwIDAwLS40Ni0uOHoiIGZpbGwtcnVsZT0iZXZlbm9kZCIgZmlsbD0idXJsKCNhKSIvPjxnIGNsaXAtcGF0aD0idXJsKCNjKSI+PHBhdGggY2xhc3M9ImciIGQ9Ik0yOS4wNSAyNi44MmwtNy42NCA0LjRhMSAxIDAgMDAtLjQ5Ljh2OC44YS45MS45MSAwIDAwLjI0LjU4bDguNTgtMTQuNjdhLjkzLjkzIDAgMDAtLjY5LjA5em0uNzMgMTkuMjhBLjg1Ljg1IDAgMDAzMCA0Nmw3LjYyLTQuNGEuOTEuOTEgMCAwMC40OC0uNzlWMzJhLjkuOSAwIDAwLS4yOC0uNjR6Ii8+PHBhdGggZD0iTTM3LjYyIDMxLjIyTDMwIDI2LjgyYTEuMTcgMS4xNyAwIDAwLS4yNC0uMDlsLTguNiAxNC42N2EuNzUuNzUgMCAwMC4yNi4yMUwyOS4wNyA0NmEuODkuODkgMCAwMC43MS4wOWw4LTE0LjcyYTEgMSAwIDAwLS4xNi0uMTV6IiBmaWxsPSJ1cmwoI2QpIi8+PHBhdGggY2xhc3M9ImciIGQ9Ik0zOC4xIDQwLjgyVjMyYTEgMSAwIDAwLS40OC0uOEwzMCAyNi44MmEuOTQuOTQgMCAwMC0uMjgtLjFMMzguMDcgNDFhLjc2Ljc2IDAgMDAuMDMtLjE4em0tMTYuNjktOS42YTEgMSAwIDAwLS40OS44djguOGEuOTMuOTMgMCAwMC41Ljc5TDI5LjA3IDQ2YS44OC44OCAwIDAwLjU5LjEybC04LjItMTQuOTR6Ii8+PHBhdGggZmlsbD0idXJsKCNlKSIgZD0iTTI4LjgxIDI1LjJsLS4xLjA3aC4xNGwtLjA0LS4wN3oiLz48cGF0aCBkPSJNMzcuNjIgNDEuNjFhLjkuOSAwIDAwLjQ1LS41OEwyOS43IDI2LjcyYS45Mi45MiAwIDAwLS42NS4xbC03LjU5IDQuMzcgOC4yIDE0Ljk0QTEuMDYgMS4wNiAwIDAwMzAgNDZ6IiBmaWxsPSJ1cmwoI2YpIi8+PHBhdGggZmlsbD0idXJsKCNnKSIgZD0iTTM4LjMzIDQxLjQ3bC0uMDUtLjA4di4xMWwuMDUtLjAzeiIvPjxwYXRoIGQ9Ik0zNy42MiA0MS42MUwzMCA0NmExLjA2IDEuMDYgMCAwMS0uMzQuMTJsLjE1LjI4IDguNDctNC45MXYtLjExbC0uMjEtLjM4YS45LjkgMCAwMS0uNDUuNjF6IiBmaWxsPSJ1cmwoI2gpIi8+PHBhdGggZD0iTTM3LjYyIDQxLjYxTDMwIDQ2YTEuMDYgMS4wNiAwIDAxLS4zNC4xMmwuMTUuMjggOC40Ny00Ljkxdi0uMTFsLS4yMS0uMzhhLjkuOSAwIDAxLS40NS42MXoiIGZpbGw9InVybCgjaSkiLz48L2c+PC9zdmc+", "Node.js", 2 },
                    { 14, "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdCb3g9IjAgMCA4MCA4MCI+PHBhdGggZmlsbD0iIzg4OTJiZiIgZD0iTTAgMGg4MHY4MEgweiIvPjxwYXRoIGQ9Ik0xMy43MyAyOS40MWg5LjQ5cTQuMTkgMCA2LjA2IDIuMzl0MS4yNCA2LjQ1YTEyLjM4IDEyLjM4IDAgMDEtMS4xIDMuNjcgMTAuNzQgMTAuNzQgMCAwMS0yLjI3IDMuMjQgNy45MiA3LjkyIDAgMDEtMy43OSAyLjMzIDE3LjQ2IDE3LjQ2IDAgMDEtNC4xOC40OWgtNC4yNWwtMS4zNCA2LjdIOC42Nmw1LjA3LTI1LjI3bTQuMTQgNEwxNS43NSA0NGEzIDMgMCAwMC40MiAwaC41YTE4LjU1IDE4LjU1IDAgMDA1LjY3LS42N2MxLjUxLS40OSAyLjUyLTIuMjEgMy01LjE0LjQzLTIuNDcgMC0zLjg5LTEuMjctNC4yN2ExNi4zNCAxNi4zNCAwIDAwLTQuNzEtLjUzIDcuODggNy44OCAwIDAxLS44MiAwaC0uNzRtMTguMzMtMTAuNzFINDFsLTEuMzggNi43M0g0NGE4LjgyIDguODIgMCAwMTUuMzkgMS40OGMxLjIuOTQgMS41NiAyLjcyIDEuMDYgNS4zNkw0OC4xIDQ4aC01bDIuMjctMTEuMjFhMy4xNyAzLjE3IDAgMDAtLjIyLTIuNSAzIDMgMCAwMC0yLjQ0LS43NGgtMy45M0wzNS45MSA0OEgzMWw1LjEtMjUuM20xOS42MiA2LjcxaDkuNDlxNC4xOSAwIDYuMDYgMi4zOXQxLjI0IDYuNDVhMTIuMzggMTIuMzggMCAwMS0xLjEgMy42NyAxMC43NCAxMC43NCAwIDAxLTIuMjcgMy4yNCA3LjkyIDcuOTIgMCAwMS0zLjc5IDIuMzMgMTcuNDYgMTcuNDYgMCAwMS00LjE4LjQ5aC00LjI1bC0xLjM0IDYuN2gtNC45M2w1LjA3LTI1LjI3bTQuMTQgNEw1Ny43NCA0NGEzIDMgMCAwMC40MiAwaC41YTE4LjU1IDE4LjU1IDAgMDA1LjY3LS42N2MxLjUxLS40OSAyLjUyLTIuMjEgMy01LjE0LjQzLTIuNDcgMC0zLjg5LTEuMjctNC4yN2ExNi4yNSAxNi4yNSAwIDAwLTQuNzEtLjUzIDcuODggNy44OCAwIDAxLS44MiAwaC0uNzQiIGZpbGw9IiNmZmYiLz48L3N2Zz4=", "php", 2 },
                    { 15, "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdCb3g9IjAgMCA4MCA4MCI+PGRlZnM+PGxpbmVhckdyYWRpZW50IGlkPSJhIiB4MT0iMTM2LjEzIiB5MT0iLTIzMy44OCIgeDI9IjIxMy43MyIgeTI9Ii0zMDAuNjQiIGdyYWRpZW50VHJhbnNmb3JtPSJtYXRyaXgoLjU2IDAgMCAtLjU3IC03OC4wOCAtMTMwLjU2KSIgZ3JhZGllbnRVbml0cz0idXNlclNwYWNlT25Vc2UiPjxzdG9wIG9mZnNldD0iMCIgc3RvcC1jb2xvcj0iIzVhOWZkNCIvPjxzdG9wIG9mZnNldD0iMSIgc3RvcC1jb2xvcj0iIzMwNjk5OCIvPjwvbGluZWFyR3JhZGllbnQ+PGxpbmVhckdyYWRpZW50IGlkPSJiIiB4MT0iMjQzLjczIiB5MT0iLTM0MS4wNSIgeDI9IjIxNi4wMiIgeTI9Ii0zMDEuODUiIGdyYWRpZW50VHJhbnNmb3JtPSJtYXRyaXgoLjU2IDAgMCAtLjU3IC03OC4wOCAtMTMwLjU2KSIgZ3JhZGllbnRVbml0cz0idXNlclNwYWNlT25Vc2UiPjxzdG9wIG9mZnNldD0iMCIgc3RvcC1jb2xvcj0iI2ZmZDQzYiIvPjxzdG9wIG9mZnNldD0iMSIgc3RvcC1jb2xvcj0iI2ZmZTg3MyIvPjwvbGluZWFyR3JhZGllbnQ+PC9kZWZzPjxwYXRoIGQ9Ik0zOS41MyAwYTU0LjQ5IDU0LjQ5IDAgMDAtOS4xMi43OGMtOC4wOCAxLjQzLTkuNTQgNC40MS05LjU0IDkuOTJWMThINDB2Mi40SDEzLjdjLTUuNTQgMC0xMC40IDMuMzMtMTEuOTIgOS42N0MwIDM3LjM0IDAgNDEuODggMS43OCA0OS40N2MxLjM2IDUuNjUgNC42IDkuNjggMTAuMTQgOS42OGg2LjU3di04LjcyYTEyLjEzIDEyLjEzIDAgMDExMS45Mi0xMS44NmgxOS4wNmE5LjYxIDkuNjEgMCAwMDkuNTMtOS43VjEwLjdjMC01LjE3LTQuMzYtOS4wNi05LjU0LTkuOTJBNTkuNjMgNTkuNjMgMCAwMDM5LjUzIDB6TTI5LjIxIDUuODVhMy42NCAzLjY0IDAgMTEtMy41OCAzLjY1IDMuNjIgMy42MiAwIDAxMy41OC0zLjY1eiIgZmlsbD0idXJsKCNhKSIvPjxwYXRoIGQ9Ik02MS4zOSAyMC40djguNDdBMTIuMjQgMTIuMjQgMCAwMTQ5LjQ3IDQxSDMwLjQxYTkuNzQgOS43NCAwIDAwLTkuNTQgOS43djE4LjE1YzAgNS4xNyA0LjQ5IDguMjEgOS41NCA5LjY5YTMxLjg3IDMxLjg3IDAgMDAxOS4wNiAwYzQuODEtMS4zOSA5LjUzLTQuMTkgOS41My05LjY5di03LjI4SDQwdi0yLjQyaDI4LjU2YzUuNTQgMCA3LjYxLTMuODcgOS41NC05LjY4IDItNiAxLjkxLTExLjczIDAtMTkuNC0xLjM3LTUuNTItNC05LjY3LTkuNTQtOS42N3ptLTEwLjcyIDQ2YTMuNjQgMy42NCAwIDExLTMuNTggMy42MyAzLjYgMy42IDAgMDEzLjU4LTMuNjF6IiBmaWxsPSJ1cmwoI2IpIi8+PC9zdmc+", "python", 2 },
                    { 16, "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdCb3g9IjAgMCA4MCA4MCI+PGRlZnM+PHN0eWxlPi5ie2ZpbGw6I2ZmZn08L3N0eWxlPjwvZGVmcz48cGF0aCBmaWxsPSIjMDkyZTIwIiBkPSJNMC0uMTFoODAuMTFWODBIMHoiLz48cGF0aCBjbGFzcz0iYiIgZD0iTTEzLjggMjguMjRoMy43OXYxNy41NGEyNSAyNSAwIDAxLTQuOTIuNTJjLTQuNjMgMC03LTIuMDktNy02LjFzMi41Ni02LjM4IDYuNTItNi4zOGE2IDYgMCAwMTEuNjUuMnYtNS43OHptMCA4LjgzYTMuNjkgMy42OSAwIDAwLTEuMjgtLjJjLTEuOTIgMC0zIDEuMTgtMyAzLjI1czEuMDYgMy4xMyAzIDMuMTNhOS40NSA5LjQ1IDAgMDAxLjMxLS4xeiIvPjxwYXRoIGNsYXNzPSJiIiBkPSJNMjMuNjEgMzQuMDl2OC43OWMwIDMtLjIyIDQuNDctLjg4IDUuNzNhNi4wOCA2LjA4IDAgMDEtMy4xIDIuOGwtMy41Mi0xLjY3YTUuNSA1LjUgMCAwMDMtMi41M2MuNTQtMS4wOS43Mi0yLjM0LjcyLTUuNjR2LTcuNDh6bS0zLjc4LTUuODNoMy43OHYzLjg5aC0zLjc4ek0yNS45IDM1YTExLjM4IDExLjM4IDAgMDE1LTEuMTRjMS45NCAwIDMuMjIuNTIgMy43OSAxLjUzYTUuODEgNS44MSAwIDAxLjQyIDIuODh2Ny43YTQyLjg0IDQyLjg0IDAgMDEtNS40MS40MmMtMy4xOCAwLTQuNjEtMS4xMS00LjYxLTMuNTcgMC0yLjY2IDEuOS0zLjg5IDYuNTUtNC4yOHYtLjg0YzAtLjY5LS4zNS0uOTMtMS4zMS0uOTNhMTAgMTAgMCAwMC00LjQ1IDEuMTVWMzV6bTUuOTMgNmMtMi41MS4yNS0zLjMyLjY0LTMuMzIgMS42MyAwIC43My40NyAxLjA4IDEuNSAxLjA4YTEwLjcgMTAuNyAwIDAwMS44Mi0uMTdWNDF6TTM3IDM0LjY4YTIyLjc5IDIyLjc5IDAgMDE2LS44NiA1LjY4IDUuNjggMCAwMTQuMTggMS4zMWMuNzkuODEgMSAxLjY5IDEgMy41OXY3LjQzaC0zLjgzdi03LjI4YzAtMS40NS0uNDktMi0xLjg0LTJhNS43NCA1Ljc0IDAgMDAtMS43NS4yN3Y5SDM3VjM0LjY4em0xMi42MSAxMy41NGE4LjczIDguNzMgMCAwMDQuMDYgMWMyLjQ5IDAgMy41NS0xIDMuNTUtMy40MnYtLjA3YTUuMTkgNS4xOSAwIDAxLTIuNDYuNTJjLTMuMzMgMC01LjQ0LTIuMTktNS40NC01LjY2IDAtNC4zMSAzLjEyLTYuNzQgOC42Ni02Ljc0YTIzLjgyIDIzLjgyIDAgMDE0Ljk0LjU0bC0xLjI5IDIuNzNjLTEtLjE5LS4wOSAwLS44NS0uMXY2LjYxYzAgMy4yNS0uMjggNC43OC0xLjA5IDYtMS4xOCAxLjg1LTMuMjIgMi43Ni02LjEyIDIuNzZhMTEgMTEgMCAwMS00LjA5LS43NHYtMy40M3ptNy41My0xMS4zMmgtLjM5YTQuMDggNC4wOCAwIDAwLTIuMTkuNTQgMi45NCAyLjk0IDAgMDAtMS4zOCAyLjc4YzAgMS44OS45NCAzIDIuNjEgM2E0LjY3IDQuNjcgMCAwMDEuNDMtLjIydi02LjF6bTExLjY2LTMuMTNjMy43OSAwIDYuMTEgMi4zOSA2LjExIDYuMjVzLTIuNDIgNi40NS02LjI1IDYuNDUtNi4xMy0yLjM5LTYuMTMtNi4yMyAyLjQxLTYuNDcgNi4yNy02LjQ3em0tLjA3IDkuNjVjMS40NSAwIDIuMzEtMS4yMSAyLjMxLTMuM3MtLjgzLTMuMy0yLjI4LTMuMy0yLjM3IDEuMjEtMi4zNyAzLjMuODYgMy4zIDIuMzQgMy4zeiIvPjwvc3ZnPg==", "django", 2 }
                });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "AvatarUrl", "Name", "PlatformTypes" },
                values: new object[] { 18, "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdCb3g9IjAgMCA4MCA4MCI+PHBhdGggZmlsbD0iIzUxMmJkNCIgZD0iTTAgMGg4MHY4MEgweiIvPjxwYXRoIGQ9Ik0xNC4yNiA1MS4xMWEyIDIgMCAwMS0xLjQ0LS41NiAxLjkgMS45IDAgMDEwLTIuNzcgMiAyIDAgMDExLjQ0LS41OCAyIDIgMCAwMTEuNDUuNTggMS44OCAxLjg4IDAgMDEwIDIuNzcgMiAyIDAgMDEtMS40NS41NnptMjIuNjEtLjMyaC0zLjY4bC05LjY4LTE1LjI4YTYuNzggNi43OCAwIDAxLS42MS0xLjJoLS4wOWEyMC41MyAyMC41MyAwIDAxLjEyIDIuODV2MTMuNjNoLTMuMjZWMzBoMy45MkwzMyA0NC45MmMuNC42Mi42NSAxIC43NyAxLjI4aC4wNWExOS42OCAxOS42OCAwIDAxLS4xNC0yLjhWMzBoMy4yNHptMTUuODQgMEg0MS4zM1YzMGgxMC45M3YyLjkzaC03LjU3djUuODloN3YyLjkxaC03djYuMTVoOHptMTYuMTgtMTcuODZoLTUuODN2MTcuODZoLTMuMzdWMzIuOTNoLTUuODFWMzBoMTV6IiBmaWxsPSIjZmZmIi8+PC9zdmc+", "Windows Presentation Foundation", 8 });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Dolorem aut incidunt repellendus qui rerum. Iusto at sapiente ut commodi officia. Iste totam molestiae reiciendis qui. Perspiciatis saepe veniam voluptatum animi doloribus. In facilis sint autem.");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Ut asperiores numquam officia nemo debitis qui aspernatur quibusdam in. Blanditiis voluptatem ea. Et quia ea. Nihil sit fugiat recusandae. Possimus amet fugiat expedita officiis autem laboriosam officia sunt. Et laboriosam laboriosam aut et aspernatur.");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Placeat ipsam enim sit minima. Sed a iusto sequi dolor eum dolorum eos. Reprehenderit eum quia. Quasi tempora consequatur. Molestiae commodi et quod.");

            migrationBuilder.UpdateData(
                table: "ApplicationTeams",
                keyColumn: "Id",
                keyValue: 18,
                column: "ApplicationId",
                value: 13);

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description", "Name", "OrganizationId", "PlatformId", "SecurityToken" },
                values: new object[] { new DateTime(2019, 8, 13, 23, 53, 43, 570, DateTimeKind.Unspecified).AddTicks(6998), "enhance efficient communities", "Vandervort - Nolan", 3, 17, "def5780176e65ae10e04f11ad54e7109" });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId", "SecurityToken" },
                values: new object[] { new DateTime(2021, 6, 15, 19, 59, 35, 109, DateTimeKind.Unspecified).AddTicks(3753), 3, "aggregate next-generation methodologies", "Yost LLC", 2, 12, "4554af2e1fff3533f41296e701552871" });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId", "SecurityToken" },
                values: new object[] { new DateTime(2021, 4, 20, 3, 4, 26, 305, DateTimeKind.Unspecified).AddTicks(8228), 12, "expedite bleeding-edge vortals", "Towne - Kutch", 1, 16, "5880670873ff126860fc72effb88671e" });

            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId", "SecurityToken" },
                values: new object[,]
                {
                    { 11, new DateTime(2019, 12, 26, 15, 15, 1, 457, DateTimeKind.Unspecified).AddTicks(1356), 15, "architect customized systems", "Kshlerin - Macejkovic", 5, 16, "714246c077aaf2a91be72f11e394fe7c" },
                    { 15, new DateTime(2021, 1, 18, 16, 18, 45, 797, DateTimeKind.Unspecified).AddTicks(5286), 16, "syndicate plug-and-play functionalities", "Donnelly Group", 1, 17, "0695a78516c5e0c252e95a7a1f3dd7ec" },
                    { 12, new DateTime(2019, 11, 21, 9, 47, 19, 338, DateTimeKind.Unspecified).AddTicks(7899), 11, "innovate viral blockchains", "Schaden, Koch and Corkery", 4, 18, "946d6706d4677f330d8180eb27de44cc" }
                });

            migrationBuilder.UpdateData(
                table: "Environments",
                keyColumn: "Id",
                keyValue: 3,
                column: "ApplicationId",
                value: 14);

            migrationBuilder.UpdateData(
                table: "Environments",
                keyColumn: "Id",
                keyValue: 4,
                column: "ApplicationId",
                value: 14);

            migrationBuilder.UpdateData(
                table: "ApplicationTeams",
                keyColumn: "Id",
                keyValue: 7,
                column: "ApplicationId",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ApplicationTeams",
                keyColumn: "Id",
                keyValue: 8,
                column: "ApplicationId",
                value: 15);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DropColumn(
                name: "PlatformTypes",
                table: "Platforms");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Applications");

            migrationBuilder.AlterColumn<string>(
                name: "AvatarUrl",
                table: "Platforms",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "ApplicationTeams",
                keyColumn: "Id",
                keyValue: 1,
                column: "ApplicationId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ApplicationTeams",
                keyColumn: "Id",
                keyValue: 3,
                column: "ApplicationId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ApplicationTeams",
                keyColumn: "Id",
                keyValue: 4,
                column: "ApplicationId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ApplicationTeams",
                keyColumn: "Id",
                keyValue: 5,
                column: "ApplicationId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ApplicationTeams",
                keyColumn: "Id",
                keyValue: 6,
                column: "ApplicationId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "ApplicationTeams",
                keyColumn: "Id",
                keyValue: 7,
                column: "ApplicationId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ApplicationTeams",
                keyColumn: "Id",
                keyValue: 8,
                column: "ApplicationId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ApplicationTeams",
                keyColumn: "Id",
                keyValue: 9,
                column: "ApplicationId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "ApplicationTeams",
                keyColumn: "Id",
                keyValue: 10,
                column: "ApplicationId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "ApplicationTeams",
                keyColumn: "Id",
                keyValue: 12,
                column: "ApplicationId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "ApplicationTeams",
                keyColumn: "Id",
                keyValue: 13,
                column: "ApplicationId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "ApplicationTeams",
                keyColumn: "Id",
                keyValue: 14,
                column: "ApplicationId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ApplicationTeams",
                keyColumn: "Id",
                keyValue: 17,
                column: "ApplicationId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "ApplicationTeams",
                keyColumn: "Id",
                keyValue: 18,
                column: "ApplicationId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "ApplicationTeams",
                keyColumn: "Id",
                keyValue: 19,
                column: "ApplicationId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ApplicationTeams",
                keyColumn: "Id",
                keyValue: 20,
                column: "ApplicationId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy", "Name", "OrganizationId", "SecurityToken" },
                values: new object[] { new DateTime(2021, 2, 12, 2, 4, 53, 954, DateTimeKind.Unspecified).AddTicks(9302), 19, "et", 4, "382c872c306c5e42126fd20bd128d2f8" });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Name", "OrganizationId", "PlatformId", "SecurityToken" },
                values: new object[] { new DateTime(2019, 11, 9, 2, 34, 53, 333, DateTimeKind.Unspecified).AddTicks(609), "eaque", 1, 1, "740bfaea383def5780176e65ae10e04f" });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy", "Name", "OrganizationId", "PlatformId", "SecurityToken" },
                values: new object[] { new DateTime(2021, 5, 2, 8, 9, 18, 808, DateTimeKind.Unspecified).AddTicks(603), 6, "aliquid", 3, 1, "4e71098eaf39041db98db018db344bc4" });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy", "Name", "OrganizationId", "PlatformId", "SecurityToken" },
                values: new object[] { new DateTime(2021, 1, 21, 4, 27, 54, 821, DateTimeKind.Unspecified).AddTicks(9297), 7, "et", 5, 3, "654e6fee6db32672fa3df4554af2e1ff" });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Name", "OrganizationId", "PlatformId", "SecurityToken" },
                values: new object[] { new DateTime(2020, 11, 1, 23, 50, 36, 645, DateTimeKind.Unspecified).AddTicks(6625), "tempora", 2, 10, "f41296e7015528714a10e9c0c05ec3f0" });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "CreatedBy", "Name", "PlatformId", "SecurityToken" },
                values: new object[] { new DateTime(2020, 12, 4, 12, 59, 54, 245, DateTimeKind.Unspecified).AddTicks(9861), 12, "fugit", 10, "b5d6e399dc98eb83345815910bd25138" });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "CreatedBy", "Name", "OrganizationId", "PlatformId", "SecurityToken" },
                values: new object[] { new DateTime(2021, 1, 20, 5, 51, 37, 155, DateTimeKind.Unspecified).AddTicks(1815), 12, "voluptatem", 2, 10, "90637f3b5d86c09ad05bb62664b806f1" });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Name", "OrganizationId", "PlatformId", "SecurityToken" },
                values: new object[] { new DateTime(2020, 9, 15, 5, 54, 32, 534, DateTimeKind.Unspecified).AddTicks(1538), "reiciendis", 2, 7, "59655ae4c809e4e3983efc33bafd62d7" });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "CreatedBy", "Name", "OrganizationId", "PlatformId", "SecurityToken" },
                values: new object[] { new DateTime(2021, 4, 2, 9, 39, 11, 203, DateTimeKind.Unspecified).AddTicks(5174), 4, "voluptates", 3, 4, "65c32abaf221ea765f963abb1d9b933c" });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "CreatedBy", "Name", "OrganizationId", "PlatformId", "SecurityToken" },
                values: new object[] { new DateTime(2021, 4, 10, 17, 22, 41, 492, DateTimeKind.Unspecified).AddTicks(341), 13, "iusto", 2, 10, "ad178b7cc87610aefaba124101bf5988" });

            migrationBuilder.UpdateData(
                table: "Environments",
                keyColumn: "Id",
                keyValue: 1,
                column: "ApplicationId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Environments",
                keyColumn: "Id",
                keyValue: 2,
                column: "ApplicationId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Environments",
                keyColumn: "Id",
                keyValue: 3,
                column: "ApplicationId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Environments",
                keyColumn: "Id",
                keyValue: 4,
                column: "ApplicationId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Environments",
                keyColumn: "Id",
                keyValue: 5,
                column: "ApplicationId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvatarUrl", "Name" },
                values: new object[] { "https://picsum.photos/250/250/?image=475", "nihil" });

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AvatarUrl", "Name" },
                values: new object[] { "https://picsum.photos/250/250/?image=892", "odio" });

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AvatarUrl", "Name" },
                values: new object[] { "https://picsum.photos/250/250/?image=1024", "eos" });

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AvatarUrl", "Name" },
                values: new object[] { "https://picsum.photos/250/250/?image=1066", "est" });

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AvatarUrl", "Name" },
                values: new object[] { "https://picsum.photos/250/250/?image=943", "quis" });

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AvatarUrl", "Name" },
                values: new object[] { "https://picsum.photos/250/250/?image=712", "sunt" });

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AvatarUrl", "Name" },
                values: new object[] { "https://picsum.photos/250/250/?image=575", "deleniti" });

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AvatarUrl", "Name" },
                values: new object[] { "https://picsum.photos/250/250/?image=315", "et" });

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AvatarUrl", "Name" },
                values: new object[] { "https://picsum.photos/250/250/?image=102", "laborum" });

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AvatarUrl", "Name" },
                values: new object[] { "https://picsum.photos/250/250/?image=238", "ut" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Expedita omnis voluptatem magnam repellat omnis quidem necessitatibus. In hic beatae eius ipsam. At totam alias non ipsa. Inventore nemo velit corporis nulla. Rerum dolor adipisci voluptate dolorem qui. Ipsam et et.");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Quod maxime modi exercitationem atque totam unde ipsum enim voluptatem. Pariatur maiores et at blanditiis animi totam quia. Sequi voluptatem asperiores quo quia asperiores dolor recusandae adipisci repellat. Ab ut sunt consectetur exercitationem ipsa voluptas qui. Possimus cum sunt quos praesentium ut quam sint. Error porro sit soluta voluptatibus.");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Placeat molestias quia quos nobis laborum aut. Dignissimos libero nemo eveniet praesentium. Velit quo est iure amet voluptatum inventore. Magnam omnis sunt ut rerum harum minima. Quis natus voluptas animi unde provident officia. Quae qui nihil omnis quae.");
        }
    }
}
