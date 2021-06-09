using Microsoft.EntityFrameworkCore.Migrations;

namespace Seminar.DAL.Migrations
{
    public partial class AccessLevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccessLevel",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: Model.AccessLevel.Guest);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessLevel",
                table: "AspNetUsers");
        }
    }
}
