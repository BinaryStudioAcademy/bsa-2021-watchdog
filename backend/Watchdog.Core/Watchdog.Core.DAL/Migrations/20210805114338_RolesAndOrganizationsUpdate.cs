using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Watchdog.Core.DAL.Migrations
{
    public partial class RolesAndOrganizationsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Organizations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddColumn<int>(
                name: "DefaultRoleId",
                table: "Organizations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "OpenMembership",
                table: "Organizations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "OrganizationSlug",
                table: "Organizations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2020, 3, 8, 20, 29, 56, 733, DateTimeKind.Unspecified).AddTicks(99), 3, 5, 2 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2019, 11, 16, 1, 22, 22, 917, DateTimeKind.Unspecified).AddTicks(2673), 20, 4, 1 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2020, 1, 3, 8, 25, 34, 990, DateTimeKind.Unspecified).AddTicks(521), 3, 1, 1 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2020, 4, 25, 10, 18, 40, 933, DateTimeKind.Unspecified).AddTicks(8555), 10, 4, 1 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId" },
                values: new object[] { new DateTime(2019, 9, 16, 10, 2, 15, 309, DateTimeKind.Unspecified).AddTicks(5491), 3, 3 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "CreatedBy", "RoleId" },
                values: new object[] { new DateTime(2021, 6, 15, 20, 0, 11, 725, DateTimeKind.Unspecified).AddTicks(3505), 3, 1 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2020, 1, 21, 6, 5, 21, 218, DateTimeKind.Unspecified).AddTicks(6260), 4, 1, 3 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2019, 12, 23, 10, 22, 47, 210, DateTimeKind.Unspecified).AddTicks(1299), 11, 1, 1 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2020, 7, 6, 4, 7, 57, 503, DateTimeKind.Unspecified).AddTicks(5793), 10, 1, 3 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2020, 1, 29, 1, 2, 39, 606, DateTimeKind.Unspecified).AddTicks(1635), 1, 1, 3 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "CreatedBy", "RoleId" },
                values: new object[] { new DateTime(2020, 5, 19, 20, 41, 5, 50, DateTimeKind.Unspecified).AddTicks(7290), 16, 1 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId" },
                values: new object[] { new DateTime(2021, 5, 21, 12, 57, 44, 740, DateTimeKind.Unspecified).AddTicks(9150), 2, 3 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2020, 1, 13, 19, 47, 33, 819, DateTimeKind.Unspecified).AddTicks(6240), 3, 5, 1 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId" },
                values: new object[] { new DateTime(2020, 5, 5, 6, 58, 55, 90, DateTimeKind.Unspecified).AddTicks(7547), 10, 4 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2021, 7, 5, 3, 30, 54, 448, DateTimeKind.Unspecified).AddTicks(9294), 15, 1, 3 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2021, 6, 14, 18, 35, 8, 962, DateTimeKind.Unspecified).AddTicks(783), 12, 2, 2 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "CreatedBy", "RoleId" },
                values: new object[] { new DateTime(2019, 11, 27, 0, 59, 19, 851, DateTimeKind.Unspecified).AddTicks(207), 2, 2 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2020, 2, 24, 22, 7, 24, 896, DateTimeKind.Unspecified).AddTicks(9869), 14, 5, 1 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2021, 6, 29, 4, 27, 33, 463, DateTimeKind.Unspecified).AddTicks(2445), 16 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2020, 8, 31, 3, 14, 25, 440, DateTimeKind.Unspecified).AddTicks(6945), 20, 3, 1 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2020, 10, 19, 4, 23, 25, 774, DateTimeKind.Unspecified).AddTicks(1835), 14, 1, 1 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2021, 7, 15, 16, 39, 54, 102, DateTimeKind.Unspecified).AddTicks(9813), 12, 4, 3 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2019, 11, 13, 12, 40, 5, 13, DateTimeKind.Unspecified).AddTicks(878), 15, 5, 3 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2019, 9, 1, 23, 36, 12, 841, DateTimeKind.Unspecified).AddTicks(6973), 5, 5, 2 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "CreatedBy", "RoleId" },
                values: new object[] { new DateTime(2020, 2, 9, 19, 23, 50, 460, DateTimeKind.Unspecified).AddTicks(534), 20, 3 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2021, 4, 23, 7, 4, 13, 49, DateTimeKind.Unspecified).AddTicks(4808), 16, 2, 2 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2019, 11, 23, 18, 4, 52, 732, DateTimeKind.Unspecified).AddTicks(9426), 3, 1 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2021, 1, 17, 9, 54, 56, 29, DateTimeKind.Unspecified).AddTicks(2520), 11, 3, 3 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId" },
                values: new object[] { new DateTime(2020, 9, 4, 5, 54, 15, 840, DateTimeKind.Unspecified).AddTicks(7823), 20, 2 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2019, 11, 5, 17, 30, 28, 659, DateTimeKind.Unspecified).AddTicks(2449), 1, 1, 2 });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvatarUrl", "CreatedAt", "CreatedBy", "DefaultRoleId", "Name", "OrganizationSlug" },
                values: new object[] { "https://picsum.photos/250/250/?image=319", new DateTime(2020, 10, 27, 4, 1, 42, 509, DateTimeKind.Unspecified).AddTicks(6365), 14, 2, "Oberbrunner, Lebsack and Collier", "doloribus" });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AvatarUrl", "CreatedAt", "CreatedBy", "DefaultRoleId", "Name", "OrganizationSlug" },
                values: new object[] { "https://picsum.photos/250/250/?image=52", new DateTime(2021, 1, 7, 22, 2, 16, 309, DateTimeKind.Unspecified).AddTicks(4029), 15, 2, "Beer LLC", "ex-" });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AvatarUrl", "CreatedAt", "CreatedBy", "DefaultRoleId", "Name", "OpenMembership", "OrganizationSlug" },
                values: new object[] { "https://picsum.photos/250/250/?image=41", new DateTime(2020, 11, 28, 3, 22, 46, 820, DateTimeKind.Unspecified).AddTicks(713), 6, 2, "Murray LLC", true, "est" });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AvatarUrl", "CreatedAt", "CreatedBy", "DefaultRoleId", "Name", "OrganizationSlug" },
                values: new object[] { "https://picsum.photos/250/250/?image=631", new DateTime(2020, 11, 2, 5, 50, 23, 307, DateTimeKind.Unspecified).AddTicks(1008), 7, 3, "Okuneva and Sons", "dicta" });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AvatarUrl", "CreatedAt", "CreatedBy", "DefaultRoleId", "Name", "OrganizationSlug" },
                values: new object[] { "https://picsum.photos/250/250/?image=332", new DateTime(2021, 1, 2, 9, 40, 40, 506, DateTimeKind.Unspecified).AddTicks(7949), 13, 1, "Watsica, Bartell and Balistreri", "dolorum" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Quo quas dolorem quisquam culpa. Occaecati est et nemo. Nulla qui sit quaerat error placeat deleniti odit. Ut quam atque iure et blanditiis error impedit velit. Eius aut eveniet ullam molestiae. Similique qui enim fugiat quisquam quo similique ut.", "Owner" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Voluptatibus amet nihil dolor delectus exercitationem aperiam. Sit quam voluptatem odio. Consequuntur laborum vel adipisci deserunt sunt earum hic. Aliquam et asperiores molestiae dolorem ad doloremque. Pariatur dolores et blanditiis voluptatum autem alias. Ut et assumenda omnis veniam molestias dolorum consequuntur.", "Manager" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Modi et rerum reiciendis. Dolorem expedita praesentium non dicta. Eaque magni omnis aut molestias similique rerum dolorem sed.", "Viewer" });

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_OrganizationSlug",
                table: "Organizations",
                column: "OrganizationSlug",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Organizations_OrganizationSlug",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "DefaultRoleId",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "OpenMembership",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "OrganizationSlug",
                table: "Organizations");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Organizations",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2020, 6, 23, 17, 55, 40, 784, DateTimeKind.Unspecified).AddTicks(6587), 19, 1, 3 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId" },
                values: new object[] { new DateTime(2020, 8, 11, 5, 32, 51, 930, DateTimeKind.Unspecified).AddTicks(3850), 5, 5 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2021, 2, 5, 12, 28, 51, 771, DateTimeKind.Unspecified).AddTicks(7583), 13, 4, 2 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2019, 11, 14, 5, 32, 33, 474, DateTimeKind.Unspecified).AddTicks(6814), 20, 2, 2 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2020, 3, 1, 10, 50, 38, 346, DateTimeKind.Unspecified).AddTicks(2283), 18, 2, 2 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2021, 7, 14, 18, 53, 43, 769, DateTimeKind.Unspecified).AddTicks(5102), 14, 4, 2 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "CreatedBy", "RoleId" },
                values: new object[] { new DateTime(2021, 6, 23, 23, 17, 16, 155, DateTimeKind.Unspecified).AddTicks(5266), 2, 2 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId" },
                values: new object[] { new DateTime(2021, 4, 5, 17, 35, 33, 328, DateTimeKind.Unspecified).AddTicks(4435), 9, 1 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2020, 6, 5, 23, 26, 15, 564, DateTimeKind.Unspecified).AddTicks(274), 12, 3, 3 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId" },
                values: new object[] { new DateTime(2020, 2, 16, 2, 0, 40, 350, DateTimeKind.Unspecified).AddTicks(4718), 6, 3 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2021, 1, 15, 16, 3, 46, 55, DateTimeKind.Unspecified).AddTicks(7176), 4, 3, 2 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2020, 11, 26, 21, 33, 26, 251, DateTimeKind.Unspecified).AddTicks(4354), 10, 3, 3 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2020, 8, 26, 0, 42, 7, 317, DateTimeKind.Unspecified).AddTicks(8157), 5 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2019, 8, 24, 23, 59, 6, 250, DateTimeKind.Unspecified).AddTicks(1004), 16, 3, 2 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2020, 1, 14, 18, 54, 42, 990, DateTimeKind.Unspecified).AddTicks(701), 9, 1, 1 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2019, 10, 12, 15, 15, 12, 766, DateTimeKind.Unspecified).AddTicks(6699), 4, 5, 3 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2019, 10, 3, 14, 41, 15, 275, DateTimeKind.Unspecified).AddTicks(7289), 5, 3 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2020, 6, 30, 21, 45, 53, 833, DateTimeKind.Unspecified).AddTicks(6612), 20, 5, 2 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId" },
                values: new object[] { new DateTime(2021, 4, 26, 1, 36, 51, 405, DateTimeKind.Unspecified).AddTicks(6570), 1, 5 });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvatarUrl", "CreatedAt", "CreatedBy", "Name" },
                values: new object[] { "https://picsum.photos/250/250/?image=144", new DateTime(2020, 3, 30, 18, 37, 49, 810, DateTimeKind.Unspecified).AddTicks(7734), 19, "Rogahn, Oberbrunner and Lebsack" });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AvatarUrl", "CreatedAt", "CreatedBy", "Name" },
                values: new object[] { "https://picsum.photos/250/250/?image=384", new DateTime(2021, 6, 8, 4, 26, 15, 192, DateTimeKind.Unspecified).AddTicks(4559), 4, "Parisian and Sons" });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AvatarUrl", "CreatedAt", "CreatedBy", "Name" },
                values: new object[] { "https://picsum.photos/250/250/?image=52", new DateTime(2021, 1, 7, 22, 2, 16, 309, DateTimeKind.Unspecified).AddTicks(4029), 15, "Okuneva - Mohr" });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AvatarUrl", "CreatedAt", "CreatedBy", "Name" },
                values: new object[] { "https://picsum.photos/250/250/?image=322", new DateTime(2021, 6, 22, 5, 11, 9, 722, DateTimeKind.Unspecified).AddTicks(9234), 12, "Bode, Murray and Powlowski" });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AvatarUrl", "CreatedAt", "CreatedBy", "Name" },
                values: new object[] { "https://picsum.photos/250/250/?image=180", new DateTime(2020, 8, 3, 16, 48, 30, 79, DateTimeKind.Unspecified).AddTicks(9857), 14, "Hammes Inc" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Labore vitae inventore. Et sunt ipsum quis labore in quia repellendus. Ut provident rerum fugit quia optio. Soluta iure animi qui pariatur maiores. Qui at similique neque nihil sit suscipit.", "explicabo" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Quos qui ea enim adipisci consequatur eveniet omnis id veritatis. Fugiat fuga asperiores. In iure molestiae pariatur deleniti sit. Debitis natus qui sint tempore ut quas animi dolores. Eveniet sapiente dolorum.", "non" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Corrupti vel nihil. Fugit molestiae sint facere. Sunt omnis corporis autem.", "ullam" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 5, "Fugiat quis aut. Velit aut tempora eligendi quod quis. Ex sed molestiae. Quae quae quia reiciendis alias iste illum error velit. Et sint delectus necessitatibus vel iusto eos asperiores. At iure incidunt sit at sit optio ut adipisci.", "omnis" },
                    { 4, "Deserunt dolorum rerum et. Cum sit distinctio ab dolores molestiae sapiente recusandae. Quis aut veritatis ad earum rem omnis nesciunt.", "voluptates" }
                });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2019, 11, 11, 3, 10, 6, 170, DateTimeKind.Unspecified).AddTicks(2841), 16, 1, 5 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2019, 10, 5, 13, 0, 34, 132, DateTimeKind.Unspecified).AddTicks(3117), 2, 3, 4 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2021, 4, 27, 7, 55, 58, 628, DateTimeKind.Unspecified).AddTicks(106), 6, 5, 4 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "CreatedBy", "RoleId" },
                values: new object[] { new DateTime(2020, 8, 29, 8, 18, 24, 585, DateTimeKind.Unspecified).AddTicks(9893), 16, 5 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "CreatedBy", "RoleId" },
                values: new object[] { new DateTime(2020, 8, 9, 5, 46, 45, 899, DateTimeKind.Unspecified).AddTicks(7907), 12, 4 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2020, 3, 28, 11, 51, 59, 488, DateTimeKind.Unspecified).AddTicks(8865), 18, 3, 5 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2020, 12, 4, 13, 22, 46, 624, DateTimeKind.Unspecified).AddTicks(5014), 6, 4, 4 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2019, 12, 13, 13, 57, 12, 13, DateTimeKind.Unspecified).AddTicks(984), 15, 3, 4 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2020, 2, 26, 14, 59, 29, 473, DateTimeKind.Unspecified).AddTicks(5763), 9, 3, 4 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "CreatedBy", "RoleId" },
                values: new object[] { new DateTime(2019, 9, 5, 4, 2, 59, 158, DateTimeKind.Unspecified).AddTicks(4664), 9, 5 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2021, 3, 13, 14, 30, 36, 921, DateTimeKind.Unspecified).AddTicks(1544), 12, 3, 4 });
        }
    }
}
