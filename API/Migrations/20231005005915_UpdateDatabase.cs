using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class UpdateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ONGs_Eventos_EventoId",
                table: "ONGs");

            migrationBuilder.DropIndex(
                name: "IX_ONGs_EventoId",
                table: "ONGs");

            migrationBuilder.DropColumn(
                name: "EventoId",
                table: "ONGs");

            migrationBuilder.AddColumn<int>(
                name: "ONGId",
                table: "Eventos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_ONGId",
                table: "Eventos",
                column: "ONGId");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_ONGs_ONGId",
                table: "Eventos",
                column: "ONGId",
                principalTable: "ONGs",
                principalColumn: "ONGId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_ONGs_ONGId",
                table: "Eventos");

            migrationBuilder.DropIndex(
                name: "IX_Eventos_ONGId",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "ONGId",
                table: "Eventos");

            migrationBuilder.AddColumn<int>(
                name: "EventoId",
                table: "ONGs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ONGs_EventoId",
                table: "ONGs",
                column: "EventoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ONGs_Eventos_EventoId",
                table: "ONGs",
                column: "EventoId",
                principalTable: "Eventos",
                principalColumn: "EventoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
