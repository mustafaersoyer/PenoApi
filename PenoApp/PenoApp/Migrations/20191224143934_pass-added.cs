using Microsoft.EntityFrameworkCore.Migrations;

namespace PenoApp.Migrations
{
    public partial class passadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Acas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Acas");
        }
    }
}
