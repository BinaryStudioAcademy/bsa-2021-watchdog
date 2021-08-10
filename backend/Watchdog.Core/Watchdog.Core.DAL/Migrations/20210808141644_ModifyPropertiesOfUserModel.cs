using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Watchdog.Core.DAL.Migrations
{
    public partial class ModifyPropertiesOfUserModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Uid",
                table: "Users",
                type: "nvarchar(28)",
                maxLength: 28,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvatarUrl", "Email", "FirstName", "LastName", "RegisteredAt", "Uid" },
                values: new object[] { "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/754.jpg", "sandy93@gmail.com", "Sandy", "Mayert", new DateTime(2021, 6, 28, 10, 18, 23, 123, DateTimeKind.Unspecified).AddTicks(5316), "77f95d3ce4ccce29e8b208555506" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AvatarUrl", "Email", "FirstName", "LastName", "RegisteredAt", "Uid" },
                values: new object[] { "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/198.jpg", "eudora_feil29@yahoo.com", "Eudora", "Feil", new DateTime(2019, 10, 30, 2, 0, 41, 493, DateTimeKind.Unspecified).AddTicks(5757), "46a24d412486b204532df2940dce" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AvatarUrl", "Email", "FirstName", "LastName", "RegisteredAt", "Uid" },
                values: new object[] { "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/72.jpg", "marianna.rau@yahoo.com", "Marianna", "Rau", new DateTime(2019, 10, 20, 21, 37, 4, 161, DateTimeKind.Unspecified).AddTicks(2171), "3565c620ce44d4bfc2a1c61705ce" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AvatarUrl", "Email", "FirstName", "LastName", "RegisteredAt", "Uid" },
                values: new object[] { "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/218.jpg", "america_ferry21@hotmail.com", "America", "Ferry", new DateTime(2019, 12, 24, 16, 33, 25, 220, DateTimeKind.Unspecified).AddTicks(4395), "fcc18f98288107909ab5d3f57a46" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AvatarUrl", "Email", "FirstName", "LastName", "RegisteredAt", "Uid" },
                values: new object[] { "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/602.jpg", "marc_lebsack43@gmail.com", "Marc", "Lebsack", new DateTime(2019, 7, 23, 17, 56, 25, 628, DateTimeKind.Unspecified).AddTicks(1090), "01223efe83b61b1c883bd79eb27e" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AvatarUrl", "Email", "FirstName", "LastName", "RegisteredAt", "Uid" },
                values: new object[] { "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/345.jpg", "arlo_thiel@hotmail.com", "Arlo", "Thiel", new DateTime(2020, 5, 5, 23, 31, 19, 283, DateTimeKind.Unspecified).AddTicks(8044), "892f40d3ed45217700597360604f" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AvatarUrl", "Email", "FirstName", "LastName", "RegisteredAt", "Uid" },
                values: new object[] { "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/98.jpg", "alejandrin_brekke80@hotmail.com", "Alejandrin", "Brekke", new DateTime(2020, 6, 13, 23, 56, 25, 451, DateTimeKind.Unspecified).AddTicks(4553), "e637da6fee1c90ada16043183cd2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AvatarUrl", "Email", "FirstName", "LastName", "RegisteredAt", "Uid" },
                values: new object[] { "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/22.jpg", "connie_johnson60@gmail.com", "Connie", "Johnson", new DateTime(2021, 7, 17, 10, 50, 46, 816, DateTimeKind.Unspecified).AddTicks(6310), "d98f138254ae601849fb4a30c3fc" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AvatarUrl", "RegisteredAt", "Uid" },
                values: new object[] { "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1014.jpg", new DateTime(2019, 9, 11, 5, 12, 42, 621, DateTimeKind.Unspecified).AddTicks(4741), "97e0ae3f1ecf026fddc2672e4cfe" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AvatarUrl", "Email", "FirstName", "LastName", "RegisteredAt", "Uid" },
                values: new object[] { "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1108.jpg", "jesse.wintheiser58@hotmail.com", "Jesse", "Wintheiser", new DateTime(2021, 1, 3, 23, 42, 56, 548, DateTimeKind.Unspecified).AddTicks(5804), "ae0563ee7fb004facd9240cef4e3" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AvatarUrl", "Email", "FirstName", "LastName", "RegisteredAt", "Uid" },
                values: new object[] { "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1131.jpg", "arnoldo_schiller@hotmail.com", "Arnoldo", "Schiller", new DateTime(2021, 5, 15, 16, 35, 43, 754, DateTimeKind.Unspecified).AddTicks(4296), "c6b284640eedebf37c8a22615a67" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AvatarUrl", "Email", "FirstName", "LastName", "RegisteredAt", "Uid" },
                values: new object[] { "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/171.jpg", "darby_beer83@yahoo.com", "Darby", "Beer", new DateTime(2020, 5, 10, 0, 27, 49, 614, DateTimeKind.Unspecified).AddTicks(386), "6169098d0615cfb7619c909ddee2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "AvatarUrl", "Email", "FirstName", "LastName", "RegisteredAt", "Uid" },
                values: new object[] { "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/245.jpg", "vesta.feest55@yahoo.com", "Vesta", "Feest", new DateTime(2020, 9, 12, 9, 25, 30, 496, DateTimeKind.Unspecified).AddTicks(8441), "0370945b45986465554679b2a5af" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "AvatarUrl", "Email", "FirstName", "LastName", "RegisteredAt", "Uid" },
                values: new object[] { "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1003.jpg", "rachel_powlowski23@gmail.com", "Rachel", "Powlowski", new DateTime(2020, 1, 6, 18, 17, 38, 650, DateTimeKind.Unspecified).AddTicks(9773), "9924ae8846cea17783a78553a6c1" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "AvatarUrl", "Email", "FirstName", "LastName", "RegisteredAt", "Uid" },
                values: new object[] { "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/401.jpg", "eliane.will@gmail.com", "Eliane", "Will", new DateTime(2020, 3, 25, 10, 45, 6, 36, DateTimeKind.Unspecified).AddTicks(3026), "2fc812d39b5ec062efa43fa327b9" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "AvatarUrl", "Email", "FirstName", "LastName", "RegisteredAt", "Uid" },
                values: new object[] { "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1066.jpg", "leopoldo.pfannerstill@hotmail.com", "Leopoldo", "Pfannerstill", new DateTime(2020, 2, 1, 19, 39, 17, 212, DateTimeKind.Unspecified).AddTicks(3797), "8726581af0e4c4ffe8893586974f" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "AvatarUrl", "Email", "FirstName", "LastName", "RegisteredAt", "Uid" },
                values: new object[] { "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/286.jpg", "dessie2@gmail.com", "Dessie", "Bernhard", new DateTime(2020, 8, 24, 12, 17, 18, 626, DateTimeKind.Unspecified).AddTicks(6944), "bc95b14b342f4501dc012fbce420" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "AvatarUrl", "Email", "FirstName", "LastName", "RegisteredAt", "Uid" },
                values: new object[] { "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/980.jpg", "camden_wisoky11@hotmail.com", "Camden", "Wisoky", new DateTime(2019, 12, 13, 10, 32, 1, 457, DateTimeKind.Unspecified).AddTicks(5363), "353c8fa4177f9991c0aac0d67e37" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "AvatarUrl", "Email", "FirstName", "LastName", "RegisteredAt", "Uid" },
                values: new object[] { "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/616.jpg", "jamaal_leannon@gmail.com", "Jamaal", "Leannon", new DateTime(2019, 12, 23, 7, 37, 36, 280, DateTimeKind.Unspecified).AddTicks(2979), "90828a947497af816c728c4ab322" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "AvatarUrl", "Email", "FirstName", "LastName", "RegisteredAt", "Uid" },
                values: new object[] { "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1012.jpg", "thelma_considine@gmail.com", "Thelma", "Considine", new DateTime(2020, 8, 18, 4, 29, 1, 814, DateTimeKind.Unspecified).AddTicks(3646), "b872268f35cc36d80a94dcd6577d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Uid",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Users",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvatarUrl", "Email", "FirstName", "LastName", "PasswordHash", "RegisteredAt" },
                values: new object[] { "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/202.jpg", "jed.kshlerin@hotmail.com", "Jed", "Kshlerin", "d3ce4ccce29e8b208555506d913e0946", new DateTime(2020, 3, 29, 21, 59, 37, 349, DateTimeKind.Unspecified).AddTicks(9351) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AvatarUrl", "Email", "FirstName", "LastName", "PasswordHash", "RegisteredAt" },
                values: new object[] { "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/221.jpg", "elbert14@gmail.com", "Elbert", "Shanahan", "486b204532df2940dce539dc4d23565c", new DateTime(2020, 9, 18, 15, 52, 23, 708, DateTimeKind.Unspecified).AddTicks(6237) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AvatarUrl", "Email", "FirstName", "LastName", "PasswordHash", "RegisteredAt" },
                values: new object[] { "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/650.jpg", "anais28@hotmail.com", "Anais", "Runolfsson", "d4bfc2a1c61705ceaba64d0fcc18f982", new DateTime(2020, 6, 23, 13, 43, 50, 92, DateTimeKind.Unspecified).AddTicks(2415) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AvatarUrl", "Email", "FirstName", "LastName", "PasswordHash", "RegisteredAt" },
                values: new object[] { "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/860.jpg", "bailee.berge@yahoo.com", "Bailee", "Berge", "9ab5d3f57a4603dff3c201223efe83b6", new DateTime(2021, 5, 29, 16, 20, 19, 156, DateTimeKind.Unspecified).AddTicks(244) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AvatarUrl", "Email", "FirstName", "LastName", "PasswordHash", "RegisteredAt" },
                values: new object[] { "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/30.jpg", "arthur.schiller@yahoo.com", "Arthur", "Schiller", "bd79eb27ea82db6f7892f40d3ed45217", new DateTime(2020, 8, 21, 15, 27, 45, 439, DateTimeKind.Unspecified).AddTicks(7151) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AvatarUrl", "Email", "FirstName", "LastName", "PasswordHash", "RegisteredAt" },
                values: new object[] { "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/362.jpg", "angeline.hand@yahoo.com", "Angeline", "Hand", "60604f1ebab94e637da6fee1c90ada16", new DateTime(2021, 7, 15, 8, 59, 55, 774, DateTimeKind.Unspecified).AddTicks(8519) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AvatarUrl", "Email", "FirstName", "LastName", "PasswordHash", "RegisteredAt" },
                values: new object[] { "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/43.jpg", "cloyd78@yahoo.com", "Cloyd", "Bogisich", "d201aa8c81d98f138254ae601849fb4a", new DateTime(2021, 2, 23, 18, 31, 26, 64, DateTimeKind.Unspecified).AddTicks(717) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AvatarUrl", "Email", "FirstName", "LastName", "PasswordHash", "RegisteredAt" },
                values: new object[] { "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1150.jpg", "paula.erdman41@hotmail.com", "Paula", "Erdman", "3c890097e0ae3f1ecf026fddc2672e4c", new DateTime(2019, 8, 13, 15, 40, 29, 274, DateTimeKind.Unspecified).AddTicks(8803) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AvatarUrl", "PasswordHash", "RegisteredAt" },
                values: new object[] { "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1193.jpg", "ecae0563ee7fb004facd9240cef4e37f", new DateTime(2019, 9, 19, 17, 36, 17, 907, DateTimeKind.Unspecified).AddTicks(4010) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AvatarUrl", "Email", "FirstName", "LastName", "PasswordHash", "RegisteredAt" },
                values: new object[] { "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/486.jpg", "cruz_mcclure42@gmail.com", "Cruz", "McClure", "b284640eedebf37c8a22615a671cd7f1", new DateTime(2019, 9, 27, 10, 3, 13, 442, DateTimeKind.Unspecified).AddTicks(2050) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AvatarUrl", "Email", "FirstName", "LastName", "PasswordHash", "RegisteredAt" },
                values: new object[] { "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/58.jpg", "arturo60@yahoo.com", "Arturo", "Johnson", "8d0615cfb7619c909ddee2307dcd9203", new DateTime(2020, 8, 7, 0, 15, 16, 197, DateTimeKind.Unspecified).AddTicks(7668) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AvatarUrl", "Email", "FirstName", "LastName", "PasswordHash", "RegisteredAt" },
                values: new object[] { "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/668.jpg", "lambert.gusikowski33@yahoo.com", "Lambert", "Gusikowski", "986465554679b2a5aff38e68639924ae", new DateTime(2020, 7, 3, 9, 11, 22, 889, DateTimeKind.Unspecified).AddTicks(4516) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "AvatarUrl", "Email", "FirstName", "LastName", "PasswordHash", "RegisteredAt" },
                values: new object[] { "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1099.jpg", "easton_kassulke7@hotmail.com", "Easton", "Kassulke", "7783a78553a6c1cb2de3cc2fc812d39b", new DateTime(2020, 10, 31, 15, 53, 56, 719, DateTimeKind.Unspecified).AddTicks(9479) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "AvatarUrl", "Email", "FirstName", "LastName", "PasswordHash", "RegisteredAt" },
                values: new object[] { "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1193.jpg", "olaf87@yahoo.com", "Olaf", "Bechtelar", "fa43fa327b94f065a58726581af0e4c4", new DateTime(2019, 8, 24, 7, 46, 4, 209, DateTimeKind.Unspecified).AddTicks(8706) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "AvatarUrl", "Email", "FirstName", "LastName", "PasswordHash", "RegisteredAt" },
                values: new object[] { "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/124.jpg", "terrill.lueilwitz@yahoo.com", "Terrill", "Lueilwitz", "586974f9af91bdbc95b14b342f4501dc", new DateTime(2021, 6, 13, 12, 3, 21, 539, DateTimeKind.Unspecified).AddTicks(1403) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "AvatarUrl", "Email", "FirstName", "LastName", "PasswordHash", "RegisteredAt" },
                values: new object[] { "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/620.jpg", "christopher_weimann25@hotmail.com", "Christopher", "Weimann", "204142073353c8fa4177f9991c0aac0d", new DateTime(2020, 9, 13, 6, 37, 58, 834, DateTimeKind.Unspecified).AddTicks(4018) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "AvatarUrl", "Email", "FirstName", "LastName", "PasswordHash", "RegisteredAt" },
                values: new object[] { "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/192.jpg", "stanford96@yahoo.com", "Stanford", "Ernser", "ffd1cc90828a947497af816c728c4ab3", new DateTime(2021, 4, 4, 3, 53, 51, 406, DateTimeKind.Unspecified).AddTicks(7802) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "AvatarUrl", "Email", "FirstName", "LastName", "PasswordHash", "RegisteredAt" },
                values: new object[] { "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/788.jpg", "jamaal_leannon@gmail.com", "Jamaal", "Leannon", "c7b872268f35cc36d80a94dcd6577de2", new DateTime(2021, 5, 22, 4, 51, 14, 422, DateTimeKind.Unspecified).AddTicks(9085) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "AvatarUrl", "Email", "FirstName", "LastName", "PasswordHash", "RegisteredAt" },
                values: new object[] { "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/804.jpg", "stephania_koelpin@hotmail.com", "Stephania", "Koelpin", "a4cfd04f7fb9f1d38afa0cafa1142db9", new DateTime(2020, 12, 11, 18, 50, 9, 819, DateTimeKind.Unspecified).AddTicks(713) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "AvatarUrl", "Email", "FirstName", "LastName", "PasswordHash", "RegisteredAt" },
                values: new object[] { "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/826.jpg", "gregoria0@hotmail.com", "Gregoria", "Hills", "b97d8b4f0476cdeddac5cf0c93145a75", new DateTime(2021, 2, 13, 8, 22, 26, 387, DateTimeKind.Unspecified).AddTicks(4942) });
        }
    }
}
