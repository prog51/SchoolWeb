using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolWeb.Migrations
{
    public partial class Rank : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RankID",
                table: "Schools",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Schools_RankID",
                table: "Schools",
                column: "RankID");

            migrationBuilder.AddForeignKey(
                name: "FK_Schools_Ranks_RankID",
                table: "Schools",
                column: "RankID",
                principalTable: "Ranks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schools_Ranks_RankID",
                table: "Schools");

            migrationBuilder.DropIndex(
                name: "IX_Schools_RankID",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "RankID",
                table: "Schools");
        }
    }
}
