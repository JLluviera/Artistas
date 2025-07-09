using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Artistas.Migrations
{
    /// <inheritdoc />
    public partial class mejora : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artistas_Usuarios_IdUsuario",
                table: "Artistas");

            migrationBuilder.AddForeignKey(
                name: "FK_Artistas_Usuarios_IdUsuario",
                table: "Artistas",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artistas_Usuarios_IdUsuario",
                table: "Artistas");

            migrationBuilder.AddForeignKey(
                name: "FK_Artistas_Usuarios_IdUsuario",
                table: "Artistas",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
