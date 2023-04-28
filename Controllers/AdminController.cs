using Microsoft.AspNetCore.Mvc;

namespace VendaLanches.Controllers
{
    public class AdminController : Controller
    {
        public string Index()
        {
            return $"Testando AdminController Index : {DateTime.Now}";
        }
        public string Demo()
        {
            return $"Testando AdminController Demo : {DateTime.Now}";
        }
    }
}
