using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WhoruBackend.Migrations
{
    /// <inheritdoc />
    public partial class DeleUserChat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserChats");

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Locations",
                type: "text",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Note",
                table: "Locations");

            migrationBuilder.CreateTable(
                name: "UserChats",
                columns: table => new
                {
                    IdUser1 = table.Column<int>(type: "integer", nullable: false),
                    IdUser2 = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    isWait = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserChats", x => new { x.IdUser1, x.IdUser2 });
                    table.ForeignKey(
                        name: "FK_UserChats_UserInfos_IdUser1",
                        column: x => x.IdUser1,
                        principalTable: "UserInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_UserChats_UserInfos_IdUser2",
                        column: x => x.IdUser2,
                        principalTable: "UserInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 7, 10, 16, 48, 1, 795, DateTimeKind.Utc).AddTicks(6231), new DateTime(2024, 7, 10, 16, 48, 1, 795, DateTimeKind.Utc).AddTicks(6234) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 7, 10, 16, 48, 1, 795, DateTimeKind.Utc).AddTicks(6235), new DateTime(2024, 7, 10, 16, 48, 1, 795, DateTimeKind.Utc).AddTicks(6236) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 7, 10, 16, 48, 1, 795, DateTimeKind.Utc).AddTicks(6283), "AQAQJwAAGksShEOAOSppMDXOUgWZdE4fPANItlP0dunHhRyNCvlhCslInQzwhlytdn1e/eLR", new DateTime(2024, 7, 10, 16, 48, 1, 795, DateTimeKind.Utc).AddTicks(6284) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 7, 10, 16, 48, 1, 807, DateTimeKind.Utc).AddTicks(9534), "AQAQJwAAXN7OkT47WaqLo+nQdj8s9VNT3uvT9QpPUSvmpcFSayOUZGgUN1xv5kCb2QnwoweC", new DateTime(2024, 7, 10, 16, 48, 1, 807, DateTimeKind.Utc).AddTicks(9537) });

            migrationBuilder.CreateIndex(
                name: "IX_UserChats_IdUser2",
                table: "UserChats",
                column: "IdUser2");
        }
    }
}
