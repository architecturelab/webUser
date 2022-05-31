using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class Reporte : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
