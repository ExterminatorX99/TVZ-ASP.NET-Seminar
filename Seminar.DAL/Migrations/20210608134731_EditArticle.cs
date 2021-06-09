using Microsoft.EntityFrameworkCore.Migrations;

namespace Seminar.DAL.Migrations
{
    public partial class EditArticle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubTitle",
                table: "Articles",
                newName: "Summary");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Summary",
                table: "Articles",
                newName: "SubTitle");
        }
    }
}
