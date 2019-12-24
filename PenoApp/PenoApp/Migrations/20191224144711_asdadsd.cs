using Microsoft.EntityFrameworkCore.Migrations;

namespace PenoApp.Migrations
{
    public partial class asdadsd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "No",
                table: "Students");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "No",
                table: "Students",
                nullable: false,
                defaultValue: 0);
        }
    }
}
