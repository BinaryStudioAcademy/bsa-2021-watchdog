using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Watchdog.Core.DAL.Migrations
{
    public partial class ProjectsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Samples");

            migrationBuilder.DropColumn(
                name: "SecurityToken",
                table: "Applications");

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
                name: "AlertSettings",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: true);

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
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy", "Description", "Name", "PlatformId" },
                values: new object[] { new DateTime(2019, 8, 12, 17, 20, 56, 326, DateTimeKind.Unspecified).AddTicks(9638), 8, "cultivate granular infrastructures", "Schmidt - Hilpert", 3 });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId" },
                values: new object[] { new DateTime(2020, 2, 23, 12, 13, 2, 529, DateTimeKind.Unspecified).AddTicks(289), 1, "cultivate one-to-one web-readiness", "Schmeler - Boehm", 3, 6 });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId" },
                values: new object[] { new DateTime(2020, 4, 6, 21, 58, 23, 764, DateTimeKind.Unspecified).AddTicks(5366), 7, "transform dot-com content", "Leuschke - Adams", 5, 8 });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId" },
                values: new object[] { new DateTime(2019, 11, 9, 2, 34, 53, 333, DateTimeKind.Unspecified).AddTicks(609), 14, "implement B2B blockchains", "Breitenberg, Bednar and Ullrich", 1, 2 });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId" },
                values: new object[] { new DateTime(2020, 3, 12, 14, 10, 16, 522, DateTimeKind.Unspecified).AddTicks(8649), 19, "target leading-edge paradigms", "Gleichner - Tromp", 4, 10 });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "CreatedBy", "Description", "Name", "PlatformId" },
                values: new object[] { new DateTime(2019, 12, 8, 6, 2, 36, 243, DateTimeKind.Unspecified).AddTicks(7412), 15, "exploit bricks-and-clicks communities", "Beier, Bergnaum and Lesch", 5 });

            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "Id", "AlertSettings", "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId" },
                values: new object[,]
                {
                    { 13, null, new DateTime(2020, 10, 20, 17, 49, 27, 974, DateTimeKind.Unspecified).AddTicks(474), 7, "expedite sticky applications", "Conroy - Yost", 5, 5 },
                    { 12, null, new DateTime(2020, 10, 16, 17, 41, 22, 99, DateTimeKind.Unspecified).AddTicks(4346), 4, "cultivate killer metrics", "Wintheiser - Ward", 4, 4 },
                    { 11, null, new DateTime(2019, 10, 13, 12, 5, 2, 725, DateTimeKind.Unspecified).AddTicks(731), 7, "morph scalable e-commerce", "Larkin Inc", 2, 7 }
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
                    { 18, "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdCb3g9IjAgMCA4MCA4MCI+PHBhdGggZmlsbD0iIzUxMmJkNCIgZD0iTTAgMGg4MHY4MEgweiIvPjxwYXRoIGQ9Ik0xNC4yNiA1MS4xMWEyIDIgMCAwMS0xLjQ0LS41NiAxLjkgMS45IDAgMDEwLTIuNzcgMiAyIDAgMDExLjQ0LS41OCAyIDIgMCAwMTEuNDUuNTggMS44OCAxLjg4IDAgMDEwIDIuNzcgMiAyIDAgMDEtMS40NS41NnptMjIuNjEtLjMyaC0zLjY4bC05LjY4LTE1LjI4YTYuNzggNi43OCAwIDAxLS42MS0xLjJoLS4wOWEyMC41MyAyMC41MyAwIDAxLjEyIDIuODV2MTMuNjNoLTMuMjZWMzBoMy45MkwzMyA0NC45MmMuNC42Mi42NSAxIC43NyAxLjI4aC4wNWExOS42OCAxOS42OCAwIDAxLS4xNC0yLjhWMzBoMy4yNHptMTUuODQgMEg0MS4zM1YzMGgxMC45M3YyLjkzaC03LjU3djUuODloN3YyLjkxaC03djYuMTVoOHptMTYuMTgtMTcuODZoLTUuODN2MTcuODZoLTMuMzdWMzIuOTNoLTUuODFWMzBoMTV6IiBmaWxsPSIjZmZmIi8+PC9zdmc+", "Windows Presentation Foundation", 8 },
                    { 11, "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdCb3g9IjAgMCA4MCA4MCI+PHBhdGggZmlsbD0iI2RkMDAzMSIgZD0iTTQwIDBMMi43NiAxMy4yOGw1LjY4IDQ5LjI0TDQwIDgwbDMxLjU2LTE3LjQ4IDUuNjgtNDkuMjRMNDAgMHoiLz48cGF0aCBmaWxsPSIjYzMwMDJmIiBkPSJNNDAgMHY4Ljg4LS4wNFY4MGwzMS41Ni0xNy40OCA1LjY4LTQ5LjI0TDQwIDB6Ii8+PHBhdGggZD0iTTQwIDguODRMMTYuNzIgNjFoOC42OGw0LjY4LTExLjY4aDE5Ljc2TDU0LjUyIDYxaDguNjhMNDAgOC44NHptNi44IDMzLjMySDMzLjJMNDAgMjUuOHoiIGZpbGw9IiNmZmYiLz48L3N2Zz4=", "AngularJs", 1 },
                    { 17, "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdCb3g9IjAgMCA4MCA4MCI+PGRlZnM+PHN0eWxlPi5ke2ZpbGw6I2ZmZn08L3N0eWxlPjwvZGVmcz48cGF0aCBkPSJNNzYuMjUgMjZ2MjhhMTIgMTIgMCAwMS0xLjY0IDZMNDAgNDBsMzQuNjItMjBhMTEuOTQgMTEuOTQgMCAwMTEuNjMgNnoiIGZpbGw9IiMwMDU5OWMiLz48cGF0aCBkPSJNNzQuNjIgMjBMNDAgNDAgNS40MSA2MGExMS45MiAxMS45MiAwIDAxLTEuNjYtNlYyNmExMiAxMiAwIDAxNi0xMC4zOUwzNCAxLjYxYTEyIDEyIDAgMDExMiAwbDI0LjI1IDE0QTExLjgyIDExLjgyIDAgMDE3NC42MiAyMHoiIGZpbGw9IiM2NTlhZDIiLz48cGF0aCBkPSJNNDAgNDBsMzQuNjEgMjBhMTIgMTIgMCAwMS00LjM2IDQuMzRMNDYgNzguMzlhMTIgMTIgMCAwMS0xMiAwbC0yNC4yNS0xNGExMiAxMiAwIDAxLTQuMzQtNC4zMnoiIGZpbGw9IiMwMDQ0ODIiLz48cGF0aCBjbGFzcz0iZCIgZD0iTTYxLjc5IDM4LjVoMi41MXYzLjA0aC0yLjUxdjIuNTFoLTMuMDV2LTIuNTFoLTIuNVYzOC41aDIuNXYtMi41MWgzLjA1djIuNTF6bTkuODEgMGgyLjV2My4wNGgtMi41djIuNTFoLTMuMDV2LTIuNTFoLTIuNVYzOC41aDIuNXYtMi41MWgzLjA1djIuNTF6Ii8+PHBhdGggY2xhc3M9ImQiIGQ9Ik02MSA1Mi4xNWEyNC4yMiAyNC4yMiAwIDExMC0yNC4yNkw1MC4zOCAzNHEtLjIxLS4zNy0uNDUtLjcyQTEyIDEyIDAgMTA1MC4zNiA0NnoiLz48L3N2Zz4=", "Native", 10 },
                    { 13, "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHhtbG5zOnhsaW5rPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5L3hsaW5rIiB2aWV3Qm94PSIwIDAgODAgODAiPjxkZWZzPjxsaW5lYXJHcmFkaWVudCBpZD0iYSIgeDE9IjMyLjYyIiB5MT0iMzAuMSIgeDI9IjI1Ljc0IiB5Mj0iNDQuMTQiIGdyYWRpZW50VW5pdHM9InVzZXJTcGFjZU9uVXNlIj48c3RvcCBvZmZzZXQ9IjAiIHN0b3AtY29sb3I9IiMzZjg3M2YiLz48c3RvcCBvZmZzZXQ9Ii4zMyIgc3RvcC1jb2xvcj0iIzNmOGIzZCIvPjxzdG9wIG9mZnNldD0iLjY0IiBzdG9wLWNvbG9yPSIjM2U5NjM3Ii8+PHN0b3Agb2Zmc2V0PSIuOTMiIHN0b3AtY29sb3I9IiMzZGE5MmUiLz48c3RvcCBvZmZzZXQ9IjEiIHN0b3AtY29sb3I9IiMzZGFlMmIiLz48L2xpbmVhckdyYWRpZW50PjxsaW5lYXJHcmFkaWVudCBpZD0iZCIgeDE9IjI4LjM3IiB5MT0iMzcuNDUiIHgyPSI0Ny42OCIgeTI9IjIzLjE3IiBncmFkaWVudFVuaXRzPSJ1c2VyU3BhY2VPblVzZSI+PHN0b3Agb2Zmc2V0PSIuMTQiIHN0b3AtY29sb3I9IiMzZjg3M2YiLz48c3RvcCBvZmZzZXQ9Ii40IiBzdG9wLWNvbG9yPSIjNTI5ZjQ0Ii8+PHN0b3Agb2Zmc2V0PSIuNzEiIHN0b3AtY29sb3I9IiM2M2I2NDkiLz48c3RvcCBvZmZzZXQ9Ii45MSIgc3RvcC1jb2xvcj0iIzZhYmY0YiIvPjwvbGluZWFyR3JhZGllbnQ+PGxpbmVhckdyYWRpZW50IGlkPSJlIiB4MT0iMjAuNzIiIHkxPSIyNS4yMyIgeDI9IjM4LjMzIiB5Mj0iMjUuMjMiIGdyYWRpZW50VW5pdHM9InVzZXJTcGFjZU9uVXNlIj48c3RvcCBvZmZzZXQ9Ii4wOSIgc3RvcC1jb2xvcj0iIzZhYmY0YiIvPjxzdG9wIG9mZnNldD0iLjI5IiBzdG9wLWNvbG9yPSIjNjNiNjQ5Ii8+PHN0b3Agb2Zmc2V0PSIuNiIgc3RvcC1jb2xvcj0iIzUyOWY0NCIvPjxzdG9wIG9mZnNldD0iLjg2IiBzdG9wLWNvbG9yPSIjM2Y4NzNmIi8+PC9saW5lYXJHcmFkaWVudD48bGluZWFyR3JhZGllbnQgaWQ9ImYiIHgxPSIyMC43MiIgeTE9IjM2LjQxIiB4Mj0iMzguMzMiIHkyPSIzNi40MSIgeGxpbms6aHJlZj0iI2UiLz48bGluZWFyR3JhZGllbnQgaWQ9ImciIHgxPSIyMC43MiIgeTE9IjQxLjQ0IiB4Mj0iMzguMzMiIHkyPSI0MS40NCIgeGxpbms6aHJlZj0iI2UiLz48bGluZWFyR3JhZGllbnQgaWQ9ImgiIHgxPSIyMC43MiIgeTE9IjQzLjcyIiB4Mj0iMzguMzMiIHkyPSI0My43MiIgeGxpbms6aHJlZj0iI2UiLz48bGluZWFyR3JhZGllbnQgaWQ9ImkiIHgxPSI0MC45IiB5MT0iMjkuNjgiIHgyPSIzMC4wNCIgeTI9IjUxLjg0IiB4bGluazpocmVmPSIjYSIvPjxjbGlwUGF0aCBpZD0iYyI+PHBhdGggZD0iTTMwIDI2LjgyYS45NC45NCAwIDAwLS45MiAwbC03LjYyIDQuNEEuOTEuOTEgMCAwMDIxIDMydjguOGEuODkuODkgMCAwMC40Ni43OUwyOS4wNyA0NmEuODkuODkgMCAwMC45MyAwbDcuNjEtNC40YS44OS44OSAwIDAwLjQ2LS43OVYzMmEuOTEuOTEgMCAwMC0uNDYtLjh6IiBjbGlwLXJ1bGU9ImV2ZW5vZGQiIGZpbGw9InVybCgjYSkiLz48L2NsaXBQYXRoPjxzdHlsZT4uYntmaWxsOiM2NzllNjN9Lmd7ZmlsbDpub25lfTwvc3R5bGU+PC9kZWZzPjxwYXRoIGNsYXNzPSJiIiBkPSJNMzkuNTQgNjQuNWExLjQ4IDEuNDggMCAwMS0uNzYtLjIxbC0yLjQxLTEuNDJjLS4zNi0uMi0uMTgtLjI4LS4wNi0uMzJhNC42NiA0LjY2IDAgMDAxLjA5LS40OS4xOS4xOSAwIDAxLjE4IDBsMS44NSAxLjFhLjIyLjIyIDAgMDAuMjIgMEw0Ni44OCA1OWEuMjQuMjQgMCAwMC4xMS0uMTl2LTguMzRhLjI2LjI2IDAgMDAtLjExLS4ybC03LjIzLTQuMTdhLjIyLjIyIDAgMDAtLjIyIDBsLTcuMjIgNC4xN2EuMjMuMjMgMCAwMC0uMTEuMnY4LjM0YS4yMS4yMSAwIDAwLjExLjE5bDIgMS4xNGMxLjA3LjU0IDEuNzMtLjA5IDEuNzMtLjczdi04LjIzYS4yMS4yMSAwIDAxLjIxLS4yMWguOTJhLjIxLjIxIDAgMDEuMjEuMjF2OC4yM2EyIDIgMCAwMS0yLjE0IDIuMjYgMy4wNyAzLjA3IDAgMDEtMS42Ny0uNDZsLTEuODktMS4wOWExLjUxIDEuNTEgMCAwMS0uNzYtMS4zMXYtOC4zNGExLjUzIDEuNTMgMCAwMS43Ni0xLjMybDcuMi00LjE1YTEuNTggMS41OCAwIDAxMS41MiAwbDcuMjMgNC4xN2ExLjU0IDEuNTQgMCAwMS43NSAxLjMydjguMzRhMS41MiAxLjUyIDAgMDEtLjc1IDEuMzFsLTcuMjMgNC4xNWExLjQ1IDEuNDUgMCAwMS0uNzYuMjF6Ii8+PHBhdGggY2xhc3M9ImIiIGQ9Ik00MS43NyA1OC43NWMtMy4xNiAwLTMuODItMS40NS0zLjgyLTIuNjZhLjIxLjIxIDAgMDEuMjEtLjIxaC45M2EuMjEuMjEgMCAwMS4yMS4xN2MuMTQgMSAuNTYgMS40MyAyLjQ3IDEuNDMgMS41MiAwIDIuMTctLjM0IDIuMTctMS4xNSAwLS40Ni0uMTgtLjgxLTIuNTUtMS0yLS4yLTMuMi0uNjMtMy4yLTIuMjFzMS4yMy0yLjMzIDMuMjktMi4zM2MyLjMyIDAgMy40Ni44IDMuNjEgMi41M2EuMjUuMjUgMCAwMS0uMDYuMTYuMi4yIDAgMDEtLjE1LjA2aC0uOTRhLjIuMiAwIDAxLS4yLS4xNmMtLjIzLTEtLjc3LTEuMzItMi4yNi0xLjMyLTEuNjYgMC0xLjg1LjU4LTEuODUgMXMuMjMuNjggMi40NyAxIDMuMjcuNzEgMy4yNyAyLjI3LTEuMzEgMi40Mi0zLjYgMi40MnpNNTIuMTkgNTBhMS4zOSAxLjM5IDAgMTEtMS4zOS0xLjM5QTEuMzkgMS4zOSAwIDAxNTIuMTkgNTB6bS0yLjU2IDBhMS4xNyAxLjE3IDAgMDAxLjE2IDEuMTdBMS4xOSAxLjE5IDAgMDA1MiA1MGExLjE3IDEuMTcgMCAxMC0yLjM0IDB6bS42NC0uNzhoLjU0Yy4xOSAwIC41NSAwIC41NS40MWEuMzUuMzUgMCAwMS0uMy4zOGMuMjIgMCAuMjMuMTYuMjYuMzZhMiAyIDAgMDAuMDguNDFoLS4zM2MwLS4wNy0uMDYtLjQ3LS4wNi0uNDlzMC0uMTQtLjE2LS4xNGgtLjI3di42M2gtLjMxem0uMy42OGguMjRhLjIxLjIxIDAgMDAuMjQtLjIyYzAtLjIxLS4xNS0uMjEtLjIzLS4yMWgtLjI1eiIvPjxwYXRoIGQ9Ik0xNy4xNyAzMS44OGEuOTQuOTQgMCAwMC0uNDYtLjgxbC03LjY2LTQuNGEuOTQuOTQgMCAwMC0uNDMtLjEzaC0uMDdhLjk0Ljk0IDAgMDAtLjQzLjEzbC03LjY2IDQuNGEuOTQuOTQgMCAwMC0uNDYuODF2MTEuODdhLjQ1LjQ1IDAgMDAuMjMuNC40Ny40NyAwIDAwLjQ2IDBsNC41NS0yLjYxYS45Mi45MiAwIDAwLjQ2LS44di01LjU1YS45NC45NCAwIDAxLjQ2LS44bDEuOTQtMS4xMmExIDEgMCAwMS40Ny0uMTIgMSAxIDAgMDEuNDYuMTJMMTEgMzQuMzlhLjkzLjkzIDAgMDEuNDcuOHY1LjU1YS45Mi45MiAwIDAwLjQ2LjhsNC41NSAyLjYxYS40Ni40NiAwIDAwLjY5LS40ek01NCAxNS41NmEuNDYuNDYgMCAwMC0uNjguNHYxMS43NmEuMzMuMzMgMCAwMS0uMTcuMjguMzEuMzEgMCAwMS0uMzIgMGwtMS45Mi0xLjExYS45Mi45MiAwIDAwLS45MiAwbC03LjY3IDQuNDJhLjkzLjkzIDAgMDAtLjQ2LjhWNDFhLjk0Ljk0IDAgMDAuNDYuODFMNTAgNDYuMTlhLjg5Ljg5IDAgMDAuOTIgMGw3LjY3LTQuNDJhLjk0Ljk0IDAgMDAuNDYtLjgxdi0yMmEuOTEuOTEgMCAwMC0uNDgtLjh6bS0uNzEgMjIuNWEuMjMuMjMgMCAwMS0uMTEuMmwtMi42MyAxLjUxYS4yLjIgMCAwMS0uMjMgMGwtMi42Mi0xLjUxYS4yMy4yMyAwIDAxLS4xMS0uMlYzNWEuMjMuMjMgMCAwMS4xMS0uMmwyLjY0LTEuNTJhLjI0LjI0IDAgMDEuMjMgMGwyLjYzIDEuNTJhLjIzLjIzIDAgMDEuMTEuMnptMjYuMjUtMy4xMmEuOTMuOTMgMCAwMC40Ni0uOFYzMmEuOTMuOTMgMCAwMC0uNDYtLjhsLTcuNjEtNC40MmEuOTEuOTEgMCAwMC0uOTMgMGwtNy42NiA0LjQyYS45MS45MSAwIDAwLS40Ni44djguODRhLjk0Ljk0IDAgMDAuNDYuODFMNzEgNDZhLjkuOSAwIDAwLjkgMGw0LjYxLTIuNTZhLjQ5LjQ5IDAgMDAuMjQtLjQuNDcuNDcgMCAwMC0uMjQtLjQxbC03Ljc1LTQuNDNhLjQ3LjQ3IDAgMDEtLjIzLS40VjM1YS40Ni40NiAwIDAxLjIzLS40bDIuNC0xLjM5YS40Ny40NyAwIDAxLjQ2IDBMNzQgMzQuNjNhLjQ1LjQ1IDAgMDEuMjQuNHYyLjE4YS40Ni40NiAwIDAwLjY5LjR6IiBmaWxsPSIjMzMzIiBmaWxsLXJ1bGU9ImV2ZW5vZGQiLz48cGF0aCBkPSJNNzEuMzUgMzQuNTNhLjE1LjE1IDAgMDEuMTggMGwxLjQ3Ljg0YS4yMi4yMiAwIDAxLjA5LjE2djEuN2EuMTkuMTkgMCAwMS0uMDkuMTVsLTEuNDcuODVhLjE5LjE5IDAgMDEtLjE4IDBsLTEuNDctLjg1YS4xOS4xOSAwIDAxLS4wOS0uMTV2LTEuN2EuMjIuMjIgMCAwMS4wOS0uMTZ6IiBmaWxsLXJ1bGU9ImV2ZW5vZGQiIGZpbGw9IiM2NzllNjMiLz48cGF0aCBkPSJNMzAgMjYuODJhLjk0Ljk0IDAgMDAtLjkyIDBsLTcuNjIgNC40QS45MS45MSAwIDAwMjEgMzJ2OC44YS44OS44OSAwIDAwLjQ2Ljc5TDI5LjA3IDQ2YS44OS44OSAwIDAwLjkzIDBsNy42MS00LjRhLjg5Ljg5IDAgMDAuNDYtLjc5VjMyYS45MS45MSAwIDAwLS40Ni0uOHoiIGZpbGwtcnVsZT0iZXZlbm9kZCIgZmlsbD0idXJsKCNhKSIvPjxnIGNsaXAtcGF0aD0idXJsKCNjKSI+PHBhdGggY2xhc3M9ImciIGQ9Ik0yOS4wNSAyNi44MmwtNy42NCA0LjRhMSAxIDAgMDAtLjQ5Ljh2OC44YS45MS45MSAwIDAwLjI0LjU4bDguNTgtMTQuNjdhLjkzLjkzIDAgMDAtLjY5LjA5em0uNzMgMTkuMjhBLjg1Ljg1IDAgMDAzMCA0Nmw3LjYyLTQuNGEuOTEuOTEgMCAwMC40OC0uNzlWMzJhLjkuOSAwIDAwLS4yOC0uNjR6Ii8+PHBhdGggZD0iTTM3LjYyIDMxLjIyTDMwIDI2LjgyYTEuMTcgMS4xNyAwIDAwLS4yNC0uMDlsLTguNiAxNC42N2EuNzUuNzUgMCAwMC4yNi4yMUwyOS4wNyA0NmEuODkuODkgMCAwMC43MS4wOWw4LTE0LjcyYTEgMSAwIDAwLS4xNi0uMTV6IiBmaWxsPSJ1cmwoI2QpIi8+PHBhdGggY2xhc3M9ImciIGQ9Ik0zOC4xIDQwLjgyVjMyYTEgMSAwIDAwLS40OC0uOEwzMCAyNi44MmEuOTQuOTQgMCAwMC0uMjgtLjFMMzguMDcgNDFhLjc2Ljc2IDAgMDAuMDMtLjE4em0tMTYuNjktOS42YTEgMSAwIDAwLS40OS44djguOGEuOTMuOTMgMCAwMC41Ljc5TDI5LjA3IDQ2YS44OC44OCAwIDAwLjU5LjEybC04LjItMTQuOTR6Ii8+PHBhdGggZmlsbD0idXJsKCNlKSIgZD0iTTI4LjgxIDI1LjJsLS4xLjA3aC4xNGwtLjA0LS4wN3oiLz48cGF0aCBkPSJNMzcuNjIgNDEuNjFhLjkuOSAwIDAwLjQ1LS41OEwyOS43IDI2LjcyYS45Mi45MiAwIDAwLS42NS4xbC03LjU5IDQuMzcgOC4yIDE0Ljk0QTEuMDYgMS4wNiAwIDAwMzAgNDZ6IiBmaWxsPSJ1cmwoI2YpIi8+PHBhdGggZmlsbD0idXJsKCNnKSIgZD0iTTM4LjMzIDQxLjQ3bC0uMDUtLjA4di4xMWwuMDUtLjAzeiIvPjxwYXRoIGQ9Ik0zNy42MiA0MS42MUwzMCA0NmExLjA2IDEuMDYgMCAwMS0uMzQuMTJsLjE1LjI4IDguNDctNC45MXYtLjExbC0uMjEtLjM4YS45LjkgMCAwMS0uNDUuNjF6IiBmaWxsPSJ1cmwoI2gpIi8+PHBhdGggZD0iTTM3LjYyIDQxLjYxTDMwIDQ2YTEuMDYgMS4wNiAwIDAxLS4zNC4xMmwuMTUuMjggOC40Ny00Ljkxdi0uMTFsLS4yMS0uMzhhLjkuOSAwIDAxLS40NS42MXoiIGZpbGw9InVybCgjaSkiLz48L2c+PC9zdmc+", "Node.js", 2 },
                    { 14, "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdCb3g9IjAgMCA4MCA4MCI+PHBhdGggZmlsbD0iIzg4OTJiZiIgZD0iTTAgMGg4MHY4MEgweiIvPjxwYXRoIGQ9Ik0xMy43MyAyOS40MWg5LjQ5cTQuMTkgMCA2LjA2IDIuMzl0MS4yNCA2LjQ1YTEyLjM4IDEyLjM4IDAgMDEtMS4xIDMuNjcgMTAuNzQgMTAuNzQgMCAwMS0yLjI3IDMuMjQgNy45MiA3LjkyIDAgMDEtMy43OSAyLjMzIDE3LjQ2IDE3LjQ2IDAgMDEtNC4xOC40OWgtNC4yNWwtMS4zNCA2LjdIOC42Nmw1LjA3LTI1LjI3bTQuMTQgNEwxNS43NSA0NGEzIDMgMCAwMC40MiAwaC41YTE4LjU1IDE4LjU1IDAgMDA1LjY3LS42N2MxLjUxLS40OSAyLjUyLTIuMjEgMy01LjE0LjQzLTIuNDcgMC0zLjg5LTEuMjctNC4yN2ExNi4zNCAxNi4zNCAwIDAwLTQuNzEtLjUzIDcuODggNy44OCAwIDAxLS44MiAwaC0uNzRtMTguMzMtMTAuNzFINDFsLTEuMzggNi43M0g0NGE4LjgyIDguODIgMCAwMTUuMzkgMS40OGMxLjIuOTQgMS41NiAyLjcyIDEuMDYgNS4zNkw0OC4xIDQ4aC01bDIuMjctMTEuMjFhMy4xNyAzLjE3IDAgMDAtLjIyLTIuNSAzIDMgMCAwMC0yLjQ0LS43NGgtMy45M0wzNS45MSA0OEgzMWw1LjEtMjUuM20xOS42MiA2LjcxaDkuNDlxNC4xOSAwIDYuMDYgMi4zOXQxLjI0IDYuNDVhMTIuMzggMTIuMzggMCAwMS0xLjEgMy42NyAxMC43NCAxMC43NCAwIDAxLTIuMjcgMy4yNCA3LjkyIDcuOTIgMCAwMS0zLjc5IDIuMzMgMTcuNDYgMTcuNDYgMCAwMS00LjE4LjQ5aC00LjI1bC0xLjM0IDYuN2gtNC45M2w1LjA3LTI1LjI3bTQuMTQgNEw1Ny43NCA0NGEzIDMgMCAwMC40MiAwaC41YTE4LjU1IDE4LjU1IDAgMDA1LjY3LS42N2MxLjUxLS40OSAyLjUyLTIuMjEgMy01LjE0LjQzLTIuNDcgMC0zLjg5LTEuMjctNC4yN2ExNi4yNSAxNi4yNSAwIDAwLTQuNzEtLjUzIDcuODggNy44OCAwIDAxLS44MiAwaC0uNzQiIGZpbGw9IiNmZmYiLz48L3N2Zz4=", "php", 2 },
                    { 15, "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdCb3g9IjAgMCA4MCA4MCI+PGRlZnM+PGxpbmVhckdyYWRpZW50IGlkPSJhIiB4MT0iMTM2LjEzIiB5MT0iLTIzMy44OCIgeDI9IjIxMy43MyIgeTI9Ii0zMDAuNjQiIGdyYWRpZW50VHJhbnNmb3JtPSJtYXRyaXgoLjU2IDAgMCAtLjU3IC03OC4wOCAtMTMwLjU2KSIgZ3JhZGllbnRVbml0cz0idXNlclNwYWNlT25Vc2UiPjxzdG9wIG9mZnNldD0iMCIgc3RvcC1jb2xvcj0iIzVhOWZkNCIvPjxzdG9wIG9mZnNldD0iMSIgc3RvcC1jb2xvcj0iIzMwNjk5OCIvPjwvbGluZWFyR3JhZGllbnQ+PGxpbmVhckdyYWRpZW50IGlkPSJiIiB4MT0iMjQzLjczIiB5MT0iLTM0MS4wNSIgeDI9IjIxNi4wMiIgeTI9Ii0zMDEuODUiIGdyYWRpZW50VHJhbnNmb3JtPSJtYXRyaXgoLjU2IDAgMCAtLjU3IC03OC4wOCAtMTMwLjU2KSIgZ3JhZGllbnRVbml0cz0idXNlclNwYWNlT25Vc2UiPjxzdG9wIG9mZnNldD0iMCIgc3RvcC1jb2xvcj0iI2ZmZDQzYiIvPjxzdG9wIG9mZnNldD0iMSIgc3RvcC1jb2xvcj0iI2ZmZTg3MyIvPjwvbGluZWFyR3JhZGllbnQ+PC9kZWZzPjxwYXRoIGQ9Ik0zOS41MyAwYTU0LjQ5IDU0LjQ5IDAgMDAtOS4xMi43OGMtOC4wOCAxLjQzLTkuNTQgNC40MS05LjU0IDkuOTJWMThINDB2Mi40SDEzLjdjLTUuNTQgMC0xMC40IDMuMzMtMTEuOTIgOS42N0MwIDM3LjM0IDAgNDEuODggMS43OCA0OS40N2MxLjM2IDUuNjUgNC42IDkuNjggMTAuMTQgOS42OGg2LjU3di04LjcyYTEyLjEzIDEyLjEzIDAgMDExMS45Mi0xMS44NmgxOS4wNmE5LjYxIDkuNjEgMCAwMDkuNTMtOS43VjEwLjdjMC01LjE3LTQuMzYtOS4wNi05LjU0LTkuOTJBNTkuNjMgNTkuNjMgMCAwMDM5LjUzIDB6TTI5LjIxIDUuODVhMy42NCAzLjY0IDAgMTEtMy41OCAzLjY1IDMuNjIgMy42MiAwIDAxMy41OC0zLjY1eiIgZmlsbD0idXJsKCNhKSIvPjxwYXRoIGQ9Ik02MS4zOSAyMC40djguNDdBMTIuMjQgMTIuMjQgMCAwMTQ5LjQ3IDQxSDMwLjQxYTkuNzQgOS43NCAwIDAwLTkuNTQgOS43djE4LjE1YzAgNS4xNyA0LjQ5IDguMjEgOS41NCA5LjY5YTMxLjg3IDMxLjg3IDAgMDAxOS4wNiAwYzQuODEtMS4zOSA5LjUzLTQuMTkgOS41My05LjY5di03LjI4SDQwdi0yLjQyaDI4LjU2YzUuNTQgMCA3LjYxLTMuODcgOS41NC05LjY4IDItNiAxLjkxLTExLjczIDAtMTkuNC0xLjM3LTUuNTItNC05LjY3LTkuNTQtOS42N3ptLTEwLjcyIDQ2YTMuNjQgMy42NCAwIDExLTMuNTggMy42MyAzLjYgMy42IDAgMDEzLjU4LTMuNjF6IiBmaWxsPSJ1cmwoI2IpIi8+PC9zdmc+", "python", 2 },
                    { 16, "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdCb3g9IjAgMCA4MCA4MCI+PGRlZnM+PHN0eWxlPi5ie2ZpbGw6I2ZmZn08L3N0eWxlPjwvZGVmcz48cGF0aCBmaWxsPSIjMDkyZTIwIiBkPSJNMC0uMTFoODAuMTFWODBIMHoiLz48cGF0aCBjbGFzcz0iYiIgZD0iTTEzLjggMjguMjRoMy43OXYxNy41NGEyNSAyNSAwIDAxLTQuOTIuNTJjLTQuNjMgMC03LTIuMDktNy02LjFzMi41Ni02LjM4IDYuNTItNi4zOGE2IDYgMCAwMTEuNjUuMnYtNS43OHptMCA4LjgzYTMuNjkgMy42OSAwIDAwLTEuMjgtLjJjLTEuOTIgMC0zIDEuMTgtMyAzLjI1czEuMDYgMy4xMyAzIDMuMTNhOS40NSA5LjQ1IDAgMDAxLjMxLS4xeiIvPjxwYXRoIGNsYXNzPSJiIiBkPSJNMjMuNjEgMzQuMDl2OC43OWMwIDMtLjIyIDQuNDctLjg4IDUuNzNhNi4wOCA2LjA4IDAgMDEtMy4xIDIuOGwtMy41Mi0xLjY3YTUuNSA1LjUgMCAwMDMtMi41M2MuNTQtMS4wOS43Mi0yLjM0LjcyLTUuNjR2LTcuNDh6bS0zLjc4LTUuODNoMy43OHYzLjg5aC0zLjc4ek0yNS45IDM1YTExLjM4IDExLjM4IDAgMDE1LTEuMTRjMS45NCAwIDMuMjIuNTIgMy43OSAxLjUzYTUuODEgNS44MSAwIDAxLjQyIDIuODh2Ny43YTQyLjg0IDQyLjg0IDAgMDEtNS40MS40MmMtMy4xOCAwLTQuNjEtMS4xMS00LjYxLTMuNTcgMC0yLjY2IDEuOS0zLjg5IDYuNTUtNC4yOHYtLjg0YzAtLjY5LS4zNS0uOTMtMS4zMS0uOTNhMTAgMTAgMCAwMC00LjQ1IDEuMTVWMzV6bTUuOTMgNmMtMi41MS4yNS0zLjMyLjY0LTMuMzIgMS42MyAwIC43My40NyAxLjA4IDEuNSAxLjA4YTEwLjcgMTAuNyAwIDAwMS44Mi0uMTdWNDF6TTM3IDM0LjY4YTIyLjc5IDIyLjc5IDAgMDE2LS44NiA1LjY4IDUuNjggMCAwMTQuMTggMS4zMWMuNzkuODEgMSAxLjY5IDEgMy41OXY3LjQzaC0zLjgzdi03LjI4YzAtMS40NS0uNDktMi0xLjg0LTJhNS43NCA1Ljc0IDAgMDAtMS43NS4yN3Y5SDM3VjM0LjY4em0xMi42MSAxMy41NGE4LjczIDguNzMgMCAwMDQuMDYgMWMyLjQ5IDAgMy41NS0xIDMuNTUtMy40MnYtLjA3YTUuMTkgNS4xOSAwIDAxLTIuNDYuNTJjLTMuMzMgMC01LjQ0LTIuMTktNS40NC01LjY2IDAtNC4zMSAzLjEyLTYuNzQgOC42Ni02Ljc0YTIzLjgyIDIzLjgyIDAgMDE0Ljk0LjU0bC0xLjI5IDIuNzNjLTEtLjE5LS4wOSAwLS44NS0uMXY2LjYxYzAgMy4yNS0uMjggNC43OC0xLjA5IDYtMS4xOCAxLjg1LTMuMjIgMi43Ni02LjEyIDIuNzZhMTEgMTEgMCAwMS00LjA5LS43NHYtMy40M3ptNy41My0xMS4zMmgtLjM5YTQuMDggNC4wOCAwIDAwLTIuMTkuNTQgMi45NCAyLjk0IDAgMDAtMS4zOCAyLjc4YzAgMS44OS45NCAzIDIuNjEgM2E0LjY3IDQuNjcgMCAwMDEuNDMtLjIydi02LjF6bTExLjY2LTMuMTNjMy43OSAwIDYuMTEgMi4zOSA2LjExIDYuMjVzLTIuNDIgNi40NS02LjI1IDYuNDUtNi4xMy0yLjM5LTYuMTMtNi4yMyAyLjQxLTYuNDcgNi4yNy02LjQ3em0tLjA3IDkuNjVjMS40NSAwIDIuMzEtMS4yMSAyLjMxLTMuM3MtLjgzLTMuMy0yLjI4LTMuMy0yLjM3IDEuMjEtMi4zNyAzLjMuODYgMy4zIDIuMzQgMy4zeiIvPjwvc3ZnPg==", "django", 2 }
                });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "AvatarUrl", "Name", "PlatformTypes" },
                values: new object[] { 12, "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdCb3g9IjAgMCA4MCA4MCI+PGRlZnM+PHN0eWxlPi5ie2ZpbGw6IzYxZGFmYn08L3N0eWxlPjwvZGVmcz48cGF0aCBmaWxsPSIjMjAyMzJhIiBkPSJNMCAwaDgwdjgwSDB6Ii8+PGNpcmNsZSBjbGFzcz0iYiIgY3g9IjQwIiBjeT0iNDAiIHI9IjYuNTMiLz48cGF0aCBjbGFzcz0iYiIgZD0iTTQwIDU1QzE5LjQ3IDU1IDMuMzggNDguMzkgMy4zOCA0MFMxOS40NyAyNSA0MCAyNXMzNi42MiA2LjU3IDM2LjYyIDE1UzYwLjUzIDU1IDQwIDU1em0wLTI2Ljc1QzIwLjMgMjguMjIgNi41NyAzNC40MyA2LjU3IDQwUzIwLjMgNTEuNzggNDAgNTEuNzggNzMuNDMgNDUuNTcgNzMuNDMgNDAgNTkuNyAyOC4yMiA0MCAyOC4yMnoiLz48cGF0aCBjbGFzcz0iYiIgZD0iTTU0LjYyIDcyLjY2Yy0zLjI1IDAtNy4xNy0xLjc4LTExLjQzLTUuMjRDMzcuNTUgNjIuODMgMzEuODEgNTUuNzUgMjcgNDcuNDhjLTEwLjI3LTE3Ljc4LTEyLjYyLTM1LTUuMzUtMzkuMTkgMy43LTIuMTQgOS4wNy0uNjIgMTUuMTIgNC4zQzQyLjQ1IDE3LjE3IDQ4LjE5IDI0LjI1IDUzIDMyLjUyYzEwLjI3IDE3Ljc4IDEyLjYyIDM1IDUuMzUgMzkuMTlhNy4yNyA3LjI3IDAgMDEtMy43My45NXpNMjUuNDMgMTAuNTJhNC4xNiA0LjE2IDAgMDAtMi4xNS41M0MxOC40NiAxMy44MyAyMCAyOC44MyAyOS44IDQ1Ljg5YzQuNTggNy45NCAxMC4wNSAxNC43MSAxNS40IDE5IDQuODcgNCA5LjA3IDUuNDMgMTEuNTIgNCA0LjgyLTIuNzkgMy4zMy0xNy43OS02LjUyLTM0Ljg1LTQuNTgtNy45NC0xMC4wNS0xNC43LTE1LjQtMTktMy42Ni0yLjk1LTYuOTMtNC41Mi05LjM3LTQuNTJ6Ii8+PHBhdGggY2xhc3M9ImIiIGQ9Ik0yNS4zOCA3Mi42NmE3LjE3IDcuMTcgMCAwMS0zLjY5LTFDMTQuNDIgNjcuNTIgMTYuNzcgNTAuMyAyNyAzMi41MmM0Ljc3LTguMjcgMTAuNTEtMTUuMzUgMTYuMTUtMTkuOTMgNi4wNS00LjkyIDExLjQyLTYuNDUgMTUuMTItNC4zIDcuMjcgNC4yIDQuOTIgMjEuNDEtNS4zNSAzOS4xOS00Ljc3IDguMjctMTAuNTEgMTUuMzUtMTYuMTUgMTkuOTQtNC4yMiAzLjQ2LTguMTQgNS4yNC0xMS4zOSA1LjI0em0yOS4xOS02Mi4xNGMtMi40NCAwLTUuNzEgMS41Ny05LjM3IDQuNTQtNS4zNSA0LjM1LTEwLjgyIDExLjExLTE1LjQgMTlDMjAgNTEuMTcgMTguNDYgNjYuMTcgMjMuMjggNjljMi40NSAxLjQgNi42NS0uMDYgMTEuNTItNCA1LjM1LTQuMzQgMTAuODItMTEuMTEgMTUuNC0xOSA5Ljg1LTE3LjA2IDExLjM0LTMyLjA2IDYuNTItMzQuODRhNC4xNiA0LjE2IDAgMDAtMi4xNS0uNjR6Ii8+PC9zdmc+", "React", 1 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2021, 2, 17, 3, 12, 8, 478, DateTimeKind.Local).AddTicks(2495), "{\"sourceProjects\": [4],\"dateRange\": 4,\"issuesCount\": 489}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2019, 8, 20, 17, 33, 22, 701, DateTimeKind.Local).AddTicks(7613), "{\"sourceProjects\": [8],\"dateRange\": 2,\"issuesCount\": 977}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2019, 9, 6, 8, 3, 25, 729, DateTimeKind.Local).AddTicks(273), "{\"sourceProjects\": [5],\"dateRange\": 4,\"issuesCount\": 919}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 9, 22, 17, 12, 301, DateTimeKind.Local).AddTicks(8247));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2020, 8, 30, 21, 4, 19, 128, DateTimeKind.Local).AddTicks(8308), "{\"sourceProjects\": [10],\"dateRange\": 2,\"issuesCount\": 74}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 2, 4, 16, 41, 16, 758, DateTimeKind.Local).AddTicks(2352));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2020, 8, 23, 12, 13, 0, 610, DateTimeKind.Local).AddTicks(5836), "{\"sourceProjects\": [6],\"dateRange\": 0,\"issuesCount\": 19}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2020, 3, 8, 18, 19, 58, 792, DateTimeKind.Local).AddTicks(7240), "{\"sourceProjects\": [3],\"dateRange\": 2,\"issuesCount\": 109}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2021, 4, 26, 12, 36, 50, 124, DateTimeKind.Local).AddTicks(8362), "{\"sourceProjects\": [7],\"dateRange\": 1,\"issuesCount\": 679}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2020, 10, 21, 3, 2, 35, 133, DateTimeKind.Local).AddTicks(389), "{\"sourceProjects\": [4],\"dateRange\": 1,\"issuesCount\": 156}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2020, 9, 15, 9, 39, 3, 446, DateTimeKind.Local).AddTicks(3407), "{\"sourceProjects\": [11],\"dateRange\": 4,\"issuesCount\": 375}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2021, 4, 21, 22, 47, 7, 618, DateTimeKind.Local).AddTicks(7519), "{\"sourceProjects\": [7],\"dateRange\": 1,\"issuesCount\": 760}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2021, 6, 26, 12, 48, 57, 981, DateTimeKind.Local).AddTicks(655), "{\"sourceProjects\": [11],\"dateRange\": 1,\"issuesCount\": 391}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2020, 2, 14, 15, 15, 23, 972, DateTimeKind.Local).AddTicks(7722), "{\"sourceProjects\": [4],\"dateRange\": 4,\"issuesCount\": 183}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2021, 7, 25, 22, 12, 32, 652, DateTimeKind.Local).AddTicks(1648), "{\"sourceProjects\": [14],\"dateRange\": 1,\"issuesCount\": 833}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2021, 4, 17, 22, 29, 41, 828, DateTimeKind.Local).AddTicks(5684), "{\"sourceProjects\": [3],\"dateRange\": 1,\"issuesCount\": 143}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 8, 20, 4, 5, 303, DateTimeKind.Local).AddTicks(8051));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2020, 8, 13, 4, 49, 4, 746, DateTimeKind.Local).AddTicks(6605), "{\"sourceProjects\": [15],\"dateRange\": 1,\"issuesCount\": 457}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2020, 5, 29, 0, 53, 33, 735, DateTimeKind.Local).AddTicks(780), "{\"sourceProjects\": [5],\"dateRange\": 0,\"issuesCount\": 729}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2021, 5, 2, 11, 4, 7, 650, DateTimeKind.Local).AddTicks(6242), "{\"sourceProjects\": [3],\"dateRange\": 3,\"issuesCount\": 148}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2020, 9, 5, 22, 44, 37, 772, DateTimeKind.Local).AddTicks(9524), "{\"sourceProjects\": [11],\"dateRange\": 3,\"issuesCount\": 69}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2020, 10, 1, 23, 45, 56, 272, DateTimeKind.Local).AddTicks(4255), "{\"sourceProjects\": [12],\"dateRange\": 3,\"issuesCount\": 60}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2021, 5, 30, 20, 10, 20, 814, DateTimeKind.Local).AddTicks(2083), "{\"sourceProjects\": [10],\"dateRange\": 1,\"issuesCount\": 691}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2020, 9, 15, 0, 40, 15, 246, DateTimeKind.Local).AddTicks(876), "{\"sourceProjects\": [15],\"dateRange\": 4,\"issuesCount\": 969}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2020, 6, 17, 22, 55, 15, 954, DateTimeKind.Local).AddTicks(9771), "{\"sourceProjects\": [14],\"dateRange\": 1,\"issuesCount\": 725}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2021, 7, 16, 17, 49, 39, 347, DateTimeKind.Local).AddTicks(3365), "{\"sourceProjects\": [5],\"dateRange\": 3,\"issuesCount\": 790}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2021, 7, 27, 2, 0, 44, 493, DateTimeKind.Local).AddTicks(9978), "{\"sourceProjects\": [14],\"dateRange\": 4,\"issuesCount\": 737}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2020, 9, 15, 6, 2, 29, 186, DateTimeKind.Local).AddTicks(8987), "{\"sourceProjects\": [15],\"dateRange\": 1,\"issuesCount\": 461}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2019, 9, 10, 12, 13, 35, 264, DateTimeKind.Local).AddTicks(3769), "{\"sourceProjects\": [8],\"dateRange\": 1,\"issuesCount\": 626}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2020, 8, 3, 11, 1, 53, 468, DateTimeKind.Local).AddTicks(7741), "{\"sourceProjects\": [9],\"dateRange\": 0,\"issuesCount\": 784}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2020, 7, 17, 19, 36, 55, 974, DateTimeKind.Local).AddTicks(3670), "{\"sourceProjects\": [10],\"dateRange\": 1,\"issuesCount\": 202}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2020, 6, 25, 18, 4, 0, 458, DateTimeKind.Local).AddTicks(3430), "{\"sourceProjects\": [12],\"dateRange\": 0,\"issuesCount\": 67}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2020, 12, 13, 18, 44, 23, 266, DateTimeKind.Local).AddTicks(7117), "{\"sourceProjects\": [10],\"dateRange\": 2,\"issuesCount\": 440}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2021, 5, 7, 23, 5, 20, 450, DateTimeKind.Local).AddTicks(4621), "{\"sourceProjects\": [9],\"dateRange\": 2,\"issuesCount\": 735}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2021, 4, 29, 9, 22, 2, 206, DateTimeKind.Local).AddTicks(4647), "{\"sourceProjects\": [13],\"dateRange\": 2,\"issuesCount\": 866}" });

            migrationBuilder.UpdateData(
                table: "ApplicationTeams",
                keyColumn: "Id",
                keyValue: 18,
                column: "ApplicationId",
                value: 13);

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId" },
                values: new object[] { new DateTime(2021, 6, 20, 4, 1, 54, 96, DateTimeKind.Unspecified).AddTicks(6185), 5, "unleash back-end supply-chains", "Fisher, Lehner and Champlin", 1, 14 });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy", "Description", "Name", "PlatformId" },
                values: new object[] { new DateTime(2019, 7, 30, 17, 0, 56, 106, DateTimeKind.Unspecified).AddTicks(8790), 3, "exploit scalable platforms", "Cole, Bartoletti and Prohaska", 16 });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId" },
                values: new object[] { new DateTime(2020, 10, 29, 10, 39, 4, 413, DateTimeKind.Unspecified).AddTicks(5606), 20, "enhance efficient communities", "Nitzsche, Vandervort and Nolan", 5, 17 });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId" },
                values: new object[] { new DateTime(2019, 10, 29, 10, 58, 52, 199, DateTimeKind.Unspecified).AddTicks(4340), 11, "incentivize robust applications", "Dibbert, Muller and Beier", 4, 12 });

            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "Id", "AlertSettings", "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId" },
                values: new object[,]
                {
                    { 15, null, new DateTime(2019, 10, 6, 4, 20, 27, 200, DateTimeKind.Unspecified).AddTicks(4990), 9, "redefine B2B partnerships", "Franecki - Fahey", 1, 12 },
                    { 14, null, new DateTime(2021, 2, 15, 8, 18, 38, 596, DateTimeKind.Unspecified).AddTicks(2936), 20, "orchestrate customized partnerships", "Olson Group", 5, 18 }
                });

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
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DropColumn(
                name: "PlatformTypes",
                table: "Platforms");

            migrationBuilder.DropColumn(
                name: "AlertSettings",
                table: "Applications");

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

            migrationBuilder.AddColumn<string>(
                name: "SecurityToken",
                table: "Applications",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Samples",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Samples", x => x.Id);
                });

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
                columns: new[] { "CreatedAt", "CreatedBy", "Name", "OrganizationId", "PlatformId", "SecurityToken" },
                values: new object[] { new DateTime(2021, 2, 12, 2, 4, 53, 954, DateTimeKind.Unspecified).AddTicks(9302), 19, "et", 4, 1, "382c872c306c5e42126fd20bd128d2f8" });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy", "Name", "PlatformId", "SecurityToken" },
                values: new object[] { new DateTime(2019, 11, 9, 2, 34, 53, 333, DateTimeKind.Unspecified).AddTicks(609), 14, "eaque", 1, "740bfaea383def5780176e65ae10e04f" });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy", "Name", "PlatformId", "SecurityToken" },
                values: new object[] { new DateTime(2021, 5, 2, 8, 9, 18, 808, DateTimeKind.Unspecified).AddTicks(603), 6, "aliquid", 1, "4e71098eaf39041db98db018db344bc4" });

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
                columns: new[] { "CreatedAt", "CreatedBy", "Name", "OrganizationId", "PlatformId", "SecurityToken" },
                values: new object[] { new DateTime(2020, 11, 1, 23, 50, 36, 645, DateTimeKind.Unspecified).AddTicks(6625), 1, "tempora", 2, 10, "f41296e7015528714a10e9c0c05ec3f0" });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "CreatedBy", "Name", "OrganizationId", "PlatformId", "SecurityToken" },
                values: new object[] { new DateTime(2020, 12, 4, 12, 59, 54, 245, DateTimeKind.Unspecified).AddTicks(9861), 12, "fugit", 1, 10, "b5d6e399dc98eb83345815910bd25138" });

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
                columns: new[] { "CreatedAt", "CreatedBy", "Name", "OrganizationId", "PlatformId", "SecurityToken" },
                values: new object[] { new DateTime(2020, 9, 15, 5, 54, 32, 534, DateTimeKind.Unspecified).AddTicks(1538), 10, "reiciendis", 2, 7, "59655ae4c809e4e3983efc33bafd62d7" });

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
                columns: new[] { "CreatedAt", "CreatedBy", "Name", "PlatformId", "SecurityToken" },
                values: new object[] { new DateTime(2021, 4, 10, 17, 22, 41, 492, DateTimeKind.Unspecified).AddTicks(341), 13, "iusto", 10, "ad178b7cc87610aefaba124101bf5988" });

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

            migrationBuilder.InsertData(
                table: "Samples",
                columns: new[] { "Id", "Body", "CreatedAt", "CreatedBy", "Title" },
                values: new object[] { 2, "Eligendi quisquam ullam iure praesentium numquam sapiente distinctio ad. Tempore voluptatibus ad et adipisci hic amet. Corporis soluta cupiditate soluta. Provident rerum nemo dolores debitis dicta voluptatem labore dolores adipisci. Adipisci illo quidem sit dolores. Ea dolor animi quod laborum quia perspiciatis sunt tempora.", new DateTime(2020, 7, 1, 1, 14, 20, 556, DateTimeKind.Unspecified).AddTicks(7372), 5, "hic" });

            migrationBuilder.InsertData(
                table: "Samples",
                columns: new[] { "Id", "Body", "CreatedAt", "CreatedBy", "Title" },
                values: new object[,]
                {
                    { 11, "Eos eum perferendis nisi alias et ducimus repudiandae ut. Voluptas rerum ullam omnis placeat non ea voluptatibus. Sint et et asperiores omnis recusandae saepe laborum enim. Non consequatur voluptatem in aut quia quo quo. Commodi aliquid aut quaerat adipisci. Modi ea maxime doloribus qui sint.", new DateTime(2021, 3, 24, 14, 25, 37, 776, DateTimeKind.Unspecified).AddTicks(56), 1, "in" },
                    { 10, "Molestias porro exercitationem omnis et eius. Est consequatur esse sit quia dolorem sequi doloribus corporis. Perspiciatis qui dignissimos.", new DateTime(2021, 4, 7, 22, 46, 32, 439, DateTimeKind.Unspecified).AddTicks(5958), 3, "esse" },
                    { 9, "Omnis culpa earum modi eos beatae autem. Deleniti labore veritatis dolorum. Omnis perferendis ut sit nulla autem ut voluptatem voluptas ut.", new DateTime(2021, 3, 25, 21, 11, 5, 602, DateTimeKind.Unspecified).AddTicks(6614), 5, "perspiciatis" },
                    { 8, "Nesciunt placeat et consectetur enim. Consectetur magnam perspiciatis ut rem perspiciatis odit dolorem. Modi corrupti corrupti.", new DateTime(2020, 1, 27, 9, 1, 30, 801, DateTimeKind.Unspecified).AddTicks(8159), 3, "corporis" },
                    { 7, "Doloremque omnis facilis unde exercitationem consectetur culpa porro consequatur sed. Vel rem rerum eum harum. Ratione voluptate est officia accusamus doloremque perferendis ea. Unde iure laudantium ut amet repellendus enim consequatur dolor porro. Sed expedita dolorem aperiam ipsa omnis. Ut omnis ipsa quia cupiditate iure.", new DateTime(2019, 7, 23, 7, 33, 40, 245, DateTimeKind.Unspecified).AddTicks(9313), 5, "impedit" },
                    { 6, "Iusto aspernatur nihil iure ut blanditiis veritatis quas. Et illum quod atque nulla voluptas quos beatae quaerat consequatur. Ab placeat tenetur perferendis et omnis. Doloremque corrupti deserunt sint enim ex sit.", new DateTime(2021, 4, 7, 16, 50, 6, 239, DateTimeKind.Unspecified).AddTicks(5929), 3, "facere" },
                    { 5, "Sapiente et saepe ut atque dolore accusantium soluta cumque perferendis. Magni adipisci labore corrupti. Ratione et quibusdam consequatur voluptatem velit expedita eos maxime.", new DateTime(2020, 2, 2, 15, 3, 56, 551, DateTimeKind.Unspecified).AddTicks(1864), 5, "placeat" },
                    { 4, "Architecto laboriosam culpa cumque dicta in. Perspiciatis amet autem rerum recusandae perspiciatis pariatur. Eum sint molestiae quis neque tempora ab distinctio. Nobis nulla dignissimos voluptas nemo cumque tenetur quod et placeat. Nihil sit eos similique fuga enim dolores ullam suscipit.", new DateTime(2021, 1, 18, 12, 14, 38, 642, DateTimeKind.Unspecified).AddTicks(7703), 1, "est" },
                    { 3, "Incidunt perferendis omnis. Quas voluptatem beatae vitae sunt a ut sed repellendus. Accusamus eos enim consequatur et praesentium ad ut beatae eius. Omnis voluptas error et velit autem ipsa atque consequuntur vitae. Nostrum accusamus soluta nisi.", new DateTime(2020, 11, 26, 1, 10, 54, 982, DateTimeKind.Unspecified).AddTicks(9175), 4, "velit" }
                });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2021, 2, 17, 0, 13, 23, 617, DateTimeKind.Local).AddTicks(4950), "{\"sourceProjects\": [3],\"dateRange\": 4,\"issuesCount\": 489}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2019, 8, 20, 14, 34, 37, 836, DateTimeKind.Local).AddTicks(8467), "{\"sourceProjects\": [6],\"dateRange\": 2,\"issuesCount\": 977}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2019, 9, 6, 5, 4, 40, 864, DateTimeKind.Local).AddTicks(511), "{\"sourceProjects\": [4],\"dateRange\": 4,\"issuesCount\": 919}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 9, 19, 18, 27, 436, DateTimeKind.Local).AddTicks(8397));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2020, 8, 30, 18, 5, 34, 263, DateTimeKind.Local).AddTicks(8230), "{\"sourceProjects\": [7],\"dateRange\": 2,\"issuesCount\": 74}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 2, 4, 13, 42, 31, 893, DateTimeKind.Local).AddTicks(2296));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2020, 8, 23, 9, 14, 15, 745, DateTimeKind.Local).AddTicks(5718), "{\"sourceProjects\": [4],\"dateRange\": 0,\"issuesCount\": 19}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2020, 3, 8, 15, 21, 13, 927, DateTimeKind.Local).AddTicks(7090), "{\"sourceProjects\": [2],\"dateRange\": 2,\"issuesCount\": 109}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2021, 4, 26, 9, 38, 5, 259, DateTimeKind.Local).AddTicks(8177), "{\"sourceProjects\": [5],\"dateRange\": 1,\"issuesCount\": 679}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2020, 10, 21, 0, 3, 50, 268, DateTimeKind.Local).AddTicks(167), "{\"sourceProjects\": [3],\"dateRange\": 1,\"issuesCount\": 156}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2020, 9, 15, 6, 40, 18, 581, DateTimeKind.Local).AddTicks(2895), "{\"sourceProjects\": [7],\"dateRange\": 4,\"issuesCount\": 375}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2021, 4, 21, 19, 48, 22, 753, DateTimeKind.Local).AddTicks(6968), "{\"sourceProjects\": [5],\"dateRange\": 1,\"issuesCount\": 760}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2021, 6, 26, 9, 50, 13, 116, DateTimeKind.Local).AddTicks(54), "{\"sourceProjects\": [7],\"dateRange\": 1,\"issuesCount\": 391}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2020, 2, 14, 12, 16, 39, 107, DateTimeKind.Local).AddTicks(7075), "{\"sourceProjects\": [3],\"dateRange\": 4,\"issuesCount\": 183}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2021, 7, 25, 19, 13, 47, 787, DateTimeKind.Local).AddTicks(955), "{\"sourceProjects\": [9],\"dateRange\": 1,\"issuesCount\": 833}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2021, 4, 17, 19, 30, 56, 963, DateTimeKind.Local).AddTicks(4947), "{\"sourceProjects\": [2],\"dateRange\": 1,\"issuesCount\": 143}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 8, 17, 5, 20, 438, DateTimeKind.Local).AddTicks(7248));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2020, 8, 13, 1, 50, 19, 881, DateTimeKind.Local).AddTicks(5758), "{\"sourceProjects\": [10],\"dateRange\": 1,\"issuesCount\": 457}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2020, 5, 28, 21, 54, 48, 869, DateTimeKind.Local).AddTicks(9905), "{\"sourceProjects\": [3],\"dateRange\": 0,\"issuesCount\": 729}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2021, 5, 2, 8, 5, 22, 785, DateTimeKind.Local).AddTicks(5313), "{\"sourceProjects\": [2],\"dateRange\": 3,\"issuesCount\": 148}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2020, 9, 5, 19, 45, 52, 907, DateTimeKind.Local).AddTicks(8544), "{\"sourceProjects\": [8],\"dateRange\": 3,\"issuesCount\": 69}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2020, 10, 1, 20, 47, 11, 407, DateTimeKind.Local).AddTicks(3217), "{\"sourceProjects\": [8],\"dateRange\": 3,\"issuesCount\": 60}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2021, 5, 30, 17, 11, 35, 949, DateTimeKind.Local).AddTicks(990), "{\"sourceProjects\": [7],\"dateRange\": 1,\"issuesCount\": 691}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2020, 9, 14, 21, 41, 30, 380, DateTimeKind.Local).AddTicks(9745), "{\"sourceProjects\": [10],\"dateRange\": 4,\"issuesCount\": 969}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2020, 6, 17, 19, 56, 31, 89, DateTimeKind.Local).AddTicks(8581), "{\"sourceProjects\": [10],\"dateRange\": 1,\"issuesCount\": 725}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2021, 7, 16, 14, 50, 54, 482, DateTimeKind.Local).AddTicks(2126), "{\"sourceProjects\": [4],\"dateRange\": 3,\"issuesCount\": 790}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2021, 7, 26, 23, 1, 59, 628, DateTimeKind.Local).AddTicks(8686), "{\"sourceProjects\": [10],\"dateRange\": 4,\"issuesCount\": 737}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2020, 9, 15, 3, 3, 44, 321, DateTimeKind.Local).AddTicks(7615), "{\"sourceProjects\": [10],\"dateRange\": 1,\"issuesCount\": 461}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2019, 9, 10, 9, 14, 50, 399, DateTimeKind.Local).AddTicks(2348), "{\"sourceProjects\": [5],\"dateRange\": 1,\"issuesCount\": 626}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2020, 8, 3, 8, 3, 8, 603, DateTimeKind.Local).AddTicks(6253), "{\"sourceProjects\": [6],\"dateRange\": 0,\"issuesCount\": 784}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2020, 7, 17, 16, 38, 11, 109, DateTimeKind.Local).AddTicks(2130), "{\"sourceProjects\": [7],\"dateRange\": 1,\"issuesCount\": 202}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2020, 6, 25, 15, 5, 15, 593, DateTimeKind.Local).AddTicks(1691), "{\"sourceProjects\": [8],\"dateRange\": 0,\"issuesCount\": 67}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2020, 12, 13, 15, 45, 38, 401, DateTimeKind.Local).AddTicks(5188), "{\"sourceProjects\": [7],\"dateRange\": 2,\"issuesCount\": 440}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2021, 5, 7, 20, 6, 35, 585, DateTimeKind.Local).AddTicks(2442), "{\"sourceProjects\": [6],\"dateRange\": 2,\"issuesCount\": 735}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "Settings" },
                values: new object[] { new DateTime(2021, 4, 29, 6, 23, 17, 341, DateTimeKind.Local).AddTicks(2360), "{\"sourceProjects\": [9],\"dateRange\": 2,\"issuesCount\": 866}" });
        }
    }
}
