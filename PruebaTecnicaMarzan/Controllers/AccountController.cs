using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaMarzan.ViewModels;

namespace PruebaTecnicaMarzan.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(SignInViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            return View(model);
        }
    }
}
