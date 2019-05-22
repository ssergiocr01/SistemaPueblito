using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaPueblito.Web.Migrations
{
    public partial class AddStateInChildren : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Children",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Children");
        }
    }
}
