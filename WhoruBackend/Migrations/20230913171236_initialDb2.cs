using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WhoruBackend.Migrations
{
    /// <inheritdoc />
    public partial class initialDb2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InfoId",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 13, 17, 12, 35, 896, DateTimeKind.Utc).AddTicks(834), new DateTime(2023, 9, 13, 17, 12, 35, 896, DateTimeKind.Utc).AddTicks(837) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 13, 17, 12, 35, 896, DateTimeKind.Utc).AddTicks(839), new DateTime(2023, 9, 13, 17, 12, 35, 896, DateTimeKind.Utc).AddTicks(840) });

            migrationBuilder.InsertData(
                table: "UserInfos",
                columns: new[] { "Id", "Avatar", "FullName", "UserId" },
                values: new object[,]
                {
                    { 1, "Link hinh anh :>", "Nguyen Minh Cuong", 1 },
                    { 2, "Link hinh anh :>", "Nguyen Minh Nhut", 2 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 13, 17, 12, 35, 896, DateTimeKind.Utc).AddTicks(914), "AQAQJwAAzGLO9OIIBakdzPH9XmAx4HJf2QR0k8xH0zvMHVuHWtgE6ZYDUaJRj/ClSgyLWXwW", new DateTime(2023, 9, 13, 17, 12, 35, 896, DateTimeKind.Utc).AddTicks(915) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 13, 17, 12, 35, 910, DateTimeKind.Utc).AddTicks(5746), "AQAQJwAA3BHuUebF5B/gkicYRypmwoQJkounPzzPujCkQygyinhKIPMfkBjx1VV69JFLAB7x", new DateTime(2023, 9, 13, 17, 12, 35, 910, DateTimeKind.Utc).AddTicks(5751) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserInfos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserInfos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AddColumn<int>(
                name: "InfoId",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 10, 19, 10, 6, 333, DateTimeKind.Utc).AddTicks(5455), new DateTime(2023, 9, 10, 19, 10, 6, 333, DateTimeKind.Utc).AddTicks(5459) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 10, 19, 10, 6, 333, DateTimeKind.Utc).AddTicks(5461), new DateTime(2023, 9, 10, 19, 10, 6, 333, DateTimeKind.Utc).AddTicks(5462) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "InfoId", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 10, 19, 10, 6, 333, DateTimeKind.Utc).AddTicks(5542), 1, "AQAQJwAAjvc2lWChvVWj5cOkLSsiL8QmaRibrroW0wepE6GITxLvrY199b1HPgXjv/KmDdgs", new DateTime(2023, 9, 10, 19, 10, 6, 333, DateTimeKind.Utc).AddTicks(5543) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "InfoId", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 10, 19, 10, 6, 346, DateTimeKind.Utc).AddTicks(7989), 2, "AQAQJwAAwtC5HnB0ixu9cm1cF4vMVlsvp4h4cQJ2nyHENOVVXcfgRFY2L2AijTCIXhbY1fZt", new DateTime(2023, 9, 10, 19, 10, 6, 346, DateTimeKind.Utc).AddTicks(7993) });
        }
    }
}
