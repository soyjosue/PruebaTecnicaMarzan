using Microsoft.AspNetCore.Mvc;

namespace PruebaTecnicaMarzan.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
