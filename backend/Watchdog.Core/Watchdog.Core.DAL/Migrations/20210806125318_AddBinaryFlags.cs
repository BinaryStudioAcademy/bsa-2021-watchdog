using Microsoft.EntityFrameworkCore.Migrations;

namespace Watchdog.Core.DAL.Migrations
{
    public partial class AddBinaryFlags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlatformsPlatformsType");

            migrationBuilder.DropTable(
                name: "PlatformTypes");

            migrationBuilder.AddColumn<int>(
                name: "PlatformTypes",
                table: "Platforms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 1,
                column: "PlatformTypes",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 2,
                column: "PlatformTypes",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 3,
                column: "PlatformTypes",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 4,
                column: "PlatformTypes",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 5,
                column: "PlatformTypes",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 6,
                column: "PlatformTypes",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 7,
                column: "PlatformTypes",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 8,
                column: "PlatformTypes",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 9,
                column: "PlatformTypes",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 10,
                column: "PlatformTypes",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 11,
                column: "PlatformTypes",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 12,
                column: "PlatformTypes",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "AvatarUrl", "Name", "PlatformTypes" },
                values: new object[] { "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHhtbG5zOnhsaW5rPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5L3hsaW5rIiB2aWV3Qm94PSIwIDAgODAgODAiPjxkZWZzPjxsaW5lYXJHcmFkaWVudCBpZD0iYSIgeDE9IjMyLjYyIiB5MT0iMzAuMSIgeDI9IjI1Ljc0IiB5Mj0iNDQuMTQiIGdyYWRpZW50VW5pdHM9InVzZXJTcGFjZU9uVXNlIj48c3RvcCBvZmZzZXQ9IjAiIHN0b3AtY29sb3I9IiMzZjg3M2YiLz48c3RvcCBvZmZzZXQ9Ii4zMyIgc3RvcC1jb2xvcj0iIzNmOGIzZCIvPjxzdG9wIG9mZnNldD0iLjY0IiBzdG9wLWNvbG9yPSIjM2U5NjM3Ii8+PHN0b3Agb2Zmc2V0PSIuOTMiIHN0b3AtY29sb3I9IiMzZGE5MmUiLz48c3RvcCBvZmZzZXQ9IjEiIHN0b3AtY29sb3I9IiMzZGFlMmIiLz48L2xpbmVhckdyYWRpZW50PjxsaW5lYXJHcmFkaWVudCBpZD0iZCIgeDE9IjI4LjM3IiB5MT0iMzcuNDUiIHgyPSI0Ny42OCIgeTI9IjIzLjE3IiBncmFkaWVudFVuaXRzPSJ1c2VyU3BhY2VPblVzZSI+PHN0b3Agb2Zmc2V0PSIuMTQiIHN0b3AtY29sb3I9IiMzZjg3M2YiLz48c3RvcCBvZmZzZXQ9Ii40IiBzdG9wLWNvbG9yPSIjNTI5ZjQ0Ii8+PHN0b3Agb2Zmc2V0PSIuNzEiIHN0b3AtY29sb3I9IiM2M2I2NDkiLz48c3RvcCBvZmZzZXQ9Ii45MSIgc3RvcC1jb2xvcj0iIzZhYmY0YiIvPjwvbGluZWFyR3JhZGllbnQ+PGxpbmVhckdyYWRpZW50IGlkPSJlIiB4MT0iMjAuNzIiIHkxPSIyNS4yMyIgeDI9IjM4LjMzIiB5Mj0iMjUuMjMiIGdyYWRpZW50VW5pdHM9InVzZXJTcGFjZU9uVXNlIj48c3RvcCBvZmZzZXQ9Ii4wOSIgc3RvcC1jb2xvcj0iIzZhYmY0YiIvPjxzdG9wIG9mZnNldD0iLjI5IiBzdG9wLWNvbG9yPSIjNjNiNjQ5Ii8+PHN0b3Agb2Zmc2V0PSIuNiIgc3RvcC1jb2xvcj0iIzUyOWY0NCIvPjxzdG9wIG9mZnNldD0iLjg2IiBzdG9wLWNvbG9yPSIjM2Y4NzNmIi8+PC9saW5lYXJHcmFkaWVudD48bGluZWFyR3JhZGllbnQgaWQ9ImYiIHgxPSIyMC43MiIgeTE9IjM2LjQxIiB4Mj0iMzguMzMiIHkyPSIzNi40MSIgeGxpbms6aHJlZj0iI2UiLz48bGluZWFyR3JhZGllbnQgaWQ9ImciIHgxPSIyMC43MiIgeTE9IjQxLjQ0IiB4Mj0iMzguMzMiIHkyPSI0MS40NCIgeGxpbms6aHJlZj0iI2UiLz48bGluZWFyR3JhZGllbnQgaWQ9ImgiIHgxPSIyMC43MiIgeTE9IjQzLjcyIiB4Mj0iMzguMzMiIHkyPSI0My43MiIgeGxpbms6aHJlZj0iI2UiLz48bGluZWFyR3JhZGllbnQgaWQ9ImkiIHgxPSI0MC45IiB5MT0iMjkuNjgiIHgyPSIzMC4wNCIgeTI9IjUxLjg0IiB4bGluazpocmVmPSIjYSIvPjxjbGlwUGF0aCBpZD0iYyI+PHBhdGggZD0iTTMwIDI2LjgyYS45NC45NCAwIDAwLS45MiAwbC03LjYyIDQuNEEuOTEuOTEgMCAwMDIxIDMydjguOGEuODkuODkgMCAwMC40Ni43OUwyOS4wNyA0NmEuODkuODkgMCAwMC45MyAwbDcuNjEtNC40YS44OS44OSAwIDAwLjQ2LS43OVYzMmEuOTEuOTEgMCAwMC0uNDYtLjh6IiBjbGlwLXJ1bGU9ImV2ZW5vZGQiIGZpbGw9InVybCgjYSkiLz48L2NsaXBQYXRoPjxzdHlsZT4uYntmaWxsOiM2NzllNjN9Lmd7ZmlsbDpub25lfTwvc3R5bGU+PC9kZWZzPjxwYXRoIGNsYXNzPSJiIiBkPSJNMzkuNTQgNjQuNWExLjQ4IDEuNDggMCAwMS0uNzYtLjIxbC0yLjQxLTEuNDJjLS4zNi0uMi0uMTgtLjI4LS4wNi0uMzJhNC42NiA0LjY2IDAgMDAxLjA5LS40OS4xOS4xOSAwIDAxLjE4IDBsMS44NSAxLjFhLjIyLjIyIDAgMDAuMjIgMEw0Ni44OCA1OWEuMjQuMjQgMCAwMC4xMS0uMTl2LTguMzRhLjI2LjI2IDAgMDAtLjExLS4ybC03LjIzLTQuMTdhLjIyLjIyIDAgMDAtLjIyIDBsLTcuMjIgNC4xN2EuMjMuMjMgMCAwMC0uMTEuMnY4LjM0YS4yMS4yMSAwIDAwLjExLjE5bDIgMS4xNGMxLjA3LjU0IDEuNzMtLjA5IDEuNzMtLjczdi04LjIzYS4yMS4yMSAwIDAxLjIxLS4yMWguOTJhLjIxLjIxIDAgMDEuMjEuMjF2OC4yM2EyIDIgMCAwMS0yLjE0IDIuMjYgMy4wNyAzLjA3IDAgMDEtMS42Ny0uNDZsLTEuODktMS4wOWExLjUxIDEuNTEgMCAwMS0uNzYtMS4zMXYtOC4zNGExLjUzIDEuNTMgMCAwMS43Ni0xLjMybDcuMi00LjE1YTEuNTggMS41OCAwIDAxMS41MiAwbDcuMjMgNC4xN2ExLjU0IDEuNTQgMCAwMS43NSAxLjMydjguMzRhMS41MiAxLjUyIDAgMDEtLjc1IDEuMzFsLTcuMjMgNC4xNWExLjQ1IDEuNDUgMCAwMS0uNzYuMjF6Ii8+PHBhdGggY2xhc3M9ImIiIGQ9Ik00MS43NyA1OC43NWMtMy4xNiAwLTMuODItMS40NS0zLjgyLTIuNjZhLjIxLjIxIDAgMDEuMjEtLjIxaC45M2EuMjEuMjEgMCAwMS4yMS4xN2MuMTQgMSAuNTYgMS40MyAyLjQ3IDEuNDMgMS41MiAwIDIuMTctLjM0IDIuMTctMS4xNSAwLS40Ni0uMTgtLjgxLTIuNTUtMS0yLS4yLTMuMi0uNjMtMy4yLTIuMjFzMS4yMy0yLjMzIDMuMjktMi4zM2MyLjMyIDAgMy40Ni44IDMuNjEgMi41M2EuMjUuMjUgMCAwMS0uMDYuMTYuMi4yIDAgMDEtLjE1LjA2aC0uOTRhLjIuMiAwIDAxLS4yLS4xNmMtLjIzLTEtLjc3LTEuMzItMi4yNi0xLjMyLTEuNjYgMC0xLjg1LjU4LTEuODUgMXMuMjMuNjggMi40NyAxIDMuMjcuNzEgMy4yNyAyLjI3LTEuMzEgMi40Mi0zLjYgMi40MnpNNTIuMTkgNTBhMS4zOSAxLjM5IDAgMTEtMS4zOS0xLjM5QTEuMzkgMS4zOSAwIDAxNTIuMTkgNTB6bS0yLjU2IDBhMS4xNyAxLjE3IDAgMDAxLjE2IDEuMTdBMS4xOSAxLjE5IDAgMDA1MiA1MGExLjE3IDEuMTcgMCAxMC0yLjM0IDB6bS42NC0uNzhoLjU0Yy4xOSAwIC41NSAwIC41NS40MWEuMzUuMzUgMCAwMS0uMy4zOGMuMjIgMCAuMjMuMTYuMjYuMzZhMiAyIDAgMDAuMDguNDFoLS4zM2MwLS4wNy0uMDYtLjQ3LS4wNi0uNDlzMC0uMTQtLjE2LS4xNGgtLjI3di42M2gtLjMxem0uMy42OGguMjRhLjIxLjIxIDAgMDAuMjQtLjIyYzAtLjIxLS4xNS0uMjEtLjIzLS4yMWgtLjI1eiIvPjxwYXRoIGQ9Ik0xNy4xNyAzMS44OGEuOTQuOTQgMCAwMC0uNDYtLjgxbC03LjY2LTQuNGEuOTQuOTQgMCAwMC0uNDMtLjEzaC0uMDdhLjk0Ljk0IDAgMDAtLjQzLjEzbC03LjY2IDQuNGEuOTQuOTQgMCAwMC0uNDYuODF2MTEuODdhLjQ1LjQ1IDAgMDAuMjMuNC40Ny40NyAwIDAwLjQ2IDBsNC41NS0yLjYxYS45Mi45MiAwIDAwLjQ2LS44di01LjU1YS45NC45NCAwIDAxLjQ2LS44bDEuOTQtMS4xMmExIDEgMCAwMS40Ny0uMTIgMSAxIDAgMDEuNDYuMTJMMTEgMzQuMzlhLjkzLjkzIDAgMDEuNDcuOHY1LjU1YS45Mi45MiAwIDAwLjQ2LjhsNC41NSAyLjYxYS40Ni40NiAwIDAwLjY5LS40ek01NCAxNS41NmEuNDYuNDYgMCAwMC0uNjguNHYxMS43NmEuMzMuMzMgMCAwMS0uMTcuMjguMzEuMzEgMCAwMS0uMzIgMGwtMS45Mi0xLjExYS45Mi45MiAwIDAwLS45MiAwbC03LjY3IDQuNDJhLjkzLjkzIDAgMDAtLjQ2LjhWNDFhLjk0Ljk0IDAgMDAuNDYuODFMNTAgNDYuMTlhLjg5Ljg5IDAgMDAuOTIgMGw3LjY3LTQuNDJhLjk0Ljk0IDAgMDAuNDYtLjgxdi0yMmEuOTEuOTEgMCAwMC0uNDgtLjh6bS0uNzEgMjIuNWEuMjMuMjMgMCAwMS0uMTEuMmwtMi42MyAxLjUxYS4yLjIgMCAwMS0uMjMgMGwtMi42Mi0xLjUxYS4yMy4yMyAwIDAxLS4xMS0uMlYzNWEuMjMuMjMgMCAwMS4xMS0uMmwyLjY0LTEuNTJhLjI0LjI0IDAgMDEuMjMgMGwyLjYzIDEuNTJhLjIzLjIzIDAgMDEuMTEuMnptMjYuMjUtMy4xMmEuOTMuOTMgMCAwMC40Ni0uOFYzMmEuOTMuOTMgMCAwMC0uNDYtLjhsLTcuNjEtNC40MmEuOTEuOTEgMCAwMC0uOTMgMGwtNy42NiA0LjQyYS45MS45MSAwIDAwLS40Ni44djguODRhLjk0Ljk0IDAgMDAuNDYuODFMNzEgNDZhLjkuOSAwIDAwLjkgMGw0LjYxLTIuNTZhLjQ5LjQ5IDAgMDAuMjQtLjQuNDcuNDcgMCAwMC0uMjQtLjQxbC03Ljc1LTQuNDNhLjQ3LjQ3IDAgMDEtLjIzLS40VjM1YS40Ni40NiAwIDAxLjIzLS40bDIuNC0xLjM5YS40Ny40NyAwIDAxLjQ2IDBMNzQgMzQuNjNhLjQ1LjQ1IDAgMDEuMjQuNHYyLjE4YS40Ni40NiAwIDAwLjY5LjR6IiBmaWxsPSIjMzMzIiBmaWxsLXJ1bGU9ImV2ZW5vZGQiLz48cGF0aCBkPSJNNzEuMzUgMzQuNTNhLjE1LjE1IDAgMDEuMTggMGwxLjQ3Ljg0YS4yMi4yMiAwIDAxLjA5LjE2djEuN2EuMTkuMTkgMCAwMS0uMDkuMTVsLTEuNDcuODVhLjE5LjE5IDAgMDEtLjE4IDBsLTEuNDctLjg1YS4xOS4xOSAwIDAxLS4wOS0uMTV2LTEuN2EuMjIuMjIgMCAwMS4wOS0uMTZ6IiBmaWxsLXJ1bGU9ImV2ZW5vZGQiIGZpbGw9IiM2NzllNjMiLz48cGF0aCBkPSJNMzAgMjYuODJhLjk0Ljk0IDAgMDAtLjkyIDBsLTcuNjIgNC40QS45MS45MSAwIDAwMjEgMzJ2OC44YS44OS44OSAwIDAwLjQ2Ljc5TDI5LjA3IDQ2YS44OS44OSAwIDAwLjkzIDBsNy42MS00LjRhLjg5Ljg5IDAgMDAuNDYtLjc5VjMyYS45MS45MSAwIDAwLS40Ni0uOHoiIGZpbGwtcnVsZT0iZXZlbm9kZCIgZmlsbD0idXJsKCNhKSIvPjxnIGNsaXAtcGF0aD0idXJsKCNjKSI+PHBhdGggY2xhc3M9ImciIGQ9Ik0yOS4wNSAyNi44MmwtNy42NCA0LjRhMSAxIDAgMDAtLjQ5Ljh2OC44YS45MS45MSAwIDAwLjI0LjU4bDguNTgtMTQuNjdhLjkzLjkzIDAgMDAtLjY5LjA5em0uNzMgMTkuMjhBLjg1Ljg1IDAgMDAzMCA0Nmw3LjYyLTQuNGEuOTEuOTEgMCAwMC40OC0uNzlWMzJhLjkuOSAwIDAwLS4yOC0uNjR6Ii8+PHBhdGggZD0iTTM3LjYyIDMxLjIyTDMwIDI2LjgyYTEuMTcgMS4xNyAwIDAwLS4yNC0uMDlsLTguNiAxNC42N2EuNzUuNzUgMCAwMC4yNi4yMUwyOS4wNyA0NmEuODkuODkgMCAwMC43MS4wOWw4LTE0LjcyYTEgMSAwIDAwLS4xNi0uMTV6IiBmaWxsPSJ1cmwoI2QpIi8+PHBhdGggY2xhc3M9ImciIGQ9Ik0zOC4xIDQwLjgyVjMyYTEgMSAwIDAwLS40OC0uOEwzMCAyNi44MmEuOTQuOTQgMCAwMC0uMjgtLjFMMzguMDcgNDFhLjc2Ljc2IDAgMDAuMDMtLjE4em0tMTYuNjktOS42YTEgMSAwIDAwLS40OS44djguOGEuOTMuOTMgMCAwMC41Ljc5TDI5LjA3IDQ2YS44OC44OCAwIDAwLjU5LjEybC04LjItMTQuOTR6Ii8+PHBhdGggZmlsbD0idXJsKCNlKSIgZD0iTTI4LjgxIDI1LjJsLS4xLjA3aC4xNGwtLjA0LS4wN3oiLz48cGF0aCBkPSJNMzcuNjIgNDEuNjFhLjkuOSAwIDAwLjQ1LS41OEwyOS43IDI2LjcyYS45Mi45MiAwIDAwLS42NS4xbC03LjU5IDQuMzcgOC4yIDE0Ljk0QTEuMDYgMS4wNiAwIDAwMzAgNDZ6IiBmaWxsPSJ1cmwoI2YpIi8+PHBhdGggZmlsbD0idXJsKCNnKSIgZD0iTTM4LjMzIDQxLjQ3bC0uMDUtLjA4di4xMWwuMDUtLjAzeiIvPjxwYXRoIGQ9Ik0zNy42MiA0MS42MUwzMCA0NmExLjA2IDEuMDYgMCAwMS0uMzQuMTJsLjE1LjI4IDguNDctNC45MXYtLjExbC0uMjEtLjM4YS45LjkgMCAwMS0uNDUuNjF6IiBmaWxsPSJ1cmwoI2gpIi8+PHBhdGggZD0iTTM3LjYyIDQxLjYxTDMwIDQ2YTEuMDYgMS4wNiAwIDAxLS4zNC4xMmwuMTUuMjggOC40Ny00Ljkxdi0uMTFsLS4yMS0uMzhhLjkuOSAwIDAxLS40NS42MXoiIGZpbGw9InVybCgjaSkiLz48L2c+PC9zdmc+", "Node.js", 2 });

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "AvatarUrl", "Name", "PlatformTypes" },
                values: new object[] { "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdCb3g9IjAgMCA4MCA4MCI+PHBhdGggZmlsbD0iIzg4OTJiZiIgZD0iTTAgMGg4MHY4MEgweiIvPjxwYXRoIGQ9Ik0xMy43MyAyOS40MWg5LjQ5cTQuMTkgMCA2LjA2IDIuMzl0MS4yNCA2LjQ1YTEyLjM4IDEyLjM4IDAgMDEtMS4xIDMuNjcgMTAuNzQgMTAuNzQgMCAwMS0yLjI3IDMuMjQgNy45MiA3LjkyIDAgMDEtMy43OSAyLjMzIDE3LjQ2IDE3LjQ2IDAgMDEtNC4xOC40OWgtNC4yNWwtMS4zNCA2LjdIOC42Nmw1LjA3LTI1LjI3bTQuMTQgNEwxNS43NSA0NGEzIDMgMCAwMC40MiAwaC41YTE4LjU1IDE4LjU1IDAgMDA1LjY3LS42N2MxLjUxLS40OSAyLjUyLTIuMjEgMy01LjE0LjQzLTIuNDcgMC0zLjg5LTEuMjctNC4yN2ExNi4zNCAxNi4zNCAwIDAwLTQuNzEtLjUzIDcuODggNy44OCAwIDAxLS44MiAwaC0uNzRtMTguMzMtMTAuNzFINDFsLTEuMzggNi43M0g0NGE4LjgyIDguODIgMCAwMTUuMzkgMS40OGMxLjIuOTQgMS41NiAyLjcyIDEuMDYgNS4zNkw0OC4xIDQ4aC01bDIuMjctMTEuMjFhMy4xNyAzLjE3IDAgMDAtLjIyLTIuNSAzIDMgMCAwMC0yLjQ0LS43NGgtMy45M0wzNS45MSA0OEgzMWw1LjEtMjUuM20xOS42MiA2LjcxaDkuNDlxNC4xOSAwIDYuMDYgMi4zOXQxLjI0IDYuNDVhMTIuMzggMTIuMzggMCAwMS0xLjEgMy42NyAxMC43NCAxMC43NCAwIDAxLTIuMjcgMy4yNCA3LjkyIDcuOTIgMCAwMS0zLjc5IDIuMzMgMTcuNDYgMTcuNDYgMCAwMS00LjE4LjQ5aC00LjI1bC0xLjM0IDYuN2gtNC45M2w1LjA3LTI1LjI3bTQuMTQgNEw1Ny43NCA0NGEzIDMgMCAwMC40MiAwaC41YTE4LjU1IDE4LjU1IDAgMDA1LjY3LS42N2MxLjUxLS40OSAyLjUyLTIuMjEgMy01LjE0LjQzLTIuNDcgMC0zLjg5LTEuMjctNC4yN2ExNi4yNSAxNi4yNSAwIDAwLTQuNzEtLjUzIDcuODggNy44OCAwIDAxLS44MiAwaC0uNzQiIGZpbGw9IiNmZmYiLz48L3N2Zz4=", "php", 2 });

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "AvatarUrl", "Name", "PlatformTypes" },
                values: new object[] { "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdCb3g9IjAgMCA4MCA4MCI+PGRlZnM+PGxpbmVhckdyYWRpZW50IGlkPSJhIiB4MT0iMTM2LjEzIiB5MT0iLTIzMy44OCIgeDI9IjIxMy43MyIgeTI9Ii0zMDAuNjQiIGdyYWRpZW50VHJhbnNmb3JtPSJtYXRyaXgoLjU2IDAgMCAtLjU3IC03OC4wOCAtMTMwLjU2KSIgZ3JhZGllbnRVbml0cz0idXNlclNwYWNlT25Vc2UiPjxzdG9wIG9mZnNldD0iMCIgc3RvcC1jb2xvcj0iIzVhOWZkNCIvPjxzdG9wIG9mZnNldD0iMSIgc3RvcC1jb2xvcj0iIzMwNjk5OCIvPjwvbGluZWFyR3JhZGllbnQ+PGxpbmVhckdyYWRpZW50IGlkPSJiIiB4MT0iMjQzLjczIiB5MT0iLTM0MS4wNSIgeDI9IjIxNi4wMiIgeTI9Ii0zMDEuODUiIGdyYWRpZW50VHJhbnNmb3JtPSJtYXRyaXgoLjU2IDAgMCAtLjU3IC03OC4wOCAtMTMwLjU2KSIgZ3JhZGllbnRVbml0cz0idXNlclNwYWNlT25Vc2UiPjxzdG9wIG9mZnNldD0iMCIgc3RvcC1jb2xvcj0iI2ZmZDQzYiIvPjxzdG9wIG9mZnNldD0iMSIgc3RvcC1jb2xvcj0iI2ZmZTg3MyIvPjwvbGluZWFyR3JhZGllbnQ+PC9kZWZzPjxwYXRoIGQ9Ik0zOS41MyAwYTU0LjQ5IDU0LjQ5IDAgMDAtOS4xMi43OGMtOC4wOCAxLjQzLTkuNTQgNC40MS05LjU0IDkuOTJWMThINDB2Mi40SDEzLjdjLTUuNTQgMC0xMC40IDMuMzMtMTEuOTIgOS42N0MwIDM3LjM0IDAgNDEuODggMS43OCA0OS40N2MxLjM2IDUuNjUgNC42IDkuNjggMTAuMTQgOS42OGg2LjU3di04LjcyYTEyLjEzIDEyLjEzIDAgMDExMS45Mi0xMS44NmgxOS4wNmE5LjYxIDkuNjEgMCAwMDkuNTMtOS43VjEwLjdjMC01LjE3LTQuMzYtOS4wNi05LjU0LTkuOTJBNTkuNjMgNTkuNjMgMCAwMDM5LjUzIDB6TTI5LjIxIDUuODVhMy42NCAzLjY0IDAgMTEtMy41OCAzLjY1IDMuNjIgMy42MiAwIDAxMy41OC0zLjY1eiIgZmlsbD0idXJsKCNhKSIvPjxwYXRoIGQ9Ik02MS4zOSAyMC40djguNDdBMTIuMjQgMTIuMjQgMCAwMTQ5LjQ3IDQxSDMwLjQxYTkuNzQgOS43NCAwIDAwLTkuNTQgOS43djE4LjE1YzAgNS4xNyA0LjQ5IDguMjEgOS41NCA5LjY5YTMxLjg3IDMxLjg3IDAgMDAxOS4wNiAwYzQuODEtMS4zOSA5LjUzLTQuMTkgOS41My05LjY5di03LjI4SDQwdi0yLjQyaDI4LjU2YzUuNTQgMCA3LjYxLTMuODcgOS41NC05LjY4IDItNiAxLjkxLTExLjczIDAtMTkuNC0xLjM3LTUuNTItNC05LjY3LTkuNTQtOS42N3ptLTEwLjcyIDQ2YTMuNjQgMy42NCAwIDExLTMuNTggMy42MyAzLjYgMy42IDAgMDEzLjU4LTMuNjF6IiBmaWxsPSJ1cmwoI2IpIi8+PC9zdmc+", "python", 2 });

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "AvatarUrl", "Name", "PlatformTypes" },
                values: new object[] { "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdCb3g9IjAgMCA4MCA4MCI+PGRlZnM+PHN0eWxlPi5ie2ZpbGw6I2ZmZn08L3N0eWxlPjwvZGVmcz48cGF0aCBmaWxsPSIjMDkyZTIwIiBkPSJNMC0uMTFoODAuMTFWODBIMHoiLz48cGF0aCBjbGFzcz0iYiIgZD0iTTEzLjggMjguMjRoMy43OXYxNy41NGEyNSAyNSAwIDAxLTQuOTIuNTJjLTQuNjMgMC03LTIuMDktNy02LjFzMi41Ni02LjM4IDYuNTItNi4zOGE2IDYgMCAwMTEuNjUuMnYtNS43OHptMCA4LjgzYTMuNjkgMy42OSAwIDAwLTEuMjgtLjJjLTEuOTIgMC0zIDEuMTgtMyAzLjI1czEuMDYgMy4xMyAzIDMuMTNhOS40NSA5LjQ1IDAgMDAxLjMxLS4xeiIvPjxwYXRoIGNsYXNzPSJiIiBkPSJNMjMuNjEgMzQuMDl2OC43OWMwIDMtLjIyIDQuNDctLjg4IDUuNzNhNi4wOCA2LjA4IDAgMDEtMy4xIDIuOGwtMy41Mi0xLjY3YTUuNSA1LjUgMCAwMDMtMi41M2MuNTQtMS4wOS43Mi0yLjM0LjcyLTUuNjR2LTcuNDh6bS0zLjc4LTUuODNoMy43OHYzLjg5aC0zLjc4ek0yNS45IDM1YTExLjM4IDExLjM4IDAgMDE1LTEuMTRjMS45NCAwIDMuMjIuNTIgMy43OSAxLjUzYTUuODEgNS44MSAwIDAxLjQyIDIuODh2Ny43YTQyLjg0IDQyLjg0IDAgMDEtNS40MS40MmMtMy4xOCAwLTQuNjEtMS4xMS00LjYxLTMuNTcgMC0yLjY2IDEuOS0zLjg5IDYuNTUtNC4yOHYtLjg0YzAtLjY5LS4zNS0uOTMtMS4zMS0uOTNhMTAgMTAgMCAwMC00LjQ1IDEuMTVWMzV6bTUuOTMgNmMtMi41MS4yNS0zLjMyLjY0LTMuMzIgMS42MyAwIC43My40NyAxLjA4IDEuNSAxLjA4YTEwLjcgMTAuNyAwIDAwMS44Mi0uMTdWNDF6TTM3IDM0LjY4YTIyLjc5IDIyLjc5IDAgMDE2LS44NiA1LjY4IDUuNjggMCAwMTQuMTggMS4zMWMuNzkuODEgMSAxLjY5IDEgMy41OXY3LjQzaC0zLjgzdi03LjI4YzAtMS40NS0uNDktMi0xLjg0LTJhNS43NCA1Ljc0IDAgMDAtMS43NS4yN3Y5SDM3VjM0LjY4em0xMi42MSAxMy41NGE4LjczIDguNzMgMCAwMDQuMDYgMWMyLjQ5IDAgMy41NS0xIDMuNTUtMy40MnYtLjA3YTUuMTkgNS4xOSAwIDAxLTIuNDYuNTJjLTMuMzMgMC01LjQ0LTIuMTktNS40NC01LjY2IDAtNC4zMSAzLjEyLTYuNzQgOC42Ni02Ljc0YTIzLjgyIDIzLjgyIDAgMDE0Ljk0LjU0bC0xLjI5IDIuNzNjLTEtLjE5LS4wOSAwLS44NS0uMXY2LjYxYzAgMy4yNS0uMjggNC43OC0xLjA5IDYtMS4xOCAxLjg1LTMuMjIgMi43Ni02LjEyIDIuNzZhMTEgMTEgMCAwMS00LjA5LS43NHYtMy40M3ptNy41My0xMS4zMmgtLjM5YTQuMDggNC4wOCAwIDAwLTIuMTkuNTQgMi45NCAyLjk0IDAgMDAtMS4zOCAyLjc4YzAgMS44OS45NCAzIDIuNjEgM2E0LjY3IDQuNjcgMCAwMDEuNDMtLjIydi02LjF6bTExLjY2LTMuMTNjMy43OSAwIDYuMTEgMi4zOSA2LjExIDYuMjVzLTIuNDIgNi40NS02LjI1IDYuNDUtNi4xMy0yLjM5LTYuMTMtNi4yMyAyLjQxLTYuNDcgNi4yNy02LjQ3em0tLjA3IDkuNjVjMS40NSAwIDIuMzEtMS4yMSAyLjMxLTMuM3MtLjgzLTMuMy0yLjI4LTMuMy0yLjM3IDEuMjEtMi4zNyAzLjMuODYgMy4zIDIuMzQgMy4zeiIvPjwvc3ZnPg==", "django", 2 });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "AvatarUrl", "Name", "PlatformTypes" },
                values: new object[,]
                {
                    { 18, "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdCb3g9IjAgMCA4MCA4MCI+PHBhdGggZmlsbD0iIzUxMmJkNCIgZD0iTTAgMGg4MHY4MEgweiIvPjxwYXRoIGQ9Ik0xNC4yNiA1MS4xMWEyIDIgMCAwMS0xLjQ0LS41NiAxLjkgMS45IDAgMDEwLTIuNzcgMiAyIDAgMDExLjQ0LS41OCAyIDIgMCAwMTEuNDUuNTggMS44OCAxLjg4IDAgMDEwIDIuNzcgMiAyIDAgMDEtMS40NS41NnptMjIuNjEtLjMyaC0zLjY4bC05LjY4LTE1LjI4YTYuNzggNi43OCAwIDAxLS42MS0xLjJoLS4wOWEyMC41MyAyMC41MyAwIDAxLjEyIDIuODV2MTMuNjNoLTMuMjZWMzBoMy45MkwzMyA0NC45MmMuNC42Mi42NSAxIC43NyAxLjI4aC4wNWExOS42OCAxOS42OCAwIDAxLS4xNC0yLjhWMzBoMy4yNHptMTUuODQgMEg0MS4zM1YzMGgxMC45M3YyLjkzaC03LjU3djUuODloN3YyLjkxaC03djYuMTVoOHptMTYuMTgtMTcuODZoLTUuODN2MTcuODZoLTMuMzdWMzIuOTNoLTUuODFWMzBoMTV6IiBmaWxsPSIjZmZmIi8+PC9zdmc+", "Windows Presentation Foundation", 8 },
                    { 17, "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdCb3g9IjAgMCA4MCA4MCI+PGRlZnM+PHN0eWxlPi5ke2ZpbGw6I2ZmZn08L3N0eWxlPjwvZGVmcz48cGF0aCBkPSJNNzYuMjUgMjZ2MjhhMTIgMTIgMCAwMS0xLjY0IDZMNDAgNDBsMzQuNjItMjBhMTEuOTQgMTEuOTQgMCAwMTEuNjMgNnoiIGZpbGw9IiMwMDU5OWMiLz48cGF0aCBkPSJNNzQuNjIgMjBMNDAgNDAgNS40MSA2MGExMS45MiAxMS45MiAwIDAxLTEuNjYtNlYyNmExMiAxMiAwIDAxNi0xMC4zOUwzNCAxLjYxYTEyIDEyIDAgMDExMiAwbDI0LjI1IDE0QTExLjgyIDExLjgyIDAgMDE3NC42MiAyMHoiIGZpbGw9IiM2NTlhZDIiLz48cGF0aCBkPSJNNDAgNDBsMzQuNjEgMjBhMTIgMTIgMCAwMS00LjM2IDQuMzRMNDYgNzguMzlhMTIgMTIgMCAwMS0xMiAwbC0yNC4yNS0xNGExMiAxMiAwIDAxLTQuMzQtNC4zMnoiIGZpbGw9IiMwMDQ0ODIiLz48cGF0aCBjbGFzcz0iZCIgZD0iTTYxLjc5IDM4LjVoMi41MXYzLjA0aC0yLjUxdjIuNTFoLTMuMDV2LTIuNTFoLTIuNVYzOC41aDIuNXYtMi41MWgzLjA1djIuNTF6bTkuODEgMGgyLjV2My4wNGgtMi41djIuNTFoLTMuMDV2LTIuNTFoLTIuNVYzOC41aDIuNXYtMi41MWgzLjA1djIuNTF6Ii8+PHBhdGggY2xhc3M9ImQiIGQ9Ik02MSA1Mi4xNWEyNC4yMiAyNC4yMiAwIDExMC0yNC4yNkw1MC4zOCAzNHEtLjIxLS4zNy0uNDUtLjcyQTEyIDEyIDAgMTA1MC4zNiA0NnoiLz48L3N2Zz4=", "Native", 10 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DropColumn(
                name: "PlatformTypes",
                table: "Platforms");

            migrationBuilder.CreateTable(
                name: "PlatformTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlatformsPlatformsType",
                columns: table => new
                {
                    PlatformId = table.Column<int>(type: "int", nullable: false),
                    PlatformTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformsPlatformsType", x => new { x.PlatformId, x.PlatformTypeId });
                    table.ForeignKey(
                        name: "FK_PlatformsPlatformsType_Platforms_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Platforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlatformsPlatformsType_PlatformTypes_PlatformTypeId",
                        column: x => x.PlatformTypeId,
                        principalTable: "PlatformTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PlatformTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "browser" },
                    { 2, "server" },
                    { 3, "mobile" },
                    { 4, "desktop" }
                });

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "AvatarUrl", "Name" },
                values: new object[] { "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdCb3g9IjAgMCA4MCA4MCI+PHBhdGggZD0iTTQ5LjI0IDUuNzFMNDAgMjEuNTUgMzAuNzcgNS43MUgwbDQwIDY4LjU4TDgwIDUuNzF6IiBmaWxsPSIjNDJjMThjIi8+PHBhdGggZD0iTTQ5LjI0IDUuNzFMNDAgMjEuNTUgMzAuNzcgNS43MUgxNmwyNCA0MS4xNUw2NCA1LjcxeiIgZmlsbD0iIzNiNTM2YSIvPjwvc3ZnPg==", "Vue" });

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "AvatarUrl", "Name" },
                values: new object[] { "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHhtbG5zOnhsaW5rPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5L3hsaW5rIiB2aWV3Qm94PSIwIDAgODAgODAiPjxkZWZzPjxsaW5lYXJHcmFkaWVudCBpZD0iYSIgeDE9IjMyLjYyIiB5MT0iMzAuMSIgeDI9IjI1Ljc0IiB5Mj0iNDQuMTQiIGdyYWRpZW50VW5pdHM9InVzZXJTcGFjZU9uVXNlIj48c3RvcCBvZmZzZXQ9IjAiIHN0b3AtY29sb3I9IiMzZjg3M2YiLz48c3RvcCBvZmZzZXQ9Ii4zMyIgc3RvcC1jb2xvcj0iIzNmOGIzZCIvPjxzdG9wIG9mZnNldD0iLjY0IiBzdG9wLWNvbG9yPSIjM2U5NjM3Ii8+PHN0b3Agb2Zmc2V0PSIuOTMiIHN0b3AtY29sb3I9IiMzZGE5MmUiLz48c3RvcCBvZmZzZXQ9IjEiIHN0b3AtY29sb3I9IiMzZGFlMmIiLz48L2xpbmVhckdyYWRpZW50PjxsaW5lYXJHcmFkaWVudCBpZD0iZCIgeDE9IjI4LjM3IiB5MT0iMzcuNDUiIHgyPSI0Ny42OCIgeTI9IjIzLjE3IiBncmFkaWVudFVuaXRzPSJ1c2VyU3BhY2VPblVzZSI+PHN0b3Agb2Zmc2V0PSIuMTQiIHN0b3AtY29sb3I9IiMzZjg3M2YiLz48c3RvcCBvZmZzZXQ9Ii40IiBzdG9wLWNvbG9yPSIjNTI5ZjQ0Ii8+PHN0b3Agb2Zmc2V0PSIuNzEiIHN0b3AtY29sb3I9IiM2M2I2NDkiLz48c3RvcCBvZmZzZXQ9Ii45MSIgc3RvcC1jb2xvcj0iIzZhYmY0YiIvPjwvbGluZWFyR3JhZGllbnQ+PGxpbmVhckdyYWRpZW50IGlkPSJlIiB4MT0iMjAuNzIiIHkxPSIyNS4yMyIgeDI9IjM4LjMzIiB5Mj0iMjUuMjMiIGdyYWRpZW50VW5pdHM9InVzZXJTcGFjZU9uVXNlIj48c3RvcCBvZmZzZXQ9Ii4wOSIgc3RvcC1jb2xvcj0iIzZhYmY0YiIvPjxzdG9wIG9mZnNldD0iLjI5IiBzdG9wLWNvbG9yPSIjNjNiNjQ5Ii8+PHN0b3Agb2Zmc2V0PSIuNiIgc3RvcC1jb2xvcj0iIzUyOWY0NCIvPjxzdG9wIG9mZnNldD0iLjg2IiBzdG9wLWNvbG9yPSIjM2Y4NzNmIi8+PC9saW5lYXJHcmFkaWVudD48bGluZWFyR3JhZGllbnQgaWQ9ImYiIHgxPSIyMC43MiIgeTE9IjM2LjQxIiB4Mj0iMzguMzMiIHkyPSIzNi40MSIgeGxpbms6aHJlZj0iI2UiLz48bGluZWFyR3JhZGllbnQgaWQ9ImciIHgxPSIyMC43MiIgeTE9IjQxLjQ0IiB4Mj0iMzguMzMiIHkyPSI0MS40NCIgeGxpbms6aHJlZj0iI2UiLz48bGluZWFyR3JhZGllbnQgaWQ9ImgiIHgxPSIyMC43MiIgeTE9IjQzLjcyIiB4Mj0iMzguMzMiIHkyPSI0My43MiIgeGxpbms6aHJlZj0iI2UiLz48bGluZWFyR3JhZGllbnQgaWQ9ImkiIHgxPSI0MC45IiB5MT0iMjkuNjgiIHgyPSIzMC4wNCIgeTI9IjUxLjg0IiB4bGluazpocmVmPSIjYSIvPjxjbGlwUGF0aCBpZD0iYyI+PHBhdGggZD0iTTMwIDI2LjgyYS45NC45NCAwIDAwLS45MiAwbC03LjYyIDQuNEEuOTEuOTEgMCAwMDIxIDMydjguOGEuODkuODkgMCAwMC40Ni43OUwyOS4wNyA0NmEuODkuODkgMCAwMC45MyAwbDcuNjEtNC40YS44OS44OSAwIDAwLjQ2LS43OVYzMmEuOTEuOTEgMCAwMC0uNDYtLjh6IiBjbGlwLXJ1bGU9ImV2ZW5vZGQiIGZpbGw9InVybCgjYSkiLz48L2NsaXBQYXRoPjxzdHlsZT4uYntmaWxsOiM2NzllNjN9Lmd7ZmlsbDpub25lfTwvc3R5bGU+PC9kZWZzPjxwYXRoIGNsYXNzPSJiIiBkPSJNMzkuNTQgNjQuNWExLjQ4IDEuNDggMCAwMS0uNzYtLjIxbC0yLjQxLTEuNDJjLS4zNi0uMi0uMTgtLjI4LS4wNi0uMzJhNC42NiA0LjY2IDAgMDAxLjA5LS40OS4xOS4xOSAwIDAxLjE4IDBsMS44NSAxLjFhLjIyLjIyIDAgMDAuMjIgMEw0Ni44OCA1OWEuMjQuMjQgMCAwMC4xMS0uMTl2LTguMzRhLjI2LjI2IDAgMDAtLjExLS4ybC03LjIzLTQuMTdhLjIyLjIyIDAgMDAtLjIyIDBsLTcuMjIgNC4xN2EuMjMuMjMgMCAwMC0uMTEuMnY4LjM0YS4yMS4yMSAwIDAwLjExLjE5bDIgMS4xNGMxLjA3LjU0IDEuNzMtLjA5IDEuNzMtLjczdi04LjIzYS4yMS4yMSAwIDAxLjIxLS4yMWguOTJhLjIxLjIxIDAgMDEuMjEuMjF2OC4yM2EyIDIgMCAwMS0yLjE0IDIuMjYgMy4wNyAzLjA3IDAgMDEtMS42Ny0uNDZsLTEuODktMS4wOWExLjUxIDEuNTEgMCAwMS0uNzYtMS4zMXYtOC4zNGExLjUzIDEuNTMgMCAwMS43Ni0xLjMybDcuMi00LjE1YTEuNTggMS41OCAwIDAxMS41MiAwbDcuMjMgNC4xN2ExLjU0IDEuNTQgMCAwMS43NSAxLjMydjguMzRhMS41MiAxLjUyIDAgMDEtLjc1IDEuMzFsLTcuMjMgNC4xNWExLjQ1IDEuNDUgMCAwMS0uNzYuMjF6Ii8+PHBhdGggY2xhc3M9ImIiIGQ9Ik00MS43NyA1OC43NWMtMy4xNiAwLTMuODItMS40NS0zLjgyLTIuNjZhLjIxLjIxIDAgMDEuMjEtLjIxaC45M2EuMjEuMjEgMCAwMS4yMS4xN2MuMTQgMSAuNTYgMS40MyAyLjQ3IDEuNDMgMS41MiAwIDIuMTctLjM0IDIuMTctMS4xNSAwLS40Ni0uMTgtLjgxLTIuNTUtMS0yLS4yLTMuMi0uNjMtMy4yLTIuMjFzMS4yMy0yLjMzIDMuMjktMi4zM2MyLjMyIDAgMy40Ni44IDMuNjEgMi41M2EuMjUuMjUgMCAwMS0uMDYuMTYuMi4yIDAgMDEtLjE1LjA2aC0uOTRhLjIuMiAwIDAxLS4yLS4xNmMtLjIzLTEtLjc3LTEuMzItMi4yNi0xLjMyLTEuNjYgMC0xLjg1LjU4LTEuODUgMXMuMjMuNjggMi40NyAxIDMuMjcuNzEgMy4yNyAyLjI3LTEuMzEgMi40Mi0zLjYgMi40MnpNNTIuMTkgNTBhMS4zOSAxLjM5IDAgMTEtMS4zOS0xLjM5QTEuMzkgMS4zOSAwIDAxNTIuMTkgNTB6bS0yLjU2IDBhMS4xNyAxLjE3IDAgMDAxLjE2IDEuMTdBMS4xOSAxLjE5IDAgMDA1MiA1MGExLjE3IDEuMTcgMCAxMC0yLjM0IDB6bS42NC0uNzhoLjU0Yy4xOSAwIC41NSAwIC41NS40MWEuMzUuMzUgMCAwMS0uMy4zOGMuMjIgMCAuMjMuMTYuMjYuMzZhMiAyIDAgMDAuMDguNDFoLS4zM2MwLS4wNy0uMDYtLjQ3LS4wNi0uNDlzMC0uMTQtLjE2LS4xNGgtLjI3di42M2gtLjMxem0uMy42OGguMjRhLjIxLjIxIDAgMDAuMjQtLjIyYzAtLjIxLS4xNS0uMjEtLjIzLS4yMWgtLjI1eiIvPjxwYXRoIGQ9Ik0xNy4xNyAzMS44OGEuOTQuOTQgMCAwMC0uNDYtLjgxbC03LjY2LTQuNGEuOTQuOTQgMCAwMC0uNDMtLjEzaC0uMDdhLjk0Ljk0IDAgMDAtLjQzLjEzbC03LjY2IDQuNGEuOTQuOTQgMCAwMC0uNDYuODF2MTEuODdhLjQ1LjQ1IDAgMDAuMjMuNC40Ny40NyAwIDAwLjQ2IDBsNC41NS0yLjYxYS45Mi45MiAwIDAwLjQ2LS44di01LjU1YS45NC45NCAwIDAxLjQ2LS44bDEuOTQtMS4xMmExIDEgMCAwMS40Ny0uMTIgMSAxIDAgMDEuNDYuMTJMMTEgMzQuMzlhLjkzLjkzIDAgMDEuNDcuOHY1LjU1YS45Mi45MiAwIDAwLjQ2LjhsNC41NSAyLjYxYS40Ni40NiAwIDAwLjY5LS40ek01NCAxNS41NmEuNDYuNDYgMCAwMC0uNjguNHYxMS43NmEuMzMuMzMgMCAwMS0uMTcuMjguMzEuMzEgMCAwMS0uMzIgMGwtMS45Mi0xLjExYS45Mi45MiAwIDAwLS45MiAwbC03LjY3IDQuNDJhLjkzLjkzIDAgMDAtLjQ2LjhWNDFhLjk0Ljk0IDAgMDAuNDYuODFMNTAgNDYuMTlhLjg5Ljg5IDAgMDAuOTIgMGw3LjY3LTQuNDJhLjk0Ljk0IDAgMDAuNDYtLjgxdi0yMmEuOTEuOTEgMCAwMC0uNDgtLjh6bS0uNzEgMjIuNWEuMjMuMjMgMCAwMS0uMTEuMmwtMi42MyAxLjUxYS4yLjIgMCAwMS0uMjMgMGwtMi42Mi0xLjUxYS4yMy4yMyAwIDAxLS4xMS0uMlYzNWEuMjMuMjMgMCAwMS4xMS0uMmwyLjY0LTEuNTJhLjI0LjI0IDAgMDEuMjMgMGwyLjYzIDEuNTJhLjIzLjIzIDAgMDEuMTEuMnptMjYuMjUtMy4xMmEuOTMuOTMgMCAwMC40Ni0uOFYzMmEuOTMuOTMgMCAwMC0uNDYtLjhsLTcuNjEtNC40MmEuOTEuOTEgMCAwMC0uOTMgMGwtNy42NiA0LjQyYS45MS45MSAwIDAwLS40Ni44djguODRhLjk0Ljk0IDAgMDAuNDYuODFMNzEgNDZhLjkuOSAwIDAwLjkgMGw0LjYxLTIuNTZhLjQ5LjQ5IDAgMDAuMjQtLjQuNDcuNDcgMCAwMC0uMjQtLjQxbC03Ljc1LTQuNDNhLjQ3LjQ3IDAgMDEtLjIzLS40VjM1YS40Ni40NiAwIDAxLjIzLS40bDIuNC0xLjM5YS40Ny40NyAwIDAxLjQ2IDBMNzQgMzQuNjNhLjQ1LjQ1IDAgMDEuMjQuNHYyLjE4YS40Ni40NiAwIDAwLjY5LjR6IiBmaWxsPSIjMzMzIiBmaWxsLXJ1bGU9ImV2ZW5vZGQiLz48cGF0aCBkPSJNNzEuMzUgMzQuNTNhLjE1LjE1IDAgMDEuMTggMGwxLjQ3Ljg0YS4yMi4yMiAwIDAxLjA5LjE2djEuN2EuMTkuMTkgMCAwMS0uMDkuMTVsLTEuNDcuODVhLjE5LjE5IDAgMDEtLjE4IDBsLTEuNDctLjg1YS4xOS4xOSAwIDAxLS4wOS0uMTV2LTEuN2EuMjIuMjIgMCAwMS4wOS0uMTZ6IiBmaWxsLXJ1bGU9ImV2ZW5vZGQiIGZpbGw9IiM2NzllNjMiLz48cGF0aCBkPSJNMzAgMjYuODJhLjk0Ljk0IDAgMDAtLjkyIDBsLTcuNjIgNC40QS45MS45MSAwIDAwMjEgMzJ2OC44YS44OS44OSAwIDAwLjQ2Ljc5TDI5LjA3IDQ2YS44OS44OSAwIDAwLjkzIDBsNy42MS00LjRhLjg5Ljg5IDAgMDAuNDYtLjc5VjMyYS45MS45MSAwIDAwLS40Ni0uOHoiIGZpbGwtcnVsZT0iZXZlbm9kZCIgZmlsbD0idXJsKCNhKSIvPjxnIGNsaXAtcGF0aD0idXJsKCNjKSI+PHBhdGggY2xhc3M9ImciIGQ9Ik0yOS4wNSAyNi44MmwtNy42NCA0LjRhMSAxIDAgMDAtLjQ5Ljh2OC44YS45MS45MSAwIDAwLjI0LjU4bDguNTgtMTQuNjdhLjkzLjkzIDAgMDAtLjY5LjA5em0uNzMgMTkuMjhBLjg1Ljg1IDAgMDAzMCA0Nmw3LjYyLTQuNGEuOTEuOTEgMCAwMC40OC0uNzlWMzJhLjkuOSAwIDAwLS4yOC0uNjR6Ii8+PHBhdGggZD0iTTM3LjYyIDMxLjIyTDMwIDI2LjgyYTEuMTcgMS4xNyAwIDAwLS4yNC0uMDlsLTguNiAxNC42N2EuNzUuNzUgMCAwMC4yNi4yMUwyOS4wNyA0NmEuODkuODkgMCAwMC43MS4wOWw4LTE0LjcyYTEgMSAwIDAwLS4xNi0uMTV6IiBmaWxsPSJ1cmwoI2QpIi8+PHBhdGggY2xhc3M9ImciIGQ9Ik0zOC4xIDQwLjgyVjMyYTEgMSAwIDAwLS40OC0uOEwzMCAyNi44MmEuOTQuOTQgMCAwMC0uMjgtLjFMMzguMDcgNDFhLjc2Ljc2IDAgMDAuMDMtLjE4em0tMTYuNjktOS42YTEgMSAwIDAwLS40OS44djguOGEuOTMuOTMgMCAwMC41Ljc5TDI5LjA3IDQ2YS44OC44OCAwIDAwLjU5LjEybC04LjItMTQuOTR6Ii8+PHBhdGggZmlsbD0idXJsKCNlKSIgZD0iTTI4LjgxIDI1LjJsLS4xLjA3aC4xNGwtLjA0LS4wN3oiLz48cGF0aCBkPSJNMzcuNjIgNDEuNjFhLjkuOSAwIDAwLjQ1LS41OEwyOS43IDI2LjcyYS45Mi45MiAwIDAwLS42NS4xbC03LjU5IDQuMzcgOC4yIDE0Ljk0QTEuMDYgMS4wNiAwIDAwMzAgNDZ6IiBmaWxsPSJ1cmwoI2YpIi8+PHBhdGggZmlsbD0idXJsKCNnKSIgZD0iTTM4LjMzIDQxLjQ3bC0uMDUtLjA4di4xMWwuMDUtLjAzeiIvPjxwYXRoIGQ9Ik0zNy42MiA0MS42MUwzMCA0NmExLjA2IDEuMDYgMCAwMS0uMzQuMTJsLjE1LjI4IDguNDctNC45MXYtLjExbC0uMjEtLjM4YS45LjkgMCAwMS0uNDUuNjF6IiBmaWxsPSJ1cmwoI2gpIi8+PHBhdGggZD0iTTM3LjYyIDQxLjYxTDMwIDQ2YTEuMDYgMS4wNiAwIDAxLS4zNC4xMmwuMTUuMjggOC40Ny00Ljkxdi0uMTFsLS4yMS0uMzhhLjkuOSAwIDAxLS40NS42MXoiIGZpbGw9InVybCgjaSkiLz48L2c+PC9zdmc+", "Node.js" });

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "AvatarUrl", "Name" },
                values: new object[] { "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdCb3g9IjAgMCA4MCA4MCI+PHBhdGggZmlsbD0iIzg4OTJiZiIgZD0iTTAgMGg4MHY4MEgweiIvPjxwYXRoIGQ9Ik0xMy43MyAyOS40MWg5LjQ5cTQuMTkgMCA2LjA2IDIuMzl0MS4yNCA2LjQ1YTEyLjM4IDEyLjM4IDAgMDEtMS4xIDMuNjcgMTAuNzQgMTAuNzQgMCAwMS0yLjI3IDMuMjQgNy45MiA3LjkyIDAgMDEtMy43OSAyLjMzIDE3LjQ2IDE3LjQ2IDAgMDEtNC4xOC40OWgtNC4yNWwtMS4zNCA2LjdIOC42Nmw1LjA3LTI1LjI3bTQuMTQgNEwxNS43NSA0NGEzIDMgMCAwMC40MiAwaC41YTE4LjU1IDE4LjU1IDAgMDA1LjY3LS42N2MxLjUxLS40OSAyLjUyLTIuMjEgMy01LjE0LjQzLTIuNDcgMC0zLjg5LTEuMjctNC4yN2ExNi4zNCAxNi4zNCAwIDAwLTQuNzEtLjUzIDcuODggNy44OCAwIDAxLS44MiAwaC0uNzRtMTguMzMtMTAuNzFINDFsLTEuMzggNi43M0g0NGE4LjgyIDguODIgMCAwMTUuMzkgMS40OGMxLjIuOTQgMS41NiAyLjcyIDEuMDYgNS4zNkw0OC4xIDQ4aC01bDIuMjctMTEuMjFhMy4xNyAzLjE3IDAgMDAtLjIyLTIuNSAzIDMgMCAwMC0yLjQ0LS43NGgtMy45M0wzNS45MSA0OEgzMWw1LjEtMjUuM20xOS42MiA2LjcxaDkuNDlxNC4xOSAwIDYuMDYgMi4zOXQxLjI0IDYuNDVhMTIuMzggMTIuMzggMCAwMS0xLjEgMy42NyAxMC43NCAxMC43NCAwIDAxLTIuMjcgMy4yNCA3LjkyIDcuOTIgMCAwMS0zLjc5IDIuMzMgMTcuNDYgMTcuNDYgMCAwMS00LjE4LjQ5aC00LjI1bC0xLjM0IDYuN2gtNC45M2w1LjA3LTI1LjI3bTQuMTQgNEw1Ny43NCA0NGEzIDMgMCAwMC40MiAwaC41YTE4LjU1IDE4LjU1IDAgMDA1LjY3LS42N2MxLjUxLS40OSAyLjUyLTIuMjEgMy01LjE0LjQzLTIuNDcgMC0zLjg5LTEuMjctNC4yN2ExNi4yNSAxNi4yNSAwIDAwLTQuNzEtLjUzIDcuODggNy44OCAwIDAxLS44MiAwaC0uNzQiIGZpbGw9IiNmZmYiLz48L3N2Zz4=", "php" });

            migrationBuilder.UpdateData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "AvatarUrl", "Name" },
                values: new object[] { "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdCb3g9IjAgMCA4MCA4MCI+PGRlZnM+PHN0eWxlPi5he2ZpbGw6IzAxNTc5Yn0uZHtmaWxsOiNmZmY7b3BhY2l0eTouMjtpc29sYXRpb246aXNvbGF0ZX08L3N0eWxlPjwvZGVmcz48cGF0aCBjbGFzcz0iYSIgZD0iTTE2LjMyIDYzLjY3TDIuNjMgNTBBOS4yNyA5LjI3IDAgMDEwIDQzLjY3IDEwLjU3IDEwLjU3IDAgMDExLjA1IDQwbDEyLjY0LTI2LjMzeiIvPjxwYXRoIGQ9Ik02My4xNiAxNi4zTDQ5LjQ4IDIuNjJBOS40NyA5LjQ3IDAgMDA0My42OSAwIDkuNzIgOS43MiAwIDAwMzkgMUwxMy42OSAxMy42N3pNMzIuNjMgNzkuOTloMzMuMTZWNjUuNzhsLTI0Ljc0LTcuOS0yMi42MyA3LjkgMTQuMjEgMTQuMjF6IiBmaWxsPSIjNDBjNGZmIi8+PHBhdGggZD0iTTEzLjY5IDU2LjNjMCA0LjIyLjUzIDUuMjYgMi42MyA3LjM3bDIuMSAyLjExaDQ3LjM3TDQyLjYzIDM5LjQ2IDEzLjY5IDEzLjY3eiIgZmlsbD0iIzI5YjZmNiIvPjxwYXRoIGNsYXNzPSJhIiBkPSJNNTUuNzkgMTMuNjdoLTQyLjFsNTIuMSA1Mi4xSDgwVjMzLjE0TDYzLjE2IDE2LjNjLTIuMzctMi4zNy00LjQ3LTIuNjMtNy4zNy0yLjYzeiIvPjxwYXRoIGNsYXNzPSJkIiBkPSJNMTYuODQgNjQuMTljLTIuMS0yLjExLTIuNjItNC4xOS0yLjYyLTcuODlWMTQuMmwtLjUzLS41M1Y1Ni4zYzAgMy43IDAgNC43MiAzLjE1IDcuODlsMS41OCAxLjU4eiIvPjxwYXRoIHN0eWxlPSJpc29sYXRpb246aXNvbGF0ZSIgZmlsbD0iIzI2MzIzOCIgb3BhY2l0eT0iLjIiIGQ9Ik03OS40OCAzMi42MnYzMi42M0g2NS4yN2wuNTIuNTNIODBWMzMuMTRsLS41Mi0uNTJ6Ii8+PHBhdGggY2xhc3M9ImQiIGQ9Ik02My4xNiAxNi4zYy0yLjYxLTIuNjEtNC43NS0yLjYzLTcuODktMi42M0gxMy42OWwuNTMuNTNoNDEuMDVjMS41NyAwIDUuNTMtLjI3IDcuODkgMi4xeiIvPjwvc3ZnPg==", "dart" });

            migrationBuilder.InsertData(
                table: "PlatformsPlatformsType",
                columns: new[] { "PlatformId", "PlatformTypeId" },
                values: new object[,]
                {
                    { 7, 1 },
                    { 2, 3 },
                    { 1, 3 },
                    { 15, 2 },
                    { 14, 2 },
                    { 8, 2 },
                    { 7, 2 },
                    { 6, 2 },
                    { 4, 2 },
                    { 3, 2 },
                    { 16, 1 },
                    { 13, 1 },
                    { 12, 1 },
                    { 11, 1 },
                    { 10, 1 },
                    { 9, 1 },
                    { 5, 3 },
                    { 3, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlatformsPlatformsType_PlatformTypeId",
                table: "PlatformsPlatformsType",
                column: "PlatformTypeId");
        }
    }
}
