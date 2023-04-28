using Microsoft.AspNetCore.Mvc;

namespace VendaLanches.Controllers
{
    public class TesteController : Controller
    {
        public string Index()
        {
            return $"Teste do método Index de TesteController: {DateTime.Now}";
        }
    }
}
