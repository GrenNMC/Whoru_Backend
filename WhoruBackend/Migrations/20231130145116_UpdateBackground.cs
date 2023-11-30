using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhoruBackend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBackground : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 11, 30, 14, 51, 16, 440, DateTimeKind.Utc).AddTicks(660), new DateTime(2023, 11, 30, 14, 51, 16, 440, DateTimeKind.Utc).AddTicks(665) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 11, 30, 14, 51, 16, 440, DateTimeKind.Utc).AddTicks(667), new DateTime(2023, 11, 30, 14, 51, 16, 440, DateTimeKind.Utc).AddTicks(667) });

            migrationBuilder.UpdateData(
                table: "UserInfos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Avatar", "Backround" },
                values: new object[] { "https://firebasestorage.googleapis.com/v0/b/whoru-2f115.appspot.com/o/Avatars%2Fdefault-avatar.jpg?alt=media&token=7721df77-f806-41c7-bcfe-2aae9acc98c7", "https://firebasestorage.googleapis.com/v0/b/whoru-2f115.appspot.com/o/Backgrounds%2Fdefault-background.jpg?alt=media&token=e99f5f3d-9b05-4594-a233-f839204e56e6" });

            migrationBuilder.UpdateData(
                table: "UserInfos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Avatar", "Backround" },
                values: new object[] { "https://firebasestorage.googleapis.com/v0/b/whoru-2f115.appspot.com/o/Avatars%2Fdefault-avatar.jpg?alt=media&token=7721df77-f806-41c7-bcfe-2aae9acc98c7", "https://firebasestorage.googleapis.com/v0/b/whoru-2f115.appspot.com/o/Backgrounds%2Fdefault-background.jpg?alt=media&token=e99f5f3d-9b05-4594-a233-f839204e56e6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 11, 30, 14, 51, 16, 440, DateTimeKind.Utc).AddTicks(722), "AQAQJwAAtfS5wS3gD695Cj93Hzu2zRBzOmN8pl5SXPlaJG2NUJBXZfnu2I5T+DySRK+h+HSE", new DateTime(2023, 11, 30, 14, 51, 16, 440, DateTimeKind.Utc).AddTicks(723) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 11, 30, 14, 51, 16, 451, DateTimeKind.Utc).AddTicks(1175), "AQAQJwAAEQM5or1xORQ2EoIoTokI2guyTYPvdPVYszgeqNcydz84nxuiwL8RgTiecgHFj6jK", new DateTime(2023, 11, 30, 14, 51, 16, 451, DateTimeKind.Utc).AddTicks(1180) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 11, 30, 14, 46, 32, 543, DateTimeKind.Utc).AddTicks(6351), new DateTime(2023, 11, 30, 14, 46, 32, 543, DateTimeKind.Utc).AddTicks(6356) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 11, 30, 14, 46, 32, 543, DateTimeKind.Utc).AddTicks(6357), new DateTime(2023, 11, 30, 14, 46, 32, 543, DateTimeKind.Utc).AddTicks(6357) });

            migrationBuilder.UpdateData(
                table: "UserInfos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Avatar", "Backround" },
                values: new object[] { "Link hinh anh :>", null });

            migrationBuilder.UpdateData(
                table: "UserInfos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Avatar", "Backround" },
                values: new object[] { "Link hinh anh :>", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 11, 30, 14, 46, 32, 543, DateTimeKind.Utc).AddTicks(6405), "AQAQJwAAlh9MXl11pzTCc2Bqq2l0R4bJeJJThPB3rBsZsoxQYHAZZsoPIi14s1kkgrpqXkW2", new DateTime(2023, 11, 30, 14, 46, 32, 543, DateTimeKind.Utc).AddTicks(6406) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 11, 30, 14, 46, 32, 553, DateTimeKind.Utc).AddTicks(2553), "AQAQJwAA8/rowujA/y5qWNP8xnYZWtMI9UA3J88jAVKluxXIge9dqCdcR6oLmVmLNquBSXDf", new DateTime(2023, 11, 30, 14, 46, 32, 553, DateTimeKind.Utc).AddTicks(2557) });
        }
    }
}
