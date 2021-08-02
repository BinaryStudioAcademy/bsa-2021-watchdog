using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Watchdog.Core.DAL.Migrations
{
    public partial class AddOrganizationSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Organizations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

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
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvatarUrl", "CreatedAt", "CreatedBy", "Name", "OrganizationSlug" },
                values: new object[] { "https://picsum.photos/250/250/?image=706", new DateTime(2020, 3, 10, 0, 59, 36, 372, DateTimeKind.Unspecified).AddTicks(8784), 6, "Oberbrunner, Lebsack and Collier", "doloribus" });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AvatarUrl", "CreatedAt", "CreatedBy", "Name", "OrganizationSlug" },
                values: new object[] { "https://picsum.photos/250/250/?image=715", new DateTime(2021, 6, 14, 9, 16, 14, 757, DateTimeKind.Unspecified).AddTicks(9149), 13, "Dicki - Beer", "commodi" });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AvatarUrl", "CreatedAt", "CreatedBy", "Name", "OrganizationSlug" },
                values: new object[] { "https://picsum.photos/250/250/?image=753", new DateTime(2020, 5, 13, 19, 24, 48, 664, DateTimeKind.Unspecified).AddTicks(4853), 6, "Pfeffer Inc", "qui" });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AvatarUrl", "CreatedAt", "CreatedBy", "Name", "OpenMembership", "OrganizationSlug" },
                values: new object[] { "https://picsum.photos/250/250/?image=715", new DateTime(2019, 9, 6, 8, 28, 5, 134, DateTimeKind.Unspecified).AddTicks(3595), 10, "Hammes Inc", true, "eaque" });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AvatarUrl", "CreatedAt", "CreatedBy", "Name", "OrganizationSlug" },
                values: new object[] { "https://picsum.photos/250/250/?image=929", new DateTime(2021, 6, 27, 10, 4, 8, 342, DateTimeKind.Unspecified).AddTicks(7723), 19, "Gutmann - Hermiston", "est" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
