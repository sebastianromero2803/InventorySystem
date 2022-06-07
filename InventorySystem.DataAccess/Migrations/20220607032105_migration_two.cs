using Microsoft.EntityFrameworkCore.Migrations;

namespace InventorySystem.DataAccess.Migrations
{
    public partial class migration_two : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdArticle",
                table: "Movement",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdArticle",
                table: "Movement");
        }
    }
}
