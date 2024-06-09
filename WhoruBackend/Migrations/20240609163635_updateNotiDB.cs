using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhoruBackend.Migrations
{
    /// <inheritdoc />
    public partial class updateNotiDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 9, 16, 36, 35, 407, DateTimeKind.Utc).AddTicks(4501), new DateTime(2024, 6, 9, 16, 36, 35, 407, DateTimeKind.Utc).AddTicks(4506) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 9, 16, 36, 35, 407, DateTimeKind.Utc).AddTicks(4507), new DateTime(2024, 6, 9, 16, 36, 35, 407, DateTimeKind.Utc).AddTicks(4507) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 9, 16, 36, 35, 407, DateTimeKind.Utc).AddTicks(4620), "AQAQJwAArq+bbI+eAtuv9tKbryvcC7Lgb521FC6AQLVqBaeq8Q4MEazWSmZJeLrHNHE8HTEh", new DateTime(2024, 6, 9, 16, 36, 35, 407, DateTimeKind.Utc).AddTicks(4620) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 9, 16, 36, 35, 416, DateTimeKind.Utc).AddTicks(7934), "AQAQJwAAPAIf5uXxtBQfvQkxce8BFI7ImQ+Z/3Pr3ZdZaS6FrJwDNbtzqjYCA5HdoQqQ8MWk", new DateTime(2024, 6, 9, 16, 36, 35, 416, DateTimeKind.Utc).AddTicks(7935) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 23, 17, 41, 0, 828, DateTimeKind.Utc).AddTicks(7412), new DateTime(2024, 5, 23, 17, 41, 0, 828, DateTimeKind.Utc).AddTicks(7417) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 23, 17, 41, 0, 828, DateTimeKind.Utc).AddTicks(7420), new DateTime(2024, 5, 23, 17, 41, 0, 828, DateTimeKind.Utc).AddTicks(7421) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 23, 17, 41, 0, 828, DateTimeKind.Utc).AddTicks(7468), "AQAQJwAAwt3L/rAir+FNOhG8LrofloPY03Ggm/RWh3hvJurkPc7B36OwaTa7t+kWi4Uc6Gh7", new DateTime(2024, 5, 23, 17, 41, 0, 828, DateTimeKind.Utc).AddTicks(7469) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 23, 17, 41, 0, 837, DateTimeKind.Utc).AddTicks(8159), "AQAQJwAAyD6ZUoxZNz3aAsV33+95QkckppIwX0d3i2mvdEQKW/lwUWv8tklEOHa35rI5GEYm", new DateTime(2024, 5, 23, 17, 41, 0, 837, DateTimeKind.Utc).AddTicks(8160) });
        }
    }
}
