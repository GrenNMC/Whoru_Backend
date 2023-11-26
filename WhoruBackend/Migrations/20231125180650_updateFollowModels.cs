using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WhoruBackend.Migrations
{
    /// <inheritdoc />
    public partial class updateFollowModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Follows");

            migrationBuilder.AlterColumn<int>(
                name: "UserSend",
                table: "Notifications",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "UserReceive",
                table: "Notifications",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 11, 25, 18, 6, 50, 111, DateTimeKind.Utc).AddTicks(7031), new DateTime(2023, 11, 25, 18, 6, 50, 111, DateTimeKind.Utc).AddTicks(7034) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 11, 25, 18, 6, 50, 111, DateTimeKind.Utc).AddTicks(7036), new DateTime(2023, 11, 25, 18, 6, 50, 111, DateTimeKind.Utc).AddTicks(7037) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 11, 25, 18, 6, 50, 111, DateTimeKind.Utc).AddTicks(7084), "AQAQJwAAp+xE9kuZ3zVzlVoIVJIcTdzvaZIY4ddBtE5MlzZ2ToNjoMFyYDUBEcbQztAfiBDk", new DateTime(2023, 11, 25, 18, 6, 50, 111, DateTimeKind.Utc).AddTicks(7085) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 11, 25, 18, 6, 50, 121, DateTimeKind.Utc).AddTicks(3544), "AQAQJwAAh8K7gwntTzGZYrcLkgpNk6dMGzDpOEnO66JWl1JG0NutYXYwe6ChS3XIt8W/w0pN", new DateTime(2023, 11, 25, 18, 6, 50, 121, DateTimeKind.Utc).AddTicks(3548) });

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserReceive",
                table: "Notifications",
                column: "UserReceive");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_UserReceive",
                table: "Notifications");

            migrationBuilder.AlterColumn<int>(
                name: "UserSend",
                table: "Notifications",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserReceive",
                table: "Notifications",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Follows",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications",
                columns: new[] { "UserReceive", "UserSend" });

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
        }
    }
}
