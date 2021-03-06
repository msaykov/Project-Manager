using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectManager.Data.Migrations
{
    public partial class PropertyIsClosedAddedToProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsClosed",
                table: "Projects",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsClosed",
                table: "Projects");
        }
    }
}
