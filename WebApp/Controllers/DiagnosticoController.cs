namespace WebApp.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WebApp.Models.Aplicacion;
    using WebApp.Validacion.Aplicacion;
    using WebApp.Validacion.General;

    [Authorize]
    public class DiagnosticoController : Controller
    {
        [HttpPost]
        public JsonResult CrearDiagnostico(DiagnosticoDTO diagnosticoDTO)
        {
            GestionClaims claim = new GestionClaims(User);
            diagnosticoDTO.usuarioCreacion = $"{claim.Nombres} {claim.Apellidos}";
            diagnosticoDTO.fechaCreacion = System.DateTime.Now;

            (bool, string, DiagnosticoDTO) resultado = new DiagnosticoValidacion().ValidacionDiagnosticoAsync(diagnosticoDTO);
            return Json(new { ok = resultado.Item1, mensaje = resultado.Item2, data = resultado.Item3 });
        }

        [HttpPost]
        public JsonResult ConsultarDiagnosticoPorId(int _id)
        {
            DiagnosticoDTO resultado = new DiagnosticoValidacion().ConsultarDiagnosticoPorId(_id);
            return Json(resultado);
        }
    }
}
