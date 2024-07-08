using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WhoruBackend.Migrations
{
    /// <inheritdoc />
    public partial class InitialUserChattb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_UserChats_IdUser2",
                table: "UserChats",
                column: "IdUser2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserChats");

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
    }
}
