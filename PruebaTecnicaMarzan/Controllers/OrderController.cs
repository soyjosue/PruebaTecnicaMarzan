using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaMarzan.Models;
using PruebaTecnicaMarzan.ViewModels;
using System.Collections.Generic;

namespace PruebaTecnicaMarzan.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View(new List<OrderViewModel>());
        }
    }
}
