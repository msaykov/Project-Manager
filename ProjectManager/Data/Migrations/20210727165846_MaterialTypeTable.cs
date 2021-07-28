using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectManager.Data.Migrations
{
    public partial class MaterialTypeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Types_TypeId",
                table: "Materials");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Types_TypeId",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "Types");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Projects",
                newName: "ProjectTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_TypeId",
                table: "Projects",
                newName: "IX_Projects_ProjectTypeId");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Materials",
                newName: "MaterialTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Materials_TypeId",
                table: "Materials",
                newName: "IX_Materials_MaterialTypeId");

            migrationBuilder.CreateTable(
                name: "MaterialTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTypes", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_MaterialTypes_MaterialTypeId",
                table: "Materials",
                column: "MaterialTypeId",
                principalTable: "MaterialTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_ProjectTypes_ProjectTypeId",
                table: "Projects",
                column: "ProjectTypeId",
                principalTable: "ProjectTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materials_MaterialTypes_MaterialTypeId",
                table: "Materials");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_ProjectTypes_ProjectTypeId",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "MaterialTypes");

            migrationBuilder.DropTable(
                name: "ProjectTypes");

            migrationBuilder.RenameColumn(
                name: "ProjectTypeId",
                table: "Projects",
                newName: "TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_ProjectTypeId",
                table: "Projects",
                newName: "IX_Projects_TypeId");

            migrationBuilder.RenameColumn(
                name: "MaterialTypeId",
                table: "Materials",
                newName: "TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Materials_MaterialTypeId",
                table: "Materials",
                newName: "IX_Materials_TypeId");

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Types_TypeId",
                table: "Materials",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Types_TypeId",
                table: "Projects",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
