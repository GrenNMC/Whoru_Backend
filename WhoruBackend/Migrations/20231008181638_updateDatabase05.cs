using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhoruBackend.Migrations
{
    /// <inheritdoc />
    public partial class updateDatabase05 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Users",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<bool>(
                name: "isDisabled",
                table: "Users",
                type: "boolean",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 8, 18, 16, 37, 766, DateTimeKind.Utc).AddTicks(6613), new DateTime(2023, 10, 8, 18, 16, 37, 766, DateTimeKind.Utc).AddTicks(6617) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 8, 18, 16, 37, 766, DateTimeKind.Utc).AddTicks(6618), new DateTime(2023, 10, 8, 18, 16, 37, 766, DateTimeKind.Utc).AddTicks(6619) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate", "isDisabled" },
                values: new object[] { new DateTime(2023, 10, 8, 18, 16, 37, 766, DateTimeKind.Utc).AddTicks(6671), "AQAQJwAARDaeNibSQP0HftNfDvORmhEISgZi1CchojNwuAE6s9WHz2HK65hnFowKJu2Kh+KN", new DateTime(2023, 10, 8, 18, 16, 37, 766, DateTimeKind.Utc).AddTicks(6671), false });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate", "isDisabled" },
                values: new object[] { new DateTime(2023, 10, 8, 18, 16, 37, 777, DateTimeKind.Utc).AddTicks(5502), "AQAQJwAAGAfDc7YSeUVklE3vsEjlNGIvw2U/xkTqzZGeFqS5Ht5KCSw/X/YNQvdmZ/9swpKT", new DateTime(2023, 10, 8, 18, 16, 37, 777, DateTimeKind.Utc).AddTicks(5504), false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDisabled",
                table: "Users");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 30, 14, 8, 47, 421, DateTimeKind.Utc).AddTicks(4061), new DateTime(2023, 9, 30, 14, 8, 47, 421, DateTimeKind.Utc).AddTicks(4066) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 30, 14, 8, 47, 421, DateTimeKind.Utc).AddTicks(4069), new DateTime(2023, 9, 30, 14, 8, 47, 421, DateTimeKind.Utc).AddTicks(4069) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 30, 14, 8, 47, 421, DateTimeKind.Utc).AddTicks(4153), "AQAQJwAASxeSaTqDPlLDJgJhvlFHMMJivsmMuxhLcjdgvO2YdPPno503v2l8tXKROTjK449g", new DateTime(2023, 9, 30, 14, 8, 47, 421, DateTimeKind.Utc).AddTicks(4154) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 30, 14, 8, 47, 442, DateTimeKind.Utc).AddTicks(5731), "AQAQJwAAIqkiJ3nPBz1R30oK6I8aeMVtEGz4XRDM75CYS0ip8xrAt4nZLsdnA7BN+nY5KUNn", new DateTime(2023, 9, 30, 14, 8, 47, 442, DateTimeKind.Utc).AddTicks(5736) });
        }
    }
}
