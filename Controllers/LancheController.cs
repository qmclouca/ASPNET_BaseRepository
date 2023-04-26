using Microsoft.AspNetCore.Mvc;
using VendaLanches.Models;
using VendaLanches.Repositories.Interfaces;
using VendaLanches.ViewModels;

namespace VendaLanches.Controllers
{
    public class LancheController : Controller
    {
        private readonly ILancheRepository _lancheRepository;

        public LancheController(ILancheRepository lancheRepository)
        {
            _lancheRepository = lancheRepository;
        }

        public IActionResult List(string categoria)
        {
            IEnumerable<Lanche> lanches;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {
                lanches = _lancheRepository.Lanches.OrderBy(l => l.LancheId);
                categoriaAtual = "Todos os lanches";
            }
            else
            {
                if (string.Equals("Normal", categoria, StringComparison.OrdinalIgnoreCase))
                {
                    lanches = _lancheRepository.Lanches
                        .Where(l => l.Categoria.CategoriaNome.ToLower().Equals("normal", StringComparison.Ordinal))
                        .OrderBy(l => l.Nome);
                }
                else
                {
                    lanches = _lancheRepository.Lanches.Where(x => x.Categoria.CategoriaNome.ToLower().Equals("natural")).OrderBy(l => l.Nome);
                }
                categoriaAtual = categoria;
            }
            var lanchesListViewModel = new LancheListVewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual
            };
            return View(lanchesListViewModel);

        }
    }
}
