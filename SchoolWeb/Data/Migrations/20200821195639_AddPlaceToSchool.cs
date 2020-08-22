using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolWeb.Migrations
{
    public partial class AddPlaceToSchool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SchoolPlaced",
                table: "Students",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SchoolPlaced",
                table: "Students");
        }
    }
}
