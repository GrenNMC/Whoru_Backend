using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhoruBackend.Migrations
{
    /// <inheritdoc />
    public partial class initialDiagram : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 7, 12, 22, 8, 16, 196, DateTimeKind.Utc).AddTicks(8012), new DateTime(2024, 7, 12, 22, 8, 16, 196, DateTimeKind.Utc).AddTicks(8016) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 7, 12, 22, 8, 16, 196, DateTimeKind.Utc).AddTicks(8018), new DateTime(2024, 7, 12, 22, 8, 16, 196, DateTimeKind.Utc).AddTicks(8019) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 7, 12, 22, 8, 16, 196, DateTimeKind.Utc).AddTicks(8095), "AQAQJwAAoQXVUlb9SGsO9fxkp5WkswWcJgOQrS2U/K1rzgiMQCoUnPLOwZu47wtEzcz33oqQ", new DateTime(2024, 7, 12, 22, 8, 16, 196, DateTimeKind.Utc).AddTicks(8095) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 7, 12, 22, 8, 16, 207, DateTimeKind.Utc).AddTicks(1770), "AQAQJwAAdIIjmZje0yC0dMQI059PrS3+HsYNHGOjXrlztl+6zr8EC6lLH2Fh96TksTHwRqxY", new DateTime(2024, 7, 12, 22, 8, 16, 207, DateTimeKind.Utc).AddTicks(1773) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 7, 11, 15, 53, 58, 70, DateTimeKind.Utc).AddTicks(3250), new DateTime(2024, 7, 11, 15, 53, 58, 70, DateTimeKind.Utc).AddTicks(3255) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 7, 11, 15, 53, 58, 70, DateTimeKind.Utc).AddTicks(3258), new DateTime(2024, 7, 11, 15, 53, 58, 70, DateTimeKind.Utc).AddTicks(3259) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 7, 11, 15, 53, 58, 70, DateTimeKind.Utc).AddTicks(3348), "AQAQJwAAfZotdOYc58fJfq3IVp4e/lNeHzc8NJ9Yn5I8dIhKxo6m8uyEMK4jF9Qjv4ezKUhZ", new DateTime(2024, 7, 11, 15, 53, 58, 70, DateTimeKind.Utc).AddTicks(3349) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 7, 11, 15, 53, 58, 84, DateTimeKind.Utc).AddTicks(3924), "AQAQJwAA/+IoisBdjuA+zAdRynd+Wq+4BjiP2y/X9xuAKawT9u2b99vrW3fz85NmGydwrVoD", new DateTime(2024, 7, 11, 15, 53, 58, 84, DateTimeKind.Utc).AddTicks(3929) });
        }
    }
}
