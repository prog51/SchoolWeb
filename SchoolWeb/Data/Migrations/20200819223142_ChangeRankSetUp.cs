using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolWeb.Migrations
{
    public partial class ChangeRankSetUp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ranks_Schools_SchoolID",
                table: "Ranks");

            migrationBuilder.DropIndex(
                name: "IX_Ranks_SchoolID",
                table: "Ranks");

            migrationBuilder.DropColumn(
                name: "SchoolID",
                table: "Ranks");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "Ranks");

            migrationBuilder.AddColumn<string>(
                name: "ValueRank",
                table: "Ranks",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValueRank",
                table: "Ranks");

            migrationBuilder.AddColumn<int>(
                name: "SchoolID",
                table: "Ranks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "Ranks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Ranks_SchoolID",
                table: "Ranks",
                column: "SchoolID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ranks_Schools_SchoolID",
                table: "Ranks",
                column: "SchoolID",
                principalTable: "Schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
