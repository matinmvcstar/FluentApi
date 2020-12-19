using Microsoft.EntityFrameworkCore.Migrations;

namespace FluentApi.Data.Migrations
{
    public partial class AddAllTables2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO Categories VALUES('طراحی گرافیک')");
            migrationBuilder.Sql(@"INSERT INTO Categories VALUES('فتوشاپ')");
            migrationBuilder.Sql(@"INSERT INTO Categories VALUES('ایلاستریتور')");
            migrationBuilder.Sql(@"INSERT INTO Categories VALUES('ایندیزاین')");
            migrationBuilder.Sql(@"INSERT INTO Categories VALUES('فوتومونتاژ')");
            migrationBuilder.Sql(@"INSERT INTO Categories VALUES('لیتوگرافی')");
            migrationBuilder.Sql(@"INSERT INTO Categories VALUES('رزآبی')");
            migrationBuilder.Sql(@"INSERT INTO Categories VALUES('PHOTOSHOP')");
            migrationBuilder.Sql(@"INSERT INTO Categories VALUES('ILLUSTRATOR')");
            migrationBuilder.Sql(@"INSERT INTO Categories VALUES('INDESIGN')");
            migrationBuilder.Sql(@"INSERT INTO Categories VALUES('ADOBE')");
            migrationBuilder.Sql(@"INSERT INTO Categories VALUES('BLUEROSIMA')");
            migrationBuilder.Sql(@"INSERT INTO Categories VALUES('طراحی سایت')");
            migrationBuilder.Sql(@"INSERT INTO Categories VALUES('برنامه نویسی سایت')");
            migrationBuilder.Sql(@"INSERT INTO Categories VALUES('FRONTEND DEVELOPER')");
            migrationBuilder.Sql(@"INSERT INTO Categories VALUES('BACKEND DEVELOPER')");
            migrationBuilder.Sql(@"INSERT INTO Categories VALUES('WEB DESIGN')");
            migrationBuilder.Sql(@"INSERT INTO Categories VALUES('UI/UX')");
            migrationBuilder.Sql(@"INSERT INTO Categories VALUES('تجربه رابط کاربری')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
