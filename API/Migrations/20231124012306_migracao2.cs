using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class migracao2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_Animais_AnimalId",
                table: "Pessoas");

            migrationBuilder.AlterColumn<int>(
                name: "AnimalId",
                table: "Pessoas",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_Animais_AnimalId",
                table: "Pessoas",
                column: "AnimalId",
                principalTable: "Animais",
                principalColumn: "AnimalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_Animais_AnimalId",
                table: "Pessoas");

            migrationBuilder.AlterColumn<int>(
                name: "AnimalId",
                table: "Pessoas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_Animais_AnimalId",
                table: "Pessoas",
                column: "AnimalId",
                principalTable: "Animais",
                principalColumn: "AnimalId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
