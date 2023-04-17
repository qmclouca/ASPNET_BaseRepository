using Microsoft.AspNetCore.Mvc;
using VendaLanches.Models;
using VendaLanches.Repositories.Interfaces;

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
            ViewData["Título"] = "Todos os lanches";
            ViewData["Data"] = DateTime.Now;
            IEnumerable<Lanche> lanches = _lancheRepository.Lanches;
            
            int totalLanches = lanches.Count();
            ViewBag.Total = "Total de lanches: ";
            ViewBag.TotalLanches = totalLanches;
            return View(lanches);
        }
    }
}
