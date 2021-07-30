using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Watchdog.Core.DAL.Migrations
{
    public partial class SeedEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "AvatarUrl", "Name" },
                values: new object[,]
                {
                    { 1, "https://picsum.photos/250/250/?image=475", "nihil" },
                    { 2, "https://picsum.photos/250/250/?image=892", "odio" },
                    { 3, "https://picsum.photos/250/250/?image=1024", "eos" },
                    { 4, "https://picsum.photos/250/250/?image=1066", "est" },
                    { 5, "https://picsum.photos/250/250/?image=943", "quis" },
                    { 6, "https://picsum.photos/250/250/?image=712", "sunt" },
                    { 7, "https://picsum.photos/250/250/?image=575", "deleniti" },
                    { 8, "https://picsum.photos/250/250/?image=315", "et" },
                    { 9, "https://picsum.photos/250/250/?image=102", "laborum" },
                    { 10, "https://picsum.photos/250/250/?image=238", "ut" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 5, "Fugiat quis aut. Velit aut tempora eligendi quod quis. Ex sed molestiae. Quae quae quia reiciendis alias iste illum error velit. Et sint delectus necessitatibus vel iusto eos asperiores. At iure incidunt sit at sit optio ut adipisci.", "omnis" },
                    { 4, "Deserunt dolorum rerum et. Cum sit distinctio ab dolores molestiae sapiente recusandae. Quis aut veritatis ad earum rem omnis nesciunt.", "voluptates" },
                    { 2, "Quos qui ea enim adipisci consequatur eveniet omnis id veritatis. Fugiat fuga asperiores. In iure molestiae pariatur deleniti sit. Debitis natus qui sint tempore ut quas animi dolores. Eveniet sapiente dolorum.", "non" },
                    { 1, "Labore vitae inventore. Et sunt ipsum quis labore in quia repellendus. Ut provident rerum fugit quia optio. Soluta iure animi qui pariatur maiores. Qui at similique neque nihil sit suscipit.", "explicabo" },
                    { 3, "Corrupti vel nihil. Fugit molestiae sint facere. Sunt omnis corporis autem.", "ullam" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarUrl", "Email", "FirstName", "LastName", "PasswordHash", "RegisteredAt" },
                values: new object[,]
                {
                    { 11, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/58.jpg", "arturo60@yahoo.com", "Arturo", "Johnson", "8d0615cfb7619c909ddee2307dcd9203", new DateTime(2020, 8, 7, 0, 15, 16, 197, DateTimeKind.Unspecified).AddTicks(7668) },
                    { 18, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/788.jpg", "jamaal_leannon@gmail.com", "Jamaal", "Leannon", "c7b872268f35cc36d80a94dcd6577de2", new DateTime(2021, 5, 22, 4, 51, 14, 422, DateTimeKind.Unspecified).AddTicks(9085) },
                    { 17, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/192.jpg", "stanford96@yahoo.com", "Stanford", "Ernser", "ffd1cc90828a947497af816c728c4ab3", new DateTime(2021, 4, 4, 3, 53, 51, 406, DateTimeKind.Unspecified).AddTicks(7802) },
                    { 16, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/620.jpg", "christopher_weimann25@hotmail.com", "Christopher", "Weimann", "204142073353c8fa4177f9991c0aac0d", new DateTime(2020, 9, 13, 6, 37, 58, 834, DateTimeKind.Unspecified).AddTicks(4018) },
                    { 15, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/124.jpg", "terrill.lueilwitz@yahoo.com", "Terrill", "Lueilwitz", "586974f9af91bdbc95b14b342f4501dc", new DateTime(2021, 6, 13, 12, 3, 21, 539, DateTimeKind.Unspecified).AddTicks(1403) },
                    { 14, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1193.jpg", "olaf87@yahoo.com", "Olaf", "Bechtelar", "fa43fa327b94f065a58726581af0e4c4", new DateTime(2019, 8, 24, 7, 46, 4, 209, DateTimeKind.Unspecified).AddTicks(8706) },
                    { 13, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1099.jpg", "easton_kassulke7@hotmail.com", "Easton", "Kassulke", "7783a78553a6c1cb2de3cc2fc812d39b", new DateTime(2020, 10, 31, 15, 53, 56, 719, DateTimeKind.Unspecified).AddTicks(9479) },
                    { 12, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/668.jpg", "lambert.gusikowski33@yahoo.com", "Lambert", "Gusikowski", "986465554679b2a5aff38e68639924ae", new DateTime(2020, 7, 3, 9, 11, 22, 889, DateTimeKind.Unspecified).AddTicks(4516) },
                    { 10, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/486.jpg", "cruz_mcclure42@gmail.com", "Cruz", "McClure", "b284640eedebf37c8a22615a671cd7f1", new DateTime(2019, 9, 27, 10, 3, 13, 442, DateTimeKind.Unspecified).AddTicks(2050) },
                    { 3, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/650.jpg", "anais28@hotmail.com", "Anais", "Runolfsson", "d4bfc2a1c61705ceaba64d0fcc18f982", new DateTime(2020, 6, 23, 13, 43, 50, 92, DateTimeKind.Unspecified).AddTicks(2415) },
                    { 8, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1150.jpg", "paula.erdman41@hotmail.com", "Paula", "Erdman", "3c890097e0ae3f1ecf026fddc2672e4c", new DateTime(2019, 8, 13, 15, 40, 29, 274, DateTimeKind.Unspecified).AddTicks(8803) },
                    { 7, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/43.jpg", "cloyd78@yahoo.com", "Cloyd", "Bogisich", "d201aa8c81d98f138254ae601849fb4a", new DateTime(2021, 2, 23, 18, 31, 26, 64, DateTimeKind.Unspecified).AddTicks(717) },
                    { 6, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/362.jpg", "angeline.hand@yahoo.com", "Angeline", "Hand", "60604f1ebab94e637da6fee1c90ada16", new DateTime(2021, 7, 15, 8, 59, 55, 774, DateTimeKind.Unspecified).AddTicks(8519) },
                    { 5, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/30.jpg", "arthur.schiller@yahoo.com", "Arthur", "Schiller", "bd79eb27ea82db6f7892f40d3ed45217", new DateTime(2020, 8, 21, 15, 27, 45, 439, DateTimeKind.Unspecified).AddTicks(7151) },
                    { 4, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/860.jpg", "bailee.berge@yahoo.com", "Bailee", "Berge", "9ab5d3f57a4603dff3c201223efe83b6", new DateTime(2021, 5, 29, 16, 20, 19, 156, DateTimeKind.Unspecified).AddTicks(244) },
                    { 19, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/804.jpg", "stephania_koelpin@hotmail.com", "Stephania", "Koelpin", "a4cfd04f7fb9f1d38afa0cafa1142db9", new DateTime(2020, 12, 11, 18, 50, 9, 819, DateTimeKind.Unspecified).AddTicks(713) },
                    { 2, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/221.jpg", "elbert14@gmail.com", "Elbert", "Shanahan", "486b204532df2940dce539dc4d23565c", new DateTime(2020, 9, 18, 15, 52, 23, 708, DateTimeKind.Unspecified).AddTicks(6237) },
                    { 1, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/202.jpg", "jed.kshlerin@hotmail.com", "Jed", "Kshlerin", "d3ce4ccce29e8b208555506d913e0946", new DateTime(2020, 3, 29, 21, 59, 37, 349, DateTimeKind.Unspecified).AddTicks(9351) },
                    { 9, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1193.jpg", "antwan.swift6@yahoo.com", "Antwan", "Swift", "ecae0563ee7fb004facd9240cef4e37f", new DateTime(2019, 9, 19, 17, 36, 17, 907, DateTimeKind.Unspecified).AddTicks(4010) },
                    { 20, "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/826.jpg", "gregoria0@hotmail.com", "Gregoria", "Hills", "b97d8b4f0476cdeddac5cf0c93145a75", new DateTime(2021, 2, 13, 8, 22, 26, 387, DateTimeKind.Unspecified).AddTicks(4942) }
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "AvatarUrl", "CreatedAt", "CreatedBy", "Name" },
                values: new object[,]
                {
                    { 2, "https://picsum.photos/250/250/?image=384", new DateTime(2021, 6, 8, 4, 26, 15, 192, DateTimeKind.Unspecified).AddTicks(4559), 4, "Parisian and Sons" },
                    { 4, "https://picsum.photos/250/250/?image=322", new DateTime(2021, 6, 22, 5, 11, 9, 722, DateTimeKind.Unspecified).AddTicks(9234), 12, "Bode, Murray and Powlowski" },
                    { 5, "https://picsum.photos/250/250/?image=180", new DateTime(2020, 8, 3, 16, 48, 30, 79, DateTimeKind.Unspecified).AddTicks(9857), 14, "Hammes Inc" },
                    { 3, "https://picsum.photos/250/250/?image=52", new DateTime(2021, 1, 7, 22, 2, 16, 309, DateTimeKind.Unspecified).AddTicks(4029), 15, "Okuneva - Mohr" },
                    { 1, "https://picsum.photos/250/250/?image=144", new DateTime(2020, 3, 30, 18, 37, 49, 810, DateTimeKind.Unspecified).AddTicks(7734), 19, "Rogahn, Oberbrunner and Lebsack" }
                });

            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Name", "OrganizationId", "PlatformId", "SecurityToken" },
                values: new object[,]
                {
                    { 5, new DateTime(2020, 11, 1, 23, 50, 36, 645, DateTimeKind.Unspecified).AddTicks(6625), 1, "tempora", 2, 10, "f41296e7015528714a10e9c0c05ec3f0" },
                    { 7, new DateTime(2021, 1, 20, 5, 51, 37, 155, DateTimeKind.Unspecified).AddTicks(1815), 12, "voluptatem", 2, 10, "90637f3b5d86c09ad05bb62664b806f1" },
                    { 8, new DateTime(2020, 9, 15, 5, 54, 32, 534, DateTimeKind.Unspecified).AddTicks(1538), 10, "reiciendis", 2, 7, "59655ae4c809e4e3983efc33bafd62d7" },
                    { 10, new DateTime(2021, 4, 10, 17, 22, 41, 492, DateTimeKind.Unspecified).AddTicks(341), 13, "iusto", 2, 10, "ad178b7cc87610aefaba124101bf5988" },
                    { 9, new DateTime(2021, 4, 2, 9, 39, 11, 203, DateTimeKind.Unspecified).AddTicks(5174), 4, "voluptates", 3, 4, "65c32abaf221ea765f963abb1d9b933c" },
                    { 3, new DateTime(2021, 5, 2, 8, 9, 18, 808, DateTimeKind.Unspecified).AddTicks(603), 6, "aliquid", 3, 1, "4e71098eaf39041db98db018db344bc4" },
                    { 4, new DateTime(2021, 1, 21, 4, 27, 54, 821, DateTimeKind.Unspecified).AddTicks(9297), 7, "et", 5, 3, "654e6fee6db32672fa3df4554af2e1ff" },
                    { 2, new DateTime(2019, 11, 9, 2, 34, 53, 333, DateTimeKind.Unspecified).AddTicks(609), 14, "eaque", 1, 1, "740bfaea383def5780176e65ae10e04f" },
                    { 6, new DateTime(2020, 12, 4, 12, 59, 54, 245, DateTimeKind.Unspecified).AddTicks(9861), 12, "fugit", 1, 10, "b5d6e399dc98eb83345815910bd25138" },
                    { 1, new DateTime(2021, 2, 12, 2, 4, 53, 954, DateTimeKind.Unspecified).AddTicks(9302), 19, "et", 4, 1, "382c872c306c5e42126fd20bd128d2f8" }
                });

            migrationBuilder.InsertData(
                table: "Dashboards",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Name", "OrganizationId" },
                values: new object[,]
                {
                    { 14, new DateTime(2019, 8, 22, 13, 56, 3, 86, DateTimeKind.Unspecified).AddTicks(1337), 13, "saepe", 3 },
                    { 6, new DateTime(2020, 9, 14, 18, 10, 26, 80, DateTimeKind.Unspecified).AddTicks(7223), 4, "fugiat", 5 },
                    { 15, new DateTime(2020, 9, 23, 15, 54, 42, 918, DateTimeKind.Unspecified).AddTicks(8524), 13, "aspernatur", 4 },
                    { 5, new DateTime(2021, 7, 8, 13, 52, 55, 910, DateTimeKind.Unspecified).AddTicks(1221), 19, "voluptatibus", 3 },
                    { 9, new DateTime(2021, 6, 2, 21, 59, 55, 122, DateTimeKind.Unspecified).AddTicks(4800), 3, "recusandae", 4 },
                    { 7, new DateTime(2021, 6, 25, 15, 10, 12, 305, DateTimeKind.Unspecified).AddTicks(8976), 20, "dolore", 4 },
                    { 11, new DateTime(2021, 7, 2, 7, 47, 50, 697, DateTimeKind.Unspecified).AddTicks(4443), 7, "eum", 4 },
                    { 10, new DateTime(2021, 2, 21, 5, 1, 25, 731, DateTimeKind.Unspecified).AddTicks(7636), 9, "dolorem", 1 },
                    { 1, new DateTime(2019, 10, 12, 6, 42, 6, 525, DateTimeKind.Unspecified).AddTicks(2732), 3, "debitis", 2 },
                    { 2, new DateTime(2019, 11, 3, 11, 13, 40, 934, DateTimeKind.Unspecified).AddTicks(2638), 12, "sit", 2 },
                    { 3, new DateTime(2021, 2, 3, 17, 43, 11, 653, DateTimeKind.Unspecified).AddTicks(4170), 7, "error", 2 },
                    { 4, new DateTime(2020, 10, 22, 5, 11, 19, 396, DateTimeKind.Unspecified).AddTicks(4577), 11, "itaque", 1 },
                    { 8, new DateTime(2021, 4, 9, 12, 29, 21, 740, DateTimeKind.Unspecified).AddTicks(5356), 11, "doloribus", 2 },
                    { 12, new DateTime(2020, 11, 9, 11, 16, 38, 651, DateTimeKind.Unspecified).AddTicks(8274), 9, "excepturi", 2 },
                    { 13, new DateTime(2020, 10, 18, 23, 59, 10, 615, DateTimeKind.Unspecified).AddTicks(7577), 3, "quae", 3 }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "OrganizationId", "RoleId" },
                values: new object[,]
                {
                    { 24, new DateTime(2020, 2, 26, 14, 59, 29, 473, DateTimeKind.Unspecified).AddTicks(5763), 9, 3, 4 },
                    { 21, new DateTime(2019, 8, 24, 23, 59, 6, 250, DateTimeKind.Unspecified).AddTicks(1004), 16, 3, 2 },
                    { 30, new DateTime(2021, 3, 13, 14, 30, 36, 921, DateTimeKind.Unspecified).AddTicks(1544), 12, 3, 4 },
                    { 16, new DateTime(2020, 11, 26, 21, 33, 26, 251, DateTimeKind.Unspecified).AddTicks(4354), 10, 3, 3 },
                    { 15, new DateTime(2021, 1, 15, 16, 3, 46, 55, DateTimeKind.Unspecified).AddTicks(7176), 4, 3, 2 },
                    { 14, new DateTime(2020, 2, 16, 2, 0, 40, 350, DateTimeKind.Unspecified).AddTicks(4718), 6, 3, 1 },
                    { 13, new DateTime(2020, 6, 5, 23, 26, 15, 564, DateTimeKind.Unspecified).AddTicks(274), 12, 3, 3 },
                    { 3, new DateTime(2019, 10, 5, 13, 0, 34, 132, DateTimeKind.Unspecified).AddTicks(3117), 2, 3, 4 },
                    { 12, new DateTime(2021, 4, 5, 17, 35, 33, 328, DateTimeKind.Unspecified).AddTicks(4435), 9, 1, 1 },
                    { 2, new DateTime(2019, 11, 11, 3, 10, 6, 170, DateTimeKind.Unspecified).AddTicks(2841), 16, 1, 5 },
                    { 1, new DateTime(2020, 6, 23, 17, 55, 40, 784, DateTimeKind.Unspecified).AddTicks(6587), 19, 1, 3 },
                    { 22, new DateTime(2019, 12, 13, 13, 57, 12, 13, DateTimeKind.Unspecified).AddTicks(984), 15, 3, 4 },
                    { 18, new DateTime(2020, 3, 28, 11, 51, 59, 488, DateTimeKind.Unspecified).AddTicks(8865), 18, 3, 5 },
                    { 26, new DateTime(2019, 10, 12, 15, 15, 12, 766, DateTimeKind.Unspecified).AddTicks(6699), 4, 5, 3 },
                    { 29, new DateTime(2021, 4, 26, 1, 36, 51, 405, DateTimeKind.Unspecified).AddTicks(6570), 1, 5, 1 },
                    { 28, new DateTime(2020, 6, 30, 21, 45, 53, 833, DateTimeKind.Unspecified).AddTicks(6612), 20, 5, 2 },
                    { 27, new DateTime(2019, 10, 3, 14, 41, 15, 275, DateTimeKind.Unspecified).AddTicks(7289), 6, 5, 3 }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "OrganizationId", "RoleId" },
                values: new object[,]
                {
                    { 23, new DateTime(2020, 1, 14, 18, 54, 42, 990, DateTimeKind.Unspecified).AddTicks(701), 9, 1, 1 },
                    { 6, new DateTime(2020, 8, 29, 8, 18, 24, 585, DateTimeKind.Unspecified).AddTicks(9893), 16, 5, 5 },
                    { 5, new DateTime(2020, 8, 11, 5, 32, 51, 930, DateTimeKind.Unspecified).AddTicks(3850), 5, 5, 3 },
                    { 4, new DateTime(2021, 4, 27, 7, 55, 58, 628, DateTimeKind.Unspecified).AddTicks(106), 6, 5, 4 },
                    { 25, new DateTime(2019, 9, 5, 4, 2, 59, 158, DateTimeKind.Unspecified).AddTicks(4664), 9, 4, 5 },
                    { 20, new DateTime(2020, 12, 4, 13, 22, 46, 624, DateTimeKind.Unspecified).AddTicks(5014), 6, 4, 4 },
                    { 10, new DateTime(2021, 7, 14, 18, 53, 43, 769, DateTimeKind.Unspecified).AddTicks(5102), 14, 4, 2 },
                    { 8, new DateTime(2019, 11, 14, 5, 32, 33, 474, DateTimeKind.Unspecified).AddTicks(6814), 20, 2, 2 },
                    { 9, new DateTime(2020, 3, 1, 10, 50, 38, 346, DateTimeKind.Unspecified).AddTicks(2283), 18, 2, 2 },
                    { 7, new DateTime(2021, 2, 5, 12, 28, 51, 771, DateTimeKind.Unspecified).AddTicks(7583), 13, 4, 2 },
                    { 11, new DateTime(2021, 6, 23, 23, 17, 16, 155, DateTimeKind.Unspecified).AddTicks(5266), 2, 2, 2 },
                    { 19, new DateTime(2020, 8, 26, 0, 42, 7, 317, DateTimeKind.Unspecified).AddTicks(8157), 5, 2, 2 },
                    { 17, new DateTime(2020, 8, 9, 5, 46, 45, 899, DateTimeKind.Unspecified).AddTicks(7907), 12, 2, 4 }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Name", "OrganizationId" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 9, 1, 7, 47, 32, 129, DateTimeKind.Unspecified).AddTicks(9329), 14, "sunt", 3 },
                    { 4, new DateTime(2021, 1, 19, 12, 53, 16, 386, DateTimeKind.Unspecified).AddTicks(1443), 16, "cum", 3 },
                    { 5, new DateTime(2020, 6, 23, 16, 8, 44, 548, DateTimeKind.Unspecified).AddTicks(2045), 4, "blanditiis", 5 },
                    { 3, new DateTime(2020, 9, 11, 20, 34, 6, 433, DateTimeKind.Unspecified).AddTicks(6472), 2, "suscipit", 2 },
                    { 2, new DateTime(2019, 10, 8, 22, 39, 56, 533, DateTimeKind.Unspecified).AddTicks(8774), 17, "eius", 1 }
                });

            migrationBuilder.InsertData(
                table: "ApplicationTeams",
                columns: new[] { "Id", "ApplicationId", "TeamId" },
                values: new object[,]
                {
                    { 6, 5, 3 },
                    { 19, 2, 5 },
                    { 3, 6, 1 },
                    { 2, 2, 1 },
                    { 7, 10, 5 },
                    { 16, 1, 5 },
                    { 15, 1, 3 },
                    { 13, 7, 3 },
                    { 10, 5, 3 },
                    { 9, 5, 3 },
                    { 12, 5, 1 },
                    { 20, 4, 5 },
                    { 14, 3, 2 },
                    { 17, 5, 2 },
                    { 1, 3, 5 },
                    { 18, 9, 4 },
                    { 11, 1, 4 },
                    { 8, 10, 4 },
                    { 5, 4, 1 },
                    { 4, 2, 5 }
                });

            migrationBuilder.InsertData(
                table: "Environments",
                columns: new[] { "Id", "ApplicationId", "Name" },
                values: new object[,]
                {
                    { 4, 9, "aperiam" },
                    { 3, 10, "est" },
                    { 2, 4, "eveniet" },
                    { 5, 6, "deleniti" },
                    { 1, 4, "voluptatibus" }
                });

            migrationBuilder.InsertData(
                table: "TeamMembers",
                columns: new[] { "Id", "MemberId", "TeamId" },
                values: new object[,]
                {
                    { 12, 8, 2 },
                    { 13, 29, 1 },
                    { 17, 7, 1 },
                    { 18, 20, 1 },
                    { 25, 29, 1 },
                    { 10, 13, 2 },
                    { 6, 4, 2 },
                    { 5, 28, 2 },
                    { 8, 5, 4 },
                    { 19, 19, 4 },
                    { 4, 1, 2 },
                    { 1, 9, 2 },
                    { 23, 26, 4 },
                    { 21, 23, 3 },
                    { 2, 12, 3 },
                    { 20, 1, 1 },
                    { 16, 30, 4 }
                });

            migrationBuilder.InsertData(
                table: "TeamMembers",
                columns: new[] { "Id", "MemberId", "TeamId" },
                values: new object[,]
                {
                    { 9, 4, 1 },
                    { 24, 7, 2 },
                    { 7, 30, 5 },
                    { 11, 16, 3 },
                    { 14, 6, 2 },
                    { 22, 7, 3 },
                    { 15, 6, 5 },
                    { 3, 10, 1 }
                });

            migrationBuilder.InsertData(
                table: "Tiles",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DashboardId", "Name" },
                values: new object[,]
                {
                    { 11, new DateTime(2020, 9, 1, 12, 11, 57, 170, DateTimeKind.Unspecified).AddTicks(2604), 4, 11, "placeat" },
                    { 5, new DateTime(2019, 8, 5, 23, 45, 48, 298, DateTimeKind.Unspecified).AddTicks(8056), 10, 8, "doloribus" },
                    { 3, new DateTime(2019, 8, 24, 2, 50, 19, 608, DateTimeKind.Unspecified).AddTicks(3027), 20, 8, "nulla" },
                    { 13, new DateTime(2019, 7, 25, 21, 17, 2, 688, DateTimeKind.Unspecified).AddTicks(6748), 7, 2, "similique" },
                    { 7, new DateTime(2020, 11, 22, 21, 23, 48, 733, DateTimeKind.Unspecified).AddTicks(9480), 20, 2, "qui" },
                    { 18, new DateTime(2019, 8, 17, 3, 34, 59, 276, DateTimeKind.Unspecified).AddTicks(8512), 5, 1, "et" },
                    { 15, new DateTime(2021, 4, 17, 15, 59, 57, 251, DateTimeKind.Unspecified).AddTicks(3258), 3, 1, "quaerat" },
                    { 14, new DateTime(2021, 2, 9, 17, 55, 34, 126, DateTimeKind.Unspecified).AddTicks(4772), 19, 1, "sint" },
                    { 10, new DateTime(2021, 1, 23, 5, 49, 51, 384, DateTimeKind.Unspecified).AddTicks(794), 20, 1, "quas" },
                    { 20, new DateTime(2021, 5, 1, 12, 45, 22, 202, DateTimeKind.Unspecified).AddTicks(5966), 12, 3, "quo" },
                    { 12, new DateTime(2020, 4, 6, 2, 33, 56, 395, DateTimeKind.Unspecified).AddTicks(7716), 10, 11, "beatae" },
                    { 23, new DateTime(2020, 8, 9, 10, 30, 58, 62, DateTimeKind.Unspecified).AddTicks(3863), 17, 11, "iure" },
                    { 19, new DateTime(2020, 6, 23, 7, 29, 11, 206, DateTimeKind.Unspecified).AddTicks(8352), 5, 4, "ut" },
                    { 4, new DateTime(2020, 2, 21, 3, 45, 34, 720, DateTimeKind.Unspecified).AddTicks(8399), 3, 15, "est" },
                    { 2, new DateTime(2021, 2, 5, 6, 31, 9, 575, DateTimeKind.Unspecified).AddTicks(2253), 5, 6, "et" },
                    { 22, new DateTime(2020, 9, 24, 0, 42, 48, 413, DateTimeKind.Unspecified).AddTicks(3080), 3, 6, "similique" },
                    { 9, new DateTime(2021, 5, 7, 18, 59, 13, 655, DateTimeKind.Unspecified).AddTicks(9528), 18, 5, "totam" },
                    { 21, new DateTime(2019, 11, 8, 11, 46, 14, 149, DateTimeKind.Unspecified).AddTicks(9025), 16, 5, "rerum" },
                    { 1, new DateTime(2019, 8, 24, 19, 56, 57, 207, DateTimeKind.Unspecified).AddTicks(5964), 14, 13, "explicabo" },
                    { 24, new DateTime(2019, 11, 16, 22, 4, 38, 925, DateTimeKind.Unspecified).AddTicks(8090), 18, 13, "eveniet" },
                    { 6, new DateTime(2020, 3, 22, 0, 4, 45, 919, DateTimeKind.Unspecified).AddTicks(3908), 12, 14, "et" },
                    { 8, new DateTime(2021, 6, 2, 10, 46, 7, 850, DateTimeKind.Unspecified).AddTicks(6927), 8, 14, "et" },
                    { 16, new DateTime(2019, 9, 11, 17, 20, 24, 304, DateTimeKind.Unspecified).AddTicks(4056), 7, 14, "consequatur" },
                    { 25, new DateTime(2021, 3, 28, 8, 14, 13, 190, DateTimeKind.Unspecified).AddTicks(2898), 7, 4, "ea" },
                    { 17, new DateTime(2020, 11, 5, 17, 32, 45, 18, DateTimeKind.Unspecified).AddTicks(7950), 10, 14, "consequuntur" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApplicationTeams",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ApplicationTeams",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ApplicationTeams",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ApplicationTeams",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ApplicationTeams",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ApplicationTeams",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ApplicationTeams",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ApplicationTeams",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ApplicationTeams",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ApplicationTeams",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ApplicationTeams",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ApplicationTeams",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ApplicationTeams",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ApplicationTeams",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ApplicationTeams",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ApplicationTeams",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ApplicationTeams",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ApplicationTeams",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ApplicationTeams",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ApplicationTeams",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Dashboards",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Dashboards",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Dashboards",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Dashboards",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Environments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Environments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Environments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Environments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Environments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Tiles",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Dashboards",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Dashboards",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Dashboards",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Dashboards",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Dashboards",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Dashboards",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Dashboards",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Dashboards",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Dashboards",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Dashboards",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Dashboards",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 19);
        }
    }
}
