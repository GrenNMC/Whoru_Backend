using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhoruBackend.Migrations
{
    /// <inheritdoc />
    public partial class FixedNameUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isDisabled",
                table: "Users",
                newName: "IsDisabled");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDisabled",
                table: "Users",
                newName: "isDisabled");

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
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 25, 18, 27, 9, 855, DateTimeKind.Utc).AddTicks(6153), "AQAQJwAASXZOr1WBGR+Oaz/RGcvYPsRgX412VCJhDyOVfQ4lAukkjkfJYvWDkfAMv22DTXqV", new DateTime(2023, 10, 25, 18, 27, 9, 855, DateTimeKind.Utc).AddTicks(6153) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 25, 18, 27, 9, 866, DateTimeKind.Utc).AddTicks(6947), "AQAQJwAAHZNStC5NkrWLzVKODgnCPRjcGv7Rv/MRudiqOwURzP5wuQqNd8GeLDcloVzoqCEA", new DateTime(2023, 10, 25, 18, 27, 9, 866, DateTimeKind.Utc).AddTicks(6951) });
        }
    }
}
