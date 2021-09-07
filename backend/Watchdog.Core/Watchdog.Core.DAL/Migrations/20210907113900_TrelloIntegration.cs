using Microsoft.EntityFrameworkCore.Migrations;

namespace Watchdog.Core.DAL.Migrations
{
    public partial class TrelloIntegration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrelloBoard",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "TrelloIntegration",
                table: "Organizations");
        }
    }
}
