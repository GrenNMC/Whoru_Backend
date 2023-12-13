using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhoruBackend.Migrations
{
    /// <inheritdoc />
    public partial class updateChatdb1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSeen",
                table: "Chats",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Chats",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 12, 13, 6, 29, 46, 828, DateTimeKind.Utc).AddTicks(1749), new DateTime(2023, 12, 13, 6, 29, 46, 828, DateTimeKind.Utc).AddTicks(1755) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 12, 13, 6, 29, 46, 828, DateTimeKind.Utc).AddTicks(1758), new DateTime(2023, 12, 13, 6, 29, 46, 828, DateTimeKind.Utc).AddTicks(1760) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 12, 13, 6, 29, 46, 828, DateTimeKind.Utc).AddTicks(1930), "AQAQJwAAeUbgIEFsWf5VK1vVSDT8DHECui7N+xONnhuNwHAZMvLDXxKNobfC5hXBOhXGjgOR", new DateTime(2023, 12, 13, 6, 29, 46, 828, DateTimeKind.Utc).AddTicks(1932) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 12, 13, 6, 29, 46, 863, DateTimeKind.Utc).AddTicks(5428), "AQAQJwAAtP4HQmOLW8sAOkyPoUD0yjesaTEfZnjUpTbXMUIaLQNKT3tpwfbxuTJsoZaoSyHs", new DateTime(2023, 12, 13, 6, 29, 46, 863, DateTimeKind.Utc).AddTicks(5434) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSeen",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Chats");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 11, 30, 17, 27, 14, 330, DateTimeKind.Utc).AddTicks(7504), new DateTime(2023, 11, 30, 17, 27, 14, 330, DateTimeKind.Utc).AddTicks(7508) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 11, 30, 17, 27, 14, 330, DateTimeKind.Utc).AddTicks(7510), new DateTime(2023, 11, 30, 17, 27, 14, 330, DateTimeKind.Utc).AddTicks(7511) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 11, 30, 17, 27, 14, 330, DateTimeKind.Utc).AddTicks(7569), "AQAQJwAA7A+ZNEIDKb7UYtKCg3ecL8J7kmAuTdXdCV8Q1TnEfZXhnAr5Fce9SnQ1zLu99x/O", new DateTime(2023, 11, 30, 17, 27, 14, 330, DateTimeKind.Utc).AddTicks(7569) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 11, 30, 17, 27, 14, 351, DateTimeKind.Utc).AddTicks(1601), "AQAQJwAACBy/l1qQEVwjedqvm/yN9FTmzeHlbk2PJX7tG2kAY5ljmH+SJofy3hPS29r3JDct", new DateTime(2023, 11, 30, 17, 27, 14, 351, DateTimeKind.Utc).AddTicks(1605) });
        }
    }
}
