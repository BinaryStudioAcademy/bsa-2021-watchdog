using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Watchdog.Core.DAL.Migrations
{
    public partial class AddOrganizationDefaultRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DefaultRoleId",
                table: "Organizations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvatarUrl", "CreatedAt", "CreatedBy", "DefaultRoleId" },
                values: new object[] { "https://picsum.photos/250/250/?image=319", new DateTime(2020, 10, 27, 4, 1, 42, 509, DateTimeKind.Unspecified).AddTicks(6365), 14, 4 });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AvatarUrl", "CreatedAt", "CreatedBy", "DefaultRoleId", "Name", "OrganizationSlug" },
                values: new object[] { "https://picsum.photos/250/250/?image=52", new DateTime(2021, 1, 7, 22, 2, 16, 309, DateTimeKind.Unspecified).AddTicks(4029), 15, 4, "Beer LLC", "ex" });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AvatarUrl", "CreatedAt", "DefaultRoleId", "Name", "OpenMembership", "OrganizationSlug" },
                values: new object[] { "https://picsum.photos/250/250/?image=41", new DateTime(2020, 11, 28, 3, 22, 46, 820, DateTimeKind.Unspecified).AddTicks(713), 3, "Murray LLC", true, "est" });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AvatarUrl", "CreatedAt", "CreatedBy", "DefaultRoleId", "Name", "OpenMembership", "OrganizationSlug" },
                values: new object[] { "https://picsum.photos/250/250/?image=631", new DateTime(2020, 11, 2, 5, 50, 23, 307, DateTimeKind.Unspecified).AddTicks(1008), 7, 4, "Okuneva and Sons", false, "dicta" });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AvatarUrl", "CreatedAt", "CreatedBy", "DefaultRoleId", "Name", "OrganizationSlug" },
                values: new object[] { "https://picsum.photos/250/250/?image=332", new DateTime(2021, 1, 2, 9, 40, 40, 506, DateTimeKind.Unspecified).AddTicks(7949), 13, 2, "Watsica, Bartell and Balistreri", "dolorum" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefaultRoleId",
                table: "Organizations");

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvatarUrl", "CreatedAt", "CreatedBy" },
                values: new object[] { "https://picsum.photos/250/250/?image=706", new DateTime(2020, 3, 10, 0, 59, 36, 372, DateTimeKind.Unspecified).AddTicks(8784), 6 });

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
                columns: new[] { "AvatarUrl", "CreatedAt", "Name", "OpenMembership", "OrganizationSlug" },
                values: new object[] { "https://picsum.photos/250/250/?image=753", new DateTime(2020, 5, 13, 19, 24, 48, 664, DateTimeKind.Unspecified).AddTicks(4853), "Pfeffer Inc", false, "qui" });

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
    }
}
