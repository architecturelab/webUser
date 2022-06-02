namespace WebApp.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    [Authorize]
    public class InicioController : Controller
    {
        public IActionResult PaginaInicial()
        {
            //var principal = HttpContext.User.Identities.ToList();
            return View();
        }
    }
}
