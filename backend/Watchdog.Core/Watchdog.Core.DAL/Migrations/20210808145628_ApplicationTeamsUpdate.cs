using Microsoft.EntityFrameworkCore.Migrations;

namespace Watchdog.Core.DAL.Migrations
{
    public partial class ApplicationTeamsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFavorite",
                table: "ApplicationTeams",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Quia dolores minus iusto delectus numquam ipsa vel aliquam quos. Sed ullam est. Ut et nihil nihil voluptatem neque. Occaecati voluptas perferendis impedit qui. Iusto ducimus sed qui quo consequatur eum doloremque sint. Eligendi minus minima molestiae voluptatem.");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Velit officia voluptas rem voluptatem itaque ut ipsam quisquam. Aut reiciendis delectus quam quaerat qui ipsum autem consequatur. Reiciendis optio nostrum vero vel aliquid architecto minus eligendi officiis. Doloremque consequatur rerum vel. Omnis qui quis.");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Dolorem sed et vero ab hic recusandae. Voluptates odit unde molestias iste voluptas. Ullam maiores explicabo quibusdam eos labore dolorum. Cupiditate rerum ut sit id qui ut omnis sunt. Iure sequi culpa quae alias.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFavorite",
                table: "ApplicationTeams");

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
