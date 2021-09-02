using Microsoft.EntityFrameworkCore.Migrations;

namespace Watchdog.Core.DAL.Migrations
{
    public partial class ModifyPropertiesIsApprovedOfMembers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Members",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.Sql("Update Members Set IsApproved = 'true';");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Members");
        }
    }
}
