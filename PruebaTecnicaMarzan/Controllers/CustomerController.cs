using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaMarzan.Models;
using System.Collections.Generic;

namespace PruebaTecnicaMarzan.Controllers
{
    public class CustomerController : Controller
    {
        public CustomerController()
        {

        }

        public IActionResult Index()
        {
            return View(new List<Customer>());
        }
    }
}
