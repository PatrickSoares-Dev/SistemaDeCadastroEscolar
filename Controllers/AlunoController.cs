using Microsoft.AspNetCore.Mvc;

namespace Sistema_Escolar.Controllers
{
    public class AlunoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
