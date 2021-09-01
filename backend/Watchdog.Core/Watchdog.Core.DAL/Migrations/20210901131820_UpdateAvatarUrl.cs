using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Watchdog.Core.DAL.Migrations
{
    public partial class UpdateAvatarUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AvatarUrl",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AvatarUrl",
                table: "Organizations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Type",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 5,
                column: "Type",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "CreatedBy", "Settings", "Type" },
                values: new object[] { new DateTime(2021, 7, 6, 5, 56, 57, 809, DateTimeKind.Unspecified).AddTicks(7691), 2, "{\"sourceProjects\": [4],\"dateRange\": 4,\"issuesCount\": 539}", 1 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Category", "DashboardId", "Name", "Type" },
                values: new object[] { 1, 11, "Intelligent Concrete Hat", 0 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "CreatedBy", "Settings", "Type" },
                values: new object[] { new DateTime(2019, 11, 12, 16, 5, 38, 894, DateTimeKind.Unspecified).AddTicks(8561), 14, "{\"sourceProjects\": [8],\"dateRange\": 4,\"issuesCount\": 848}", 1 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { new DateTime(2021, 2, 3, 13, 9, 18, 256, DateTimeKind.Unspecified).AddTicks(6869), 4, 4, "Refined Fresh Shirt", "{\"sourceProjects\": [2],\"dateRange\": 2,\"issuesCount\": 549}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 1, new DateTime(2021, 4, 22, 12, 42, 25, 714, DateTimeKind.Unspecified).AddTicks(9197), 11, 11, "Refined Cotton Table", "{\"sourceProjects\": [7],\"dateRange\": 0,\"issuesCount\": 487}", 2 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 3, new DateTime(2019, 8, 15, 5, 1, 52, 281, DateTimeKind.Unspecified).AddTicks(6096), 2, 6, "Small Wooden Table", "{\"sourceProjects\": [6],\"dateRange\": 0,\"issuesCount\": 731}", 2 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { new DateTime(2019, 11, 24, 6, 26, 2, 408, DateTimeKind.Unspecified).AddTicks(3940), 10, 6, "Ergonomic Metal Pants", "{\"sourceProjects\": [7],\"dateRange\": 4,\"issuesCount\": 518}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 1, new DateTime(2021, 7, 11, 13, 57, 50, 473, DateTimeKind.Unspecified).AddTicks(6824), 12, 3, "Handmade Concrete Chips", "{\"sourceProjects\": [3],\"dateRange\": 3,\"issuesCount\": 25}", 2 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 3, new DateTime(2020, 10, 15, 11, 5, 13, 423, DateTimeKind.Unspecified).AddTicks(7192), 12, 11, "Refined Plastic Bacon", "{\"sourceProjects\": [3],\"dateRange\": 0,\"issuesCount\": 192}", 2 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { new DateTime(2021, 1, 23, 4, 18, 44, 192, DateTimeKind.Unspecified).AddTicks(5282), 9, 12, "Fantastic Wooden Gloves", "{\"sourceProjects\": [1],\"dateRange\": 1,\"issuesCount\": 19}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "Name", "Settings", "Type" },
                values: new object[] { 0, new DateTime(2020, 12, 4, 13, 19, 1, 987, DateTimeKind.Unspecified).AddTicks(6992), 17, "Rustic Frozen Gloves", "{\"sourceProjects\": [8],\"dateRange\": 4,\"issuesCount\": 214}", 1 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { 2, new DateTime(2020, 5, 5, 11, 5, 51, 737, DateTimeKind.Unspecified).AddTicks(7741), 4, 5, "Practical Metal Mouse", "{\"sourceProjects\": [5],\"dateRange\": 0,\"issuesCount\": 729}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 0, new DateTime(2021, 4, 12, 0, 15, 19, 181, DateTimeKind.Unspecified).AddTicks(4159), 3, 13, "Fantastic Rubber Pizza", "{\"sourceProjects\": [12],\"dateRange\": 0,\"issuesCount\": 426}", 2 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { new DateTime(2020, 2, 19, 6, 8, 23, 542, DateTimeKind.Unspecified).AddTicks(9640), 15, 9, "Small Soft Shirt", "{\"sourceProjects\": [2],\"dateRange\": 3,\"issuesCount\": 207}", 2 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { 3, new DateTime(2021, 6, 6, 18, 57, 44, 606, DateTimeKind.Unspecified).AddTicks(5866), 15, 3, "Tasty Frozen Table", "{\"sourceProjects\": [7],\"dateRange\": 0,\"issuesCount\": 970}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { 1, new DateTime(2021, 3, 16, 16, 2, 36, 334, DateTimeKind.Unspecified).AddTicks(3898), 14, 2, "Practical Rubber Fish", "{\"sourceProjects\": [6],\"dateRange\": 0,\"issuesCount\": 66}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 3, new DateTime(2019, 10, 1, 7, 27, 50, 470, DateTimeKind.Unspecified).AddTicks(5602), 15, 15, "Small Metal Table", "{\"sourceProjects\": [9],\"dateRange\": 4,\"issuesCount\": 75}", 2 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 2, new DateTime(2020, 9, 28, 16, 20, 10, 300, DateTimeKind.Unspecified).AddTicks(9930), 7, 6, "Rustic Rubber Sausages", "{\"sourceProjects\": [11],\"dateRange\": 3,\"issuesCount\": 405}", 2 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 3, new DateTime(2021, 7, 8, 2, 51, 5, 17, DateTimeKind.Unspecified).AddTicks(3906), 8, 12, "Small Plastic Cheese", "{\"sourceProjects\": [14],\"dateRange\": 1,\"issuesCount\": 23}", 1 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { new DateTime(2020, 11, 12, 18, 33, 40, 796, DateTimeKind.Unspecified).AddTicks(2720), 16, 11, "Unbranded Fresh Fish", "{\"sourceProjects\": [8],\"dateRange\": 2,\"issuesCount\": 989}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { new DateTime(2019, 8, 13, 2, 20, 12, 290, DateTimeKind.Unspecified).AddTicks(8065), 12, 3, "Incredible Granite Mouse", "{\"sourceProjects\": [13],\"dateRange\": 4,\"issuesCount\": 476}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { new DateTime(2020, 11, 20, 23, 30, 36, 158, DateTimeKind.Unspecified).AddTicks(7919), 5, 2, "Incredible Rubber Tuna", "{\"sourceProjects\": [14],\"dateRange\": 2,\"issuesCount\": 552}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { new DateTime(2021, 6, 17, 18, 33, 20, 161, DateTimeKind.Unspecified).AddTicks(7027), 14, 10, "Ergonomic Soft Keyboard", "{\"sourceProjects\": [4],\"dateRange\": 2,\"issuesCount\": 639}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { new DateTime(2020, 8, 14, 9, 51, 2, 711, DateTimeKind.Unspecified).AddTicks(8693), 13, 1, "Fantastic Concrete Sausages", "{\"sourceProjects\": [9],\"dateRange\": 3,\"issuesCount\": 50}", 2 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "DashboardId", "Name", "Settings" },
                values: new object[] { new DateTime(2020, 6, 12, 12, 1, 19, 384, DateTimeKind.Unspecified).AddTicks(8239), 9, "Ergonomic Plastic Towels", "{\"sourceProjects\": [5],\"dateRange\": 3,\"issuesCount\": 435}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { new DateTime(2021, 4, 14, 9, 17, 38, 452, DateTimeKind.Unspecified).AddTicks(9347), 11, 14, "Practical Steel Salad", "{\"sourceProjects\": [9],\"dateRange\": 2,\"issuesCount\": 735}", 1 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { new DateTime(2019, 11, 13, 10, 57, 57, 851, DateTimeKind.Unspecified).AddTicks(6700), 3, 3, "Incredible Plastic Computer", "{\"sourceProjects\": [9],\"dateRange\": 4,\"issuesCount\": 337}", 2 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { 0, new DateTime(2020, 5, 17, 2, 10, 20, 689, DateTimeKind.Unspecified).AddTicks(3480), 16, 7, "Handmade Granite Chair", "{\"sourceProjects\": [8],\"dateRange\": 4,\"issuesCount\": 932}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 1, new DateTime(2019, 7, 29, 14, 57, 56, 6, DateTimeKind.Unspecified).AddTicks(4108), 9, 1, "Intelligent Frozen Mouse", "{\"sourceProjects\": [2],\"dateRange\": 1,\"issuesCount\": 973}", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AvatarUrl",
                table: "Users",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AvatarUrl",
                table: "Organizations",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Type",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 5,
                column: "Type",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "CreatedBy", "Settings", "Type" },
                values: new object[] { new DateTime(2021, 6, 2, 12, 19, 51, 35, DateTimeKind.Unspecified).AddTicks(1215), 8, "{\"sourceProjects\": [1],\"dateRange\": 1,\"issuesCount\": 962}", 0 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Category", "DashboardId", "Name", "Type" },
                values: new object[] { 0, 9, "Awesome Concrete Bike", 1 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "CreatedBy", "Settings", "Type" },
                values: new object[] { new DateTime(2020, 3, 10, 21, 33, 41, 933, DateTimeKind.Unspecified).AddTicks(2252), 8, "{\"sourceProjects\": [13],\"dateRange\": 2,\"issuesCount\": 898}", 0 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { new DateTime(2021, 3, 28, 8, 14, 13, 190, DateTimeKind.Unspecified).AddTicks(2898), 7, 7, "Refined Fresh Pizza", "{\"sourceProjects\": [4],\"dateRange\": 0,\"issuesCount\": 578}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 3, new DateTime(2020, 7, 15, 13, 23, 17, 330, DateTimeKind.Unspecified).AddTicks(9130), 8, 7, "Awesome Fresh Shirt", "{\"sourceProjects\": [2],\"dateRange\": 2,\"issuesCount\": 22}", 1 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 1, new DateTime(2019, 12, 30, 21, 8, 59, 766, DateTimeKind.Unspecified).AddTicks(5706), 16, 7, "Sleek Steel Keyboard", "{\"sourceProjects\": [2],\"dateRange\": 4,\"issuesCount\": 387}", 0 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { new DateTime(2021, 4, 14, 18, 14, 18, 70, DateTimeKind.Unspecified).AddTicks(9748), 8, 11, "Intelligent Soft Car", "{\"sourceProjects\": [8],\"dateRange\": 4,\"issuesCount\": 429}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 0, new DateTime(2020, 8, 14, 7, 49, 57, 778, DateTimeKind.Unspecified).AddTicks(8714), 19, 4, "Refined Granite Fish", "{\"sourceProjects\": [9],\"dateRange\": 0,\"issuesCount\": 174}", 1 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 2, new DateTime(2019, 10, 17, 17, 35, 23, 658, DateTimeKind.Unspecified).AddTicks(473), 19, 6, "Handmade Steel Salad", "{\"sourceProjects\": [9],\"dateRange\": 1,\"issuesCount\": 153}", 1 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { new DateTime(2020, 11, 24, 10, 33, 32, 125, DateTimeKind.Unspecified).AddTicks(5620), 16, 3, "Rustic Concrete Pants", "{\"sourceProjects\": [7],\"dateRange\": 1,\"issuesCount\": 26}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "Name", "Settings", "Type" },
                values: new object[] { 1, new DateTime(2020, 8, 1, 23, 56, 22, 709, DateTimeKind.Unspecified).AddTicks(4062), 19, "Incredible Steel Keyboard", "{\"sourceProjects\": [3],\"dateRange\": 4,\"issuesCount\": 312}", 0 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { 0, new DateTime(2020, 6, 30, 9, 29, 19, 969, DateTimeKind.Unspecified).AddTicks(1461), 7, 7, "Sleek Frozen Bike", "{\"sourceProjects\": [11],\"dateRange\": 0,\"issuesCount\": 603}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 3, new DateTime(2019, 10, 30, 20, 33, 0, 122, DateTimeKind.Unspecified).AddTicks(8421), 17, 6, "Gorgeous Steel Fish", "{\"sourceProjects\": [3],\"dateRange\": 0,\"issuesCount\": 136}", 1 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { new DateTime(2020, 1, 26, 2, 41, 21, 23, DateTimeKind.Unspecified).AddTicks(4949), 11, 1, "Licensed Wooden Table", "{\"sourceProjects\": [7],\"dateRange\": 3,\"issuesCount\": 707}", 1 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { 1, new DateTime(2020, 9, 8, 9, 58, 14, 275, DateTimeKind.Unspecified).AddTicks(889), 3, 15, "Ergonomic Metal Mouse", "{\"sourceProjects\": [12],\"dateRange\": 3,\"issuesCount\": 60}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { 2, new DateTime(2020, 4, 1, 18, 7, 6, 622, DateTimeKind.Unspecified).AddTicks(7415), 3, 7, "Practical Steel Chips", "{\"sourceProjects\": [5],\"dateRange\": 3,\"issuesCount\": 172}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 1, new DateTime(2019, 7, 25, 10, 41, 12, 636, DateTimeKind.Unspecified).AddTicks(4419), 19, 1, "Fantastic Concrete Car", "{\"sourceProjects\": [15],\"dateRange\": 3,\"issuesCount\": 900}", 1 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 3, new DateTime(2020, 2, 6, 2, 6, 53, 517, DateTimeKind.Unspecified).AddTicks(9108), 8, 3, "Awesome Frozen Car", "{\"sourceProjects\": [11],\"dateRange\": 1,\"issuesCount\": 403}", 1 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 1, new DateTime(2019, 12, 21, 4, 39, 42, 128, DateTimeKind.Unspecified).AddTicks(915), 16, 1, "Handmade Metal Shirt", "{\"sourceProjects\": [10],\"dateRange\": 4,\"issuesCount\": 388}", 0 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { new DateTime(2020, 3, 9, 7, 33, 33, 356, DateTimeKind.Unspecified).AddTicks(2081), 15, 1, "Small Fresh Ball", "{\"sourceProjects\": [8],\"dateRange\": 4,\"issuesCount\": 765}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { new DateTime(2021, 3, 18, 9, 0, 51, 247, DateTimeKind.Unspecified).AddTicks(113), 10, 15, "Incredible Granite Table", "{\"sourceProjects\": [3],\"dateRange\": 1,\"issuesCount\": 591}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { new DateTime(2020, 3, 22, 2, 21, 23, 456, DateTimeKind.Unspecified).AddTicks(8659), 13, 8, "Tasty Fresh Chips", "{\"sourceProjects\": [2],\"dateRange\": 0,\"issuesCount\": 204}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { new DateTime(2021, 4, 17, 5, 10, 7, 178, DateTimeKind.Unspecified).AddTicks(6237), 16, 9, "Incredible Fresh Hat", "{\"sourceProjects\": [10],\"dateRange\": 0,\"issuesCount\": 660}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { new DateTime(2019, 8, 24, 8, 40, 39, 207, DateTimeKind.Unspecified).AddTicks(3970), 5, 10, "Small Concrete Hat", "{\"sourceProjects\": [1],\"dateRange\": 4,\"issuesCount\": 320}", 0 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "DashboardId", "Name", "Settings" },
                values: new object[] { new DateTime(2020, 11, 20, 11, 13, 28, 472, DateTimeKind.Unspecified).AddTicks(2916), 12, "Generic Granite Towels", "{\"sourceProjects\": [9],\"dateRange\": 2,\"issuesCount\": 259}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { new DateTime(2021, 7, 11, 16, 54, 8, 255, DateTimeKind.Unspecified).AddTicks(4198), 9, 10, "Ergonomic Rubber Gloves", "{\"sourceProjects\": [14],\"dateRange\": 4,\"issuesCount\": 554}", 0 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { new DateTime(2020, 11, 26, 18, 11, 33, 480, DateTimeKind.Unspecified).AddTicks(9602), 6, 9, "Incredible Granite Keyboard", "{\"sourceProjects\": [2],\"dateRange\": 0,\"issuesCount\": 675}", 1 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { 1, new DateTime(2020, 7, 18, 0, 34, 38, 543, DateTimeKind.Unspecified).AddTicks(620), 15, 9, "Generic Wooden Pizza", "{\"sourceProjects\": [1],\"dateRange\": 2,\"issuesCount\": 581}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 3, new DateTime(2019, 9, 10, 11, 8, 14, 739, DateTimeKind.Unspecified).AddTicks(4528), 5, 8, "Ergonomic Soft Soap", "{\"sourceProjects\": [3],\"dateRange\": 0,\"issuesCount\": 144}", 1 });
        }
    }
}
