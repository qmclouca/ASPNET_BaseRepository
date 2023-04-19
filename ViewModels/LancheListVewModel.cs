using VendaLanches.Models;

namespace VendaLanches.ViewModels
{
    public class LancheListVewModel
    {
        public IEnumerable<Lanche> Lanches { get; set; }
        public string CategoriaAtual { get; set; }

    }
}
