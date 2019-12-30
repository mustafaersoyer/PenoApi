using Microsoft.EntityFrameworkCore.Migrations;

namespace PenoApp.Migrations
{
    public partial class noticetitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "No",
                table: "Students",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "title",
                table: "Notices",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "No",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "title",
                table: "Notices");
        }
    }
}
