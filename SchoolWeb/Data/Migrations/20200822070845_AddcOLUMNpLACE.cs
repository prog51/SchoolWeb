using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolWeb.Migrations
{
    public partial class AddcOLUMNpLACE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Placed",
                table: "Schools");

            migrationBuilder.AddColumn<string>(
                name: "Placed",
                table: "Students",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Placed",
                table: "Students");

            migrationBuilder.AddColumn<string>(
                name: "Placed",
                table: "Schools",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
