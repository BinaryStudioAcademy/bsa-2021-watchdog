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
        }
    }
}
