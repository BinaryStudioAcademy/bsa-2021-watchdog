using Microsoft.EntityFrameworkCore.Migrations;

namespace Watchdog.Core.DAL.Migrations
{
    public partial class TeamsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationTeams_Teams_TeamId",
                table: "ApplicationTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Users_CreatedBy",
                table: "Organizations");

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
                value: "Quod est nobis quasi. Deleniti neque et ex. Autem aut minus nam consectetur voluptatum excepturi fugiat sint iusto.");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Quas eum hic praesentium fugiat. Sit rerum qui numquam natus rerum quis aut veniam ad. Voluptates enim quam ipsa totam aspernatur. Iure expedita repellat dolor est aut voluptate maxime. Corrupti odit vero quia quod. Non ipsam quo ratione culpa ducimus repellendus exercitationem.");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Labore ea id neque. Non aperiam minus incidunt architecto dolor. In hic porro aut vel cum aut optio nihil sequi. Voluptatem inventore aut voluptas quia sint enim animi.");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Name",
                table: "Teams",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationTeams_Teams_TeamId",
                table: "ApplicationTeams",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_Users_CreatedBy",
                table: "Organizations",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationTeams_Teams_TeamId",
                table: "ApplicationTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Users_CreatedBy",
                table: "Organizations");

            migrationBuilder.DropIndex(
                name: "IX_Teams_Name",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "IsFavorite",
                table: "ApplicationTeams");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationTeams_Teams_TeamId",
                table: "ApplicationTeams",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_Users_CreatedBy",
                table: "Organizations",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
