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
            string resultado = await new DominioValidacion().ValidacionEmpleadoAsync(empleadoDTO);
            return Json(new { mensaje = resultado });
        }

        public async Task<IActionResult> Dependencias()
        {
            return View(await new DominioValidacion().ConsultarDependencias());
        }

        [HttpPost]
        public async Task<JsonResult> CrearDependencia(DependenciaDTO dependenciaDTO)
        {
            string resultado = await new DominioValidacion().ValidacionDependenciaAsync(dependenciaDTO);
            return Json(new { mensaje = resultado });
        }

        public async Task<IActionResult> Clases()
        {
            return View(await new DominioValidacion().ConsultarClases());
        }

        [HttpPost]
        public async Task<JsonResult> CrearClase(ClaseDTO claseDTO)
        {
            string resultado = await new DominioValidacion().ValidacionClaseAsync(claseDTO);
            return Json(new { mensaje = resultado });
        }

        public async Task<IActionResult> Marcas()
        {
            ViewBag.CLASE = new SelectList(await new DominioValidacion().ConsultarClases(), "CLASE_ID", "NOMBRE");

            return View(await new DominioValidacion().ConsultarMarcas());
        }

        [HttpPost]
        public async Task<JsonResult> CrearMarca(MarcaDTO marcaDTO)
        {
            string resultado = await new DominioValidacion().ValidacionMarcaAsync(marcaDTO);
            return Json(new { mensaje = resultado });
        }

        public async Task<IActionResult> Modelos()
        {
            ViewBag.MARCA = new SelectList(await new DominioValidacion().ConsultarMarcas(), "MARCA_ID", "NOMBRE");

            return View(await new DominioValidacion().ConsultarModelos());
        }

        [HttpPost]
        public async Task<JsonResult> CrearModelo(ModeloDTO modeloDTO)
        {
            string resultado = await new DominioValidacion().ValidacionModeloAsync(modeloDTO);
            return Json(new { mensaje = resultado });
        }
    }
}
