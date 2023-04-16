using VendaLanches.Context;
using VendaLanches.Models;
using VendaLanches.Repositories.Interfaces;

namespace VendaLanches.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _appDbContext;
        public CategoriaRepository(AppDbContext context)
        {
            _appDbContext = context;
        }
        public IEnumerable<Categoria> Categorias => throw new NotImplementedException();
    }
}
