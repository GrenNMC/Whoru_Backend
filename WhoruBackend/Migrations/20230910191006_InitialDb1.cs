using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhoruBackend.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 10, 19, 10, 6, 333, DateTimeKind.Utc).AddTicks(5542), "AQAQJwAAjvc2lWChvVWj5cOkLSsiL8QmaRibrroW0wepE6GITxLvrY199b1HPgXjv/KmDdgs", new DateTime(2023, 9, 10, 19, 10, 6, 333, DateTimeKind.Utc).AddTicks(5543) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 10, 19, 10, 6, 346, DateTimeKind.Utc).AddTicks(7989), "AQAQJwAAwtC5HnB0ixu9cm1cF4vMVlsvp4h4cQJ2nyHENOVVXcfgRFY2L2AijTCIXhbY1fZt", new DateTime(2023, 9, 10, 19, 10, 6, 346, DateTimeKind.Utc).AddTicks(7993) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 10, 16, 59, 16, 191, DateTimeKind.Utc).AddTicks(1900), new DateTime(2023, 9, 10, 16, 59, 16, 191, DateTimeKind.Utc).AddTicks(1903) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 10, 16, 59, 16, 191, DateTimeKind.Utc).AddTicks(1905), new DateTime(2023, 9, 10, 16, 59, 16, 191, DateTimeKind.Utc).AddTicks(1905) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 10, 16, 59, 16, 191, DateTimeKind.Utc).AddTicks(1945), "AQAQJwAAQ2AtuU4CoWrYJjP/7L2KcXJ8jAdNzCq1hUs7OxFk4oM1bvTTau5e7Qw6o44DH5V5", new DateTime(2023, 9, 10, 16, 59, 16, 191, DateTimeKind.Utc).AddTicks(1946) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 10, 16, 59, 16, 201, DateTimeKind.Utc).AddTicks(3302), "AQAQJwAARWzcNaXkHVneDmdMsO+cJNj5qIAsn6RUCj3d7HcNlYwZa1CFzHzC/P4EIKafRHxZ", new DateTime(2023, 9, 10, 16, 59, 16, 201, DateTimeKind.Utc).AddTicks(3305) });
        }
    }
}
