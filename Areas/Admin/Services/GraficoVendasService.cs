using VendaLanches.Context;
using VendaLanches.Models;

namespace VendaLanches.Areas.Admin.Services
{
    public class GraficoVendasService
    {
        private readonly AppDbContext _context;

        public GraficoVendasService(AppDbContext context)
        {
            _context = context;
        }

        public List<LancheGrafico> GetVendasLanches(int dias = 360)
        {
            DateTime data = DateTime.Now.AddDays(-dias);
            var lanches = (from detalhesPedido in _context.PedidoDetalhes
                           join lanche in _context.Lanches on detalhesPedido.LancheId equals lanche.LancheId
                           where detalhesPedido.Pedido.PedidoEnviado >= data
                           group detalhesPedido by new { detalhesPedido.LancheId, lanche.Nome, detalhesPedido.Quantidade }
                           into g
                           select new
                           {
                               LancheNome = g.Key.Nome,
                               LanchesQuantidade = g.Sum(q => q.Quantidade),
                               LanchesValorTotal = g.Sum(a => a.Preco * a.Quantidade)
                           });
            List<LancheGrafico> lista = new List<LancheGrafico>();
            foreach (var item in lanches)
            {
                var lanche = new LancheGrafico();
                lanche.LancheNome = item.LancheNome;
                lanche.LanchesQuantidade = item.LanchesQuantidade;
                lanche.LanchesValorTotal = item.LanchesValorTotal;
                lista.Add(lanche);
            }
            return lista;
        } 
    }
}