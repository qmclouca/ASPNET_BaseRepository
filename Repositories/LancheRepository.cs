using Microsoft.EntityFrameworkCore;
using VendaLanches.Context;
using VendaLanches.Models;
using VendaLanches.Repositories.Interfaces;

namespace VendaLanches.Repositories
{
    public class LancheRepository: ILancheRepository
    {
        private readonly AppDbContext _context;
        public LancheRepository()
        {
        }
        public LancheRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Lanche> Lanches => _context.Lanches.Include(c => c.Categoria);
        public IEnumerable<Lanche> LanchesPreferidos => _context.Lanches.Where(p => p.IsLanchePreferido).Include(c => c.Categoria);
        public Lanche GetLancheById(int lancheId) => _context.Lanches.FirstOrDefault(p => p.LancheId == lancheId);
        
    }
}
