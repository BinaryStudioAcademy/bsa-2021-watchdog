using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Watchdog.Core.DAL.Migrations
{
    public partial class RemoveUniqueTeamName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Teams_Name",
                table: "Teams");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 1,
                column: "ApiKey",
                value: "3D576A66-C2D0-B973-5496-049EC4C8B237");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ApiKey", "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId" },
                values: new object[] { "2ABB45FA-6B15-73FA-4D00-739E2245C578", new DateTime(2021, 2, 12, 2, 4, 53, 954, DateTimeKind.Unspecified).AddTicks(9302), 19, "enable rich convergence", "Lang Group", 4, 2 });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ApiKey", "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId" },
                values: new object[] { "392A4645-25A4-5E97-C82D-FD2A8198A350", new DateTime(2020, 4, 6, 21, 58, 23, 764, DateTimeKind.Unspecified).AddTicks(5366), 7, "transform dot-com content", "Leuschke - Adams", 5, 8 });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ApiKey", "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId" },
                values: new object[] { "6266BC9A-789E-4851-26B4-49135C4E06C4", new DateTime(2021, 1, 10, 15, 3, 19, 975, DateTimeKind.Unspecified).AddTicks(2834), 2, "iterate open-source methodologies", "Monahan LLC", 1, 12 });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ApiKey", "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId" },
                values: new object[] { "CB5F6485-86D2-8B54-DBF7-658F84D83972", new DateTime(2019, 10, 13, 12, 5, 2, 725, DateTimeKind.Unspecified).AddTicks(731), 7, "morph scalable e-commerce", "Goyette, Larkin and Boyer", 2, 7 });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ApiKey", "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId" },
                values: new object[] { "AB779A58-AA46-CCF9-E3C6-E8778C07C32B", new DateTime(2019, 8, 14, 17, 42, 2, 349, DateTimeKind.Unspecified).AddTicks(9103), 3, "morph world-class web services", "Gleichner, Hammes and Hintz", 1, 17 });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ApiKey", "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId" },
                values: new object[] { "C138099D-EAF7-22F5-FBF0-634C1FE48B0C", new DateTime(2021, 6, 15, 19, 59, 35, 109, DateTimeKind.Unspecified).AddTicks(3753), 3, "synthesize bleeding-edge paradigms", "Harber - Collins", 2, 12 });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ApiKey", "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId" },
                values: new object[] { "9BEDE7D8-200E-91F6-0CF0-9322CEFE826A", new DateTime(2019, 11, 20, 11, 41, 29, 323, DateTimeKind.Unspecified).AddTicks(8875), 12, "generate killer e-business", "Price and Sons", 2, 11 });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ApiKey", "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId" },
                values: new object[] { "574FDA26-EA17-11A7-0D35-5FE143558ED8", new DateTime(2020, 12, 4, 12, 59, 54, 245, DateTimeKind.Unspecified).AddTicks(9861), 12, "evolve one-to-one relationships", "Schultz, Conroy and Hane", 1, 18 });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ApiKey", "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId" },
                values: new object[] { "7DB45655-3483-D02F-CFB6-BD987C3726ED", new DateTime(2020, 9, 11, 23, 4, 44, 138, DateTimeKind.Unspecified).AddTicks(6437), 9, "harness out-of-the-box deliverables", "Shanahan - Bayer", 3, 3 });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ApiKey", "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId" },
                values: new object[] { "19480132-0B6A-BC77-9551-5C90B12AB273", new DateTime(2021, 1, 2, 17, 17, 10, 167, DateTimeKind.Unspecified).AddTicks(9812), 18, "morph out-of-the-box relationships", "Oberbrunner - Volkman", 1, 11 });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ApiKey", "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId" },
                values: new object[] { "EB29D6EE-AD68-0292-2D87-B64CB120BFA2", new DateTime(2021, 2, 5, 12, 2, 8, 727, DateTimeKind.Unspecified).AddTicks(3042), 16, "grow killer functionalities", "Kling, Hintz and Okuneva", 2, 7 });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ApiKey", "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId" },
                values: new object[] { "4936F4CE-812E-742E-89E6-6B65F3E31F28", new DateTime(2021, 2, 3, 5, 11, 14, 419, DateTimeKind.Unspecified).AddTicks(2970), 13, "visualize robust applications", "Ondricka LLC", 4, 13 });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ApiKey", "CreatedAt", "CreatedBy", "Description", "Name" },
                values: new object[] { "AF16B9B4-84C6-3858-DE9D-CBE459351D3C", new DateTime(2020, 2, 5, 6, 23, 41, 435, DateTimeKind.Unspecified).AddTicks(7930), 14, "optimize vertical infomediaries", "Kovacek - Hirthe" });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ApiKey", "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId" },
                values: new object[] { "EDC608D6-DCB7-A466-CC75-5EDA20E70DBB", new DateTime(2021, 4, 16, 6, 3, 51, 505, DateTimeKind.Unspecified).AddTicks(7350), 6, "visualize ubiquitous channels", "Kunde Group", 5, 6 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 1,
                column: "ApiKey",
                value: "7780B80F-5FD6-4BE0-B0B8-D66CE988DB9D");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ApiKey", "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId" },
                values: new object[] { "AFEC1C46-C01C-4AF8-BA42-B5C7913B501D", new DateTime(2019, 8, 12, 17, 20, 56, 326, DateTimeKind.Unspecified).AddTicks(9638), 8, "cultivate granular infrastructures", "Schmidt - Hilpert", 1, 3 });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ApiKey", "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId" },
                values: new object[] { "ED51B204-B786-4F36-A0D3-4D188999BDBF", new DateTime(2019, 7, 30, 17, 0, 56, 106, DateTimeKind.Unspecified).AddTicks(8790), 3, "exploit scalable platforms", "Cole, Bartoletti and Prohaska", 3, 16 });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ApiKey", "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId" },
                values: new object[] { "0D7E6C59-C8D8-44D0-AE9E-F19624529DF5", new DateTime(2020, 2, 23, 12, 13, 2, 529, DateTimeKind.Unspecified).AddTicks(289), 1, "cultivate one-to-one web-readiness", "Schmeler - Boehm", 3, 6 });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ApiKey", "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId" },
                values: new object[] { "3482B274-9CEE-44EE-A1AB-005B236107A1", new DateTime(2020, 10, 29, 10, 39, 4, 413, DateTimeKind.Unspecified).AddTicks(5606), 20, "enhance efficient communities", "Nitzsche, Vandervort and Nolan", 5, 17 });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ApiKey", "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId" },
                values: new object[] { "18EB3E31-6F02-4332-B38A-4DB87EF530FB", new DateTime(2020, 4, 6, 21, 58, 23, 764, DateTimeKind.Unspecified).AddTicks(5366), 7, "transform dot-com content", "Leuschke - Adams", 5, 8 });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ApiKey", "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId" },
                values: new object[] { "4A1C44B8-B6E9-47DD-8077-8FC4B9D5E69D", new DateTime(2019, 11, 9, 2, 34, 53, 333, DateTimeKind.Unspecified).AddTicks(609), 14, "implement B2B blockchains", "Breitenberg, Bednar and Ullrich", 1, 2 });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ApiKey", "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId" },
                values: new object[] { "B3854AA4-A529-4B2A-8F03-F8FE72823A61", new DateTime(2020, 3, 12, 14, 10, 16, 522, DateTimeKind.Unspecified).AddTicks(8649), 19, "target leading-edge paradigms", "Gleichner - Tromp", 4, 10 });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ApiKey", "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId" },
                values: new object[] { "51880460-BFF5-41AA-A52B-7B058EC5218D", new DateTime(2019, 10, 29, 10, 58, 52, 199, DateTimeKind.Unspecified).AddTicks(4340), 11, "incentivize robust applications", "Dibbert, Muller and Beier", 4, 12 });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ApiKey", "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId" },
                values: new object[] { "30A12F02-CA94-4089-969D-0671AC291C73", new DateTime(2019, 12, 8, 6, 2, 36, 243, DateTimeKind.Unspecified).AddTicks(7412), 15, "exploit bricks-and-clicks communities", "Beier, Bergnaum and Lesch", 2, 5 });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ApiKey", "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId" },
                values: new object[] { "63AD102A-58CF-46C0-8C10-ADCEAE2E8955", new DateTime(2019, 10, 13, 12, 5, 2, 725, DateTimeKind.Unspecified).AddTicks(731), 7, "morph scalable e-commerce", "Larkin Inc", 2, 7 });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ApiKey", "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId" },
                values: new object[] { "B44E7E2D-3B81-4189-9916-3AF83F7B108B", new DateTime(2020, 10, 16, 17, 41, 22, 99, DateTimeKind.Unspecified).AddTicks(4346), 4, "cultivate killer metrics", "Wintheiser - Ward", 4, 4 });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ApiKey", "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId" },
                values: new object[] { "F1929F7E-C003-4185-9C80-E65B60BEBDD3", new DateTime(2020, 10, 20, 17, 49, 27, 974, DateTimeKind.Unspecified).AddTicks(474), 7, "expedite sticky applications", "Conroy - Yost", 5, 5 });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ApiKey", "CreatedAt", "CreatedBy", "Description", "Name" },
                values: new object[] { "F67B3095-8977-4558-9D09-AA50992BBD6C", new DateTime(2021, 2, 15, 8, 18, 38, 596, DateTimeKind.Unspecified).AddTicks(2936), 20, "orchestrate customized partnerships", "Olson Group" });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ApiKey", "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId" },
                values: new object[] { "C62F35E9-4D32-4A1D-B14F-1BDBBE427B8A", new DateTime(2019, 10, 6, 4, 20, 27, 200, DateTimeKind.Unspecified).AddTicks(4990), 9, "redefine B2B partnerships", "Franecki - Fahey", 1, 12 });

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Name",
                table: "Teams",
                column: "Name",
                unique: true);
        }
    }
}
