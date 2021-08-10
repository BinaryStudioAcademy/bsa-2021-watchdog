using Microsoft.EntityFrameworkCore.Migrations;

namespace Watchdog.Core.DAL.Migrations
{
    public partial class UpdateRequiredFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Expedita omnis voluptatem magnam repellat omnis quidem necessitatibus. In hic beatae eius ipsam. At totam alias non ipsa. Inventore nemo velit corporis nulla. Rerum dolor adipisci voluptate dolorem qui. Ipsam et et.");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Quod maxime modi exercitationem atque totam unde ipsum enim voluptatem. Pariatur maiores et at blanditiis animi totam quia. Sequi voluptatem asperiores quo quia asperiores dolor recusandae adipisci repellat. Ab ut sunt consectetur exercitationem ipsa voluptas qui. Possimus cum sunt quos praesentium ut quam sint. Error porro sit soluta voluptatibus.");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Placeat molestias quia quos nobis laborum aut. Dignissimos libero nemo eveniet praesentium. Velit quo est iure amet voluptatum inventore. Magnam omnis sunt ut rerum harum minima. Quis natus voluptas animi unde provident officia. Quae qui nihil omnis quae.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128,
                oldNullable: true);

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
    }
}
