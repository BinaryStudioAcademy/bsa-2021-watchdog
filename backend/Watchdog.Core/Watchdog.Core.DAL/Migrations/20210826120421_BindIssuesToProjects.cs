using Microsoft.EntityFrameworkCore.Migrations;

namespace Watchdog.Core.DAL.Migrations
{
    public partial class BindIssuesToProjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicationId",
                table: "Issues",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 1,
                column: "ApiKey",
                value: "AA8D9EB4-513F-4485-AB88-FDA2C7DDBF37");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 2,
                column: "ApiKey",
                value: "FF092079-FF3A-4266-8441-C8F556ADB3C7");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 3,
                column: "ApiKey",
                value: "86649B15-6FC2-42B0-8D46-E8781F57C1C4");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 4,
                column: "ApiKey",
                value: "CF99AE20-2A8F-409E-94ED-56DEC20A1E53");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 5,
                column: "ApiKey",
                value: "3A122FCD-6CFC-4D1F-819C-CDE1926B9F2C");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 6,
                column: "ApiKey",
                value: "78C3EAA4-3DB8-4FFF-A671-604D23669C8E");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 7,
                column: "ApiKey",
                value: "50B066A9-39C4-4684-B02D-1F577E6B243C");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 8,
                column: "ApiKey",
                value: "790B7A91-6D5D-42C8-81A3-7B777DCB4328");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 9,
                column: "ApiKey",
                value: "3752717F-BB9A-4834-AC7A-5B65D596C624");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 10,
                column: "ApiKey",
                value: "03B01E0A-3995-4E96-B6B2-D622C2BD8F19");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 11,
                column: "ApiKey",
                value: "9CD472DA-27D0-447A-BA12-9574F8C7846A");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 12,
                column: "ApiKey",
                value: "B4992B8B-66CB-4D06-A495-E3BDCB957A79");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 13,
                column: "ApiKey",
                value: "D1647082-5A1E-4967-820B-17A08FB07EC4");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 14,
                column: "ApiKey",
                value: "3C04D6F6-34A4-4CAF-80FD-AFF370BD9349");

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 15,
                column: "ApiKey",
                value: "78A7753E-88D4-41F6-8895-086808841189");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_ApplicationId",
                table: "Issues",
                column: "ApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Applications_ApplicationId",
                table: "Issues",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Applications_ApplicationId",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Issues_ApplicationId",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "ApplicationId",
                table: "Issues");

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
        }
    }
}
