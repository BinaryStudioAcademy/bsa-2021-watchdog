using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Watchdog.Core.DAL.Migrations
{
    public partial class NullAppsFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Applications_ApplicationId",
                table: "Issues");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationId",
                table: "Issues",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 1,
                column: "ApiKey",
                value: "5536A932-6C4E-4188-9792-828799E42B01");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 2,
                column: "ApiKey",
                value: "1133612F-95AF-44A3-BF5D-983E0CDE23BC");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 3,
                column: "ApiKey",
                value: "922A46F3-4BE6-44E3-98EC-FA2ED266D1FA");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 4,
                column: "ApiKey",
                value: "2852E95A-0A7B-481E-8B8C-0E8001735C03");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 5,
                column: "ApiKey",
                value: "DD74AC8A-6FB6-4766-97F4-9C0EEC0E3985");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 6,
                column: "ApiKey",
                value: "478DA34D-8C27-4C8B-8B7D-984D3BF091B9");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 7,
                column: "ApiKey",
                value: "F2567440-0FF5-45D0-903B-5ECA94D604BF");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 8,
                column: "ApiKey",
                value: "0C6F4526-9C22-4E5B-8E1C-81AB61B3D73C");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 9,
                column: "ApiKey",
                value: "1E8C84B7-C717-420F-9BB0-B16D81103723");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 10,
                column: "ApiKey",
                value: "CC8D20E9-34C2-417D-A06B-0CFE2E7DC4D6");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 11,
                column: "ApiKey",
                value: "71B693C8-0F57-4BF3-B149-30DC998C4CD2");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 12,
                column: "ApiKey",
                value: "CDF2787C-791A-4A72-96C6-6C0A41237E1D");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 13,
                column: "ApiKey",
                value: "8EA51D03-0C00-451B-BF4C-F61962272FE0");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 14,
                column: "ApiKey",
                value: "6E82D8FE-A61C-4141-9DC2-717B8D441E0F");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 15,
                column: "ApiKey",
                value: "6B30D12A-5B3C-480C-AA0B-67FAAF8FD7CA");

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "Settings", "Type" },
                values: new object[] { 0, new DateTime(2020, 11, 22, 21, 23, 48, 733, DateTimeKind.Unspecified).AddTicks(9480), 20, "{\"sourceProjects\": [14],\"dateRange\": 4,\"issuesCount\": 361}", 1 });

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
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { new DateTime(2020, 5, 31, 14, 22, 36, 601, DateTimeKind.Unspecified).AddTicks(4903), 13, 2, "Handmade Wooden Table", "{\"sourceProjects\": [2],\"dateRange\": 1,\"issuesCount\": 992}", 1 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { new DateTime(2021, 4, 15, 19, 36, 58, 134, DateTimeKind.Unspecified).AddTicks(8802), 1, 4, "Unbranded Steel Salad", "{\"sourceProjects\": [2],\"dateRange\": 1,\"issuesCount\": 915}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "CreatedBy", "Name", "Settings" },
                values: new object[] { new DateTime(2021, 6, 2, 12, 19, 51, 35, DateTimeKind.Unspecified).AddTicks(1215), 8, "Incredible Frozen Keyboard", "{\"sourceProjects\": [1],\"dateRange\": 1,\"issuesCount\": 962}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 0, new DateTime(2021, 5, 1, 12, 45, 22, 202, DateTimeKind.Unspecified).AddTicks(5966), 12, 9, "Awesome Concrete Bike", "{\"sourceProjects\": [10],\"dateRange\": 1,\"issuesCount\": 761}", 1 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "DashboardId", "Name", "Settings" },
                values: new object[] { new DateTime(2020, 3, 10, 21, 33, 41, 933, DateTimeKind.Unspecified).AddTicks(2252), 3, "Refined Rubber Pants", "{\"sourceProjects\": [13],\"dateRange\": 2,\"issuesCount\": 898}" });

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
                columns: new[] { "Category", "CreatedAt", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 3, new DateTime(2020, 7, 15, 13, 23, 17, 330, DateTimeKind.Unspecified).AddTicks(9130), 7, "Awesome Fresh Shirt", "{\"sourceProjects\": [2],\"dateRange\": 2,\"issuesCount\": 22}", 1 });

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
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { new DateTime(2020, 8, 1, 23, 56, 22, 709, DateTimeKind.Unspecified).AddTicks(4062), 19, 15, "Incredible Steel Keyboard", "{\"sourceProjects\": [3],\"dateRange\": 4,\"issuesCount\": 312}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Category", "CreatedAt", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 0, new DateTime(2020, 6, 30, 9, 29, 19, 969, DateTimeKind.Unspecified).AddTicks(1461), 7, "Sleek Frozen Bike", "{\"sourceProjects\": [11],\"dateRange\": 0,\"issuesCount\": 603}", 1 });

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
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { new DateTime(2020, 9, 8, 9, 58, 14, 275, DateTimeKind.Unspecified).AddTicks(889), 3, 15, "Ergonomic Metal Mouse", "{\"sourceProjects\": [12],\"dateRange\": 3,\"issuesCount\": 60}", 1 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Category", "CreatedAt", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 2, new DateTime(2020, 4, 1, 18, 7, 6, 622, DateTimeKind.Unspecified).AddTicks(7415), 7, "Practical Steel Chips", "{\"sourceProjects\": [5],\"dateRange\": 3,\"issuesCount\": 172}", 1 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { new DateTime(2019, 7, 25, 10, 41, 12, 636, DateTimeKind.Unspecified).AddTicks(4419), 19, 1, "Fantastic Concrete Car", "{\"sourceProjects\": [15],\"dateRange\": 3,\"issuesCount\": 900}", 1 });

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
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { new DateTime(2019, 12, 21, 4, 39, 42, 128, DateTimeKind.Unspecified).AddTicks(915), 16, 1, "Handmade Metal Shirt", "{\"sourceProjects\": [10],\"dateRange\": 4,\"issuesCount\": 388}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 3, new DateTime(2020, 3, 9, 7, 33, 33, 356, DateTimeKind.Unspecified).AddTicks(2081), 15, 1, "Small Fresh Ball", "{\"sourceProjects\": [8],\"dateRange\": 4,\"issuesCount\": 765}", 1 });

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
                columns: new[] { "CreatedAt", "CreatedBy", "Name", "Settings" },
                values: new object[] { new DateTime(2021, 4, 17, 5, 10, 7, 178, DateTimeKind.Unspecified).AddTicks(6237), 16, "Incredible Fresh Hat", "{\"sourceProjects\": [10],\"dateRange\": 0,\"issuesCount\": 660}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { new DateTime(2019, 8, 24, 8, 40, 39, 207, DateTimeKind.Unspecified).AddTicks(3970), 5, 10, "Small Concrete Hat", "{\"sourceProjects\": [1],\"dateRange\": 4,\"issuesCount\": 320}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { new DateTime(2020, 11, 20, 11, 13, 28, 472, DateTimeKind.Unspecified).AddTicks(2916), 2, 12, "Generic Granite Towels", "{\"sourceProjects\": [9],\"dateRange\": 2,\"issuesCount\": 259}" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Applications_ApplicationId",
                table: "Issues",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Applications_ApplicationId",
                table: "Issues");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationId",
                table: "Issues",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 1,
                column: "ApiKey",
                value: "AA8D9EB4-513F-4485-AB88-FDA2C7DDBF37");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 2,
                column: "ApiKey",
                value: "FF092079-FF3A-4266-8441-C8F556ADB3C7");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 3,
                column: "ApiKey",
                value: "86649B15-6FC2-42B0-8D46-E8781F57C1C4");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 4,
                column: "ApiKey",
                value: "CF99AE20-2A8F-409E-94ED-56DEC20A1E53");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 5,
                column: "ApiKey",
                value: "3A122FCD-6CFC-4D1F-819C-CDE1926B9F2C");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 6,
                column: "ApiKey",
                value: "78C3EAA4-3DB8-4FFF-A671-604D23669C8E");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 7,
                column: "ApiKey",
                value: "50B066A9-39C4-4684-B02D-1F577E6B243C");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 8,
                column: "ApiKey",
                value: "790B7A91-6D5D-42C8-81A3-7B777DCB4328");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 9,
                column: "ApiKey",
                value: "3752717F-BB9A-4834-AC7A-5B65D596C624");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 10,
                column: "ApiKey",
                value: "03B01E0A-3995-4E96-B6B2-D622C2BD8F19");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 11,
                column: "ApiKey",
                value: "9CD472DA-27D0-447A-BA12-9574F8C7846A");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 12,
                column: "ApiKey",
                value: "B4992B8B-66CB-4D06-A495-E3BDCB957A79");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 13,
                column: "ApiKey",
                value: "D1647082-5A1E-4967-820B-17A08FB07EC4");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 14,
                column: "ApiKey",
                value: "3C04D6F6-34A4-4CAF-80FD-AFF370BD9349");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 15,
                column: "ApiKey",
                value: "78A7753E-88D4-41F6-8895-086808841189");

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "Settings", "Type" },
                values: new object[] { 1, new DateTime(2019, 8, 13, 18, 15, 43, 731, DateTimeKind.Unspecified).AddTicks(9466), 3, "{\"sourceProjects\": [5],\"dateRange\": 4,\"issuesCount\": 919}", 0 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { new DateTime(2020, 7, 17, 8, 29, 30, 304, DateTimeKind.Unspecified).AddTicks(7284), 3, 5, "Fantastic Steel Shoes", "{\"sourceProjects\": [1],\"dateRange\": 4,\"issuesCount\": 244}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { new DateTime(2020, 8, 7, 7, 16, 37, 131, DateTimeKind.Unspecified).AddTicks(7056), 15, 7, "Handmade Metal Keyboard", "{\"sourceProjects\": [10],\"dateRange\": 2,\"issuesCount\": 74}", 0 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { new DateTime(2021, 1, 12, 2, 53, 34, 761, DateTimeKind.Unspecified).AddTicks(966), 5, 1, "Incredible Frozen Sausages", "{\"sourceProjects\": [1],\"dateRange\": 0,\"issuesCount\": 128}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "CreatedBy", "Name", "Settings" },
                values: new object[] { new DateTime(2020, 7, 30, 22, 25, 18, 613, DateTimeKind.Unspecified).AddTicks(4327), 19, "Fantastic Frozen Gloves", "{\"sourceProjects\": [6],\"dateRange\": 0,\"issuesCount\": 19}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 1, new DateTime(2020, 2, 14, 4, 32, 16, 795, DateTimeKind.Unspecified).AddTicks(5642), 11, 4, "Intelligent Frozen Hat", "{\"sourceProjects\": [3],\"dateRange\": 2,\"issuesCount\": 109}", 0 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "DashboardId", "Name", "Settings" },
                values: new object[] { new DateTime(2021, 4, 2, 22, 49, 8, 127, DateTimeKind.Unspecified).AddTicks(6671), 13, "Generic Plastic Cheese", "{\"sourceProjects\": [7],\"dateRange\": 1,\"issuesCount\": 679}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { new DateTime(2020, 9, 27, 13, 14, 53, 135, DateTimeKind.Unspecified).AddTicks(8604), 17, 13, "Refined Granite Salad", "{\"sourceProjects\": [4],\"dateRange\": 1,\"issuesCount\": 156}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Category", "CreatedAt", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 1, new DateTime(2020, 8, 22, 19, 51, 21, 449, DateTimeKind.Unspecified).AddTicks(1277), 9, "Intelligent Wooden Towels", "{\"sourceProjects\": [11],\"dateRange\": 4,\"issuesCount\": 375}", 0 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { new DateTime(2021, 3, 29, 8, 59, 25, 621, DateTimeKind.Unspecified).AddTicks(5252), 1, 1, "Sleek Wooden Table", "{\"sourceProjects\": [7],\"dateRange\": 1,\"issuesCount\": 760}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { new DateTime(2021, 6, 2, 23, 1, 15, 983, DateTimeKind.Unspecified).AddTicks(8282), 15, 6, "Licensed Steel Chips", "{\"sourceProjects\": [11],\"dateRange\": 1,\"issuesCount\": 391}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 1, new DateTime(2020, 1, 22, 1, 27, 41, 975, DateTimeKind.Unspecified).AddTicks(5248), 11, 7, "Rustic Granite Bacon", "{\"sourceProjects\": [4],\"dateRange\": 4,\"issuesCount\": 183}", 0 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 1, new DateTime(2021, 7, 2, 8, 24, 50, 654, DateTimeKind.Unspecified).AddTicks(9073), 15, 1, "Unbranded Granite Towels", "{\"sourceProjects\": [14],\"dateRange\": 1,\"issuesCount\": 833}", 0 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { new DateTime(2021, 3, 25, 8, 41, 59, 831, DateTimeKind.Unspecified).AddTicks(3010), 4, 9, "Handcrafted Frozen Salad", "{\"sourceProjects\": [3],\"dateRange\": 1,\"issuesCount\": 143}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { new DateTime(2020, 12, 16, 6, 16, 23, 306, DateTimeKind.Unspecified).AddTicks(5257), 1, 7, "Incredible Soft Gloves", "{\"sourceProjects\": [1],\"dateRange\": 0,\"issuesCount\": 970}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Category", "CreatedAt", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 1, new DateTime(2020, 7, 20, 15, 1, 22, 749, DateTimeKind.Unspecified).AddTicks(3651), 3, "Incredible Frozen Shoes", "{\"sourceProjects\": [15],\"dateRange\": 1,\"issuesCount\": 457}", 0 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 1, new DateTime(2020, 5, 5, 11, 5, 51, 737, DateTimeKind.Unspecified).AddTicks(7741), 4, 8, "Handcrafted Concrete Gloves", "{\"sourceProjects\": [5],\"dateRange\": 0,\"issuesCount\": 729}", 0 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { new DateTime(2021, 4, 8, 21, 16, 25, 653, DateTimeKind.Unspecified).AddTicks(3094), 4, 13, "Fantastic Rubber Pizza", "{\"sourceProjects\": [3],\"dateRange\": 3,\"issuesCount\": 148}", 0 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { new DateTime(2020, 8, 13, 8, 56, 55, 775, DateTimeKind.Unspecified).AddTicks(6270), 15, 6, "Practical Steel Fish", "{\"sourceProjects\": [11],\"dateRange\": 3,\"issuesCount\": 69}", 0 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Category", "CreatedAt", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 1, new DateTime(2020, 9, 8, 9, 58, 14, 275, DateTimeKind.Unspecified).AddTicks(889), 14, "Handcrafted Concrete Chips", "{\"sourceProjects\": [12],\"dateRange\": 3,\"issuesCount\": 60}", 0 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { new DateTime(2021, 5, 7, 6, 22, 38, 816, DateTimeKind.Unspecified).AddTicks(8609), 15, 7, "Practical Steel Chips", "{\"sourceProjects\": [10],\"dateRange\": 1,\"issuesCount\": 691}", 0 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 1, new DateTime(2020, 8, 22, 10, 52, 33, 248, DateTimeKind.Unspecified).AddTicks(7232), 15, 1, "Rustic Plastic Mouse", "{\"sourceProjects\": [15],\"dateRange\": 4,\"issuesCount\": 969}", 0 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { new DateTime(2020, 5, 25, 9, 7, 33, 957, DateTimeKind.Unspecified).AddTicks(6013), 4, 15, "Handmade Fresh Towels", "{\"sourceProjects\": [14],\"dateRange\": 1,\"issuesCount\": 725}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 1, new DateTime(2021, 6, 23, 4, 1, 57, 349, DateTimeKind.Unspecified).AddTicks(9503), 9, 11, "Handmade Plastic Shirt", "{\"sourceProjects\": [5],\"dateRange\": 3,\"issuesCount\": 790}", 0 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { new DateTime(2021, 7, 3, 12, 13, 2, 496, DateTimeKind.Unspecified).AddTicks(6010), 6, 1, "Generic Soft Shirt", "{\"sourceProjects\": [14],\"dateRange\": 4,\"issuesCount\": 737}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { new DateTime(2020, 8, 22, 16, 14, 47, 189, DateTimeKind.Unspecified).AddTicks(4885), 11, 12, "Handcrafted Granite Bacon", "{\"sourceProjects\": [15],\"dateRange\": 1,\"issuesCount\": 461}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "CreatedBy", "Name", "Settings" },
                values: new object[] { new DateTime(2019, 8, 17, 22, 25, 53, 266, DateTimeKind.Unspecified).AddTicks(9563), 17, "Rustic Wooden Ball", "{\"sourceProjects\": [8],\"dateRange\": 1,\"issuesCount\": 626}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { new DateTime(2020, 7, 10, 21, 14, 11, 471, DateTimeKind.Unspecified).AddTicks(3375), 19, 4, "Handcrafted Wooden Keyboard", "{\"sourceProjects\": [9],\"dateRange\": 0,\"issuesCount\": 784}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { new DateTime(2020, 6, 24, 5, 49, 13, 976, DateTimeKind.Unspecified).AddTicks(9196), 5, 10, "Rustic Metal Car", "{\"sourceProjects\": [10],\"dateRange\": 1,\"issuesCount\": 202}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings" },
                values: new object[] { new DateTime(2020, 6, 2, 4, 16, 18, 460, DateTimeKind.Unspecified).AddTicks(8704), 10, 5, "Tasty Steel Chips", "{\"sourceProjects\": [12],\"dateRange\": 0,\"issuesCount\": 67}" });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 1, new DateTime(2020, 11, 20, 4, 56, 41, 269, DateTimeKind.Unspecified).AddTicks(2147), 12, 4, "Incredible Rubber Towels", "{\"sourceProjects\": [10],\"dateRange\": 2,\"issuesCount\": 440}", 0 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "CreatedAt", "CreatedBy", "Name", "Settings", "Type" },
                values: new object[] { new DateTime(2021, 4, 14, 9, 17, 38, 452, DateTimeKind.Unspecified).AddTicks(9347), 11, "Small Fresh Salad", "{\"sourceProjects\": [9],\"dateRange\": 2,\"issuesCount\": 735}", 0 });

            migrationBuilder.UpdateData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "Category", "CreatedAt", "CreatedBy", "DashboardId", "Name", "Settings", "Type" },
                values: new object[] { 1, new DateTime(2021, 4, 5, 19, 34, 20, 208, DateTimeKind.Unspecified).AddTicks(9212), 13, 3, "Incredible Plastic Computer", "{\"sourceProjects\": [13],\"dateRange\": 2,\"issuesCount\": 866}", 0 });

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Applications_ApplicationId",
                table: "Issues",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
