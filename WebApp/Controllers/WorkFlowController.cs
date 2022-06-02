using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Models.Aplicacion;
using WebApp.Validacion.Aplicacion;
using WebApp.Validacion.General;

namespace WebApp.Controllers
{
    public class WorkFlowController : Controller
    {
        [HttpGet]
        [Authorize(Roles = "Administrador,Almacenista")]
        public async Task<IActionResult> Bandeja()
        {
            return View(await new WorkFlowValidacion().ConsultarWorkFlows());
        }

        [HttpPost]
        public async Task<JsonResult> CrearWorkFlow(WorkFlowDTO workFlowDTO)
        {
            GestionClaims claim = new GestionClaims(User);
            workFlowDTO.usuarioCreacion = $"{claim.Nombres} {claim.Apellidos}";
            workFlowDTO.fechaCreacion = System.DateTime.Now;

            (bool, string) resultado = await new WorkFlowValidacion().ValidacionWorkFlowAsync(workFlowDTO);
            return Json(new { ok = resultado.Item1, mensaje = resultado.Item2 });
        }

        [HttpPost]
        public async Task<JsonResult> ActualizarWorkFlow(WorkFlowDTO workFlowDTO)
        {
            GestionClaims claim = new GestionClaims(User);
            workFlowDTO.usuarioModifica = $"{claim.Nombres} {claim.Apellidos}";

            (bool, string) resultado = await new WorkFlowValidacion().ValidacionWorkFlowActualizarAsync(workFlowDTO);
            return Json(new { ok = resultado.Item1, mensaje = resultado.Item2 });
        }
    }
}
