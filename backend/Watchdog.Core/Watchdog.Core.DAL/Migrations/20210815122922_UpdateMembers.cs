using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Watchdog.Core.DAL.Migrations
{
    public partial class UpdateMembers : Migration
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
                name: "FK_TeamMembers_Members_MemberId",
                table: "TeamMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Users_CreatedBy",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_Tiles_Users_CreatedBy",
                table: "Tiles");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Tiles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Teams",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Organizations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Members",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Dashboards",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Applications",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 24, 13, 24, 26, 487, DateTimeKind.Unspecified).AddTicks(9308));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2019, 7, 28, 3, 45, 40, 704, DateTimeKind.Unspecified).AddTicks(7543));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2019, 8, 13, 18, 15, 43, 731, DateTimeKind.Unspecified).AddTicks(9466));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 17, 8, 29, 30, 304, DateTimeKind.Unspecified).AddTicks(7284));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 7, 7, 16, 37, 131, DateTimeKind.Unspecified).AddTicks(7056));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2021, 1, 12, 2, 53, 34, 761, DateTimeKind.Unspecified).AddTicks(966));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 30, 22, 25, 18, 613, DateTimeKind.Unspecified).AddTicks(4327));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2020, 2, 14, 4, 32, 16, 795, DateTimeKind.Unspecified).AddTicks(5642));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 2, 22, 49, 8, 127, DateTimeKind.Unspecified).AddTicks(6671));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 27, 13, 14, 53, 135, DateTimeKind.Unspecified).AddTicks(8604));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 22, 19, 51, 21, 449, DateTimeKind.Unspecified).AddTicks(1277));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 29, 8, 59, 25, 621, DateTimeKind.Unspecified).AddTicks(5252));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 2, 23, 1, 15, 983, DateTimeKind.Unspecified).AddTicks(8282));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2020, 1, 22, 1, 27, 41, 975, DateTimeKind.Unspecified).AddTicks(5248));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 2, 8, 24, 50, 654, DateTimeKind.Unspecified).AddTicks(9073));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2021, 3, 25, 8, 41, 59, 831, DateTimeKind.Unspecified).AddTicks(3010));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2020, 12, 16, 6, 16, 23, 306, DateTimeKind.Unspecified).AddTicks(5257));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 20, 15, 1, 22, 749, DateTimeKind.Unspecified).AddTicks(3651));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2020, 5, 5, 11, 5, 51, 737, DateTimeKind.Unspecified).AddTicks(7741));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 8, 21, 16, 25, 653, DateTimeKind.Unspecified).AddTicks(3094));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 13, 8, 56, 55, 775, DateTimeKind.Unspecified).AddTicks(6270));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreatedAt",
                value: new DateTime(2020, 9, 8, 9, 58, 14, 275, DateTimeKind.Unspecified).AddTicks(889));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreatedAt",
                value: new DateTime(2021, 5, 7, 6, 22, 38, 816, DateTimeKind.Unspecified).AddTicks(8609));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 22, 10, 52, 33, 248, DateTimeKind.Unspecified).AddTicks(7232));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreatedAt",
                value: new DateTime(2020, 5, 25, 9, 7, 33, 957, DateTimeKind.Unspecified).AddTicks(6013));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreatedAt",
                value: new DateTime(2021, 6, 23, 4, 1, 57, 349, DateTimeKind.Unspecified).AddTicks(9503));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 3, 12, 13, 2, 496, DateTimeKind.Unspecified).AddTicks(6010));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreatedAt",
                value: new DateTime(2020, 8, 22, 16, 14, 47, 189, DateTimeKind.Unspecified).AddTicks(4885));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreatedAt",
                value: new DateTime(2019, 8, 17, 22, 25, 53, 266, DateTimeKind.Unspecified).AddTicks(9563));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreatedAt",
                value: new DateTime(2020, 7, 10, 21, 14, 11, 471, DateTimeKind.Unspecified).AddTicks(3375));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 24, 5, 49, 13, 976, DateTimeKind.Unspecified).AddTicks(9196));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreatedAt",
                value: new DateTime(2020, 6, 2, 4, 16, 18, 460, DateTimeKind.Unspecified).AddTicks(8704));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreatedAt",
                value: new DateTime(2020, 11, 20, 4, 56, 41, 269, DateTimeKind.Unspecified).AddTicks(2147));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 14, 9, 17, 38, 452, DateTimeKind.Unspecified).AddTicks(9347));

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreatedAt",
                value: new DateTime(2021, 4, 5, 19, 34, 20, 208, DateTimeKind.Unspecified).AddTicks(9212));

            migrationBuilder.Sql("Update Members Set UserId = CreatedBy, IsAccepted = 'true';");

            migrationBuilder.CreateIndex(
                name: "IX_Members_UserId",
                table: "Members",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Users_CreatedBy",
                table: "Applications",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Dashboards_Users_CreatedBy",
                table: "Dashboards",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

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
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Users_UserId",
                table: "Members",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_Users_CreatedBy",
                table: "Organizations",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMembers_Members_MemberId",
                table: "TeamMembers",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Users_CreatedBy",
                table: "Teams",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Tiles_Users_CreatedBy",
                table: "Tiles",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
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
                name: "FK_TeamMembers_Members_MemberId",
                table: "TeamMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Users_CreatedBy",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_Tiles_Users_CreatedBy",
                table: "Tiles");

            migrationBuilder.DropIndex(
                name: "IX_Members_UserId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "IsAccepted",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Members");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Tiles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Organizations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Members",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Dashboards",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Applications",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
                name: "FK_TeamMembers_Members_MemberId",
                table: "TeamMembers",
                column: "MemberId",
                principalTable: "Members",
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
