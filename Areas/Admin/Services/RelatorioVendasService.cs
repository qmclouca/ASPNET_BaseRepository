using Microsoft.EntityFrameworkCore;
using VendaLanches.Context;
using VendaLanches.Models;

namespace VendaLanches.Areas.Admin.Services
{
    public class RelatorioVendasService
    {
        private readonly AppDbContext _context;

        public RelatorioVendasService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Pedido>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.Pedidos select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.PedidoEnviado >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.PedidoEnviado <= maxDate.Value);
            }
            return await result
                .Include(x => x.PedidosItens)
                .ThenInclude(x => x.Lanche)
                .OrderByDescending(x => x.PedidoEnviado)
                .ToListAsync();
        }
    }
}
