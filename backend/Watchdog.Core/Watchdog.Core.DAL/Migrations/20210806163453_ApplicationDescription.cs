using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Watchdog.Core.DAL.Migrations
{
    public partial class ApplicationDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description", "Name", "OrganizationId", "PlatformId", "SecurityToken" },
                values: new object[] { new DateTime(2019, 8, 13, 23, 53, 43, 570, DateTimeKind.Unspecified).AddTicks(6998), "enhance efficient communities", "Vandervort - Nolan", 3, 17, "def5780176e65ae10e04f11ad54e7109" });

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
                    { 14, new DateTime(2021, 5, 30, 7, 45, 50, 91, DateTimeKind.Unspecified).AddTicks(1381), 16, "optimize killer deliverables", "Runolfsson Inc", 4, 8, "c7988f7da32c60eeac50dca6261e7fc8" },
                    { 13, new DateTime(2020, 8, 28, 1, 4, 9, 926, DateTimeKind.Unspecified).AddTicks(4139), 10, "extend plug-and-play relationships", "Hintz - Daniel", 1, 1, "97854c787524685abf92298ab776baac" },
                    { 12, new DateTime(2019, 11, 21, 9, 47, 19, 338, DateTimeKind.Unspecified).AddTicks(7899), 11, "innovate viral blockchains", "Schaden, Koch and Corkery", 4, 18, "946d6706d4677f330d8180eb27de44cc" }
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
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Molestiae totam odio. Culpa sed vel qui. Ducimus libero sed repellat maxime veritatis eum.");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Sit modi et rem consequatur voluptate suscipit dicta. Eos et tempora. Voluptas occaecati in. Dolor commodi nemo sequi animi qui tempore tempore cupiditate.");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Ut commodi omnis harum quis architecto voluptatem fugiat consectetur. Praesentium doloremque illum quos ratione cum non ex iure dolorem. Animi et rerum.");

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
                table: "ApplicationTeams",
                keyColumn: "Id",
                keyValue: 18,
                column: "ApplicationId",
                value: 13);

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
                columns: new[] { "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "SecurityToken" },
                values: new object[] { new DateTime(2021, 2, 12, 2, 4, 53, 954, DateTimeKind.Unspecified).AddTicks(9302), 19, null, "et", 4, "382c872c306c5e42126fd20bd128d2f8" });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description", "Name", "OrganizationId", "PlatformId", "SecurityToken" },
                values: new object[] { new DateTime(2019, 11, 9, 2, 34, 53, 333, DateTimeKind.Unspecified).AddTicks(609), null, "eaque", 1, 1, "740bfaea383def5780176e65ae10e04f" });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId", "SecurityToken" },
                values: new object[] { new DateTime(2021, 5, 2, 8, 9, 18, 808, DateTimeKind.Unspecified).AddTicks(603), 6, null, "aliquid", 3, 1, "4e71098eaf39041db98db018db344bc4" });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId", "SecurityToken" },
                values: new object[] { new DateTime(2021, 1, 21, 4, 27, 54, 821, DateTimeKind.Unspecified).AddTicks(9297), 7, null, "et", 5, 3, "654e6fee6db32672fa3df4554af2e1ff" });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Description", "Name", "OrganizationId", "PlatformId", "SecurityToken" },
                values: new object[] { new DateTime(2020, 11, 1, 23, 50, 36, 645, DateTimeKind.Unspecified).AddTicks(6625), null, "tempora", 2, 10, "f41296e7015528714a10e9c0c05ec3f0" });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "CreatedBy", "Description", "Name", "PlatformId", "SecurityToken" },
                values: new object[] { new DateTime(2020, 12, 4, 12, 59, 54, 245, DateTimeKind.Unspecified).AddTicks(9861), 12, null, "fugit", 10, "b5d6e399dc98eb83345815910bd25138" });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId", "SecurityToken" },
                values: new object[] { new DateTime(2021, 1, 20, 5, 51, 37, 155, DateTimeKind.Unspecified).AddTicks(1815), 12, null, "voluptatem", 2, 10, "90637f3b5d86c09ad05bb62664b806f1" });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Description", "Name", "OrganizationId", "PlatformId", "SecurityToken" },
                values: new object[] { new DateTime(2020, 9, 15, 5, 54, 32, 534, DateTimeKind.Unspecified).AddTicks(1538), null, "reiciendis", 2, 7, "59655ae4c809e4e3983efc33bafd62d7" });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId", "SecurityToken" },
                values: new object[] { new DateTime(2021, 4, 2, 9, 39, 11, 203, DateTimeKind.Unspecified).AddTicks(5174), 4, null, "voluptates", 3, 4, "65c32abaf221ea765f963abb1d9b933c" });

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "PlatformId", "SecurityToken" },
                values: new object[] { new DateTime(2021, 4, 10, 17, 22, 41, 492, DateTimeKind.Unspecified).AddTicks(341), 13, null, "iusto", 2, 10, "ad178b7cc87610aefaba124101bf5988" });

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
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Sit nam quasi qui quis nostrum sit voluptatibus velit. Ducimus est sed id harum quasi non facilis. Vel commodi qui voluptate perspiciatis temporibus. Ex est officiis et mollitia error et praesentium.");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Harum qui voluptas corrupti quae ullam quo. Dolorem molestiae iste magnam voluptatem est aperiam ut. Voluptatibus voluptatum itaque aliquam. Autem sunt itaque nostrum odit unde et.");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Distinctio ipsum vitae iusto omnis et consequatur. Et natus placeat porro et. Aut laudantium sit eum. In vitae voluptatibus dolores nostrum aut expedita ut. Facere consectetur nostrum deserunt earum eum eveniet. Dolor aliquam ad.");
        }
    }
}
