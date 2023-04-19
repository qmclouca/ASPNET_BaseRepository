using Microsoft.AspNetCore.Mvc;
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

        public IActionResult List()
        {
           
            //IEnumerable<Lanche> lanches = _lancheRepository.Lanches;
            //return View(lanches);
            LancheListVewModel lancheListViewModel = new LancheListVewModel();
            lancheListViewModel.Lanches = _lancheRepository.Lanches;
            lancheListViewModel.CategoriaAtual = "Categoria Atual";
            return View(lancheListViewModel);
        }
    }
}
