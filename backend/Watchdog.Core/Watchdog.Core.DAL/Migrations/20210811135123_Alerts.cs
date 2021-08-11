using Microsoft.EntityFrameworkCore.Migrations;

namespace Watchdog.Core.DAL.Migrations
{
    public partial class Alerts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AlertSettings",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Velit et quis non impedit saepe rerum aut. Et nemo sit recusandae officia et ut repudiandae doloremque maxime. Ullam adipisci aliquid. Sed magni error. Vel modi laudantium sed laboriosam quia.");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Deleniti voluptatem adipisci. Dicta tenetur nemo. Quo vel aut sed. Voluptas ipsa quia impedit optio voluptas consequatur sunt sit qui. Sit rem adipisci est laboriosam odit soluta.");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Accusantium veritatis deserunt fugiat quisquam sint ut necessitatibus qui voluptas. Voluptatem dignissimos cupiditate ab sit aliquam quos rerum pariatur. Rem ratione officia et optio et omnis. Accusamus id cumque ut ratione molestiae cumque. Autem maiores dolor voluptatibus fugit et. Voluptates iste rerum.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlertSettings",
                table: "Applications");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Dolorem aut incidunt repellendus qui rerum. Iusto at sapiente ut commodi officia. Iste totam molestiae reiciendis qui. Perspiciatis saepe veniam voluptatum animi doloribus. In facilis sint autem.");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Ut asperiores numquam officia nemo debitis qui aspernatur quibusdam in. Blanditiis voluptatem ea. Et quia ea. Nihil sit fugiat recusandae. Possimus amet fugiat expedita officiis autem laboriosam officia sunt. Et laboriosam laboriosam aut et aspernatur.");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Placeat ipsam enim sit minima. Sed a iusto sequi dolor eum dolorum eos. Reprehenderit eum quia. Quasi tempora consequatur. Molestiae commodi et quod.");
        }
    }
}
