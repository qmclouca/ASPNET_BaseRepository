using Microsoft.AspNetCore.Mvc;
using VendaLanches.Models;
using VendaLanches.Repositories.Interfaces;
using VendaLanches.ViewModels;

namespace VendaLanches.Controllers
{
    public class LancheController : Controller
    {
        private readonly ILancheRepository _lancheRepository;
        private readonly ICategoriaRepository _categoriaRepository;

        public LancheController(ILancheRepository lancheRepository, ICategoriaRepository categoriaRepository)
        {
            _lancheRepository = lancheRepository;
            _categoriaRepository = categoriaRepository;
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
                lanches = _lancheRepository.Lanches
                    .Where(l => l.Categoria.CategoriaNome.Equals(categoria))
                    .OrderBy(c => c.Nome);
                //if (categoria.ToUpper().Equals("NORMAL"))
                //{
                //    int categoriaId = _categoriaRepository.Categorias.FirstOrDefault(c => c.CategoriaNome.ToUpper().Equals("NORMAL")).CategoriaId;
                //    lanches = _lancheRepository.Lanches.Where(l=> l.CategoriaId.Equals(categoriaId))
                //        .OrderBy(l => l.Nome);
                //}
                //else
                //{
                //    int categoriaId = _categoriaRepository.Categorias.FirstOrDefault(c => c.CategoriaNome.ToUpper().Equals("NATURAL")).CategoriaId;
                //    lanches = _lancheRepository.Lanches.Where(l => l.CategoriaId.Equals(categoriaId))
                //        .OrderBy(l => l.Nome);
                //}
                categoriaAtual = categoria;
            }

            var lanchesListViewModel = new LancheListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual
            };

            return View(lanchesListViewModel);
        }
    }
}
