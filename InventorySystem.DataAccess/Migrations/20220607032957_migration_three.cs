using Microsoft.EntityFrameworkCore.Migrations;

namespace InventorySystem.DataAccess.Migrations
{
    public partial class migration_three : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Movement_IdArticle",
                table: "Movement",
                column: "IdArticle");

            migrationBuilder.AddForeignKey(
                name: "FK_Movement_Article_IdArticle",
                table: "Movement",
                column: "IdArticle",
                principalTable: "Article",
                principalColumn: "IdArticle",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movement_Article_IdArticle",
                table: "Movement");

            migrationBuilder.DropIndex(
                name: "IX_Movement_IdArticle",
                table: "Movement");
        }
    }
}
