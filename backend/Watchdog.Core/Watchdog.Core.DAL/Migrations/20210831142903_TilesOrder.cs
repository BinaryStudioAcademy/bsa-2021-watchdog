using Microsoft.EntityFrameworkCore.Migrations;

namespace Watchdog.Core.DAL.Migrations
{
    public partial class TilesOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TileOrder",
                table: "Tiles",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.Sql("DECLARE @counter int Declare @dashId int DECLARE TileCursor Cursor for select Id from Dashboards Open TileCursor " +
                "Fetch next from TileCursor into @dashId While @@FETCH_STATUS = 0 Begin SET @counter = 0 Update Tiles set @counter = TileOrder = @counter + 1     Where DashboardId = @dashId " +
                "Fetch next from TileCursor into @dashId End close TileCursor Deallocate TileCursor");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TileOrder",
                table: "Tiles");
        }
    }
}
