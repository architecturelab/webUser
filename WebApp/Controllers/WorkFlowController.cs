using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using WebApp.Models.Aplicacion;
using WebApp.Validacion.Aplicacion;
using WebApp.Validacion.General;

namespace WebApp.Controllers
{
    [Authorize]
    public class WorkFlowController : Controller
    {
        [HttpGet]
        public IActionResult Bandeja()
        {
            List<SelectListItem> items2 = new List<SelectListItem>();
            items2.Add(new SelectListItem { Text = "SI", Value = "true" });
            items2.Add(new SelectListItem { Text = "NO", Value = "false" });
            ViewBag.DESICION = new SelectList(items2, "Value", "Text");

            List<WorkFlowDTO> resultados = new WorkFlowValidacion().ConsultarWorkFlows();

            if (User.IsInRole("Diagnosticador"))
                resultados = resultados.Where(x => x.estado == "Diagnostico").ToList();
            else if (User.IsInRole("Evaluaciones"))
                resultados = resultados.Where(x => x.estado == "Reparación").ToList();
            else if (User.IsInRole("Reparaciones"))
                resultados = resultados.Where(x => x.estado == "Evaluación").ToList();

            return View(resultados);
        }

        [HttpPost]
        public JsonResult CrearWorkFlow(WorkFlowDTO workFlowDTO)
        {
            GestionClaims claim = new GestionClaims(User);
            workFlowDTO.usuarioCreacion = $"{claim.Nombres} {claim.Apellidos}";
            workFlowDTO.fechaCreacion = System.DateTime.Now;

            (bool, string) resultado = new WorkFlowValidacion().ValidacionWorkFlowAsync(workFlowDTO);
            return Json(new { ok = resultado.Item1, mensaje = resultado.Item2 });
        }

        [HttpPost]
        public JsonResult ActualizarWorkFlow(WorkFlowDTO workFlowDTO)
        {
            GestionClaims claim = new GestionClaims(User);
            workFlowDTO.usuarioModifica = $"{claim.Nombres} {claim.Apellidos}";

            (bool, string) resultado = new WorkFlowValidacion().ValidacionWorkFlowActualizarAsync(workFlowDTO);
            return Json(new { ok = resultado.Item1, mensaje = resultado.Item2 });
        }
    }
}
