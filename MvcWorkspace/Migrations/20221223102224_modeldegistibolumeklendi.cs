using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcWorkspace.Migrations
{
    public partial class modeldegistibolumeklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BolumId",
                table: "Personeller",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Personeller_BolumId",
                table: "Personeller",
                column: "BolumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personeller_Bolumler_BolumId",
                table: "Personeller",
                column: "BolumId",
                principalTable: "Bolumler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personeller_Bolumler_BolumId",
                table: "Personeller");

            migrationBuilder.DropIndex(
                name: "IX_Personeller_BolumId",
                table: "Personeller");

            migrationBuilder.DropColumn(
                name: "BolumId",
                table: "Personeller");
        }
    }
}
