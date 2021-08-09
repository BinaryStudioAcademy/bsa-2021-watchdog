using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Watchdog.Core.DAL.Migrations
{
    public partial class UpdateRegistredAt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisteredAt",
                table: "Users",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Dolorem deleniti est dolorum nihil odio. Ut ab cupiditate aut harum nihil similique occaecati. Fugit numquam numquam autem. Ut accusantium ducimus omnis. Nisi facere vel minima nulla sit voluptatem.");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Tenetur aut autem voluptatem fugit voluptatum facilis. Quam odio necessitatibus amet cumque sapiente quia hic quis. Labore minima vero.");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Eos consequuntur aspernatur necessitatibus officia. Soluta doloribus ipsam nemo veritatis error ut voluptatem veritatis. Ut omnis neque. Aut accusamus reprehenderit rerum autem quaerat sit.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisteredAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

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
    }
}
