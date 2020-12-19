using Microsoft.EntityFrameworkCore.Migrations;

namespace FluentApi.Data.Migrations
{
    public partial class AddCoLogos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CoLogo",
                table: "CoLogo");

            migrationBuilder.RenameTable(
                name: "CoLogo",
                newName: "CoLogos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoLogos",
                table: "CoLogos",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CoLogos",
                table: "CoLogos");

            migrationBuilder.RenameTable(
                name: "CoLogos",
                newName: "CoLogo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoLogo",
                table: "CoLogo",
                column: "Id");
        }
    }
}
