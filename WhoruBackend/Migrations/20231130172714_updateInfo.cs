using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhoruBackend.Migrations
{
    /// <inheritdoc />
    public partial class updateInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AvtName",
                table: "UserInfos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BackroundName",
                table: "UserInfos",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 11, 30, 17, 27, 14, 330, DateTimeKind.Utc).AddTicks(7504), new DateTime(2023, 11, 30, 17, 27, 14, 330, DateTimeKind.Utc).AddTicks(7508) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 11, 30, 17, 27, 14, 330, DateTimeKind.Utc).AddTicks(7510), new DateTime(2023, 11, 30, 17, 27, 14, 330, DateTimeKind.Utc).AddTicks(7511) });

            migrationBuilder.UpdateData(
                table: "UserInfos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvtName", "BackroundName" },
                values: new object[] { "default-avatar", "default-backround" });

            migrationBuilder.UpdateData(
                table: "UserInfos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AvtName", "BackroundName" },
                values: new object[] { "default-avatar", "default-backround" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 11, 30, 17, 27, 14, 330, DateTimeKind.Utc).AddTicks(7569), "AQAQJwAA7A+ZNEIDKb7UYtKCg3ecL8J7kmAuTdXdCV8Q1TnEfZXhnAr5Fce9SnQ1zLu99x/O", new DateTime(2023, 11, 30, 17, 27, 14, 330, DateTimeKind.Utc).AddTicks(7569) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 11, 30, 17, 27, 14, 351, DateTimeKind.Utc).AddTicks(1601), "AQAQJwAACBy/l1qQEVwjedqvm/yN9FTmzeHlbk2PJX7tG2kAY5ljmH+SJofy3hPS29r3JDct", new DateTime(2023, 11, 30, 17, 27, 14, 351, DateTimeKind.Utc).AddTicks(1605) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvtName",
                table: "UserInfos");

            migrationBuilder.DropColumn(
                name: "BackroundName",
                table: "UserInfos");

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
    }
}
