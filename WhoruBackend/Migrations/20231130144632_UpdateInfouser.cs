using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhoruBackend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInfouser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "UserInfos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudyAt",
                table: "UserInfos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkingAt",
                table: "UserInfos",
                type: "text",
                nullable: true);

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
                columns: new[] { "Description", "StudyAt", "WorkingAt" },
                values: new object[] { "Lonely", "HCMUTE", "HCMUTE" });

            migrationBuilder.UpdateData(
                table: "UserInfos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "StudyAt", "WorkingAt" },
                values: new object[] { "Naive", "HCMUTE", "HCMUTE" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "UserInfos");

            migrationBuilder.DropColumn(
                name: "StudyAt",
                table: "UserInfos");

            migrationBuilder.DropColumn(
                name: "WorkingAt",
                table: "UserInfos");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 11, 27, 17, 54, 59, 710, DateTimeKind.Utc).AddTicks(9319), new DateTime(2023, 11, 27, 17, 54, 59, 710, DateTimeKind.Utc).AddTicks(9323) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 11, 27, 17, 54, 59, 710, DateTimeKind.Utc).AddTicks(9324), new DateTime(2023, 11, 27, 17, 54, 59, 710, DateTimeKind.Utc).AddTicks(9325) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 11, 27, 17, 54, 59, 710, DateTimeKind.Utc).AddTicks(9371), "AQAQJwAAihnN30y2bcTQufIBanPgV/NYdLl8ZmwRGLv+OYk7TwBMsvZenWXxobxIn9USiDFE", new DateTime(2023, 11, 27, 17, 54, 59, 710, DateTimeKind.Utc).AddTicks(9372) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 11, 27, 17, 54, 59, 720, DateTimeKind.Utc).AddTicks(4315), "AQAQJwAAVV5xm6T3aPHxin2bjVTS5R3khKh/klEGCBtzCGUlotaGEDSIB8f+d0FeEj2cvlo6", new DateTime(2023, 11, 27, 17, 54, 59, 720, DateTimeKind.Utc).AddTicks(4317) });
        }
    }
}
