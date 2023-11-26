using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhoruBackend.Migrations
{
    /// <inheritdoc />
    public partial class fixedErrorShareOb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shares_UserInfos_FeedId",
                table: "Shares");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 11, 26, 9, 39, 37, 32, DateTimeKind.Utc).AddTicks(6774), new DateTime(2023, 11, 26, 9, 39, 37, 32, DateTimeKind.Utc).AddTicks(6778) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 11, 26, 9, 39, 37, 32, DateTimeKind.Utc).AddTicks(6781), new DateTime(2023, 11, 26, 9, 39, 37, 32, DateTimeKind.Utc).AddTicks(6781) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 11, 26, 9, 39, 37, 32, DateTimeKind.Utc).AddTicks(6833), "AQAQJwAAOdXiJUMhxfF9iZgUQ+NurKqURI47PwzvROmtICMNUu4FpOQmGDUHgdV++J/bZWIW", new DateTime(2023, 11, 26, 9, 39, 37, 32, DateTimeKind.Utc).AddTicks(6834) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 11, 26, 9, 39, 37, 42, DateTimeKind.Utc).AddTicks(267), "AQAQJwAAmANqZUfh5m65phhLBrvdsoczQwhhx/yE320v0ThbOjkTjTTEYWzr1F99Vtn7+rP7", new DateTime(2023, 11, 26, 9, 39, 37, 42, DateTimeKind.Utc).AddTicks(268) });

            migrationBuilder.CreateIndex(
                name: "IX_Shares_UserId",
                table: "Shares",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shares_UserInfos_UserId",
                table: "Shares",
                column: "UserId",
                principalTable: "UserInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shares_UserInfos_UserId",
                table: "Shares");

            migrationBuilder.DropIndex(
                name: "IX_Shares_UserId",
                table: "Shares");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 11, 26, 9, 29, 57, 468, DateTimeKind.Utc).AddTicks(3640), new DateTime(2023, 11, 26, 9, 29, 57, 468, DateTimeKind.Utc).AddTicks(3645) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 11, 26, 9, 29, 57, 468, DateTimeKind.Utc).AddTicks(3647), new DateTime(2023, 11, 26, 9, 29, 57, 468, DateTimeKind.Utc).AddTicks(3648) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 11, 26, 9, 29, 57, 468, DateTimeKind.Utc).AddTicks(3716), "AQAQJwAAlCzp0R87s9pBOL99LFaBMbbj90a691hOIq5tyjXksE2eAzYE+X7lDFrJrb3/U/4Y", new DateTime(2023, 11, 26, 9, 29, 57, 468, DateTimeKind.Utc).AddTicks(3717) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 11, 26, 9, 29, 57, 479, DateTimeKind.Utc).AddTicks(134), "AQAQJwAATAakuIQ9+PFab7+aPUDK8NcHgzBGp1TfRD7B4aSxV4+qxr1+S+f7XDTE/8mh2XLN", new DateTime(2023, 11, 26, 9, 29, 57, 479, DateTimeKind.Utc).AddTicks(137) });

            migrationBuilder.AddForeignKey(
                name: "FK_Shares_UserInfos_FeedId",
                table: "Shares",
                column: "FeedId",
                principalTable: "UserInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
