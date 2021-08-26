using Microsoft.EntityFrameworkCore.Migrations;

namespace Watchdog.Core.DAL.Migrations
{
    public partial class AddApiKeyForApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApiKey",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 1,
                column: "ApiKey",
                value: "7780B80F-5FD6-4BE0-B0B8-D66CE988DB9D");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 2,
                column: "ApiKey",
                value: "AFEC1C46-C01C-4AF8-BA42-B5C7913B501D");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 3,
                column: "ApiKey",
                value: "ED51B204-B786-4F36-A0D3-4D188999BDBF");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 4,
                column: "ApiKey",
                value: "0D7E6C59-C8D8-44D0-AE9E-F19624529DF5");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 5,
                column: "ApiKey",
                value: "3482B274-9CEE-44EE-A1AB-005B236107A1");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 6,
                column: "ApiKey",
                value: "18EB3E31-6F02-4332-B38A-4DB87EF530FB");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 7,
                column: "ApiKey",
                value: "4A1C44B8-B6E9-47DD-8077-8FC4B9D5E69D");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 8,
                column: "ApiKey",
                value: "B3854AA4-A529-4B2A-8F03-F8FE72823A61");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 9,
                column: "ApiKey",
                value: "51880460-BFF5-41AA-A52B-7B058EC5218D");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 10,
                column: "ApiKey",
                value: "30A12F02-CA94-4089-969D-0671AC291C73");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 11,
                column: "ApiKey",
                value: "63AD102A-58CF-46C0-8C10-ADCEAE2E8955");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 12,
                column: "ApiKey",
                value: "B44E7E2D-3B81-4189-9916-3AF83F7B108B");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 13,
                column: "ApiKey",
                value: "F1929F7E-C003-4185-9C80-E65B60BEBDD3");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 14,
                column: "ApiKey",
                value: "F67B3095-8977-4558-9D09-AA50992BBD6C");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 15,
                column: "ApiKey",
                value: "C62F35E9-4D32-4A1D-B14F-1BDBBE427B8A");

            var sqlCommand = @"UPDATE dbo.Applications SET ApiKey = NEWID() WHERE ApiKey IS NULL";
            
            migrationBuilder.Sql(sqlCommand);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApiKey",
                table: "Applications");
        }
    }
}
