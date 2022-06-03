namespace WebApp.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WebApp.Models.Aplicacion;
    using WebApp.Validacion.Aplicacion;
    using WebApp.Validacion.General;

    [Authorize]
    public class EvaluacionController : Controller
    {
        [HttpPost]
        public JsonResult CrearEvaluacion(EvaluacionDTO evaluacionDTO)
        {
            GestionClaims claim = new GestionClaims(User);
            evaluacionDTO.usuarioCreacion = $"{claim.Nombres} {claim.Apellidos}";
            evaluacionDTO.fechaCreacion = System.DateTime.Now;

            (bool, string, EvaluacionDTO) resultado = new EvaluacionValidacion().ValidacionEvaluacionAsync(evaluacionDTO);
            return Json(new { ok = resultado.Item1, mensaje = resultado.Item2, data = resultado.Item3 });
        }

        [HttpPost]
        public JsonResult ConsultarEvaluacionPorId(int _id)
        {
            EvaluacionDTO resultado = new EvaluacionValidacion().ConsultarEvaluacionPorId(_id);
            return Json(resultado);
        }
    }
}
