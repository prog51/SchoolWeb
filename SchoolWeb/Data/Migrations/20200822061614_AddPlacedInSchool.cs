using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolWeb.Migrations
{
    public partial class AddPlacedInSchool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Placed",
                table: "Schools",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Placed",
                table: "Schools");
        }
    }
}
