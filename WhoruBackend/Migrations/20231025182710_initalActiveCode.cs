using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhoruBackend.Migrations
{
    /// <inheritdoc />
    public partial class initalActiveCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ActiveCode",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 25, 18, 27, 9, 855, DateTimeKind.Utc).AddTicks(6099), new DateTime(2023, 10, 25, 18, 27, 9, 855, DateTimeKind.Utc).AddTicks(6103) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 25, 18, 27, 9, 855, DateTimeKind.Utc).AddTicks(6105), new DateTime(2023, 10, 25, 18, 27, 9, 855, DateTimeKind.Utc).AddTicks(6106) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ActiveCode", "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { "412002", new DateTime(2023, 10, 25, 18, 27, 9, 855, DateTimeKind.Utc).AddTicks(6153), "AQAQJwAASXZOr1WBGR+Oaz/RGcvYPsRgX412VCJhDyOVfQ4lAukkjkfJYvWDkfAMv22DTXqV", new DateTime(2023, 10, 25, 18, 27, 9, 855, DateTimeKind.Utc).AddTicks(6153) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ActiveCode", "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { "412222", new DateTime(2023, 10, 25, 18, 27, 9, 866, DateTimeKind.Utc).AddTicks(6947), "AQAQJwAAHZNStC5NkrWLzVKODgnCPRjcGv7Rv/MRudiqOwURzP5wuQqNd8GeLDcloVzoqCEA", new DateTime(2023, 10, 25, 18, 27, 9, 866, DateTimeKind.Utc).AddTicks(6951) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActiveCode",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 22, 16, 15, 13, 708, DateTimeKind.Utc).AddTicks(7799), new DateTime(2023, 10, 22, 16, 15, 13, 708, DateTimeKind.Utc).AddTicks(7804) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 22, 16, 15, 13, 708, DateTimeKind.Utc).AddTicks(7807), new DateTime(2023, 10, 22, 16, 15, 13, 708, DateTimeKind.Utc).AddTicks(7808) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 22, 16, 15, 13, 708, DateTimeKind.Utc).AddTicks(8122), "AQAQJwAApC4/tW0O5FPLe2k+7KL5rCXKiILmrI63g+CQOKdUtByk/HTL9QfwkOe2fMQhVhhr", new DateTime(2023, 10, 22, 16, 15, 13, 708, DateTimeKind.Utc).AddTicks(8123) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 22, 16, 15, 13, 724, DateTimeKind.Utc).AddTicks(7608), "AQAQJwAA/OZzZ5SQ2U+Tu1zYbhE7t8Q6NypkDMqXlYK6WWIcdCtHtbma3450fLWouY2GCMy/", new DateTime(2023, 10, 22, 16, 15, 13, 724, DateTimeKind.Utc).AddTicks(7612) });
        }
    }
}
