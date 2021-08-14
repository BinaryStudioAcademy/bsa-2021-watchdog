using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Watchdog.Core.DAL.Migrations
{
    public partial class MembersUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Users_CreatedBy",
                table: "Applications");

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

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.AddColumn<bool>(
                name: "IsAccepted",
                table: "Members",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
                column: "UserId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId", "UserId" },
                values: new object[] { new DateTime(2021, 4, 24, 5, 42, 53, 386, DateTimeKind.Unspecified).AddTicks(1855), 4, 5, 3, 3 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy", "IsAccepted", "OrganizationId", "UserId" },
                values: new object[] { new DateTime(2020, 4, 25, 10, 18, 40, 933, DateTimeKind.Unspecified).AddTicks(8555), 10, true, 4, 16 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy", "IsAccepted", "OrganizationId", "UserId" },
                values: new object[] { new DateTime(2019, 11, 5, 7, 22, 47, 824, DateTimeKind.Unspecified).AddTicks(21), 6, true, 5, 3 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedBy", "IsAccepted", "OrganizationId", "UserId" },
                values: new object[] { new DateTime(2020, 1, 21, 6, 5, 21, 218, DateTimeKind.Unspecified).AddTicks(6260), 4, true, 1, 6 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId", "UserId" },
                values: new object[] { new DateTime(2021, 2, 28, 22, 5, 30, 458, DateTimeKind.Unspecified).AddTicks(9031), 14, 4, 2, 10 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "CreatedBy", "IsAccepted", "UserId" },
                values: new object[] { new DateTime(2020, 1, 29, 1, 2, 39, 606, DateTimeKind.Unspecified).AddTicks(1635), 1, true, 4 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "CreatedBy", "IsAccepted", "OrganizationId", "RoleId", "UserId" },
                values: new object[] { new DateTime(2020, 7, 8, 18, 12, 38, 93, DateTimeKind.Unspecified).AddTicks(8466), 1, true, 3, 3, 2 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId", "UserId" },
                values: new object[] { new DateTime(2020, 1, 13, 19, 47, 33, 819, DateTimeKind.Unspecified).AddTicks(6240), 3, 5, 1, 5 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "CreatedBy", "IsAccepted", "OrganizationId", "RoleId", "UserId" },
                values: new object[] { new DateTime(2021, 5, 20, 11, 50, 19, 47, DateTimeKind.Unspecified).AddTicks(253), 16, true, 4, 2, 15 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "CreatedBy", "IsAccepted", "RoleId", "UserId" },
                values: new object[] { new DateTime(2021, 6, 14, 18, 35, 8, 962, DateTimeKind.Unspecified).AddTicks(783), 12, true, 2, 13 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "UserId" },
                values: new object[] { new DateTime(2019, 9, 7, 12, 17, 31, 207, DateTimeKind.Unspecified).AddTicks(9579), 6, 5, 14 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId", "UserId" },
                values: new object[] { new DateTime(2021, 6, 29, 4, 27, 33, 463, DateTimeKind.Unspecified).AddTicks(2445), 16, 2, 2, 2 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "CreatedBy", "IsAccepted", "OrganizationId", "RoleId", "UserId" },
                values: new object[] { new DateTime(2021, 5, 16, 11, 31, 26, 113, DateTimeKind.Unspecified).AddTicks(7211), 1, true, 3, 3, 14 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "UserId" },
                values: new object[] { new DateTime(2021, 7, 15, 16, 39, 54, 102, DateTimeKind.Unspecified).AddTicks(9813), 12, 4, 15 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId", "UserId" },
                values: new object[] { new DateTime(2019, 8, 2, 17, 28, 38, 255, DateTimeKind.Unspecified).AddTicks(559), 7, 5, 3, 5 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "CreatedBy", "IsAccepted", "OrganizationId", "RoleId", "UserId" },
                values: new object[] { new DateTime(2020, 2, 9, 19, 23, 50, 460, DateTimeKind.Unspecified).AddTicks(534), 20, true, 4, 3, 9 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId", "UserId" },
                values: new object[] { new DateTime(2020, 9, 21, 7, 23, 28, 415, DateTimeKind.Unspecified).AddTicks(1317), 5, 1, 3, 6 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "CreatedBy", "IsAccepted", "OrganizationId", "RoleId", "UserId" },
                values: new object[] { new DateTime(2021, 1, 17, 9, 54, 56, 29, DateTimeKind.Unspecified).AddTicks(2520), 11, true, 3, 3, 2 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "CreatedBy", "RoleId", "UserId" },
                values: new object[] { new DateTime(2021, 3, 13, 6, 12, 52, 490, DateTimeKind.Unspecified).AddTicks(6102), 11, 3, 1 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "CreatedBy", "RoleId", "UserId" },
                values: new object[] { new DateTime(2020, 9, 14, 7, 34, 19, 58, DateTimeKind.Unspecified).AddTicks(6759), 2, 3, 5 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "CreatedBy", "IsAccepted", "OrganizationId", "RoleId", "UserId" },
                values: new object[] { new DateTime(2019, 11, 30, 15, 17, 55, 781, DateTimeKind.Unspecified).AddTicks(7584), 4, true, 3, 2, 7 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId", "UserId" },
                values: new object[] { new DateTime(2020, 1, 13, 16, 1, 7, 292, DateTimeKind.Unspecified).AddTicks(9094), 1, 2, 2, 6 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "CreatedBy", "IsAccepted", "OrganizationId", "RoleId", "UserId" },
                values: new object[] { new DateTime(2020, 1, 27, 23, 56, 34, 496, DateTimeKind.Unspecified).AddTicks(8297), 10, true, 3, 1, 2 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId", "UserId" },
                values: new object[] { new DateTime(2021, 6, 7, 2, 37, 52, 346, DateTimeKind.Unspecified).AddTicks(510), 16, 3, 1, 20 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "CreatedBy", "IsAccepted", "OrganizationId", "UserId" },
                values: new object[] { new DateTime(2021, 4, 19, 13, 27, 42, 278, DateTimeKind.Unspecified).AddTicks(5809), 14, true, 3, 20 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "UserId" },
                values: new object[] { new DateTime(2020, 10, 25, 3, 26, 10, 143, DateTimeKind.Unspecified).AddTicks(8932), 19, 2, 2 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId", "UserId" },
                values: new object[] { new DateTime(2021, 2, 21, 14, 28, 48, 971, DateTimeKind.Unspecified).AddTicks(5086), 3, 1, 2, 14 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "CreatedBy", "IsAccepted", "UserId" },
                values: new object[] { new DateTime(2019, 8, 22, 5, 8, 52, 971, DateTimeKind.Unspecified).AddTicks(5025), 3, true, 1 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "CreatedBy", "UserId" },
                values: new object[] { new DateTime(2020, 1, 5, 23, 5, 3, 573, DateTimeKind.Unspecified).AddTicks(2194), 20, 2 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 2, 19, 13, 17, 33, 791, DateTimeKind.Local).AddTicks(8967));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 8, 23, 3, 38, 48, 13, DateTimeKind.Local).AddTicks(9126));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 9, 8, 18, 8, 51, 41, DateTimeKind.Local).AddTicks(1338));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 12, 8, 22, 37, 613, DateTimeKind.Local).AddTicks(9271));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 2, 7, 9, 44, 440, DateTimeKind.Local).AddTicks(9139));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 2, 7, 2, 46, 42, 70, DateTimeKind.Local).AddTicks(3137));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 25, 22, 18, 25, 922, DateTimeKind.Local).AddTicks(6583));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2020, 3, 11, 4, 25, 24, 104, DateTimeKind.Local).AddTicks(7981));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 28, 22, 42, 15, 436, DateTimeKind.Local).AddTicks(9108));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 23, 13, 8, 0, 445, DateTimeKind.Local).AddTicks(1126));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 17, 19, 44, 28, 758, DateTimeKind.Local).AddTicks(3882));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 24, 8, 52, 32, 930, DateTimeKind.Local).AddTicks(7939));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 28, 22, 54, 23, 293, DateTimeKind.Local).AddTicks(1054));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 17, 1, 20, 49, 284, DateTimeKind.Local).AddTicks(8101));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 28, 8, 17, 57, 964, DateTimeKind.Local).AddTicks(2020));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 20, 8, 35, 7, 140, DateTimeKind.Local).AddTicks(6041));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 11, 6, 9, 30, 615, DateTimeKind.Local).AddTicks(8372));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 15, 14, 54, 30, 58, DateTimeKind.Local).AddTicks(6849));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2020, 5, 31, 10, 58, 59, 47, DateTimeKind.Local).AddTicks(1022));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 4, 21, 9, 32, 962, DateTimeKind.Local).AddTicks(6460));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 8, 8, 50, 3, 84, DateTimeKind.Local).AddTicks(9729));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2020, 10, 4, 9, 51, 21, 584, DateTimeKind.Local).AddTicks(4432));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 2, 6, 15, 46, 126, DateTimeKind.Local).AddTicks(2236));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 17, 10, 45, 40, 558, DateTimeKind.Local).AddTicks(943));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 20, 9, 0, 41, 266, DateTimeKind.Local).AddTicks(9809));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 19, 3, 55, 4, 659, DateTimeKind.Local).AddTicks(3383));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 29, 12, 6, 9, 805, DateTimeKind.Local).AddTicks(9997));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 17, 16, 7, 54, 498, DateTimeKind.Local).AddTicks(8957));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2019, 9, 12, 22, 19, 0, 576, DateTimeKind.Local).AddTicks(3717));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 5, 21, 7, 18, 780, DateTimeKind.Local).AddTicks(7612));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 20, 5, 42, 21, 286, DateTimeKind.Local).AddTicks(3515));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 28, 4, 9, 25, 770, DateTimeKind.Local).AddTicks(3107));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2020, 12, 16, 4, 49, 48, 578, DateTimeKind.Local).AddTicks(6650));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 10, 9, 10, 45, 762, DateTimeKind.Local).AddTicks(3936));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 1, 19, 27, 27, 518, DateTimeKind.Local).AddTicks(3885));

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
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_Dashboards_Users_CreatedBy",
                table: "Dashboards");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_Organizations_OrganizationId",
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
                name: "IX_Members_UserId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "IsAccepted",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Members");

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
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId" },
                values: new object[] { new DateTime(2020, 1, 3, 8, 25, 34, 990, DateTimeKind.Unspecified).AddTicks(521), 3, 1 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId" },
                values: new object[] { new DateTime(2020, 4, 25, 10, 18, 40, 933, DateTimeKind.Unspecified).AddTicks(8555), 10, 4 });

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
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2021, 6, 15, 20, 0, 11, 725, DateTimeKind.Unspecified).AddTicks(3505), 3, 5, 1 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2020, 1, 21, 6, 5, 21, 218, DateTimeKind.Unspecified).AddTicks(6260), 4 });

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
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2021, 6, 14, 18, 35, 8, 962, DateTimeKind.Unspecified).AddTicks(783), 12, 2, 2 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2019, 11, 27, 0, 59, 19, 851, DateTimeKind.Unspecified).AddTicks(207), 2, 2, 2 });

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
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2021, 6, 29, 4, 27, 33, 463, DateTimeKind.Unspecified).AddTicks(2445), 16, 2, 2 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "CreatedBy", "RoleId" },
                values: new object[] { new DateTime(2020, 8, 31, 3, 14, 25, 440, DateTimeKind.Unspecified).AddTicks(6945), 20, 1 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "CreatedBy", "RoleId" },
                values: new object[] { new DateTime(2020, 10, 19, 4, 23, 25, 774, DateTimeKind.Unspecified).AddTicks(1835), 14, 1 });

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
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2020, 2, 9, 19, 23, 50, 460, DateTimeKind.Unspecified).AddTicks(534), 20, 4, 3 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId" },
                values: new object[] { new DateTime(2021, 4, 23, 7, 4, 13, 49, DateTimeKind.Unspecified).AddTicks(4808), 16, 2 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId" },
                values: new object[] { new DateTime(2019, 11, 23, 18, 4, 52, 732, DateTimeKind.Unspecified).AddTicks(9426), 6, 3 });

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
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2020, 9, 4, 5, 54, 15, 840, DateTimeKind.Unspecified).AddTicks(7823), 20 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2019, 11, 5, 17, 30, 28, 659, DateTimeKind.Unspecified).AddTicks(2449), 1 });

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

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Users_CreatedBy",
                table: "Applications",
                column: "CreatedBy",
                principalTable: "Users",
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
