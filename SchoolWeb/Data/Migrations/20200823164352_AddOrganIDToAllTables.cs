using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolWeb.Migrations
{
    public partial class AddOrganIDToAllTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OrganizationID",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrganizationID",
                table: "Schools",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_OrganizationID",
                table: "Students",
                column: "OrganizationID");

            migrationBuilder.CreateIndex(
                name: "IX_Schools_OrganizationID",
                table: "Schools",
                column: "OrganizationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Schools_AspNetUsers_OrganizationID",
                table: "Schools",
                column: "OrganizationID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AspNetUsers_OrganizationID",
                table: "Students",
                column: "OrganizationID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schools_AspNetUsers_OrganizationID",
                table: "Schools");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_AspNetUsers_OrganizationID",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_OrganizationID",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Schools_OrganizationID",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "OrganizationID",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "OrganizationID",
                table: "Schools");
        }
    }
}
