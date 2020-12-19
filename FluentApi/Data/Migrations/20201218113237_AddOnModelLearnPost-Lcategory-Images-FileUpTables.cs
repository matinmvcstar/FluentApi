using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FluentApi.Data.Migrations
{
    public partial class AddOnModelLearnPostLcategoryImagesFileUpTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoLogo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Tell = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoLogo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileUps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrlFile = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    NameFile = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileUps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Imagess",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagePost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GraphicPostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imagess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Imagess_GraphicPosts_GraphicPostId",
                        column: x => x.GraphicPostId,
                        principalTable: "GraphicPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LearnPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Video = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Header = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateSlide = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearnPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LearnPosts_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LearnPosts_LCategories_LCategoryId",
                        column: x => x.LCategoryId,
                        principalTable: "LCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Imagess_GraphicPostId",
                table: "Imagess",
                column: "GraphicPostId");

            migrationBuilder.CreateIndex(
                name: "IX_LearnPosts_CustomerId",
                table: "LearnPosts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_LearnPosts_LCategoryId",
                table: "LearnPosts",
                column: "LCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoLogo");

            migrationBuilder.DropTable(
                name: "FileUps");

            migrationBuilder.DropTable(
                name: "Imagess");

            migrationBuilder.DropTable(
                name: "LearnPosts");

            migrationBuilder.DropTable(
                name: "LCategories");
        }
    }
}
