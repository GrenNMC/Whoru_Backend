using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhoruBackend.Migrations
{
    /// <inheritdoc />
    public partial class fixedErrorLikeOb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_UserInfos_FeedId",
                table: "Likes");

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

            migrationBuilder.CreateIndex(
                name: "IX_Likes_UserId",
                table: "Likes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_UserInfos_UserId",
                table: "Likes",
                column: "UserId",
                principalTable: "UserInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_UserInfos_UserId",
                table: "Likes");

            migrationBuilder.DropIndex(
                name: "IX_Likes_UserId",
                table: "Likes");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 11, 25, 18, 6, 50, 111, DateTimeKind.Utc).AddTicks(7031), new DateTime(2023, 11, 25, 18, 6, 50, 111, DateTimeKind.Utc).AddTicks(7034) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 11, 25, 18, 6, 50, 111, DateTimeKind.Utc).AddTicks(7036), new DateTime(2023, 11, 25, 18, 6, 50, 111, DateTimeKind.Utc).AddTicks(7037) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 11, 25, 18, 6, 50, 111, DateTimeKind.Utc).AddTicks(7084), "AQAQJwAAp+xE9kuZ3zVzlVoIVJIcTdzvaZIY4ddBtE5MlzZ2ToNjoMFyYDUBEcbQztAfiBDk", new DateTime(2023, 11, 25, 18, 6, 50, 111, DateTimeKind.Utc).AddTicks(7085) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 11, 25, 18, 6, 50, 121, DateTimeKind.Utc).AddTicks(3544), "AQAQJwAAh8K7gwntTzGZYrcLkgpNk6dMGzDpOEnO66JWl1JG0NutYXYwe6ChS3XIt8W/w0pN", new DateTime(2023, 11, 25, 18, 6, 50, 121, DateTimeKind.Utc).AddTicks(3548) });

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_UserInfos_FeedId",
                table: "Likes",
                column: "FeedId",
                principalTable: "UserInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
