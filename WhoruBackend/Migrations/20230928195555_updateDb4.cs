using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhoruBackend.Migrations
{
    /// <inheritdoc />
    public partial class updateDb4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 28, 19, 55, 55, 710, DateTimeKind.Utc).AddTicks(9327), new DateTime(2023, 9, 28, 19, 55, 55, 710, DateTimeKind.Utc).AddTicks(9330) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 28, 19, 55, 55, 710, DateTimeKind.Utc).AddTicks(9332), new DateTime(2023, 9, 28, 19, 55, 55, 710, DateTimeKind.Utc).AddTicks(9333) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password", "Phone", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 28, 19, 55, 55, 710, DateTimeKind.Utc).AddTicks(9381), "AQAQJwAA6iY4jyFdyzniDRLE14cUqqjNIpL92/tA+FpQxTL+DgxX2FmKl5kIdRTJv1qQ4Jmz", "0769395658", new DateTime(2023, 9, 28, 19, 55, 55, 710, DateTimeKind.Utc).AddTicks(9382) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Password", "Phone", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 28, 19, 55, 55, 720, DateTimeKind.Utc).AddTicks(1843), "AQAQJwAApWennW3cyNEPm3HaYT5GIMdgEyaDt9iuJIJs/ddglHsNZTa1/HD5QkOE2OHVv8Dn", "0769395658", new DateTime(2023, 9, 28, 19, 55, 55, 720, DateTimeKind.Utc).AddTicks(1845) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 28, 19, 43, 35, 170, DateTimeKind.Utc).AddTicks(8741), new DateTime(2023, 9, 28, 19, 43, 35, 170, DateTimeKind.Utc).AddTicks(8746) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 28, 19, 43, 35, 170, DateTimeKind.Utc).AddTicks(8747), new DateTime(2023, 9, 28, 19, 43, 35, 170, DateTimeKind.Utc).AddTicks(8748) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 28, 19, 43, 35, 170, DateTimeKind.Utc).AddTicks(8808), "AQAQJwAAZ+IlLCHxIFpAHARmXA78L/gTCTYUMcH/PoTM5mlLnfaFpDl09Ds94jxaWacogl8q", new DateTime(2023, 9, 28, 19, 43, 35, 170, DateTimeKind.Utc).AddTicks(8810) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 28, 19, 43, 35, 183, DateTimeKind.Utc).AddTicks(6334), "AQAQJwAAgS1eqovE+d056J6p/kPJCAYuaDtAE3+hcMsW8oVv6F+VzxIly0O36PyTzgdA/ViZ", new DateTime(2023, 9, 28, 19, 43, 35, 183, DateTimeKind.Utc).AddTicks(6339) });
        }
    }
}
