using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WhoruBackend.Migrations
{
    /// <inheritdoc />
    public partial class updatedDBv1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stories_UserInfos_UserId",
                        column: x => x.UserId,
                        principalTable: "UserInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Stories_UserId",
                table: "Stories",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stories");

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
    }
}
