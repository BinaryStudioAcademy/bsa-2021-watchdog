using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Watchdog.Core.DAL.Migrations
{
    public partial class TilesOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TileOrder",
                table: "Tiles",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Type",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 5,
                column: "Type",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "Settings", "Type" },
                values: new object[] { 0, new DateTime(2021, 4, 17, 15, 59, 57, 251, DateTimeKind.Unspecified).AddTicks(3258), 3, "{\"sourceProjects\": [6],\"dateRange\": 4,\"issuesCount\": 305}", 1 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 0, new DateTime(2021, 2, 22, 19, 16, 4, 416, DateTimeKind.Unspecified).AddTicks(1115), 1, 8, "Unbranded Wooden Sausages", "{\"sourceProjects\": [15],\"dateRange\": 2,\"issuesCount\": 235}", 1 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { new DateTime(2020, 11, 25, 15, 41, 47, 336, DateTimeKind.Unspecified).AddTicks(1749), 13, 3, "Intelligent Granite Fish", "{\"sourceProjects\": [12],\"dateRange\": 4,\"issuesCount\": 570}", 2 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 3, new DateTime(2019, 10, 3, 4, 33, 43, 293, DateTimeKind.Unspecified).AddTicks(230), 10, 6, "Fantastic Wooden Shirt", "{\"sourceProjects\": [13],\"dateRange\": 4,\"issuesCount\": 836}", 2 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { new DateTime(2020, 5, 23, 14, 14, 5, 360, DateTimeKind.Unspecified).AddTicks(6501), 3, 3, "Fantastic Concrete Gloves", "{\"sourceProjects\": [9],\"dateRange\": 4,\"issuesCount\": 388}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 0, new DateTime(2021, 7, 4, 6, 51, 35, 932, DateTimeKind.Unspecified).AddTicks(2836), 9, 6, "Practical Metal Bacon", "{\"sourceProjects\": [8],\"dateRange\": 0,\"issuesCount\": 155}", 2 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { new DateTime(2020, 10, 10, 14, 46, 9, 101, DateTimeKind.Unspecified).AddTicks(8963), 20, 12, "Practical Plastic Cheese", "{\"sourceProjects\": [3],\"dateRange\": 3,\"issuesCount\": 65}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 3, new DateTime(2019, 10, 14, 23, 36, 3, 945, DateTimeKind.Unspecified).AddTicks(9097), 9, 2, "Handcrafted Plastic Shirt", "{\"sourceProjects\": [8],\"dateRange\": 3,\"issuesCount\": 213}", 1 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { new DateTime(2020, 2, 9, 3, 23, 13, 179, DateTimeKind.Unspecified).AddTicks(9364), 4, 7, "Tasty Concrete Salad", "{\"sourceProjects\": [1],\"dateRange\": 4,\"issuesCount\": 361}", 2 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 1, new DateTime(2021, 3, 25, 8, 41, 59, 831, DateTimeKind.Unspecified).AddTicks(3010), 4, 14, "Refined Metal Sausages", "{\"sourceProjects\": [3],\"dateRange\": 1,\"issuesCount\": 143}", 2 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { new DateTime(2020, 12, 16, 6, 16, 23, 306, DateTimeKind.Unspecified).AddTicks(5257), 1, 7, "Incredible Soft Gloves", "{\"sourceProjects\": [1],\"dateRange\": 0,\"issuesCount\": 970}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { new DateTime(2019, 8, 23, 15, 4, 1, 807, DateTimeKind.Unspecified).AddTicks(9271), 10, 3, "Incredible Frozen Shoes", "{\"sourceProjects\": [4],\"dateRange\": 2,\"issuesCount\": 706}", 3 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 1, new DateTime(2020, 12, 31, 10, 4, 59, 830, DateTimeKind.Unspecified).AddTicks(6), 13, 11, "Intelligent Plastic Hat", "{\"sourceProjects\": [1],\"dateRange\": 3,\"issuesCount\": 358}", 0 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 1, new DateTime(2021, 4, 12, 0, 15, 19, 181, DateTimeKind.Unspecified).AddTicks(4159), 3, 13, "Awesome Fresh Bacon", "{\"sourceProjects\": [12],\"dateRange\": 0,\"issuesCount\": 426}", 0 });

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
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 1, new DateTime(2021, 3, 16, 16, 2, 36, 334, DateTimeKind.Unspecified).AddTicks(3898), 14, 2, "Practical Rubber Fish", "{\"sourceProjects\": [6],\"dateRange\": 0,\"issuesCount\": 66}", 2 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 3, new DateTime(2019, 10, 1, 7, 27, 50, 470, DateTimeKind.Unspecified).AddTicks(5602), 15, 15, "Small Metal Table", "{\"sourceProjects\": [9],\"dateRange\": 4,\"issuesCount\": 75}", 3 });

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
                values: new object[] { 3, new DateTime(2021, 7, 8, 2, 51, 5, 17, DateTimeKind.Unspecified).AddTicks(3906), 8, 12, "Small Plastic Cheese", "{\"sourceProjects\": [14],\"dateRange\": 1,\"issuesCount\": 23}", 2 });

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
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 2, new DateTime(2019, 11, 20, 19, 50, 22, 837, DateTimeKind.Unspecified).AddTicks(4963), 20, 3, "Incredible Granite Mouse", "{\"sourceProjects\": [15],\"dateRange\": 2,\"issuesCount\": 341}", 1 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { new DateTime(2019, 9, 30, 9, 34, 14, 657, DateTimeKind.Unspecified).AddTicks(4291), 7, 3, "Generic Metal Keyboard", "{\"sourceProjects\": [8],\"dateRange\": 2,\"issuesCount\": 84}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 0, new DateTime(2020, 6, 24, 5, 49, 13, 976, DateTimeKind.Unspecified).AddTicks(9196), 5, 1, "Licensed Wooden Tuna", "{\"sourceProjects\": [10],\"dateRange\": 1,\"issuesCount\": 202}", 2 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { new DateTime(2019, 12, 14, 18, 56, 10, 249, DateTimeKind.Unspecified).AddTicks(1422), 12, 5, "Tasty Steel Chips", "{\"sourceProjects\": [1],\"dateRange\": 0,\"issuesCount\": 331}", 2 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { new DateTime(2020, 9, 5, 12, 35, 14, 356, DateTimeKind.Unspecified).AddTicks(2051), 13, 2, "Awesome Rubber Ball", "{\"sourceProjects\": [7],\"dateRange\": 0,\"issuesCount\": 903}", 2 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { new DateTime(2020, 6, 15, 20, 44, 8, 588, DateTimeKind.Unspecified).AddTicks(3777), 12, 8, "Unbranded Rubber Gloves", "{\"sourceProjects\": [12],\"dateRange\": 1,\"issuesCount\": 322}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 1, new DateTime(2020, 5, 19, 10, 22, 39, 627, DateTimeKind.Unspecified).AddTicks(2702), 17, 10, "Ergonomic Wooden Chicken", "{\"sourceProjects\": [13],\"dateRange\": 1,\"issuesCount\": 714}", 0 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "CreatedBy", "Name", "Settings", "Type" },
                values: new object[] { new DateTime(2020, 5, 17, 2, 10, 20, 689, DateTimeKind.Unspecified).AddTicks(3480), 16, "Sleek Steel Table", "{\"sourceProjects\": [8],\"dateRange\": 4,\"issuesCount\": 932}", 0 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 1, new DateTime(2019, 7, 29, 14, 57, 56, 6, DateTimeKind.Unspecified).AddTicks(4108), 9, 1, "Intelligent Frozen Mouse", "{\"sourceProjects\": [2],\"dateRange\": 1,\"issuesCount\": 973}", 0 });

            migrationBuilder.Sql("DECLARE @counter int Declare @dashId int DECLARE TileCursor Cursor for select Id from Dashboards Open TileCursor " +
            "Fetch next from TileCursor into @dashId While @@FETCH_STATUS = 0 Begin SET @counter = 0 Update Tiles set @counter = TileOrder = @counter + 1     Where DashboardId = @dashId " +
            "Fetch next from TileCursor into @dashId End close TileCursor Deallocate TileCursor");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TileOrder",
                table: "Tiles");

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
                keyValue: 6,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "Settings", "Type" },
                values: new object[] { 1, new DateTime(2021, 4, 15, 19, 36, 58, 134, DateTimeKind.Unspecified).AddTicks(8802), 1, "{\"sourceProjects\": [2],\"dateRange\": 1,\"issuesCount\": 915}", 0 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 1, new DateTime(2021, 6, 2, 12, 19, 51, 35, DateTimeKind.Unspecified).AddTicks(1215), 8, 14, "Incredible Frozen Keyboard", "{\"sourceProjects\": [1],\"dateRange\": 1,\"issuesCount\": 962}", 0 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { new DateTime(2021, 5, 1, 12, 45, 22, 202, DateTimeKind.Unspecified).AddTicks(5966), 12, 9, "Awesome Concrete Bike", "{\"sourceProjects\": [10],\"dateRange\": 1,\"issuesCount\": 761}", 1 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 1, new DateTime(2020, 3, 10, 21, 33, 41, 933, DateTimeKind.Unspecified).AddTicks(2252), 8, 3, "Refined Rubber Pants", "{\"sourceProjects\": [13],\"dateRange\": 2,\"issuesCount\": 898}", 0 });

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
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { new DateTime(2019, 12, 30, 21, 8, 59, 766, DateTimeKind.Unspecified).AddTicks(5706), 16, 7, "Sleek Steel Keyboard", "{\"sourceProjects\": [2],\"dateRange\": 4,\"issuesCount\": 387}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 1, new DateTime(2021, 4, 14, 18, 14, 18, 70, DateTimeKind.Unspecified).AddTicks(9748), 8, 11, "Intelligent Soft Car", "{\"sourceProjects\": [8],\"dateRange\": 4,\"issuesCount\": 429}", 0 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { new DateTime(2020, 8, 14, 7, 49, 57, 778, DateTimeKind.Unspecified).AddTicks(8714), 19, 4, "Refined Granite Fish", "{\"sourceProjects\": [9],\"dateRange\": 0,\"issuesCount\": 174}", 1 });

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
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { new DateTime(2020, 8, 1, 23, 56, 22, 709, DateTimeKind.Unspecified).AddTicks(4062), 19, 15, "Incredible Steel Keyboard", "{\"sourceProjects\": [3],\"dateRange\": 4,\"issuesCount\": 312}", 0 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 0, new DateTime(2020, 6, 30, 9, 29, 19, 969, DateTimeKind.Unspecified).AddTicks(1461), 7, 7, "Sleek Frozen Bike", "{\"sourceProjects\": [11],\"dateRange\": 0,\"issuesCount\": 603}", 1 });

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
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 2, new DateTime(2020, 4, 1, 18, 7, 6, 622, DateTimeKind.Unspecified).AddTicks(7415), 3, 7, "Practical Steel Chips", "{\"sourceProjects\": [5],\"dateRange\": 3,\"issuesCount\": 172}", 1 });

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
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 1, new DateTime(2021, 3, 18, 9, 0, 51, 247, DateTimeKind.Unspecified).AddTicks(113), 10, 15, "Incredible Granite Table", "{\"sourceProjects\": [3],\"dateRange\": 1,\"issuesCount\": 591}", 0 });

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
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 1, new DateTime(2021, 4, 17, 5, 10, 7, 178, DateTimeKind.Unspecified).AddTicks(6237), 16, 9, "Incredible Fresh Hat", "{\"sourceProjects\": [10],\"dateRange\": 0,\"issuesCount\": 660}", 0 });

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
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { new DateTime(2020, 11, 20, 11, 13, 28, 472, DateTimeKind.Unspecified).AddTicks(2916), 2, 12, "Generic Granite Towels", "{\"sourceProjects\": [9],\"dateRange\": 2,\"issuesCount\": 259}", 0 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { new DateTime(2021, 7, 11, 16, 54, 8, 255, DateTimeKind.Unspecified).AddTicks(4198), 9, 10, "Ergonomic Rubber Gloves", "{\"sourceProjects\": [14],\"dateRange\": 4,\"issuesCount\": 554}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 2, new DateTime(2020, 11, 26, 18, 11, 33, 480, DateTimeKind.Unspecified).AddTicks(9602), 6, 9, "Incredible Granite Keyboard", "{\"sourceProjects\": [2],\"dateRange\": 0,\"issuesCount\": 675}", 1 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "CreatedBy", "Name", "Settings", "Type" },
                values: new object[] { new DateTime(2020, 7, 18, 0, 34, 38, 543, DateTimeKind.Unspecified).AddTicks(620), 15, "Generic Wooden Pizza", "{\"sourceProjects\": [1],\"dateRange\": 2,\"issuesCount\": 581}", 1 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 3, new DateTime(2019, 9, 10, 11, 8, 14, 739, DateTimeKind.Unspecified).AddTicks(4528), 5, 8, "Ergonomic Soft Soap", "{\"sourceProjects\": [3],\"dateRange\": 0,\"issuesCount\": 144}", 1 });

        }
    }
}
