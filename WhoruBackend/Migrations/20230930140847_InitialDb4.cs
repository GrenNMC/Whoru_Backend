using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WhoruBackend.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chats_UserInfos_ReceiverId",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Chats_UserInfos_SenderId",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_UserInfos_ReceiverId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_UserInfos_SenderId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInfos_UserInfos_UserId",
                table: "UserInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInfos_UserInfos_UserInfoId",
                table: "UserInfos");

            migrationBuilder.DropIndex(
                name: "IX_UserInfos_UserInfoId",
                table: "UserInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_ReceiverId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_SenderId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Chats_ReceiverId",
                table: "Chats");

            migrationBuilder.DropIndex(
                name: "IX_Chats_SenderId",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "UserInfoId",
                table: "UserInfos");

            migrationBuilder.DropColumn(
                name: "ReceiverId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "SenderId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "ReceiverId",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "SenderId",
                table: "Chats");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications",
                columns: new[] { "UserReceive", "UserSend" });

            migrationBuilder.CreateTable(
                name: "Follows",
                columns: table => new
                {
                    IdFollower = table.Column<int>(type: "integer", nullable: false),
                    IdFollowing = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Follows", x => new { x.IdFollowing, x.IdFollower });
                    table.ForeignKey(
                        name: "FK_Follows_UserInfos_IdFollower",
                        column: x => x.IdFollower,
                        principalTable: "UserInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Follows_UserInfos_IdFollowing",
                        column: x => x.IdFollowing,
                        principalTable: "UserInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 30, 14, 8, 47, 421, DateTimeKind.Utc).AddTicks(4061), new DateTime(2023, 9, 30, 14, 8, 47, 421, DateTimeKind.Utc).AddTicks(4066) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 30, 14, 8, 47, 421, DateTimeKind.Utc).AddTicks(4069), new DateTime(2023, 9, 30, 14, 8, 47, 421, DateTimeKind.Utc).AddTicks(4069) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 30, 14, 8, 47, 421, DateTimeKind.Utc).AddTicks(4153), "AQAQJwAASxeSaTqDPlLDJgJhvlFHMMJivsmMuxhLcjdgvO2YdPPno503v2l8tXKROTjK449g", new DateTime(2023, 9, 30, 14, 8, 47, 421, DateTimeKind.Utc).AddTicks(4154) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 30, 14, 8, 47, 442, DateTimeKind.Utc).AddTicks(5731), "AQAQJwAAIqkiJ3nPBz1R30oK6I8aeMVtEGz4XRDM75CYS0ip8xrAt4nZLsdnA7BN+nY5KUNn", new DateTime(2023, 9, 30, 14, 8, 47, 442, DateTimeKind.Utc).AddTicks(5736) });

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserSend",
                table: "Notifications",
                column: "UserSend");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_UserReceive",
                table: "Chats",
                column: "UserReceive");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_UserSend",
                table: "Chats",
                column: "UserSend");

            migrationBuilder.CreateIndex(
                name: "IX_Follows_IdFollower",
                table: "Follows",
                column: "IdFollower");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_UserInfos_UserReceive",
                table: "Chats",
                column: "UserReceive",
                principalTable: "UserInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_UserInfos_UserSend",
                table: "Chats",
                column: "UserSend",
                principalTable: "UserInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_UserInfos_UserReceive",
                table: "Notifications",
                column: "UserReceive",
                principalTable: "UserInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_UserInfos_UserSend",
                table: "Notifications",
                column: "UserSend",
                principalTable: "UserInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chats_UserInfos_UserReceive",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Chats_UserInfos_UserSend",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_UserInfos_UserReceive",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_UserInfos_UserSend",
                table: "Notifications");

            migrationBuilder.DropTable(
                name: "Follows");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_UserSend",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Chats_UserReceive",
                table: "Chats");

            migrationBuilder.DropIndex(
                name: "IX_Chats_UserSend",
                table: "Chats");

            migrationBuilder.AddColumn<int>(
                name: "UserInfoId",
                table: "UserInfos",
                type: "integer",
                nullable: true);

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

            migrationBuilder.AddColumn<int>(
                name: "ReceiverId",
                table: "Notifications",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SenderId",
                table: "Notifications",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReceiverId",
                table: "Chats",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SenderId",
                table: "Chats",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications",
                column: "Id");

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
                table: "UserInfos",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserInfoId",
                value: null);

            migrationBuilder.UpdateData(
                table: "UserInfos",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserInfoId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 28, 19, 55, 55, 710, DateTimeKind.Utc).AddTicks(9381), "AQAQJwAA6iY4jyFdyzniDRLE14cUqqjNIpL92/tA+FpQxTL+DgxX2FmKl5kIdRTJv1qQ4Jmz", new DateTime(2023, 9, 28, 19, 55, 55, 710, DateTimeKind.Utc).AddTicks(9382) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 28, 19, 55, 55, 720, DateTimeKind.Utc).AddTicks(1843), "AQAQJwAApWennW3cyNEPm3HaYT5GIMdgEyaDt9iuJIJs/ddglHsNZTa1/HD5QkOE2OHVv8Dn", new DateTime(2023, 9, 28, 19, 55, 55, 720, DateTimeKind.Utc).AddTicks(1845) });

            migrationBuilder.CreateIndex(
                name: "IX_UserInfos_UserInfoId",
                table: "UserInfos",
                column: "UserInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_ReceiverId",
                table: "Notifications",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_SenderId",
                table: "Notifications",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_ReceiverId",
                table: "Chats",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_SenderId",
                table: "Chats",
                column: "SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_UserInfos_ReceiverId",
                table: "Chats",
                column: "ReceiverId",
                principalTable: "UserInfos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_UserInfos_SenderId",
                table: "Chats",
                column: "SenderId",
                principalTable: "UserInfos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_UserInfos_ReceiverId",
                table: "Notifications",
                column: "ReceiverId",
                principalTable: "UserInfos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_UserInfos_SenderId",
                table: "Notifications",
                column: "SenderId",
                principalTable: "UserInfos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfos_UserInfos_UserId",
                table: "UserInfos",
                column: "UserId",
                principalTable: "UserInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfos_UserInfos_UserInfoId",
                table: "UserInfos",
                column: "UserInfoId",
                principalTable: "UserInfos",
                principalColumn: "Id");
        }
    }
}
