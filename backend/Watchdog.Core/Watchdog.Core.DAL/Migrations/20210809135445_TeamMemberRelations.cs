using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Watchdog.Core.DAL.Migrations
{
    public partial class TeamMemberRelations : Migration
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
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Sunt maxime numquam alias alias placeat corrupti nisi veniam. In adipisci ipsa doloribus amet. Earum dolore enim sapiente.");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Eligendi aspernatur molestias et eum et. Ipsa inventore quam qui dolor. Minus non repudiandae harum architecto nesciunt reprehenderit. Numquam sunt nostrum fugiat. Occaecati aut quam consequatur aliquid eius sed quia ab.");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Iure sint dolorum maiores et eius. Maxime eos quis qui. Doloremque laborum ut aut tempora.");

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

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Sit est commodi explicabo numquam eaque aut est. Hic expedita natus ut impedit. Natus voluptas delectus. Cum dignissimos rem quaerat reiciendis incidunt dicta quam veritatis.");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Ab hic incidunt alias omnis totam molestias et beatae. Soluta maxime cum repudiandae. Voluptatem et aspernatur explicabo voluptatibus adipisci. Totam id incidunt perspiciatis reprehenderit. Et magni et qui voluptas et. Nihil voluptas ut non provident illo voluptate rerum cupiditate asperiores.");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Ut omnis beatae expedita voluptatem ut eos et est. Dolores assumenda incidunt beatae quia inventore. Est eos reiciendis dolor aut quisquam dolorem non dolorem natus. Repellendus iure earum maxime provident placeat quae fugiat temporibus voluptatum. At ut accusamus consequuntur modi.");

            migrationBuilder.InsertData(
                table: "TeamMembers",
                columns: new[] { "Id", "MemberId", "TeamId" },
                values: new object[,]
                {
                    { 24, 7, 2 },
                    { 2, 12, 3 },
                    { 3, 10, 1 },
                    { 4, 1, 2 },
                    { 5, 28, 2 },
                    { 6, 4, 2 },
                    { 7, 30, 5 },
                    { 8, 5, 4 },
                    { 9, 4, 1 },
                    { 10, 13, 2 }
                });

            migrationBuilder.InsertData(
                table: "TeamMembers",
                columns: new[] { "Id", "MemberId", "TeamId" },
                values: new object[,]
                {
                    { 11, 16, 3 },
                    { 25, 29, 1 },
                    { 12, 8, 2 },
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
                    { 13, 29, 1 },
                    { 1, 9, 2 }
                });

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
                onDelete: ReferentialAction.Cascade);

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
