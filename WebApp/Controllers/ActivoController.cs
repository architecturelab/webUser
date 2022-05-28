namespace Web.Controllers
{
    using Web.Models.Aplicacion;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Web.Validacion.Aplicacion;

    [Authorize]
    public class ActivoController : Controller
    {

        [HttpGet]
        [Authorize(Roles = "Administrador,Diagnosticador,Evaluaciones,Reparaciones")]
        public async Task<IActionResult> BandejaActivos()
        {
            //ViewBag.RESULTADO_RICKMORTY = (new RickyMortyValidacion().Consultar()).results;
            return View(await new ActivoValidacion().ConsultarActivos());
        }

        [HttpGet]
        [Authorize(Roles = "Administrador,Almacenista")]

        public async Task<IActionResult> GestionActivos()
        {
            ViewBag.CLASE = new SelectList(await new DominioValidacion().ConsultarClases(), "claseId", "nombre");
            ViewBag.MARCA = new SelectList(await new DominioValidacion().ConsultarMarcas(), "marcaId", "nombre");
            ViewBag.MODELO = new SelectList(await new DominioValidacion().ConsultarModelos(), "modeloId", "nombre");
            ViewBag.DEPENDENCIA = new SelectList(await new DominioValidacion().ConsultarDependencias(), "dependenciaId", "nombre");

            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "Disponible", Value = "Disponible" });
            items.Add(new SelectListItem { Text = "Diagnostico", Value = "Diagnostico" });
            items.Add(new SelectListItem { Text = "Reparación", Value = "Reparación" });
            items.Add(new SelectListItem { Text = "Evaluación", Value = "Evaluación" });

            ViewBag.ESTADO = new SelectList(items, "Text", "Value");

            return View();
        }

        [HttpPost]
        public async Task<JsonResult> CrearActivo(ActivoDTO activoDTO)
        {
            (bool, string) resultado = await new ActivoValidacion().ValidacionActivoAsync(activoDTO);
            return Json(new { ok = resultado.Item1, mensaje = resultado.Item2 });
        }


        [HttpGet]
        [Authorize(Roles = "Administrador,Diagnosticador,Evaluaciones,Reparaciones")]
        public async Task<IActionResult> DetalleGestionActivo(int _id) {
            return View(await new ActivoValidacion().ConsultarActivoPorId(_id));
        }
    }
}
