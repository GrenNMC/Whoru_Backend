using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhoruBackend.Migrations
{
    /// <inheritdoc />
    public partial class update_feed_status : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Feeds",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 26, 17, 38, 45, 841, DateTimeKind.Utc).AddTicks(7225), new DateTime(2024, 6, 26, 17, 38, 45, 841, DateTimeKind.Utc).AddTicks(7231) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 26, 17, 38, 45, 841, DateTimeKind.Utc).AddTicks(7232), new DateTime(2024, 6, 26, 17, 38, 45, 841, DateTimeKind.Utc).AddTicks(7233) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 26, 17, 38, 45, 841, DateTimeKind.Utc).AddTicks(7290), "AQAQJwAAS9FG/jABWmdsoajf0m5HIwoXoHq2YfAIV7TdNbOAY/KMMPDkGVMR7OtkbKtQCMXp", new DateTime(2024, 6, 26, 17, 38, 45, 841, DateTimeKind.Utc).AddTicks(7291) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 26, 17, 38, 45, 858, DateTimeKind.Utc).AddTicks(6413), "AQAQJwAAtQz303mXpLBgi1OdDexl8NVgdrPjJjLhiOYyo60xXtzHRls97ChpeMO6F5+nH2vC", new DateTime(2024, 6, 26, 17, 38, 45, 858, DateTimeKind.Utc).AddTicks(6417) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Feeds");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 10, 6, 51, 59, 659, DateTimeKind.Utc).AddTicks(1618), new DateTime(2024, 6, 10, 6, 51, 59, 659, DateTimeKind.Utc).AddTicks(1623) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 10, 6, 51, 59, 659, DateTimeKind.Utc).AddTicks(1626), new DateTime(2024, 6, 10, 6, 51, 59, 659, DateTimeKind.Utc).AddTicks(1626) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 10, 6, 51, 59, 659, DateTimeKind.Utc).AddTicks(1716), "AQAQJwAAxmKzx+ac7omT9IyRnAR4B08jDe35Mb/rtpjCkXaHY6X6rDVHuDoccT6ZtHAYnPdj", new DateTime(2024, 6, 10, 6, 51, 59, 659, DateTimeKind.Utc).AddTicks(1717) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 10, 6, 51, 59, 676, DateTimeKind.Utc).AddTicks(7278), "AQAQJwAAhnx7I2MkvBLugGjB2Ihra140stctzBCw/yH8ga55GluGIiKBkq2KCXpNt+tSBmlg", new DateTime(2024, 6, 10, 6, 51, 59, 676, DateTimeKind.Utc).AddTicks(7282) });
        }
    }
}
