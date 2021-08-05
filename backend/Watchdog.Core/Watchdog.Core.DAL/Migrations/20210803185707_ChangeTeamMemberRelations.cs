using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Watchdog.Core.DAL.Migrations
{
    public partial class ChangeTeamMemberRelations : Migration
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

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Members",
                type: "nvarchar(128)",
                nullable: true);

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

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Users_Email",
                table: "Users",
                column: "Email");

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "TeamId" },
                values: new object[] { "bailee.berge@yahoo.com", 5 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy", "Email", "OrganizationId", "TeamId" },
                values: new object[] { new DateTime(2021, 6, 5, 15, 33, 52, 668, DateTimeKind.Unspecified).AddTicks(8238), 12, "christopher_weimann25@hotmail.com", 4, 5 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy", "Email", "OrganizationId", "RoleId", "TeamId" },
                values: new object[] { new DateTime(2019, 8, 7, 13, 50, 23, 863, DateTimeKind.Unspecified).AddTicks(6323), 9, "cruz_mcclure42@gmail.com", 1, 2, 2 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy", "Email", "IsAccepted", "OrganizationId", "RoleId", "TeamId" },
                values: new object[] { new DateTime(2020, 11, 7, 7, 48, 7, 318, DateTimeKind.Unspecified).AddTicks(7986), 9, "easton_kassulke7@hotmail.com", true, 4, 5, 4 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedBy", "Email", "OrganizationId", "RoleId", "TeamId" },
                values: new object[] { new DateTime(2019, 11, 14, 5, 32, 33, 474, DateTimeKind.Unspecified).AddTicks(6814), 20, "angeline.hand@yahoo.com", 2, 2, 2 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Email", "IsAccepted", "OrganizationId", "RoleId", "TeamId" },
                values: new object[] { new DateTime(2020, 3, 5, 3, 13, 6, 437, DateTimeKind.Unspecified).AddTicks(6226), "arthur.schiller@yahoo.com", true, 2, 4, 1 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "CreatedBy", "Email", "IsAccepted", "OrganizationId", "RoleId", "TeamId" },
                values: new object[] { new DateTime(2021, 6, 22, 18, 25, 20, 694, DateTimeKind.Unspecified).AddTicks(2971), 4, "anais28@hotmail.com", true, 1, 1, 3 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "CreatedBy", "Email", "OrganizationId", "RoleId", "TeamId" },
                values: new object[] { new DateTime(2021, 4, 16, 15, 25, 9, 203, DateTimeKind.Unspecified).AddTicks(3466), 12, "angeline.hand@yahoo.com", 3, 3, 3 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "CreatedBy", "Email", "IsAccepted", "OrganizationId", "TeamId" },
                values: new object[] { new DateTime(2021, 1, 15, 16, 3, 46, 55, DateTimeKind.Unspecified).AddTicks(7176), 4, "arturo60@yahoo.com", true, 3, 3 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "CreatedBy", "Email", "TeamId" },
                values: new object[] { new DateTime(2020, 5, 8, 6, 46, 11, 349, DateTimeKind.Unspecified).AddTicks(6948), 5, "gregoria0@hotmail.com", 3 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "CreatedBy", "Email", "OrganizationId", "RoleId", "TeamId" },
                values: new object[] { new DateTime(2021, 1, 31, 0, 43, 53, 927, DateTimeKind.Unspecified).AddTicks(6177), 6, "antwan.swift6@yahoo.com", 4, 5, 2 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "CreatedBy", "Email", "OrganizationId", "RoleId", "TeamId" },
                values: new object[] { new DateTime(2021, 1, 30, 18, 46, 23, 83, DateTimeKind.Unspecified).AddTicks(5076), 7, "christopher_weimann25@hotmail.com", 2, 4, 3 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "CreatedBy", "Email", "IsAccepted", "RoleId", "TeamId" },
                values: new object[] { new DateTime(2019, 12, 13, 13, 57, 12, 13, DateTimeKind.Unspecified).AddTicks(984), 15, "bailee.berge@yahoo.com", true, 4, 1 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "CreatedBy", "Email", "OrganizationId", "RoleId", "TeamId" },
                values: new object[] { new DateTime(2020, 9, 11, 9, 15, 12, 793, DateTimeKind.Unspecified).AddTicks(4954), 9, "stephania_koelpin@hotmail.com", 4, 4, 4 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "CreatedBy", "Email", "OrganizationId", "RoleId", "TeamId" },
                values: new object[] { new DateTime(2019, 8, 6, 23, 13, 48, 118, DateTimeKind.Unspecified).AddTicks(309), 9, "jamaal_leannon@gmail.com", 5, 3, 1 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "CreatedBy", "Email", "OrganizationId", "RoleId", "TeamId" },
                values: new object[] { new DateTime(2021, 1, 10, 12, 2, 35, 88, DateTimeKind.Unspecified).AddTicks(947), 18, "gregoria0@hotmail.com", 2, 5, 5 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "CreatedBy", "Email", "OrganizationId", "RoleId", "TeamId" },
                values: new object[] { new DateTime(2021, 4, 26, 1, 36, 51, 405, DateTimeKind.Unspecified).AddTicks(6570), 1, "arturo60@yahoo.com", 5, 1, 4 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "CreatedBy", "Email", "IsAccepted", "RoleId", "TeamId" },
                values: new object[] { new DateTime(2020, 9, 6, 19, 18, 22, 748, DateTimeKind.Unspecified).AddTicks(509), 16, "bailee.berge@yahoo.com", true, 1, 5 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "CreatedBy", "Email", "IsAccepted", "OrganizationId", "RoleId", "TeamId" },
                values: new object[] { new DateTime(2020, 6, 21, 13, 15, 6, 207, DateTimeKind.Unspecified).AddTicks(8475), 17, "jed.kshlerin@hotmail.com", true, 5, 1, 3 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "Email", "OrganizationId", "RoleId", "TeamId" },
                values: new object[] { new DateTime(2020, 12, 17, 19, 34, 20, 969, DateTimeKind.Unspecified).AddTicks(6895), "paula.erdman41@hotmail.com", 5, 2, 5 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "CreatedBy", "Email", "OrganizationId", "RoleId", "TeamId" },
                values: new object[] { new DateTime(2021, 1, 30, 6, 54, 45, 33, DateTimeKind.Unspecified).AddTicks(484), 11, "jamaal_leannon@gmail.com", 5, 1, 2 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "CreatedBy", "Email", "IsAccepted", "TeamId" },
                values: new object[] { new DateTime(2019, 8, 31, 13, 33, 3, 674, DateTimeKind.Unspecified).AddTicks(2628), 7, "bailee.berge@yahoo.com", true, 3 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "CreatedBy", "Email", "OrganizationId", "RoleId", "TeamId" },
                values: new object[] { new DateTime(2020, 11, 3, 15, 22, 10, 442, DateTimeKind.Unspecified).AddTicks(8194), 11, "antwan.swift6@yahoo.com", 4, 3, 4 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "CreatedBy", "Email", "OrganizationId", "RoleId", "TeamId" },
                values: new object[] { new DateTime(2020, 12, 24, 20, 15, 53, 153, DateTimeKind.Unspecified).AddTicks(2359), 15, "bailee.berge@yahoo.com", 1, 3, 5 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "CreatedBy", "Email", "IsAccepted", "RoleId", "TeamId" },
                values: new object[] { new DateTime(2019, 11, 1, 7, 49, 17, 589, DateTimeKind.Unspecified).AddTicks(9121), 17, "terrill.lueilwitz@yahoo.com", true, 1, 1 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "Email", "IsAccepted", "OrganizationId", "RoleId", "TeamId" },
                values: new object[] { new DateTime(2020, 4, 26, 15, 3, 39, 855, DateTimeKind.Unspecified).AddTicks(2801), "lambert.gusikowski33@yahoo.com", true, 2, 4, 2 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "CreatedBy", "Email", "OrganizationId", "TeamId" },
                values: new object[] { new DateTime(2021, 5, 9, 17, 49, 41, 427, DateTimeKind.Unspecified).AddTicks(2032), 12, "elbert14@gmail.com", 3, 5 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "CreatedBy", "Email", "OrganizationId", "TeamId" },
                values: new object[] { new DateTime(2021, 3, 18, 8, 26, 12, 459, DateTimeKind.Unspecified).AddTicks(5733), 19, "gregoria0@hotmail.com", 4, 5 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "CreatedBy", "Email", "RoleId", "TeamId" },
                values: new object[] { new DateTime(2021, 1, 9, 2, 53, 25, 743, DateTimeKind.Unspecified).AddTicks(3222), 20, "terrill.lueilwitz@yahoo.com", 4, 4 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "CreatedBy", "Email", "TeamId" },
                values: new object[] { new DateTime(2020, 12, 4, 19, 55, 17, 960, DateTimeKind.Unspecified).AddTicks(9409), 2, "arthur.schiller@yahoo.com", 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Members_Email",
                table: "Members",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Members_TeamId",
                table: "Members",
                column: "TeamId");

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
                name: "FK_Members_Users_Email",
                table: "Members",
                column: "Email",
                principalTable: "Users",
                principalColumn: "Email");

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
                name: "FK_Members_Users_Email",
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
                name: "IX_Members_Email",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_TeamId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "IsAccepted",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "TeamId",
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
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId" },
                values: new object[] { new DateTime(2019, 11, 11, 3, 10, 6, 170, DateTimeKind.Unspecified).AddTicks(2841), 16, 1 });

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
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2020, 8, 11, 5, 32, 51, 930, DateTimeKind.Unspecified).AddTicks(3850), 5, 5, 3 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2020, 8, 29, 8, 18, 24, 585, DateTimeKind.Unspecified).AddTicks(9893), 5, 5 });

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
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId" },
                values: new object[] { new DateTime(2020, 3, 1, 10, 50, 38, 346, DateTimeKind.Unspecified).AddTicks(2283), 18, 2 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2021, 7, 14, 18, 53, 43, 769, DateTimeKind.Unspecified).AddTicks(5102), 14 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2021, 6, 23, 23, 17, 16, 155, DateTimeKind.Unspecified).AddTicks(5266), 2, 2, 2 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2021, 4, 5, 17, 35, 33, 328, DateTimeKind.Unspecified).AddTicks(4435), 9, 1, 1 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "CreatedBy", "RoleId" },
                values: new object[] { new DateTime(2020, 6, 5, 23, 26, 15, 564, DateTimeKind.Unspecified).AddTicks(274), 12, 3 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2020, 2, 16, 2, 0, 40, 350, DateTimeKind.Unspecified).AddTicks(4718), 6, 3, 1 });

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
                keyValue: 17,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2020, 8, 9, 5, 46, 45, 899, DateTimeKind.Unspecified).AddTicks(7907), 12, 2, 4 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "CreatedBy", "RoleId" },
                values: new object[] { new DateTime(2020, 3, 28, 11, 51, 59, 488, DateTimeKind.Unspecified).AddTicks(8865), 18, 5 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2020, 8, 26, 0, 42, 7, 317, DateTimeKind.Unspecified).AddTicks(8157), 5, 2, 2 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2020, 12, 4, 13, 22, 46, 624, DateTimeKind.Unspecified).AddTicks(5014), 4, 4 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2019, 8, 24, 23, 59, 6, 250, DateTimeKind.Unspecified).AddTicks(1004), 16, 3, 2 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2019, 12, 13, 13, 57, 12, 13, DateTimeKind.Unspecified).AddTicks(984), 15 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2020, 1, 14, 18, 54, 42, 990, DateTimeKind.Unspecified).AddTicks(701), 9, 1, 1 });

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
                keyValue: 26,
                columns: new[] { "CreatedAt", "OrganizationId", "RoleId" },
                values: new object[] { new DateTime(2019, 10, 12, 15, 15, 12, 766, DateTimeKind.Unspecified).AddTicks(6699), 5, 3 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId" },
                values: new object[] { new DateTime(2019, 10, 3, 14, 41, 15, 275, DateTimeKind.Unspecified).AddTicks(7289), 6, 5 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId" },
                values: new object[] { new DateTime(2020, 6, 30, 21, 45, 53, 833, DateTimeKind.Unspecified).AddTicks(6612), 20, 5 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "CreatedBy", "RoleId" },
                values: new object[] { new DateTime(2021, 4, 26, 1, 36, 51, 405, DateTimeKind.Unspecified).AddTicks(6570), 1, 1 });

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "CreatedBy" },
                values: new object[] { new DateTime(2021, 3, 13, 14, 30, 36, 921, DateTimeKind.Unspecified).AddTicks(1544), 12 });

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
                    { 10, 13, 2 },
                    { 11, 16, 3 },
                    { 25, 29, 1 },
                    { 12, 8, 2 }
                });

            migrationBuilder.InsertData(
                table: "TeamMembers",
                columns: new[] { "Id", "MemberId", "TeamId" },
                values: new object[,]
                {
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
