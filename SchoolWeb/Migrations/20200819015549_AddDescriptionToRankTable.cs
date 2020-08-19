using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolWeb.Migrations
{
    public partial class AddDescriptionToRankTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Ranks",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Ranks");
        }
    }
}
