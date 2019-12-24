using Microsoft.EntityFrameworkCore.Migrations;

namespace PenoApp.Migrations
{
    public partial class noadde : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "No",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "No",
                table: "Acas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "No",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "No",
                table: "Acas");
        }
    }
}
