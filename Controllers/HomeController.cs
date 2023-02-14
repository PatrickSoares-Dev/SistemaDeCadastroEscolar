using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sistema_Escolar.Models;
using System.Diagnostics;

namespace Sistema_Escolar.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
