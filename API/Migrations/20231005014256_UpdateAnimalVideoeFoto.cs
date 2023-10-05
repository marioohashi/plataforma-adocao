using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class UpdateAnimalVideoeFoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Idade",
                table: "Animais",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "Animais",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Video",
                table: "Animais",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Animais");

            migrationBuilder.DropColumn(
                name: "Video",
                table: "Animais");

            migrationBuilder.AlterColumn<int>(
                name: "Idade",
                table: "Animais",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
