using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhoruBackend.Migrations
{
    /// <inheritdoc />
    public partial class FixedFeedDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feeds_UserInfos_UserInfoId",
                table: "Feeds");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 11, 13, 10, 47, 43, 666, DateTimeKind.Utc).AddTicks(566), new DateTime(2023, 11, 13, 10, 47, 43, 666, DateTimeKind.Utc).AddTicks(571) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 11, 13, 10, 47, 43, 666, DateTimeKind.Utc).AddTicks(572), new DateTime(2023, 11, 13, 10, 47, 43, 666, DateTimeKind.Utc).AddTicks(572) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 11, 13, 10, 47, 43, 666, DateTimeKind.Utc).AddTicks(630), "AQAQJwAAVJVTPUzhCp0FCE4KdeMBBlzXL0PGNZvIoKrvrFTM35eRZBA30ULuUKf5AUM8J/Ry", new DateTime(2023, 11, 13, 10, 47, 43, 666, DateTimeKind.Utc).AddTicks(631) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 11, 13, 10, 47, 43, 675, DateTimeKind.Utc).AddTicks(7968), "AQAQJwAAP7WKD0qbAJiaQXWIE5ifiKeqnxVD3FrRGGj6TR+zAOfRcfpgRtLGj+COWIN6J/6v", new DateTime(2023, 11, 13, 10, 47, 43, 675, DateTimeKind.Utc).AddTicks(7971) });

            migrationBuilder.AddForeignKey(
                name: "FK_Feeds_UserInfos_UserInfoId",
                table: "Feeds",
                column: "UserInfoId",
                principalTable: "UserInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feeds_UserInfos_UserInfoId",
                table: "Feeds");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 25, 19, 2, 26, 726, DateTimeKind.Utc).AddTicks(6669), new DateTime(2023, 10, 25, 19, 2, 26, 726, DateTimeKind.Utc).AddTicks(6673) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 25, 19, 2, 26, 726, DateTimeKind.Utc).AddTicks(6675), new DateTime(2023, 10, 25, 19, 2, 26, 726, DateTimeKind.Utc).AddTicks(6676) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 25, 19, 2, 26, 726, DateTimeKind.Utc).AddTicks(6719), "AQAQJwAACdmXlO4POHRD9/xTsCUw4E1Jh8nbBO2mUlbccrN/jFQ1CUg3z5RKXJeotqJvIFLF", new DateTime(2023, 10, 25, 19, 2, 26, 726, DateTimeKind.Utc).AddTicks(6719) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 25, 19, 2, 26, 738, DateTimeKind.Utc).AddTicks(4336), "AQAQJwAAvoJvmm/MP6iw5+kT9j1qoEII+mmAjjwnwBHigujXwdd0fLIreHbWcnkQmnfqaCkT", new DateTime(2023, 10, 25, 19, 2, 26, 738, DateTimeKind.Utc).AddTicks(4340) });

            migrationBuilder.AddForeignKey(
                name: "FK_Feeds_UserInfos_UserInfoId",
                table: "Feeds",
                column: "UserInfoId",
                principalTable: "UserInfos",
                principalColumn: "Id");
        }
    }
}
