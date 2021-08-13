using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Watchdog.Core.DAL.Migrations
{
    public partial class TeamMemberRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Users_CreatedBy",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationTeams_Teams_TeamId",
                table: "ApplicationTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_Dashboards_Users_CreatedBy",
                table: "Dashboards");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_Organizations_OrganizationId",
                table: "Members");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_Users_CreatedBy",
                table: "Members");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Users_CreatedBy",
                table: "Organizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Users_CreatedBy",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_Tiles_Users_CreatedBy",
                table: "Tiles");

            migrationBuilder.DropTable(
                name: "TeamMembers");

            migrationBuilder.AddColumn<bool>(
                name: "IsAccepted",
                table: "Members",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Members",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Members",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Users_Email",
                table: "Users",
                column: "Email");

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TeamId", "UserId" },
                values: new object[] { 1, 14 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId", "TeamId", "UserId" },
                values: new object[] { new DateTime(2021, 4, 27, 20, 21, 58, 172, DateTimeKind.Unspecified).AddTicks(5799), 3, 1, 3, 4, 1 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy", "IsAccepted", "OrganizationId", "RoleId", "TeamId", "UserId" },
                values: new object[] { new DateTime(2020, 7, 23, 10, 54, 45, 854, DateTimeKind.Unspecified).AddTicks(9241), 16, true, 4, 2, 1, 19 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId", "TeamId", "UserId" },
                values: new object[] { new DateTime(2019, 8, 20, 21, 27, 3, 534, DateTimeKind.Unspecified).AddTicks(5410), 1, 1, 3, 1, 4 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedBy", "IsAccepted", "OrganizationId", "RoleId", "TeamId", "UserId" },
                values: new object[] { new DateTime(2019, 12, 23, 10, 22, 47, 210, DateTimeKind.Unspecified).AddTicks(1299), 11, true, 1, 1, 4, 4 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "CreatedBy", "IsAccepted", "RoleId", "TeamId", "UserId" },
                values: new object[] { new DateTime(2021, 7, 18, 20, 59, 32, 703, DateTimeKind.Unspecified).AddTicks(9853), 2, true, 2, 4, 4 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "CreatedBy", "IsAccepted", "OrganizationId", "TeamId", "UserId" },
                values: new object[] { new DateTime(2020, 7, 8, 18, 12, 38, 93, DateTimeKind.Unspecified).AddTicks(8466), 1, true, 3, 1, 2 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "CreatedBy", "RoleId", "TeamId", "UserId" },
                values: new object[] { new DateTime(2021, 2, 7, 16, 21, 19, 980, DateTimeKind.Unspecified).AddTicks(3576), 16, 3, 4, 10 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "CreatedBy", "TeamId", "UserId" },
                values: new object[] { new DateTime(2021, 7, 5, 3, 30, 54, 448, DateTimeKind.Unspecified).AddTicks(9294), 15, 3, 5 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId", "TeamId", "UserId" },
                values: new object[] { new DateTime(2021, 5, 19, 6, 44, 6, 919, DateTimeKind.Unspecified).AddTicks(278), 7, 4, 1, 5, 6 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "CreatedBy", "IsAccepted", "OrganizationId", "RoleId", "TeamId", "UserId" },
                values: new object[] { new DateTime(2020, 10, 3, 22, 16, 27, 247, DateTimeKind.Unspecified).AddTicks(4150), 10, true, 4, 3, 4, 1 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "CreatedBy", "IsAccepted", "OrganizationId", "RoleId", "TeamId", "UserId" },
                values: new object[] { new DateTime(2021, 7, 4, 15, 24, 41, 967, DateTimeKind.Unspecified).AddTicks(8073), 9, true, 5, 2, 1, 14 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId", "TeamId", "UserId" },
                values: new object[] { new DateTime(2021, 7, 15, 16, 39, 54, 102, DateTimeKind.Unspecified).AddTicks(9813), 12, 4, 3, 4, 18 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId", "TeamId", "UserId" },
                values: new object[] { new DateTime(2021, 2, 15, 7, 36, 57, 651, DateTimeKind.Unspecified).AddTicks(6601), 20, 2, 3, 5, 15 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "CreatedBy", "IsAccepted", "OrganizationId", "TeamId", "UserId" },
                values: new object[] { new DateTime(2021, 1, 7, 23, 23, 34, 674, DateTimeKind.Unspecified).AddTicks(8980), 9, true, 4, 4, 3 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "CreatedBy", "IsAccepted", "TeamId", "UserId" },
                values: new object[] { new DateTime(2019, 9, 13, 18, 7, 25, 344, DateTimeKind.Unspecified).AddTicks(5872), 17, true, 3, 11 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "CreatedBy", "IsAccepted", "RoleId", "TeamId", "UserId" },
                values: new object[] { new DateTime(2020, 9, 4, 5, 54, 15, 840, DateTimeKind.Unspecified).AddTicks(7823), 20, true, 1, 3, 4 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId", "TeamId", "UserId" },
                values: new object[] { new DateTime(2021, 5, 20, 18, 28, 35, 426, DateTimeKind.Unspecified).AddTicks(5341), 2, 4, 3, 3, 5 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "TeamId", "UserId" },
                values: new object[] { new DateTime(2019, 11, 30, 15, 17, 55, 781, DateTimeKind.Unspecified).AddTicks(7584), 4, 3, 2, 7 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "TeamId", "UserId" },
                values: new object[] { new DateTime(2020, 12, 16, 9, 10, 24, 976, DateTimeKind.Unspecified).AddTicks(8307), 16, 1, 3, 4 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId", "TeamId", "UserId" },
                values: new object[] { new DateTime(2020, 12, 1, 19, 23, 31, 853, DateTimeKind.Unspecified).AddTicks(3147), 2, 4, 2, 2, 10 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "CreatedBy", "IsAccepted", "OrganizationId", "RoleId", "TeamId", "UserId" },
                values: new object[] { new DateTime(2020, 9, 22, 14, 47, 55, 958, DateTimeKind.Unspecified).AddTicks(4884), 16, true, 5, 1, 3, 14 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "CreatedBy", "IsAccepted", "OrganizationId", "TeamId", "UserId" },
                values: new object[] { new DateTime(2020, 10, 21, 18, 46, 42, 78, DateTimeKind.Unspecified).AddTicks(2145), 4, true, 2, 5, 8 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId", "TeamId", "UserId" },
                values: new object[] { new DateTime(2021, 4, 28, 1, 57, 4, 519, DateTimeKind.Unspecified).AddTicks(2546), 3, 4, 3, 2, 14 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "CreatedBy", "IsAccepted", "OrganizationId", "RoleId", "TeamId", "UserId" },
                values: new object[] { new DateTime(2019, 8, 22, 5, 8, 52, 971, DateTimeKind.Unspecified).AddTicks(5025), 3, true, 2, 1, 1, 10 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "IsAccepted", "OrganizationId", "RoleId", "TeamId", "UserId" },
                values: new object[] { new DateTime(2021, 5, 14, 1, 44, 54, 610, DateTimeKind.Unspecified).AddTicks(3587), true, 5, 1, 4, 2 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "CreatedBy", "IsAccepted", "RoleId", "TeamId", "UserId" },
                values: new object[] { new DateTime(2020, 1, 3, 20, 5, 35, 131, DateTimeKind.Unspecified).AddTicks(2006), 9, true, 2, 4, 9 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "CreatedBy", "RoleId", "TeamId", "UserId" },
                values: new object[] { new DateTime(2020, 3, 25, 4, 9, 19, 385, DateTimeKind.Unspecified).AddTicks(2515), 19, 2, 4, 11 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "TeamId", "UserId" },
                values: new object[] { new DateTime(2021, 4, 17, 15, 20, 35, 476, DateTimeKind.Unspecified).AddTicks(8086), 5, 5, 4, 20 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId", "TeamId", "UserId" },
                values: new object[] { new DateTime(2020, 7, 4, 10, 40, 44, 199, DateTimeKind.Unspecified).AddTicks(7424), 10, 4, 3, 2, 16 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 2, 17, 13, 26, 9, 380, DateTimeKind.Local).AddTicks(153));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 8, 21, 3, 47, 23, 600, DateTimeKind.Local).AddTicks(2708));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 9, 6, 18, 17, 26, 627, DateTimeKind.Local).AddTicks(4778));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 10, 8, 31, 13, 200, DateTimeKind.Local).AddTicks(2652));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 31, 7, 18, 20, 27, DateTimeKind.Local).AddTicks(2472));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 2, 5, 2, 55, 17, 656, DateTimeKind.Local).AddTicks(6430));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 22, 27, 1, 508, DateTimeKind.Local).AddTicks(9846));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 9, 4, 33, 59, 691, DateTimeKind.Local).AddTicks(1209));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 26, 22, 50, 51, 23, DateTimeKind.Local).AddTicks(2283));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 21, 13, 16, 36, 31, DateTimeKind.Local).AddTicks(4260));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 15, 19, 53, 4, 344, DateTimeKind.Local).AddTicks(6979));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 22, 9, 1, 8, 517, DateTimeKind.Local).AddTicks(999));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 26, 23, 2, 58, 879, DateTimeKind.Local).AddTicks(4073));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 15, 1, 29, 24, 871, DateTimeKind.Local).AddTicks(1091));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 26, 8, 26, 33, 550, DateTimeKind.Local).AddTicks(4960));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 18, 8, 43, 42, 726, DateTimeKind.Local).AddTicks(8941));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 9, 6, 18, 6, 202, DateTimeKind.Local).AddTicks(1233));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 13, 15, 3, 5, 644, DateTimeKind.Local).AddTicks(9671));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2020, 5, 29, 11, 7, 34, 633, DateTimeKind.Local).AddTicks(3806));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 2, 21, 18, 8, 548, DateTimeKind.Local).AddTicks(9210));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 6, 8, 58, 38, 671, DateTimeKind.Local).AddTicks(2431));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 2, 9, 59, 57, 170, DateTimeKind.Local).AddTicks(7094));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 31, 6, 24, 21, 712, DateTimeKind.Local).AddTicks(4860));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 15, 10, 54, 16, 144, DateTimeKind.Local).AddTicks(3527));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 18, 9, 9, 16, 853, DateTimeKind.Local).AddTicks(2353));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 17, 4, 3, 40, 245, DateTimeKind.Local).AddTicks(5896));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 27, 12, 14, 45, 392, DateTimeKind.Local).AddTicks(2448));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 15, 16, 16, 30, 85, DateTimeKind.Local).AddTicks(1368));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2019, 9, 10, 22, 27, 36, 162, DateTimeKind.Local).AddTicks(6091));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 3, 21, 15, 54, 366, DateTimeKind.Local).AddTicks(9948));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 18, 5, 50, 56, 872, DateTimeKind.Local).AddTicks(5815));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 26, 4, 18, 1, 356, DateTimeKind.Local).AddTicks(5374));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2020, 12, 14, 4, 58, 24, 164, DateTimeKind.Local).AddTicks(8863));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 8, 9, 19, 21, 348, DateTimeKind.Local).AddTicks(6107));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 29, 19, 36, 3, 104, DateTimeKind.Local).AddTicks(6017));

            migrationBuilder.CreateIndex(
                name: "IX_Members_TeamId",
                table: "Members",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_UserId",
                table: "Members",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Users_CreatedBy",
                table: "Applications",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationTeams_Teams_TeamId",
                table: "ApplicationTeams",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dashboards_Users_CreatedBy",
                table: "Dashboards",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Organizations_OrganizationId",
                table: "Members",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Teams_TeamId",
                table: "Members",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Users_CreatedBy",
                table: "Members",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Users_UserId",
                table: "Members",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_Users_CreatedBy",
                table: "Organizations",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Users_CreatedBy",
                table: "Teams",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tiles_Users_CreatedBy",
                table: "Tiles",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Users_CreatedBy",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationTeams_Teams_TeamId",
                table: "ApplicationTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_Dashboards_Users_CreatedBy",
                table: "Dashboards");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_Organizations_OrganizationId",
                table: "Members");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_Teams_TeamId",
                table: "Members");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_Users_CreatedBy",
                table: "Members");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_Users_UserId",
                table: "Members");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Users_CreatedBy",
                table: "Organizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Users_CreatedBy",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_Tiles_Users_CreatedBy",
                table: "Tiles");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Users_Email",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Members_TeamId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_UserId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "IsAccepted",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Members");

            migrationBuilder.CreateTable(
                name: "TeamMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamMembers_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamMembers_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2019, 9, 16, 10, 2, 15, 309, DateTimeKind.Unspecified).AddTicks(5491), 3, 3, 3 });

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
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId" },
                values: new object[] { new DateTime(2020, 1, 21, 6, 5, 21, 218, DateTimeKind.Unspecified).AddTicks(6260), 4, 1 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "CreatedBy", "RoleId" },
                values: new object[] { new DateTime(2019, 12, 23, 10, 22, 47, 210, DateTimeKind.Unspecified).AddTicks(1299), 11, 1 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2020, 7, 6, 4, 7, 57, 503, DateTimeKind.Unspecified).AddTicks(5793), 10 });

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
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2020, 5, 19, 20, 41, 5, 50, DateTimeKind.Unspecified).AddTicks(7290), 16, 2, 1 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2021, 5, 21, 12, 57, 44, 740, DateTimeKind.Unspecified).AddTicks(9150), 2, 3, 1 });

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
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2020, 5, 5, 6, 58, 55, 90, DateTimeKind.Unspecified).AddTicks(7547), 10, 4, 1 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId" },
                values: new object[] { new DateTime(2021, 7, 5, 3, 30, 54, 448, DateTimeKind.Unspecified).AddTicks(9294), 15, 1 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2021, 6, 14, 18, 35, 8, 962, DateTimeKind.Unspecified).AddTicks(783), 12 });

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
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId" },
                values: new object[] { new DateTime(2021, 6, 29, 4, 27, 33, 463, DateTimeKind.Unspecified).AddTicks(2445), 16, 2 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId" },
                values: new object[] { new DateTime(2020, 8, 31, 3, 14, 25, 440, DateTimeKind.Unspecified).AddTicks(6945), 20, 3 });

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
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId" },
                values: new object[] { new DateTime(2019, 11, 13, 12, 40, 5, 13, DateTimeKind.Unspecified).AddTicks(878), 15, 5 });

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
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2020, 2, 9, 19, 23, 50, 460, DateTimeKind.Unspecified).AddTicks(534), 20, 4, 3 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2021, 4, 23, 7, 4, 13, 49, DateTimeKind.Unspecified).AddTicks(4808), 2, 2 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "CreatedBy", "RoleId" },
                values: new object[] { new DateTime(2019, 11, 23, 18, 4, 52, 732, DateTimeKind.Unspecified).AddTicks(9426), 6, 1 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "CreatedBy", "RoleId" },
                values: new object[] { new DateTime(2021, 1, 17, 9, 54, 56, 29, DateTimeKind.Unspecified).AddTicks(2520), 11, 3 });

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

            migrationBuilder.InsertData(
                table: "TeamMembers",
                columns: new[] { "Id", "MemberId", "TeamId" },
                values: new object[,]
                {
                    { 1, 9, 2 },
                    { 24, 7, 2 },
                    { 2, 12, 3 },
                    { 3, 10, 1 },
                    { 4, 1, 2 },
                    { 5, 28, 2 },
                    { 6, 4, 2 },
                    { 7, 30, 5 },
                    { 8, 5, 4 },
                    { 9, 4, 1 },
                    { 10, 13, 2 },
                    { 11, 16, 3 },
                    { 12, 8, 2 }
                });

            migrationBuilder.InsertData(
                table: "TeamMembers",
                columns: new[] { "Id", "MemberId", "TeamId" },
                values: new object[,]
                {
                    { 25, 29, 1 },
                    { 14, 6, 2 },
                    { 15, 6, 5 },
                    { 16, 30, 4 },
                    { 17, 7, 1 },
                    { 18, 20, 1 },
                    { 19, 19, 4 },
                    { 20, 1, 1 },
                    { 21, 23, 3 },
                    { 22, 7, 3 },
                    { 23, 26, 4 },
                    { 13, 29, 1 }
                });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 2, 17, 3, 12, 8, 478, DateTimeKind.Local).AddTicks(2495));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 8, 20, 17, 33, 22, 701, DateTimeKind.Local).AddTicks(7613));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 9, 6, 8, 3, 25, 729, DateTimeKind.Local).AddTicks(273));

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
                column: "CreatedAt",
                value: new DateTime(2020, 8, 30, 21, 4, 19, 128, DateTimeKind.Local).AddTicks(8308));

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
                column: "CreatedAt",
                value: new DateTime(2020, 8, 23, 12, 13, 0, 610, DateTimeKind.Local).AddTicks(5836));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 8, 18, 19, 58, 792, DateTimeKind.Local).AddTicks(7240));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 26, 12, 36, 50, 124, DateTimeKind.Local).AddTicks(8362));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 21, 3, 2, 35, 133, DateTimeKind.Local).AddTicks(389));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 15, 9, 39, 3, 446, DateTimeKind.Local).AddTicks(3407));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 21, 22, 47, 7, 618, DateTimeKind.Local).AddTicks(7519));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 26, 12, 48, 57, 981, DateTimeKind.Local).AddTicks(655));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 14, 15, 15, 23, 972, DateTimeKind.Local).AddTicks(7722));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 25, 22, 12, 32, 652, DateTimeKind.Local).AddTicks(1648));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 17, 22, 29, 41, 828, DateTimeKind.Local).AddTicks(5684));

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
                column: "CreatedAt",
                value: new DateTime(2020, 8, 13, 4, 49, 4, 746, DateTimeKind.Local).AddTicks(6605));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2020, 5, 29, 0, 53, 33, 735, DateTimeKind.Local).AddTicks(780));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 2, 11, 4, 7, 650, DateTimeKind.Local).AddTicks(6242));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 5, 22, 44, 37, 772, DateTimeKind.Local).AddTicks(9524));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 1, 23, 45, 56, 272, DateTimeKind.Local).AddTicks(4255));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 30, 20, 10, 20, 814, DateTimeKind.Local).AddTicks(2083));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 15, 0, 40, 15, 246, DateTimeKind.Local).AddTicks(876));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 17, 22, 55, 15, 954, DateTimeKind.Local).AddTicks(9771));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 16, 17, 49, 39, 347, DateTimeKind.Local).AddTicks(3365));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 27, 2, 0, 44, 493, DateTimeKind.Local).AddTicks(9978));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 15, 6, 2, 29, 186, DateTimeKind.Local).AddTicks(8987));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2019, 9, 10, 12, 13, 35, 264, DateTimeKind.Local).AddTicks(3769));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 3, 11, 1, 53, 468, DateTimeKind.Local).AddTicks(7741));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 17, 19, 36, 55, 974, DateTimeKind.Local).AddTicks(3670));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 25, 18, 4, 0, 458, DateTimeKind.Local).AddTicks(3430));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2020, 12, 13, 18, 44, 23, 266, DateTimeKind.Local).AddTicks(7117));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 7, 23, 5, 20, 450, DateTimeKind.Local).AddTicks(4621));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 29, 9, 22, 2, 206, DateTimeKind.Local).AddTicks(4647));

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_MemberId",
                table: "TeamMembers",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_TeamId",
                table: "TeamMembers",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Users_CreatedBy",
                table: "Applications",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationTeams_Teams_TeamId",
                table: "ApplicationTeams",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dashboards_Users_CreatedBy",
                table: "Dashboards",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Organizations_OrganizationId",
                table: "Members",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Users_CreatedBy",
                table: "Members",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_Users_CreatedBy",
                table: "Organizations",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Users_CreatedBy",
                table: "Teams",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tiles_Users_CreatedBy",
                table: "Tiles",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
