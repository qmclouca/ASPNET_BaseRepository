using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendaLanches.Migrations
{
    /// <inheritdoc />
    public partial class PopularCategorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categorias (CategoriaNome, Descricao) VALUES ('Bebidas', 'Bebidas quentes e frias')");
            migrationBuilder.Sql("INSERT INTO Categorias (CategoriaNome, Descricao) VALUES ('Lanches', 'Lanches de carne, frango, peixe e vegetarianos')");
            migrationBuilder.Sql("INSERT INTO Categorias (CategoriaNome, Descricao) VALUES ('Sobremesas', 'Sobremesas de frutas, sorvetes e doces')");
            migrationBuilder.Sql("INSERT INTO Categorias (CategoriaNome, Descricao) VALUES ('Normal', 'Ingredientes normais')");
            migrationBuilder.Sql("INSERT INTO Categorias (CategoriaNome, Descricao) VALUES ('Natural', 'Ingredientes naturais')");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categorias WHERE CategoriaNome IN ('Bebidas', 'Lanches', 'Sobremesas', 'Normal', 'Natural')");

        }
    }
}
