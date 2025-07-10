using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Artistas.Migrations
{
    /// <inheritdoc />
    public partial class espectuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdUsuarioEspc",
                table: "Espectaculos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Espectaculos_IdUsuarioEspc",
                table: "Espectaculos",
                column: "IdUsuarioEspc");

            migrationBuilder.AddForeignKey(
                name: "FK_Espectaculos_Usuarios_IdUsuarioEspc",
                table: "Espectaculos",
                column: "IdUsuarioEspc",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Espectaculos_Usuarios_IdUsuarioEspc",
                table: "Espectaculos");

            migrationBuilder.DropIndex(
                name: "IX_Espectaculos_IdUsuarioEspc",
                table: "Espectaculos");

            migrationBuilder.DropColumn(
                name: "IdUsuarioEspc",
                table: "Espectaculos");
        }
    }
}
