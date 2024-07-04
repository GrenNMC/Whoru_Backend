using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WhoruBackend.Migrations
{
    /// <inheritdoc />
    public partial class updatedbv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SuggestionUsers",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    SuggestUser = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuggestionUsers", x => new { x.UserId, x.SuggestUser });
                    table.ForeignKey(
                        name: "FK_SuggestionUsers_UserInfos_SuggestUser",
                        column: x => x.SuggestUser,
                        principalTable: "UserInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_SuggestionUsers_UserInfos_UserId",
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

            migrationBuilder.CreateIndex(
                name: "IX_SuggestionUsers_SuggestUser",
                table: "SuggestionUsers",
                column: "SuggestUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SuggestionUsers");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 26, 17, 38, 45, 841, DateTimeKind.Utc).AddTicks(7225), new DateTime(2024, 6, 26, 17, 38, 45, 841, DateTimeKind.Utc).AddTicks(7231) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 26, 17, 38, 45, 841, DateTimeKind.Utc).AddTicks(7232), new DateTime(2024, 6, 26, 17, 38, 45, 841, DateTimeKind.Utc).AddTicks(7233) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 26, 17, 38, 45, 841, DateTimeKind.Utc).AddTicks(7290), "AQAQJwAAS9FG/jABWmdsoajf0m5HIwoXoHq2YfAIV7TdNbOAY/KMMPDkGVMR7OtkbKtQCMXp", new DateTime(2024, 6, 26, 17, 38, 45, 841, DateTimeKind.Utc).AddTicks(7291) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 26, 17, 38, 45, 858, DateTimeKind.Utc).AddTicks(6413), "AQAQJwAAtQz303mXpLBgi1OdDexl8NVgdrPjJjLhiOYyo60xXtzHRls97ChpeMO6F5+nH2vC", new DateTime(2024, 6, 26, 17, 38, 45, 858, DateTimeKind.Utc).AddTicks(6417) });
        }
    }
}
