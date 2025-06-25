using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Artistas.Migrations
{
    /// <inheritdoc />
    public partial class relaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artistas_CategoriaArtistas_CategoriaArtistasid",
                table: "Artistas");

            migrationBuilder.DropIndex(
                name: "IX_Artistas_CategoriaArtistasid",
                table: "Artistas");

            migrationBuilder.DropColumn(
                name: "CategoriaArtistasid",
                table: "Artistas");

            migrationBuilder.CreateIndex(
                name: "IX_Artistas_idCategoria",
                table: "Artistas",
                column: "idCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Artistas_CategoriaArtistas_idCategoria",
                table: "Artistas",
                column: "idCategoria",
                principalTable: "CategoriaArtistas",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artistas_CategoriaArtistas_idCategoria",
                table: "Artistas");

            migrationBuilder.DropIndex(
                name: "IX_Artistas_idCategoria",
                table: "Artistas");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaArtistasid",
                table: "Artistas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Artistas_CategoriaArtistasid",
                table: "Artistas",
                column: "CategoriaArtistasid");

            migrationBuilder.AddForeignKey(
                name: "FK_Artistas_CategoriaArtistas_CategoriaArtistasid",
                table: "Artistas",
                column: "CategoriaArtistasid",
                principalTable: "CategoriaArtistas",
                principalColumn: "id");
        }
    }
}
