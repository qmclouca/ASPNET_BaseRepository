using Microsoft.EntityFrameworkCore;
using VendaLanches.Models;

namespace VendaLanches.Context
{
    public class AppDbContext : DbContext
    {
        private DbSet<Lanche> lanches;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Lanche> Lanches { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<CarrinhoCompraItem> CarrinhoCompraItens { get; set; }
    }
}
