using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Watchdog.Core.DAL.Migrations
{
    public partial class UpdateTiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tiles",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Tiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Settings",
                table: "Tiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Tiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { 1, new DateTime(2021, 2, 17, 0, 13, 23, 617, DateTimeKind.Local).AddTicks(4950), 7, 15, "Ergonomic Fresh Chicken", "{\"sourceProjects\": [3],\"dateRange\": 4,\"issuesCount\": 489}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { 1, new DateTime(2019, 8, 20, 14, 34, 37, 836, DateTimeKind.Local).AddTicks(8467), 15, 15, "Tasty Frozen Tuna", "{\"sourceProjects\": [6],\"dateRange\": 2,\"issuesCount\": 977}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { 1, new DateTime(2019, 9, 6, 5, 4, 40, 864, DateTimeKind.Local).AddTicks(511), 3, 10, "Gorgeous Fresh Towels", "{\"sourceProjects\": [4],\"dateRange\": 4,\"issuesCount\": 919}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Category", "CreatedAt", "DashboardId", "Name", "Settings" },
                values: new object[] { 1, new DateTime(2020, 8, 9, 19, 18, 27, 436, DateTimeKind.Local).AddTicks(8397), 5, "Fantastic Steel Shoes", "{\"sourceProjects\": [1],\"dateRange\": 4,\"issuesCount\": 244}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { 1, new DateTime(2020, 8, 30, 18, 5, 34, 263, DateTimeKind.Local).AddTicks(8230), 15, 7, "Handmade Metal Keyboard", "{\"sourceProjects\": [7],\"dateRange\": 2,\"issuesCount\": 74}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { 1, new DateTime(2021, 2, 4, 13, 42, 31, 893, DateTimeKind.Local).AddTicks(2296), 5, 1, "Incredible Frozen Sausages", "{\"sourceProjects\": [1],\"dateRange\": 0,\"issuesCount\": 128}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { 1, new DateTime(2020, 8, 23, 9, 14, 15, 745, DateTimeKind.Local).AddTicks(5718), 19, 14, "Fantastic Frozen Gloves", "{\"sourceProjects\": [4],\"dateRange\": 0,\"issuesCount\": 19}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { 1, new DateTime(2020, 3, 8, 15, 21, 13, 927, DateTimeKind.Local).AddTicks(7090), 11, 4, "Intelligent Frozen Hat", "{\"sourceProjects\": [2],\"dateRange\": 2,\"issuesCount\": 109}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { 1, new DateTime(2021, 4, 26, 9, 38, 5, 259, DateTimeKind.Local).AddTicks(8177), 8, 13, "Generic Plastic Cheese", "{\"sourceProjects\": [5],\"dateRange\": 1,\"issuesCount\": 679}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { 1, new DateTime(2020, 10, 21, 0, 3, 50, 268, DateTimeKind.Local).AddTicks(167), 17, 13, "Refined Granite Salad", "{\"sourceProjects\": [3],\"dateRange\": 1,\"issuesCount\": 156}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { 1, new DateTime(2020, 9, 15, 6, 40, 18, 581, DateTimeKind.Local).AddTicks(2895), 8, 9, "Intelligent Wooden Towels", "{\"sourceProjects\": [7],\"dateRange\": 4,\"issuesCount\": 375}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { 1, new DateTime(2021, 4, 21, 19, 48, 22, 753, DateTimeKind.Local).AddTicks(6968), 1, 1, "Sleek Wooden Table", "{\"sourceProjects\": [5],\"dateRange\": 1,\"issuesCount\": 760}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { 1, new DateTime(2021, 6, 26, 9, 50, 13, 116, DateTimeKind.Local).AddTicks(54), 15, 6, "Licensed Steel Chips", "{\"sourceProjects\": [7],\"dateRange\": 1,\"issuesCount\": 391}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { 1, new DateTime(2020, 2, 14, 12, 16, 39, 107, DateTimeKind.Local).AddTicks(7075), 11, 7, "Rustic Granite Bacon", "{\"sourceProjects\": [3],\"dateRange\": 4,\"issuesCount\": 183}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "Name", "Settings" },
                values: new object[] { 1, new DateTime(2021, 7, 25, 19, 13, 47, 787, DateTimeKind.Local).AddTicks(955), 15, "Unbranded Granite Towels", "{\"sourceProjects\": [9],\"dateRange\": 1,\"issuesCount\": 833}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { 1, new DateTime(2021, 4, 17, 19, 30, 56, 963, DateTimeKind.Local).AddTicks(4947), 4, 9, "Handcrafted Frozen Salad", "{\"sourceProjects\": [2],\"dateRange\": 1,\"issuesCount\": 143}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { 1, new DateTime(2021, 1, 8, 17, 5, 20, 438, DateTimeKind.Local).AddTicks(7248), 1, 7, "Incredible Soft Gloves", "{\"sourceProjects\": [1],\"dateRange\": 0,\"issuesCount\": 970}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { 1, new DateTime(2020, 8, 13, 1, 50, 19, 881, DateTimeKind.Local).AddTicks(5758), 7, 3, "Incredible Frozen Shoes", "{\"sourceProjects\": [10],\"dateRange\": 1,\"issuesCount\": 457}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { 1, new DateTime(2020, 5, 28, 21, 54, 48, 869, DateTimeKind.Local).AddTicks(9905), 4, 8, "Handcrafted Concrete Gloves", "{\"sourceProjects\": [3],\"dateRange\": 0,\"issuesCount\": 729}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { 1, new DateTime(2021, 5, 2, 8, 5, 22, 785, DateTimeKind.Local).AddTicks(5313), 4, 13, "Fantastic Rubber Pizza", "{\"sourceProjects\": [2],\"dateRange\": 3,\"issuesCount\": 148}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { 1, new DateTime(2020, 9, 5, 19, 45, 52, 907, DateTimeKind.Local).AddTicks(8544), 15, 6, "Practical Steel Fish", "{\"sourceProjects\": [8],\"dateRange\": 3,\"issuesCount\": 69}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Category", "CreatedAt", "DashboardId", "Name", "Settings" },
                values: new object[] { 1, new DateTime(2020, 10, 1, 20, 47, 11, 407, DateTimeKind.Local).AddTicks(3217), 14, "Handcrafted Concrete Chips", "{\"sourceProjects\": [8],\"dateRange\": 3,\"issuesCount\": 60}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { 1, new DateTime(2021, 5, 30, 17, 11, 35, 949, DateTimeKind.Local).AddTicks(990), 15, 7, "Practical Steel Chips", "{\"sourceProjects\": [7],\"dateRange\": 1,\"issuesCount\": 691}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { 1, new DateTime(2020, 9, 14, 21, 41, 30, 380, DateTimeKind.Local).AddTicks(9745), 15, 1, "Rustic Plastic Mouse", "{\"sourceProjects\": [10],\"dateRange\": 4,\"issuesCount\": 969}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { 1, new DateTime(2020, 6, 17, 19, 56, 31, 89, DateTimeKind.Local).AddTicks(8581), 4, 15, "Handmade Fresh Towels", "{\"sourceProjects\": [10],\"dateRange\": 1,\"issuesCount\": 725}" });

            migrationBuilder.InsertData(
                table: "Tiles",
                columns: new[] { "Id", "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[,]
                {
                    { 34, 1, new DateTime(2021, 5, 7, 20, 6, 35, 585, DateTimeKind.Local).AddTicks(2442), 11, 9, "Small Fresh Salad", "{\"sourceProjects\": [6],\"dateRange\": 2,\"issuesCount\": 735}", 0 },
                    { 33, 1, new DateTime(2020, 12, 13, 15, 45, 38, 401, DateTimeKind.Local).AddTicks(5188), 12, 4, "Incredible Rubber Towels", "{\"sourceProjects\": [7],\"dateRange\": 2,\"issuesCount\": 440}", 0 },
                    { 32, 1, new DateTime(2020, 6, 25, 15, 5, 15, 593, DateTimeKind.Local).AddTicks(1691), 10, 5, "Tasty Steel Chips", "{\"sourceProjects\": [8],\"dateRange\": 0,\"issuesCount\": 67}", 0 },
                    { 31, 1, new DateTime(2020, 7, 17, 16, 38, 11, 109, DateTimeKind.Local).AddTicks(2130), 5, 10, "Rustic Metal Car", "{\"sourceProjects\": [7],\"dateRange\": 1,\"issuesCount\": 202}", 0 },
                    { 30, 1, new DateTime(2020, 8, 3, 8, 3, 8, 603, DateTimeKind.Local).AddTicks(6253), 19, 4, "Handcrafted Wooden Keyboard", "{\"sourceProjects\": [6],\"dateRange\": 0,\"issuesCount\": 784}", 0 },
                    { 29, 1, new DateTime(2019, 9, 10, 9, 14, 50, 399, DateTimeKind.Local).AddTicks(2348), 17, 9, "Rustic Wooden Ball", "{\"sourceProjects\": [5],\"dateRange\": 1,\"issuesCount\": 626}", 0 },
                    { 28, 1, new DateTime(2020, 9, 15, 3, 3, 44, 321, DateTimeKind.Local).AddTicks(7615), 11, 12, "Handcrafted Granite Bacon", "{\"sourceProjects\": [10],\"dateRange\": 1,\"issuesCount\": 461}", 0 },
                    { 27, 1, new DateTime(2021, 7, 26, 23, 1, 59, 628, DateTimeKind.Local).AddTicks(8686), 6, 1, "Generic Soft Shirt", "{\"sourceProjects\": [10],\"dateRange\": 4,\"issuesCount\": 737}", 0 },
                    { 35, 1, new DateTime(2021, 4, 29, 6, 23, 17, 341, DateTimeKind.Local).AddTicks(2360), 13, 3, "Incredible Plastic Computer", "{\"sourceProjects\": [9],\"dateRange\": 2,\"issuesCount\": 866}", 0 },
                    { 26, 1, new DateTime(2021, 7, 16, 14, 50, 54, 482, DateTimeKind.Local).AddTicks(2126), 9, 11, "Handmade Plastic Shirt", "{\"sourceProjects\": [4],\"dateRange\": 3,\"issuesCount\": 790}", 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Tiles");

            migrationBuilder.DropColumn(
                name: "Settings",
                table: "Tiles");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Tiles");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tiles",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name" },
                values: new object[] { new DateTime(2019, 8, 24, 19, 56, 57, 207, DateTimeKind.Unspecified).AddTicks(5964), 14, 13, "explicabo" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name" },
                values: new object[] { new DateTime(2021, 2, 5, 6, 31, 9, 575, DateTimeKind.Unspecified).AddTicks(2253), 5, 6, "et" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name" },
                values: new object[] { new DateTime(2019, 8, 24, 2, 50, 19, 608, DateTimeKind.Unspecified).AddTicks(3027), 20, 8, "nulla" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "DashboardId", "Name" },
                values: new object[] { new DateTime(2020, 2, 21, 3, 45, 34, 720, DateTimeKind.Unspecified).AddTicks(8399), 15, "est" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name" },
                values: new object[] { new DateTime(2019, 8, 5, 23, 45, 48, 298, DateTimeKind.Unspecified).AddTicks(8056), 10, 8, "doloribus" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name" },
                values: new object[] { new DateTime(2020, 3, 22, 0, 4, 45, 919, DateTimeKind.Unspecified).AddTicks(3908), 12, 14, "et" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name" },
                values: new object[] { new DateTime(2020, 11, 22, 21, 23, 48, 733, DateTimeKind.Unspecified).AddTicks(9480), 20, 2, "qui" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name" },
                values: new object[] { new DateTime(2021, 6, 2, 10, 46, 7, 850, DateTimeKind.Unspecified).AddTicks(6927), 8, 14, "et" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name" },
                values: new object[] { new DateTime(2021, 5, 7, 18, 59, 13, 655, DateTimeKind.Unspecified).AddTicks(9528), 18, 5, "totam" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name" },
                values: new object[] { new DateTime(2021, 1, 23, 5, 49, 51, 384, DateTimeKind.Unspecified).AddTicks(794), 20, 1, "quas" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name" },
                values: new object[] { new DateTime(2020, 9, 1, 12, 11, 57, 170, DateTimeKind.Unspecified).AddTicks(2604), 4, 11, "placeat" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name" },
                values: new object[] { new DateTime(2020, 4, 6, 2, 33, 56, 395, DateTimeKind.Unspecified).AddTicks(7716), 10, 11, "beatae" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name" },
                values: new object[] { new DateTime(2019, 7, 25, 21, 17, 2, 688, DateTimeKind.Unspecified).AddTicks(6748), 7, 2, "similique" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name" },
                values: new object[] { new DateTime(2021, 2, 9, 17, 55, 34, 126, DateTimeKind.Unspecified).AddTicks(4772), 19, 1, "sint" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "CreatedBy", "Name" },
                values: new object[] { new DateTime(2021, 4, 17, 15, 59, 57, 251, DateTimeKind.Unspecified).AddTicks(3258), 3, "quaerat" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name" },
                values: new object[] { new DateTime(2019, 9, 11, 17, 20, 24, 304, DateTimeKind.Unspecified).AddTicks(4056), 7, 14, "consequatur" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name" },
                values: new object[] { new DateTime(2020, 11, 5, 17, 32, 45, 18, DateTimeKind.Unspecified).AddTicks(7950), 10, 14, "consequuntur" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name" },
                values: new object[] { new DateTime(2019, 8, 17, 3, 34, 59, 276, DateTimeKind.Unspecified).AddTicks(8512), 5, 1, "et" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name" },
                values: new object[] { new DateTime(2020, 6, 23, 7, 29, 11, 206, DateTimeKind.Unspecified).AddTicks(8352), 5, 4, "ut" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name" },
                values: new object[] { new DateTime(2021, 5, 1, 12, 45, 22, 202, DateTimeKind.Unspecified).AddTicks(5966), 12, 3, "quo" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name" },
                values: new object[] { new DateTime(2019, 11, 8, 11, 46, 14, 149, DateTimeKind.Unspecified).AddTicks(9025), 16, 5, "rerum" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "DashboardId", "Name" },
                values: new object[] { new DateTime(2020, 9, 24, 0, 42, 48, 413, DateTimeKind.Unspecified).AddTicks(3080), 6, "similique" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name" },
                values: new object[] { new DateTime(2020, 8, 9, 10, 30, 58, 62, DateTimeKind.Unspecified).AddTicks(3863), 17, 11, "iure" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name" },
                values: new object[] { new DateTime(2019, 11, 16, 22, 4, 38, 925, DateTimeKind.Unspecified).AddTicks(8090), 18, 13, "eveniet" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name" },
                values: new object[] { new DateTime(2021, 3, 28, 8, 14, 13, 190, DateTimeKind.Unspecified).AddTicks(2898), 7, 4, "ea" });
        }
    }
}
