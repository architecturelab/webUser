using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Models.Aplicacion;
using WebApp.Validacion.Aplicacion;

namespace WebApp.Controllers
{
    [Authorize]
    public class DominioController : Controller
    {
        public IActionResult Empleados()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "SI", Value = "SI" });
            items.Add(new SelectListItem { Text = "NO", Value = "NO" });
            ViewBag.VIGENTE = new SelectList(items, "Text", "Value");

            return View(new DominioValidacion().ConsultarEmpleados());
        }

        [HttpPost]
        public JsonResult CrearEmpleado(EmpleadoDTO empleadoDTO)
        {
            (bool, string) resultado = new DominioValidacion().ValidacionEmpleadoAsync(empleadoDTO);
            return Json(new { ok = resultado.Item1, mensaje = resultado.Item2 });
        }

        public IActionResult Dependencias()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "SI", Value = "SI" });
            items.Add(new SelectListItem { Text = "NO", Value = "NO" });
            ViewBag.VIGENTE = new SelectList(items, "Text", "Value");
            
            return View(new DominioValidacion().ConsultarDependencias());
        }

        [HttpPost]
        public JsonResult CrearDependencia(DependenciaDTO dependenciaDTO)
        {
            (bool, string) resultado = new DominioValidacion().ValidacionDependenciaAsync(dependenciaDTO);
            return Json(new { ok = resultado.Item1, mensaje = resultado.Item2 });
        }

        [HttpPost]
        public JsonResult ActualizarDependencia(DependenciaDTO dependenciaDTO)
        {
            (bool, string) resultado = new DominioValidacion().ActualizarDependenciaAsync(dependenciaDTO);
            return Json(new { ok = resultado.Item1, mensaje = resultado.Item2 });
        }

        public IActionResult Clases()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "SI", Value = "SI" });
            items.Add(new SelectListItem { Text = "NO", Value = "NO" });
            ViewBag.VIGENTE = new SelectList(items, "Text", "Value");

            return View(new DominioValidacion().ConsultarClases());
        }

        [HttpPost]
        public JsonResult CrearClase(ClaseDTO claseDTO)
        {
            (bool, string) resultado = new DominioValidacion().ValidacionClaseAsync(claseDTO);
            return Json(new { ok = resultado.Item1, mensaje = resultado.Item2 });
        }

        [HttpPost]
        public JsonResult ActualizarClase(ClaseDTO claseDTO)
        {
            (bool, string) resultado = new DominioValidacion().ActualizarClaseAsync(claseDTO);
            return Json(new { ok = resultado.Item1, mensaje = resultado.Item2 });
        }

        public IActionResult Marcas()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "SI", Value = "SI" });
            items.Add(new SelectListItem { Text = "NO", Value = "NO" });
            ViewBag.VIGENTE = new SelectList(items, "Text", "Value");

            return View(new DominioValidacion().ConsultarMarcas());
        }

        [HttpPost]
        public JsonResult CrearMarca(MarcaDTO marcaDTO)
        {
            (bool, string) resultado = new DominioValidacion().ValidacionMarcaAsync(marcaDTO);
            return Json(new { ok = resultado.Item1, mensaje = resultado.Item2 });
        }

        [HttpPost]
        public JsonResult ActualizarMarca(MarcaDTO marcaDTO)
        {
            (bool, string) resultado = new DominioValidacion().ActualizarMarcaAsync(marcaDTO);
            return Json(new { ok = resultado.Item1, mensaje = resultado.Item2 });
        }

        public IActionResult Modelos()
        {
            ViewBag.MARCA = new SelectList(new DominioValidacion().ConsultarMarcas(), "marcaId", "nombre");
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "SI", Value = "SI" });
            items.Add(new SelectListItem { Text = "NO", Value = "NO" });
            ViewBag.VIGENTE = new SelectList(items, "Text", "Value");

            return View(new DominioValidacion().ConsultarModelos());
        }

        [HttpPost]
        public JsonResult CrearModelo(ModeloDTO modeloDTO)
        {
            (bool, string) resultado = new DominioValidacion().ValidacionModeloAsync(modeloDTO);
            return Json(new { ok = resultado.Item1, mensaje = resultado.Item2 });
        }

        [HttpPost]
        public JsonResult ActualizarModelo(ModeloDTO modeloDTO)
        {
            (bool, string) resultado = new DominioValidacion().ActualizarModeloAsync(modeloDTO);
            return Json(new { ok = resultado.Item1, mensaje = resultado.Item2 });
        }
    }
}
