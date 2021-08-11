using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Watchdog.Core.DAL.Migrations
{
    public partial class DropSecureTocken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SecurityToken",
                table: "Applications");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "PlatformId" },
                values: new object[] { new DateTime(2021, 6, 20, 4, 1, 54, 96, DateTimeKind.Unspecified).AddTicks(6185), 5, 1, 14 });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId" },
                values: new object[] { new DateTime(2019, 8, 12, 17, 20, 56, 326, DateTimeKind.Unspecified).AddTicks(9638), 8, "cultivate granular infrastructures", "Schmidt - Hilpert", 1, 3 });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId" },
                values: new object[] { new DateTime(2019, 7, 30, 17, 0, 56, 106, DateTimeKind.Unspecified).AddTicks(8790), 3, "exploit scalable platforms", "Cole, Bartoletti and Prohaska", 3, 16 });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId" },
                values: new object[] { new DateTime(2020, 2, 23, 12, 13, 2, 529, DateTimeKind.Unspecified).AddTicks(289), 1, "cultivate one-to-one web-readiness", "Schmeler - Boehm", 3, 6 });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId" },
                values: new object[] { new DateTime(2020, 10, 29, 10, 39, 4, 413, DateTimeKind.Unspecified).AddTicks(5606), 20, "enhance efficient communities", "Nitzsche, Vandervort and Nolan", 5, 17 });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId" },
                values: new object[] { new DateTime(2020, 4, 6, 21, 58, 23, 764, DateTimeKind.Unspecified).AddTicks(5366), 7, "transform dot-com content", "Leuschke - Adams", 5 });

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
                keyValue: 9,
                columns: new[] { "CreatedAt", "Description", "Name", "OrganizationId", "PlatformId" },
                values: new object[] { new DateTime(2019, 10, 29, 10, 58, 52, 199, DateTimeKind.Unspecified).AddTicks(4340), "incentivize robust applications", "Dibbert, Muller and Beier", 4, 12 });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId" },
                values: new object[] { new DateTime(2019, 12, 8, 6, 2, 36, 243, DateTimeKind.Unspecified).AddTicks(7412), 15, "exploit bricks-and-clicks communities", "Beier, Bergnaum and Lesch", 2, 5 });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId" },
                values: new object[] { new DateTime(2019, 10, 13, 12, 5, 2, 725, DateTimeKind.Unspecified).AddTicks(731), 7, "morph scalable e-commerce", "Larkin Inc", 2, 7 });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "CreatedBy", "Description", "Name", "PlatformId" },
                values: new object[] { new DateTime(2020, 10, 16, 17, 41, 22, 99, DateTimeKind.Unspecified).AddTicks(4346), 4, "cultivate killer metrics", "Wintheiser - Ward", 4 });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId" },
                values: new object[] { new DateTime(2020, 10, 20, 17, 49, 27, 974, DateTimeKind.Unspecified).AddTicks(474), 7, "expedite sticky applications", "Conroy - Yost", 5, 5 });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId" },
                values: new object[] { new DateTime(2021, 2, 15, 8, 18, 38, 596, DateTimeKind.Unspecified).AddTicks(2936), 20, "orchestrate customized partnerships", "Olson Group", 5, 18 });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "CreatedBy", "Description", "Name", "PlatformId" },
                values: new object[] { new DateTime(2019, 10, 6, 4, 20, 27, 200, DateTimeKind.Unspecified).AddTicks(4990), 9, "redefine B2B partnerships", "Franecki - Fahey", 12 });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "In maiores aut totam nam sint. Voluptatem nihil porro tempora aliquid voluptas cumque veritatis architecto est. Dolorem distinctio est quisquam. Rerum perferendis ab quia unde repellat modi sunt. Vel placeat voluptatibus harum odio.");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Numquam assumenda possimus minima et dolorum libero velit. Voluptatum dolor dignissimos voluptatem ullam rerum. Cum et vero blanditiis et nisi reprehenderit quia. Et rerum ut culpa porro et. Voluptatem excepturi tenetur necessitatibus recusandae dignissimos tempore quia.");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Assumenda architecto numquam omnis assumenda ipsa et inventore. Iure culpa quia ab accusamus. Iusto quibusdam odio id magni fugiat. Quae ratione exercitationem consequatur nisi illo facere ut.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SecurityToken",
                table: "Applications",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "PlatformId", "SecurityToken" },
                values: new object[] { new DateTime(2019, 8, 18, 22, 5, 24, 907, DateTimeKind.Unspecified).AddTicks(5351), 15, 2, 1, "2c306c5e42126fd20bd128d2f8c1e307" });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId", "SecurityToken" },
                values: new object[] { new DateTime(2019, 8, 13, 23, 53, 43, 570, DateTimeKind.Unspecified).AddTicks(6998), 14, "enhance efficient communities", "Vandervort - Nolan", 3, 17, "def5780176e65ae10e04f11ad54e7109" });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId", "SecurityToken" },
                values: new object[] { new DateTime(2020, 8, 3, 23, 52, 58, 240, DateTimeKind.Unspecified).AddTicks(6701), 8, "incentivize robust applications", "Muller Inc", 2, 3, "b98db018db344bc481419654e6fee6db" });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId", "SecurityToken" },
                values: new object[] { new DateTime(2021, 6, 15, 19, 59, 35, 109, DateTimeKind.Unspecified).AddTicks(3753), 3, "aggregate next-generation methodologies", "Yost LLC", 2, 12, "4554af2e1fff3533f41296e701552871" });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId", "SecurityToken" },
                values: new object[] { new DateTime(2020, 1, 25, 22, 41, 22, 327, DateTimeKind.Unspecified).AddTicks(9806), 1, "drive clicks-and-mortar e-services", "Mohr, Rosenbaum and Balistreri", 4, 2, "ec3f03e051b5d6e399dc98eb83345815" });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "SecurityToken" },
                values: new object[] { new DateTime(2021, 4, 21, 14, 16, 33, 196, DateTimeKind.Unspecified).AddTicks(986), 20, "architect sexy partnerships", "Conroy, Hane and Boyer", 1, "f94490637f3b5d86c09ad05bb62664b8" });

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
                columns: new[] { "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId", "SecurityToken" },
                values: new object[] { new DateTime(2020, 6, 28, 13, 18, 7, 643, DateTimeKind.Unspecified).AddTicks(9586), 10, "architect innovative infomediaries", "Hintz - Runte", 5, 2, "baf221ea765f963abb1d9b933c75226a" });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Description", "Name", "OrganizationId", "PlatformId", "SecurityToken" },
                values: new object[] { new DateTime(2021, 3, 1, 22, 43, 39, 144, DateTimeKind.Unspecified).AddTicks(7803), "deliver web-enabled portals", "Kutch, Schneider and Satterfield", 1, 6, "10aefaba124101bf59884fa27fbe3e44" });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId", "SecurityToken" },
                values: new object[] { new DateTime(2021, 4, 20, 3, 4, 26, 305, DateTimeKind.Unspecified).AddTicks(8228), 12, "expedite bleeding-edge vortals", "Towne - Kutch", 1, 16, "5880670873ff126860fc72effb88671e" });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId", "SecurityToken" },
                values: new object[] { new DateTime(2019, 12, 26, 15, 15, 1, 457, DateTimeKind.Unspecified).AddTicks(1356), 15, "architect customized systems", "Kshlerin - Macejkovic", 5, 16, "714246c077aaf2a91be72f11e394fe7c" });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "CreatedBy", "Description", "Name", "PlatformId", "SecurityToken" },
                values: new object[] { new DateTime(2019, 11, 21, 9, 47, 19, 338, DateTimeKind.Unspecified).AddTicks(7899), 11, "innovate viral blockchains", "Schaden, Koch and Corkery", 18, "946d6706d4677f330d8180eb27de44cc" });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId", "SecurityToken" },
                values: new object[] { new DateTime(2020, 8, 28, 1, 4, 9, 926, DateTimeKind.Unspecified).AddTicks(4139), 10, "extend plug-and-play relationships", "Hintz - Daniel", 1, 1, "97854c787524685abf92298ab776baac" });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId", "SecurityToken" },
                values: new object[] { new DateTime(2021, 5, 30, 7, 45, 50, 91, DateTimeKind.Unspecified).AddTicks(1381), 16, "optimize killer deliverables", "Runolfsson Inc", 4, 8, "c7988f7da32c60eeac50dca6261e7fc8" });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "CreatedBy", "Description", "Name", "PlatformId", "SecurityToken" },
                values: new object[] { new DateTime(2021, 1, 18, 16, 18, 45, 797, DateTimeKind.Unspecified).AddTicks(5286), 16, "syndicate plug-and-play functionalities", "Donnelly Group", 17, "0695a78516c5e0c252e95a7a1f3dd7ec" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Velit et quis non impedit saepe rerum aut. Et nemo sit recusandae officia et ut repudiandae doloremque maxime. Ullam adipisci aliquid. Sed magni error. Vel modi laudantium sed laboriosam quia.");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Deleniti voluptatem adipisci. Dicta tenetur nemo. Quo vel aut sed. Voluptas ipsa quia impedit optio voluptas consequatur sunt sit qui. Sit rem adipisci est laboriosam odit soluta.");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Accusantium veritatis deserunt fugiat quisquam sint ut necessitatibus qui voluptas. Voluptatem dignissimos cupiditate ab sit aliquam quos rerum pariatur. Rem ratione officia et optio et omnis. Accusamus id cumque ut ratione molestiae cumque. Autem maiores dolor voluptatibus fugit et. Voluptates iste rerum.");
        }
    }
}
