using Web.Models.Aplicacion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Validacion.Aplicacion;

namespace Web.Controllers
{
    [Authorize]
    public class DominioController : Controller
    {
        public async Task<IActionResult> Empleados()
        {
            return View(await new DominioValidacion().ConsultarEmpleados());
        }

        [HttpPost]
        public async Task<JsonResult> CrearEmpleado(EmpleadoDTO empleadoDTO)
        {
            (bool, string) resultado = await new DominioValidacion().ValidacionEmpleadoAsync(empleadoDTO);
            return Json(new { ok = resultado.Item1, mensaje = resultado.Item2 });
        }

        public async Task<IActionResult> Dependencias()
        {
            return View(await new DominioValidacion().ConsultarDependencias());
        }

        [HttpPost]
        public async Task<JsonResult> CrearDependencia(DependenciaDTO dependenciaDTO)
        {
            (bool, string) resultado = await new DominioValidacion().ValidacionDependenciaAsync(dependenciaDTO);
            return Json(new { ok = resultado.Item1, mensaje = resultado.Item2 });
        }

        public async Task<IActionResult> Clases()
        {
            return View(await new DominioValidacion().ConsultarClases());
        }

        [HttpPost]
        public async Task<JsonResult> CrearClase(ClaseDTO claseDTO)
        {
            (bool, string) resultado = await new DominioValidacion().ValidacionClaseAsync(claseDTO);
            return Json(new { ok = resultado.Item1, mensaje = resultado.Item2 });
        }

        public async Task<IActionResult> Marcas()
        {
            return View(await new DominioValidacion().ConsultarMarcas());
        }

        [HttpPost]
        public async Task<JsonResult> CrearMarca(MarcaDTO marcaDTO)
        {
            (bool, string) resultado = await new DominioValidacion().ValidacionMarcaAsync(marcaDTO);
            return Json(new { ok = resultado.Item1, mensaje = resultado.Item2 });
        }

        public async Task<IActionResult> Modelos()
        {
            ViewBag.MARCA = new SelectList(await new DominioValidacion().ConsultarMarcas(), "marcaId", "nombre");

            return View(await new DominioValidacion().ConsultarModelos());
        }

        [HttpPost]
        public async Task<JsonResult> CrearModelo(ModeloDTO modeloDTO)
        {
            (bool, string) resultado = await new DominioValidacion().ValidacionModeloAsync(modeloDTO);
            return Json(new { ok = resultado.Item1, mensaje = resultado.Item2 });
        }
    }
}
