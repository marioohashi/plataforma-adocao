using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class UpdateAnimalTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ONGId",
                table: "Animais",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Animais_ONGId",
                table: "Animais",
                column: "ONGId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animais_ONGs_ONGId",
                table: "Animais",
                column: "ONGId",
                principalTable: "ONGs",
                principalColumn: "ONGId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animais_ONGs_ONGId",
                table: "Animais");

            migrationBuilder.DropIndex(
                name: "IX_Animais_ONGId",
                table: "Animais");

            migrationBuilder.DropColumn(
                name: "ONGId",
                table: "Animais");
        }
    }
}
