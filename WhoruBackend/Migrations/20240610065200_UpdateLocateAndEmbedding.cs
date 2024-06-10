using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WhoruBackend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLocateAndEmbedding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FaceRecogNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Embedding = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaceRecogNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FaceRecogNumbers_UserInfos_UserId",
                        column: x => x.UserId,
                        principalTable: "UserInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Latitude = table.Column<double>(type: "double precision", nullable: false),
                    Longitude = table.Column<double>(type: "double precision", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_UserInfos_UserId",
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
                values: new object[] { new DateTime(2024, 6, 10, 6, 51, 59, 659, DateTimeKind.Utc).AddTicks(1618), new DateTime(2024, 6, 10, 6, 51, 59, 659, DateTimeKind.Utc).AddTicks(1623) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 10, 6, 51, 59, 659, DateTimeKind.Utc).AddTicks(1626), new DateTime(2024, 6, 10, 6, 51, 59, 659, DateTimeKind.Utc).AddTicks(1626) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 10, 6, 51, 59, 659, DateTimeKind.Utc).AddTicks(1716), "AQAQJwAAxmKzx+ac7omT9IyRnAR4B08jDe35Mb/rtpjCkXaHY6X6rDVHuDoccT6ZtHAYnPdj", new DateTime(2024, 6, 10, 6, 51, 59, 659, DateTimeKind.Utc).AddTicks(1717) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 10, 6, 51, 59, 676, DateTimeKind.Utc).AddTicks(7278), "AQAQJwAAhnx7I2MkvBLugGjB2Ihra140stctzBCw/yH8ga55GluGIiKBkq2KCXpNt+tSBmlg", new DateTime(2024, 6, 10, 6, 51, 59, 676, DateTimeKind.Utc).AddTicks(7282) });

            migrationBuilder.CreateIndex(
                name: "IX_FaceRecogNumbers_UserId",
                table: "FaceRecogNumbers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_UserId",
                table: "Locations",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FaceRecogNumbers");

            migrationBuilder.DropTable(
                name: "Locations");

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
    }
}
