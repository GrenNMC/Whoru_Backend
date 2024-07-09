using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WhoruBackend.Migrations
{
    /// <inheritdoc />
    public partial class InitialSavedFeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SavedFeeds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    FeedId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedFeeds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SavedFeeds_Feeds_FeedId",
                        column: x => x.FeedId,
                        principalTable: "Feeds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_SavedFeeds_UserInfos_UserId",
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
                values: new object[] { new DateTime(2024, 7, 9, 17, 55, 24, 689, DateTimeKind.Utc).AddTicks(7697), new DateTime(2024, 7, 9, 17, 55, 24, 689, DateTimeKind.Utc).AddTicks(7701) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 7, 9, 17, 55, 24, 689, DateTimeKind.Utc).AddTicks(7702), new DateTime(2024, 7, 9, 17, 55, 24, 689, DateTimeKind.Utc).AddTicks(7703) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 7, 9, 17, 55, 24, 689, DateTimeKind.Utc).AddTicks(7748), "AQAQJwAA4P2RLZcv7/YpanVgYlMgwODBNALFhe+D/q3nT6r17uLqqPWq3TtsO7BURBW0j1QG", new DateTime(2024, 7, 9, 17, 55, 24, 689, DateTimeKind.Utc).AddTicks(7748) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 7, 9, 17, 55, 24, 699, DateTimeKind.Utc).AddTicks(4023), "AQAQJwAABLHlPbEfPrL/bv5LQhablzlM0mQS00bNfCXLUFSzTcruGauN2c+muWUlVNPDdTKh", new DateTime(2024, 7, 9, 17, 55, 24, 699, DateTimeKind.Utc).AddTicks(4026) });

            migrationBuilder.CreateIndex(
                name: "IX_SavedFeeds_FeedId",
                table: "SavedFeeds",
                column: "FeedId");

            migrationBuilder.CreateIndex(
                name: "IX_SavedFeeds_UserId",
                table: "SavedFeeds",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SavedFeeds");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 7, 7, 18, 36, 30, 447, DateTimeKind.Utc).AddTicks(3559), new DateTime(2024, 7, 7, 18, 36, 30, 447, DateTimeKind.Utc).AddTicks(3563) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 7, 7, 18, 36, 30, 447, DateTimeKind.Utc).AddTicks(3564), new DateTime(2024, 7, 7, 18, 36, 30, 447, DateTimeKind.Utc).AddTicks(3565) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 7, 7, 18, 36, 30, 447, DateTimeKind.Utc).AddTicks(3613), "AQAQJwAATyNqMlg43Zuae3upYBVGLPl2LhcCuBDmU0LY2+qXm9WYV8IbdmE6bZUTSH9+ra1o", new DateTime(2024, 7, 7, 18, 36, 30, 447, DateTimeKind.Utc).AddTicks(3614) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 7, 7, 18, 36, 30, 456, DateTimeKind.Utc).AddTicks(4198), "AQAQJwAAQ6GwNSLRcpVqDe5IsYuY0txybMQrYviLz5w1OZcauK8UNcYppMZqCscUVbxsGnAj", new DateTime(2024, 7, 7, 18, 36, 30, 456, DateTimeKind.Utc).AddTicks(4199) });
        }
    }
}
