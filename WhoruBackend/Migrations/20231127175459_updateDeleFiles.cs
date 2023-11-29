using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhoruBackend.Migrations
{
    /// <inheritdoc />
    public partial class updateDeleFiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "FeedImages",
                type: "text",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "FeedImages");

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
        }
    }
}
