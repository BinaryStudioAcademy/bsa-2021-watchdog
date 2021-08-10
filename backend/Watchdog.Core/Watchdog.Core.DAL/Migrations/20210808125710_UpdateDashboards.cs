using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Watchdog.Core.DAL.Migrations
{
    public partial class UpdateDashboards : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "Dashboards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Dashboards",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy", "Icon", "OrganizationId" },
                values: new object[] { new DateTime(2021, 7, 7, 12, 18, 32, 231, DateTimeKind.Unspecified).AddTicks(2842), 18, "pi-chart-line", 1 });

            migrationBuilder.UpdateData(
                table: "Dashboards",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Icon", "Name", "OrganizationId" },
                values: new object[] { new DateTime(2020, 11, 16, 13, 23, 24, 72, DateTimeKind.Unspecified).AddTicks(4979), "pi-chart-bar", "aliquid", 5 });

            migrationBuilder.UpdateData(
                table: "Dashboards",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy", "Icon", "Name", "OrganizationId" },
                values: new object[] { new DateTime(2020, 6, 25, 3, 54, 40, 463, DateTimeKind.Unspecified).AddTicks(4845), 3, "pi-chart-line", "sit", 5 });

            migrationBuilder.UpdateData(
                table: "Dashboards",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy", "Icon", "Name", "OrganizationId" },
                values: new object[] { new DateTime(2021, 7, 8, 13, 52, 55, 910, DateTimeKind.Unspecified).AddTicks(1221), 19, "pi-chart-bar", "quis", 3 });

            migrationBuilder.UpdateData(
                table: "Dashboards",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedBy", "Icon", "Name", "OrganizationId" },
                values: new object[] { new DateTime(2021, 1, 19, 14, 4, 14, 838, DateTimeKind.Unspecified).AddTicks(7674), 9, "pi-chart-bar", "fugiat", 1 });

            migrationBuilder.UpdateData(
                table: "Dashboards",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "CreatedBy", "Icon", "Name", "OrganizationId" },
                values: new object[] { new DateTime(2021, 1, 26, 12, 10, 12, 919, DateTimeKind.Unspecified).AddTicks(858), 20, "pi-chart-bar", "est", 1 });

            migrationBuilder.UpdateData(
                table: "Dashboards",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "CreatedBy", "Icon", "Name", "OrganizationId" },
                values: new object[] { new DateTime(2021, 4, 3, 16, 37, 56, 229, DateTimeKind.Unspecified).AddTicks(682), 13, "pi-chart-line", "molestias", 5 });

            migrationBuilder.UpdateData(
                table: "Dashboards",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "CreatedBy", "Icon", "Name", "OrganizationId" },
                values: new object[] { new DateTime(2021, 2, 21, 5, 1, 25, 731, DateTimeKind.Unspecified).AddTicks(7636), 9, "pi-chart-bar", "et", 1 });

            migrationBuilder.UpdateData(
                table: "Dashboards",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "CreatedBy", "Icon", "Name", "OrganizationId" },
                values: new object[] { new DateTime(2020, 7, 10, 5, 58, 24, 127, DateTimeKind.Unspecified).AddTicks(2249), 1, "pi-chart-bar", "eum", 2 });

            migrationBuilder.UpdateData(
                table: "Dashboards",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "CreatedBy", "Icon", "Name", "OrganizationId" },
                values: new object[] { new DateTime(2020, 6, 27, 23, 12, 19, 637, DateTimeKind.Unspecified).AddTicks(5211), 1, "pi-chart-line", "quaerat", 2 });

            migrationBuilder.UpdateData(
                table: "Dashboards",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "CreatedBy", "Icon", "Name", "OrganizationId" },
                values: new object[] { new DateTime(2020, 4, 30, 1, 5, 53, 311, DateTimeKind.Unspecified).AddTicks(8922), 9, "pi-chart-line", "fugit", 5 });

            migrationBuilder.UpdateData(
                table: "Dashboards",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "CreatedBy", "Icon", "Name", "OrganizationId" },
                values: new object[] { new DateTime(2020, 9, 23, 15, 54, 42, 918, DateTimeKind.Unspecified).AddTicks(8524), 13, "pi-chart-line", "tenetur", 4 });

            migrationBuilder.UpdateData(
                table: "Dashboards",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "CreatedBy", "Icon", "Name", "OrganizationId" },
                values: new object[] { new DateTime(2019, 11, 21, 20, 24, 3, 447, DateTimeKind.Unspecified).AddTicks(3782), 7, "pi-chart-bar", "ea", 5 });

            migrationBuilder.UpdateData(
                table: "Dashboards",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "CreatedBy", "Icon", "Name", "OrganizationId" },
                values: new object[] { new DateTime(2020, 8, 11, 5, 54, 45, 341, DateTimeKind.Unspecified).AddTicks(45), 20, "pi-chart-line", "adipisci", 2 });

            migrationBuilder.UpdateData(
                table: "Dashboards",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "CreatedBy", "Icon", "Name", "OrganizationId" },
                values: new object[] { new DateTime(2020, 4, 14, 13, 23, 49, 497, DateTimeKind.Unspecified).AddTicks(2242), 15, "pi-chart-bar", "perspiciatis", 5 });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icon",
                table: "Dashboards");

            migrationBuilder.UpdateData(
                table: "Dashboards",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedBy", "OrganizationId" },
                values: new object[] { new DateTime(2019, 10, 12, 6, 42, 6, 525, DateTimeKind.Unspecified).AddTicks(2732), 3, 2 });

            migrationBuilder.UpdateData(
                table: "Dashboards",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Name", "OrganizationId" },
                values: new object[] { new DateTime(2019, 11, 3, 11, 13, 40, 934, DateTimeKind.Unspecified).AddTicks(2638), "sit", 2 });

            migrationBuilder.UpdateData(
                table: "Dashboards",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedBy", "Name", "OrganizationId" },
                values: new object[] { new DateTime(2021, 2, 3, 17, 43, 11, 653, DateTimeKind.Unspecified).AddTicks(4170), 7, "error", 2 });

            migrationBuilder.UpdateData(
                table: "Dashboards",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedBy", "Name", "OrganizationId" },
                values: new object[] { new DateTime(2020, 10, 22, 5, 11, 19, 396, DateTimeKind.Unspecified).AddTicks(4577), 11, "itaque", 1 });

            migrationBuilder.UpdateData(
                table: "Dashboards",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedBy", "Name", "OrganizationId" },
                values: new object[] { new DateTime(2021, 7, 8, 13, 52, 55, 910, DateTimeKind.Unspecified).AddTicks(1221), 19, "voluptatibus", 3 });

            migrationBuilder.UpdateData(
                table: "Dashboards",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "CreatedBy", "Name", "OrganizationId" },
                values: new object[] { new DateTime(2020, 9, 14, 18, 10, 26, 80, DateTimeKind.Unspecified).AddTicks(7223), 4, "fugiat", 5 });

            migrationBuilder.UpdateData(
                table: "Dashboards",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "CreatedBy", "Name", "OrganizationId" },
                values: new object[] { new DateTime(2021, 6, 25, 15, 10, 12, 305, DateTimeKind.Unspecified).AddTicks(8976), 20, "dolore", 4 });

            migrationBuilder.UpdateData(
                table: "Dashboards",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "CreatedBy", "Name", "OrganizationId" },
                values: new object[] { new DateTime(2021, 4, 9, 12, 29, 21, 740, DateTimeKind.Unspecified).AddTicks(5356), 11, "doloribus", 2 });

            migrationBuilder.UpdateData(
                table: "Dashboards",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "CreatedBy", "Name", "OrganizationId" },
                values: new object[] { new DateTime(2021, 6, 2, 21, 59, 55, 122, DateTimeKind.Unspecified).AddTicks(4800), 3, "recusandae", 4 });

            migrationBuilder.UpdateData(
                table: "Dashboards",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "CreatedBy", "Name", "OrganizationId" },
                values: new object[] { new DateTime(2021, 2, 21, 5, 1, 25, 731, DateTimeKind.Unspecified).AddTicks(7636), 9, "dolorem", 1 });

            migrationBuilder.UpdateData(
                table: "Dashboards",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "CreatedBy", "Name", "OrganizationId" },
                values: new object[] { new DateTime(2021, 7, 2, 7, 47, 50, 697, DateTimeKind.Unspecified).AddTicks(4443), 7, "eum", 4 });

            migrationBuilder.UpdateData(
                table: "Dashboards",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "CreatedBy", "Name", "OrganizationId" },
                values: new object[] { new DateTime(2020, 11, 9, 11, 16, 38, 651, DateTimeKind.Unspecified).AddTicks(8274), 9, "excepturi", 2 });

            migrationBuilder.UpdateData(
                table: "Dashboards",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "CreatedBy", "Name", "OrganizationId" },
                values: new object[] { new DateTime(2020, 10, 18, 23, 59, 10, 615, DateTimeKind.Unspecified).AddTicks(7577), 3, "quae", 3 });

            migrationBuilder.UpdateData(
                table: "Dashboards",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "CreatedBy", "Name", "OrganizationId" },
                values: new object[] { new DateTime(2019, 8, 22, 13, 56, 3, 86, DateTimeKind.Unspecified).AddTicks(1337), 13, "saepe", 3 });

            migrationBuilder.UpdateData(
                table: "Dashboards",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "CreatedBy", "Name", "OrganizationId" },
                values: new object[] { new DateTime(2020, 9, 23, 15, 54, 42, 918, DateTimeKind.Unspecified).AddTicks(8524), 13, "aspernatur", 4 });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Quo quas dolorem quisquam culpa. Occaecati est et nemo. Nulla qui sit quaerat error placeat deleniti odit. Ut quam atque iure et blanditiis error impedit velit. Eius aut eveniet ullam molestiae. Similique qui enim fugiat quisquam quo similique ut.");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Voluptatibus amet nihil dolor delectus exercitationem aperiam. Sit quam voluptatem odio. Consequuntur laborum vel adipisci deserunt sunt earum hic. Aliquam et asperiores molestiae dolorem ad doloremque. Pariatur dolores et blanditiis voluptatum autem alias. Ut et assumenda omnis veniam molestias dolorum consequuntur.");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Modi et rerum reiciendis. Dolorem expedita praesentium non dicta. Eaque magni omnis aut molestias similique rerum dolorem sed.");
        }
    }
}
