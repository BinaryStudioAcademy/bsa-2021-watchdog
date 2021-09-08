using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Watchdog.Core.DAL.Migrations
{
    public partial class TrelloIntegration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TrelloUserId",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrelloBoard",
                table: "Organizations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TrelloIntegration",
                table: "Organizations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "TrelloToken",
                table: "Organizations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy", "Settings", "Type" },
                values: new object[] { new DateTime(2021, 2, 5, 6, 31, 9, 575, DateTimeKind.Unspecified).AddTicks(2253), 5, "{\"sourceProjects\": [13],\"dateRange\": 2,\"issuesCount\": 989}", 1 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 3, new DateTime(2020, 8, 5, 2, 47, 40, 758, DateTimeKind.Unspecified).AddTicks(3093), 11, 2, "Tasty Metal Chips", "{\"sourceProjects\": [15],\"dateRange\": 1,\"issuesCount\": 875}", 4 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 1, new DateTime(2019, 9, 17, 9, 26, 17, 51, DateTimeKind.Unspecified).AddTicks(4095), 19, 2, "Awesome Metal Bacon", "{\"sourceProjects\": [6],\"dateRange\": 0,\"issuesCount\": 468}", 5 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { new DateTime(2021, 1, 23, 5, 49, 51, 384, DateTimeKind.Unspecified).AddTicks(794), 20, 8, "Incredible Fresh Computer", "{\"sourceProjects\": [12],\"dateRange\": 3,\"issuesCount\": 161}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 2, new DateTime(2020, 11, 6, 22, 21, 30, 488, DateTimeKind.Unspecified).AddTicks(6993), 2, 8, "Practical Steel Fish", "{\"sourceProjects\": [15],\"dateRange\": 4,\"issuesCount\": 59}", 3 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Category", "CreatedAt", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 1, new DateTime(2020, 10, 24, 13, 17, 40, 233, DateTimeKind.Unspecified).AddTicks(833), 1, "Unbranded Concrete Ball", "{\"sourceProjects\": [14],\"dateRange\": 1,\"issuesCount\": 927}", 0 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Category", "DashboardId", "Name", "Type" },
                values: new object[] { 1, 6, "Rustic Frozen Shoes", 0 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 8,
                column: "Type",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 9,
                column: "Type",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "Settings", "Type" },
                values: new object[] { 0, new DateTime(2020, 6, 14, 8, 25, 38, 791, DateTimeKind.Unspecified).AddTicks(7213), 12, "{\"sourceProjects\": [14],\"dateRange\": 1,\"issuesCount\": 454}", 1 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Category", "DashboardId", "Name", "Type" },
                values: new object[] { 1, 8, "Handcrafted Fresh Pants", 0 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 13,
                column: "Type",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 14,
                column: "Type",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 15,
                column: "Type",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "Settings", "Type" },
                values: new object[] { 0, new DateTime(2021, 7, 6, 14, 27, 55, 762, DateTimeKind.Unspecified).AddTicks(9056), 6, "{\"sourceProjects\": [3],\"dateRange\": 4,\"issuesCount\": 299}", 1 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { new DateTime(2021, 2, 14, 6, 35, 44, 499, DateTimeKind.Unspecified).AddTicks(5842), 20, 13, "Tasty Granite Mouse", "{\"sourceProjects\": [7],\"dateRange\": 3,\"issuesCount\": 189}", 1 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { new DateTime(2020, 2, 3, 8, 9, 15, 889, DateTimeKind.Unspecified).AddTicks(3474), 1, 3, "Incredible Granite Fish", "{\"sourceProjects\": [6],\"dateRange\": 2,\"issuesCount\": 842}", 3 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { new DateTime(2021, 4, 2, 23, 28, 22, 667, DateTimeKind.Unspecified).AddTicks(2205), 16, 3, "Refined Fresh Keyboard", "{\"sourceProjects\": [7],\"dateRange\": 0,\"issuesCount\": 736}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 2, new DateTime(2020, 3, 29, 0, 25, 25, 307, DateTimeKind.Unspecified).AddTicks(1971), 2, 7, "Fantastic Granite Fish", "{\"sourceProjects\": [4],\"dateRange\": 4,\"issuesCount\": 915}", 4 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 0, new DateTime(2021, 7, 4, 20, 11, 23, 476, DateTimeKind.Unspecified).AddTicks(5251), 9, 12, "Practical Wooden Table", "{\"sourceProjects\": [15],\"dateRange\": 2,\"issuesCount\": 612}", 4 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 0, new DateTime(2021, 3, 7, 5, 24, 55, 526, DateTimeKind.Unspecified).AddTicks(7729), 8, 5, "Handmade Wooden Tuna", "{\"sourceProjects\": [1],\"dateRange\": 0,\"issuesCount\": 701}", 4 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "CreatedBy", "Name", "Settings", "Type" },
                values: new object[] { new DateTime(2019, 8, 3, 2, 46, 46, 784, DateTimeKind.Unspecified).AddTicks(8342), 12, "Practical Frozen Chips", "{\"sourceProjects\": [2],\"dateRange\": 0,\"issuesCount\": 576}", 4 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { 1, new DateTime(2020, 2, 6, 1, 52, 12, 469, DateTimeKind.Unspecified).AddTicks(9031), 15, 11, "Unbranded Cotton Fish", "{\"sourceProjects\": [7],\"dateRange\": 0,\"issuesCount\": 324}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { 0, new DateTime(2020, 12, 19, 9, 39, 21, 739, DateTimeKind.Unspecified).AddTicks(2478), 18, 13, "Licensed Soft Tuna", "{\"sourceProjects\": [1],\"dateRange\": 4,\"issuesCount\": 885}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 1, new DateTime(2020, 8, 22, 16, 14, 47, 189, DateTimeKind.Unspecified).AddTicks(4885), 11, 13, "Handmade Metal Shoes", "{\"sourceProjects\": [15],\"dateRange\": 1,\"issuesCount\": 461}", 4 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Category", "CreatedAt", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 3, new DateTime(2020, 8, 6, 14, 43, 33, 852, DateTimeKind.Unspecified).AddTicks(2052), 9, "Rustic Wooden Ball", "{\"sourceProjects\": [6],\"dateRange\": 3,\"issuesCount\": 664}", 5 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 2, new DateTime(2021, 5, 19, 21, 3, 11, 683, DateTimeKind.Unspecified).AddTicks(2040), 12, 5, "Rustic Wooden Mouse", "{\"sourceProjects\": [12],\"dateRange\": 0,\"issuesCount\": 663}", 5 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 2, new DateTime(2021, 2, 22, 11, 43, 52, 743, DateTimeKind.Unspecified).AddTicks(1458), 8, 4, "Small Metal Car", "{\"sourceProjects\": [15],\"dateRange\": 0,\"issuesCount\": 987}", 3 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 0, new DateTime(2020, 11, 20, 11, 13, 28, 472, DateTimeKind.Unspecified).AddTicks(2916), 2, 9, "Incredible Rubber Shoes", "{\"sourceProjects\": [9],\"dateRange\": 2,\"issuesCount\": 259}", 4 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { new DateTime(2019, 9, 29, 15, 9, 15, 919, DateTimeKind.Unspecified).AddTicks(8425), 1, 10, "Ergonomic Rubber Gloves", "{\"sourceProjects\": [14],\"dateRange\": 2,\"issuesCount\": 333}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { new DateTime(2021, 5, 2, 18, 35, 52, 973, DateTimeKind.Unspecified).AddTicks(9096), 7, 9, "Sleek Wooden Soap", "{\"sourceProjects\": [3],\"dateRange\": 3,\"issuesCount\": 616}", 4 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 2, new DateTime(2021, 7, 7, 11, 9, 59, 419, DateTimeKind.Unspecified).AddTicks(701), 11, 13, "Rustic Fresh Soap", "{\"sourceProjects\": [7],\"dateRange\": 2,\"issuesCount\": 90}", 2 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 0, new DateTime(2021, 3, 2, 18, 49, 44, 487, DateTimeKind.Unspecified).AddTicks(7261), 19, 14, "Licensed Rubber Shoes", "{\"sourceProjects\": [1],\"dateRange\": 0,\"issuesCount\": 434}", 5 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { new DateTime(2021, 7, 13, 17, 1, 54, 991, DateTimeKind.Unspecified).AddTicks(3313), 16, 15, "Tasty Wooden Gloves", "{\"sourceProjects\": [7],\"dateRange\": 2,\"issuesCount\": 584}", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrelloUserId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TrelloBoard",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "TrelloIntegration",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "TrelloToken",
                table: "Organizations");

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy", "Settings", "Type" },
                values: new object[] { new DateTime(2021, 1, 24, 13, 24, 26, 487, DateTimeKind.Unspecified).AddTicks(9308), 7, "{\"sourceProjects\": [4],\"dateRange\": 4,\"issuesCount\": 489}", 0 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 1, new DateTime(2019, 7, 28, 3, 45, 40, 704, DateTimeKind.Unspecified).AddTicks(7543), 15, 15, "Tasty Frozen Tuna", "{\"sourceProjects\": [8],\"dateRange\": 2,\"issuesCount\": 977}", 0 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 0, new DateTime(2020, 11, 22, 21, 23, 48, 733, DateTimeKind.Unspecified).AddTicks(9480), 20, 10, "Gorgeous Fresh Towels", "{\"sourceProjects\": [14],\"dateRange\": 4,\"issuesCount\": 361}", 3 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { new DateTime(2021, 6, 30, 0, 10, 41, 427, DateTimeKind.Unspecified).AddTicks(9032), 11, 14, "Ergonomic Granite Gloves", "{\"sourceProjects\": [15],\"dateRange\": 1,\"issuesCount\": 751}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 1, new DateTime(2020, 5, 31, 14, 22, 36, 601, DateTimeKind.Unspecified).AddTicks(4903), 13, 2, "Handmade Wooden Table", "{\"sourceProjects\": [2],\"dateRange\": 1,\"issuesCount\": 992}", 2 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Category", "CreatedAt", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 0, new DateTime(2021, 4, 17, 15, 59, 57, 251, DateTimeKind.Unspecified).AddTicks(3258), 4, "Unbranded Steel Salad", "{\"sourceProjects\": [6],\"dateRange\": 4,\"issuesCount\": 305}", 1 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Category", "DashboardId", "Name", "Type" },
                values: new object[] { 0, 8, "Unbranded Wooden Sausages", 1 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 8,
                column: "Type",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 9,
                column: "Type",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "Settings", "Type" },
                values: new object[] { 1, new DateTime(2020, 5, 23, 14, 14, 5, 360, DateTimeKind.Unspecified).AddTicks(6501), 3, "{\"sourceProjects\": [9],\"dateRange\": 4,\"issuesCount\": 388}", 0 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Category", "DashboardId", "Name", "Type" },
                values: new object[] { 0, 6, "Practical Metal Bacon", 2 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 13,
                column: "Type",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 14,
                column: "Type",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 15,
                column: "Type",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "Settings", "Type" },
                values: new object[] { 1, new DateTime(2020, 12, 16, 6, 16, 23, 306, DateTimeKind.Unspecified).AddTicks(5257), 1, "{\"sourceProjects\": [1],\"dateRange\": 0,\"issuesCount\": 970}", 0 });

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
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { new DateTime(2020, 12, 31, 10, 4, 59, 830, DateTimeKind.Unspecified).AddTicks(6), 13, 11, "Intelligent Plastic Hat", "{\"sourceProjects\": [1],\"dateRange\": 3,\"issuesCount\": 358}", 0 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { new DateTime(2021, 4, 12, 0, 15, 19, 181, DateTimeKind.Unspecified).AddTicks(4159), 3, 13, "Awesome Fresh Bacon", "{\"sourceProjects\": [12],\"dateRange\": 0,\"issuesCount\": 426}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 1, new DateTime(2020, 2, 19, 6, 8, 23, 542, DateTimeKind.Unspecified).AddTicks(9640), 15, 9, "Small Soft Shirt", "{\"sourceProjects\": [2],\"dateRange\": 3,\"issuesCount\": 207}", 2 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 3, new DateTime(2021, 6, 6, 18, 57, 44, 606, DateTimeKind.Unspecified).AddTicks(5866), 15, 3, "Tasty Frozen Table", "{\"sourceProjects\": [7],\"dateRange\": 0,\"issuesCount\": 970}", 1 });

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
                columns: new[] { "CreatedAt", "CreatedBy", "Name", "Settings", "Type" },
                values: new object[] { new DateTime(2019, 10, 1, 7, 27, 50, 470, DateTimeKind.Unspecified).AddTicks(5602), 15, "Small Metal Table", "{\"sourceProjects\": [9],\"dateRange\": 4,\"issuesCount\": 75}", 3 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { 2, new DateTime(2020, 9, 28, 16, 20, 10, 300, DateTimeKind.Unspecified).AddTicks(9930), 7, 6, "Rustic Rubber Sausages", "{\"sourceProjects\": [11],\"dateRange\": 3,\"issuesCount\": 405}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { 3, new DateTime(2021, 7, 8, 2, 51, 5, 17, DateTimeKind.Unspecified).AddTicks(3906), 8, 12, "Small Plastic Cheese", "{\"sourceProjects\": [14],\"dateRange\": 1,\"issuesCount\": 23}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 3, new DateTime(2020, 11, 12, 18, 33, 40, 796, DateTimeKind.Unspecified).AddTicks(2720), 16, 11, "Unbranded Fresh Fish", "{\"sourceProjects\": [8],\"dateRange\": 2,\"issuesCount\": 989}", 1 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Category", "CreatedAt", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 2, new DateTime(2019, 11, 20, 19, 50, 22, 837, DateTimeKind.Unspecified).AddTicks(4963), 3, "Incredible Granite Mouse", "{\"sourceProjects\": [15],\"dateRange\": 2,\"issuesCount\": 341}", 1 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 1, new DateTime(2019, 9, 30, 9, 34, 14, 657, DateTimeKind.Unspecified).AddTicks(4291), 7, 3, "Generic Metal Keyboard", "{\"sourceProjects\": [8],\"dateRange\": 2,\"issuesCount\": 84}", 0 });

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
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 1, new DateTime(2019, 12, 14, 18, 56, 10, 249, DateTimeKind.Unspecified).AddTicks(1422), 12, 5, "Tasty Steel Chips", "{\"sourceProjects\": [1],\"dateRange\": 0,\"issuesCount\": 331}", 2 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { new DateTime(2020, 9, 5, 12, 35, 14, 356, DateTimeKind.Unspecified).AddTicks(2051), 13, 2, "Awesome Rubber Ball", "{\"sourceProjects\": [7],\"dateRange\": 0,\"issuesCount\": 903}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { new DateTime(2020, 6, 15, 20, 44, 8, 588, DateTimeKind.Unspecified).AddTicks(3777), 12, 8, "Unbranded Rubber Gloves", "{\"sourceProjects\": [12],\"dateRange\": 1,\"issuesCount\": 322}", 0 });

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
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 1, new DateTime(2020, 5, 17, 2, 10, 20, 689, DateTimeKind.Unspecified).AddTicks(3480), 16, 9, "Sleek Steel Table", "{\"sourceProjects\": [8],\"dateRange\": 4,\"issuesCount\": 932}", 0 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { new DateTime(2019, 7, 29, 14, 57, 56, 6, DateTimeKind.Unspecified).AddTicks(4108), 9, 1, "Intelligent Frozen Mouse", "{\"sourceProjects\": [2],\"dateRange\": 1,\"issuesCount\": 973}", 0 });
        }
    }
}
