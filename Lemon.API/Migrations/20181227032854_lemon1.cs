using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lemon.API.Migrations
{
    public partial class lemon1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogModel",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Content = table.Column<string>(nullable: true),
                    Createtime = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    BlogImgUri = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogModel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ReplyModel",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Content = table.Column<string>(nullable: true),
                    Createtime = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReplyModel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RoleModel",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Name = table.Column<string>(nullable: true),
                    roleType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleModel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "userModels",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    RoleId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    UserHeadImageUri = table.Column<string>(nullable: true),
                    Createtime = table.Column<DateTime>(nullable: false),
                    LastLoginTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userModels", x => x.ID);
                    table.ForeignKey(
                        name: "FK_userModels_RoleModel_RoleId",
                        column: x => x.RoleId,
                        principalTable: "RoleModel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_userModels_RoleId",
                table: "userModels",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogModel");

            migrationBuilder.DropTable(
                name: "ReplyModel");

            migrationBuilder.DropTable(
                name: "userModels");

            migrationBuilder.DropTable(
                name: "RoleModel");
        }
    }
}
