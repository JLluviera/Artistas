using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Artistas.Migrations
{
    /// <inheritdoc />
    public partial class primera : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriaArtistas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaArtistas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Artistas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(40)", nullable: false),
                    Nacionalidad = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    FechaNacimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    idCategoria = table.Column<int>(type: "int", nullable: false),
                    CategoriaArtistasid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artistas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Artistas_CategoriaArtistas_CategoriaArtistasid",
                        column: x => x.CategoriaArtistasid,
                        principalTable: "CategoriaArtistas",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artistas_CategoriaArtistasid",
                table: "Artistas",
                column: "CategoriaArtistasid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artistas");

            migrationBuilder.DropTable(
                name: "CategoriaArtistas");
        }
    }
}
