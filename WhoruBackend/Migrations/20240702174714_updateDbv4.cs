using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhoruBackend.Migrations
{
    /// <inheritdoc />
    public partial class updateDbv4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "SuggestionUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "SuggestionUsers");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 30, 16, 34, 2, 118, DateTimeKind.Utc).AddTicks(9957), new DateTime(2024, 6, 30, 16, 34, 2, 118, DateTimeKind.Utc).AddTicks(9962) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 30, 16, 34, 2, 118, DateTimeKind.Utc).AddTicks(9963), new DateTime(2024, 6, 30, 16, 34, 2, 118, DateTimeKind.Utc).AddTicks(9963) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 30, 16, 34, 2, 119, DateTimeKind.Utc).AddTicks(21), "AQAQJwAAF3eshUuFoYsAlZ+pegbXULu74DldSWlMmZ+rshi/r1WnDfsFVFZ9ARlHLwD6qM02", new DateTime(2024, 6, 30, 16, 34, 2, 119, DateTimeKind.Utc).AddTicks(22) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 30, 16, 34, 2, 131, DateTimeKind.Utc).AddTicks(671), "AQAQJwAA6fjWuIcjpSsTRIzX/UEqeQ6vvmnt3Br/VmuLFCimLQV+vZbVbWgF1Hh40IWu6GDB", new DateTime(2024, 6, 30, 16, 34, 2, 131, DateTimeKind.Utc).AddTicks(675) });
        }
    }
}
