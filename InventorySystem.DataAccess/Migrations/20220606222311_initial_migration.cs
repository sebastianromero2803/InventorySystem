using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InventorySystem.DataAccess.Migrations
{
    public partial class initial_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    IdArticle = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    MeasurementUnit = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.IdArticle);
                });

            migrationBuilder.CreateTable(
                name: "Movement",
                columns: table => new
                {
                    IdMovement = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Concept = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    State = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    MovementType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movement", x => x.IdMovement);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Article");

            migrationBuilder.DropTable(
                name: "Movement");
        }
    }
}
