using Microsoft.EntityFrameworkCore.Migrations;

namespace Watchdog.Core.DAL.Migrations
{
    public partial class IssueUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventMessages_Issues_IssueId",
                table: "EventMessages");

            migrationBuilder.AddColumn<int>(
                name: "EventsCount",
                table: "Issues",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NewestId",
                table: "Issues",
                type: "int",
                nullable: true);

            migrationBuilder.Sql(@"UPDATE Issues SET
                NewestId = 
                    (SELECT TOP(1) Id  
                     FROM EventMessages 
                     WHERE IssueId = Issues.Id 
                     ORDER BY OccurredOn DESC),
                EventsCount = 
                    (SELECT COUNT(*)
                     FROM EventMessages 
                     WHERE IssueId = Issues.Id)");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_NewestId",
                table: "Issues",
                column: "NewestId",
                unique: true,
                filter: "[NewestId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_EventMessages_Issues_IssueId",
                table: "EventMessages",
                column: "IssueId",
                principalTable: "Issues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_EventMessages_NewestId",
                table: "Issues",
                column: "NewestId",
                principalTable: "EventMessages",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventMessages_Issues_IssueId",
                table: "EventMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_Issues_EventMessages_NewestId",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Issues_NewestId",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "EventsCount",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "NewestId",
                table: "Issues");

            migrationBuilder.AddForeignKey(
                name: "FK_EventMessages_Issues_IssueId",
                table: "EventMessages",
                column: "IssueId",
                principalTable: "Issues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
