using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WhoruBackend.Migrations
{
    /// <inheritdoc />
    public partial class updateChatUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Feeds",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Chats",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OwnerId = table.Column<int>(type: "integer", nullable: false),
                    NameGroup = table.Column<string>(type: "text", nullable: true),
                    DescriptionGroup = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FeedGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GroupId = table.Column<int>(type: "integer", nullable: false),
                    FeedId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeedGroup_Feeds_FeedId",
                        column: x => x.FeedId,
                        principalTable: "Feeds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FeedGroup_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemberGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GroupId = table.Column<int>(type: "integer", nullable: false),
                    MemberId = table.Column<int>(type: "integer", nullable: false),
                    UserInfoId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemberGroup_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MemberGroup_UserInfos_UserInfoId",
                        column: x => x.UserInfoId,
                        principalTable: "UserInfos",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 7, 10, 16, 48, 1, 795, DateTimeKind.Utc).AddTicks(6231), new DateTime(2024, 7, 10, 16, 48, 1, 795, DateTimeKind.Utc).AddTicks(6234) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 7, 10, 16, 48, 1, 795, DateTimeKind.Utc).AddTicks(6235), new DateTime(2024, 7, 10, 16, 48, 1, 795, DateTimeKind.Utc).AddTicks(6236) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 7, 10, 16, 48, 1, 795, DateTimeKind.Utc).AddTicks(6283), "AQAQJwAAGksShEOAOSppMDXOUgWZdE4fPANItlP0dunHhRyNCvlhCslInQzwhlytdn1e/eLR", new DateTime(2024, 7, 10, 16, 48, 1, 795, DateTimeKind.Utc).AddTicks(6284) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 7, 10, 16, 48, 1, 807, DateTimeKind.Utc).AddTicks(9534), "AQAQJwAAXN7OkT47WaqLo+nQdj8s9VNT3uvT9QpPUSvmpcFSayOUZGgUN1xv5kCb2QnwoweC", new DateTime(2024, 7, 10, 16, 48, 1, 807, DateTimeKind.Utc).AddTicks(9537) });

            migrationBuilder.CreateIndex(
                name: "IX_Feeds_GroupId",
                table: "Feeds",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_FeedGroup_FeedId",
                table: "FeedGroup",
                column: "FeedId");

            migrationBuilder.CreateIndex(
                name: "IX_FeedGroup_GroupId",
                table: "FeedGroup",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberGroup_GroupId",
                table: "MemberGroup",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberGroup_UserInfoId",
                table: "MemberGroup",
                column: "UserInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feeds_Group_GroupId",
                table: "Feeds",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feeds_Group_GroupId",
                table: "Feeds");

            migrationBuilder.DropTable(
                name: "FeedGroup");

            migrationBuilder.DropTable(
                name: "MemberGroup");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropIndex(
                name: "IX_Feeds_GroupId",
                table: "Feeds");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Feeds");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Chats");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 7, 9, 17, 55, 24, 689, DateTimeKind.Utc).AddTicks(7697), new DateTime(2024, 7, 9, 17, 55, 24, 689, DateTimeKind.Utc).AddTicks(7701) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 7, 9, 17, 55, 24, 689, DateTimeKind.Utc).AddTicks(7702), new DateTime(2024, 7, 9, 17, 55, 24, 689, DateTimeKind.Utc).AddTicks(7703) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 7, 9, 17, 55, 24, 689, DateTimeKind.Utc).AddTicks(7748), "AQAQJwAA4P2RLZcv7/YpanVgYlMgwODBNALFhe+D/q3nT6r17uLqqPWq3TtsO7BURBW0j1QG", new DateTime(2024, 7, 9, 17, 55, 24, 689, DateTimeKind.Utc).AddTicks(7748) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Password", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 7, 9, 17, 55, 24, 699, DateTimeKind.Utc).AddTicks(4023), "AQAQJwAABLHlPbEfPrL/bv5LQhablzlM0mQS00bNfCXLUFSzTcruGauN2c+muWUlVNPDdTKh", new DateTime(2024, 7, 9, 17, 55, 24, 699, DateTimeKind.Utc).AddTicks(4026) });
        }
    }
}
