using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhoruBackend.Migrations
{
    /// <inheritdoc />
    public partial class updateDbv5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "State",
                table: "Feeds",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 7, 2, 18, 41, 59, 668, DateTimeKind.Utc).AddTicks(6999), new DateTime(2024, 7, 2, 18, 41, 59, 668, DateTimeKind.Utc).AddTicks(7003) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 7, 2, 18, 41, 59, 668, DateTimeKind.Utc).AddTicks(7005), new DateTime(2024, 7, 2, 18, 41, 59, 668, DateTimeKind.Utc).AddTicks(7006) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 7, 2, 18, 41, 59, 668, DateTimeKind.Utc).AddTicks(7091), "AQAQJwAANfT4KxaNQEIuy6bn0YqAn+U5KgYt+gCuBN0lOK5GAU8cFrwhsgaw7fqSYfOXst3T", new DateTime(2024, 7, 2, 18, 41, 59, 668, DateTimeKind.Utc).AddTicks(7093) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 7, 2, 18, 41, 59, 690, DateTimeKind.Utc).AddTicks(3730), "AQAQJwAAfCoBPJ3drb+FcQGrY9puTj5RNM9FY+q89O/C97YNOiC75WCkeSPSfKP7VF3yAldG", new DateTime(2024, 7, 2, 18, 41, 59, 690, DateTimeKind.Utc).AddTicks(3737) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Feeds",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 7, 2, 17, 47, 13, 737, DateTimeKind.Utc).AddTicks(7248), new DateTime(2024, 7, 2, 17, 47, 13, 737, DateTimeKind.Utc).AddTicks(7254) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 7, 2, 17, 47, 13, 737, DateTimeKind.Utc).AddTicks(7255), new DateTime(2024, 7, 2, 17, 47, 13, 737, DateTimeKind.Utc).AddTicks(7256) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 7, 2, 17, 47, 13, 737, DateTimeKind.Utc).AddTicks(7317), "AQAQJwAAQgCqdwpY+ZT5p/Wi1XsXqD7gyrvpBsNBr1c1mCbZlbKehJyBoom9ZLShmRlAkUrN", new DateTime(2024, 7, 2, 17, 47, 13, 737, DateTimeKind.Utc).AddTicks(7319) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 7, 2, 17, 47, 13, 754, DateTimeKind.Utc).AddTicks(6715), "AQAQJwAAortF5z1/I4FgHU7IQCEhEm3us4nU2IymZ5FQFvyX7Isrfnw4iCrjswfgxP6bOcyU", new DateTime(2024, 7, 2, 17, 47, 13, 754, DateTimeKind.Utc).AddTicks(6720) });
        }
    }
}
