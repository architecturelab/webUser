namespace WebApp.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WebApp.Models.Aplicacion;
    using WebApp.Validacion.Aplicacion;
    using WebApp.Validacion.General;

    [Authorize]
    public class ReparacionController : Controller
    {
        [HttpPost]
        public JsonResult CrearReparacion(ReparacionDTO reparacionDTO)
        {
            GestionClaims claim = new GestionClaims(User);
            reparacionDTO.usuarioCreacion = $"{claim.Nombres} {claim.Apellidos}";
            reparacionDTO.fechaCreacion = System.DateTime.Now;

            (bool, string, ReparacionDTO) resultado = new ReparacionValidacion().ValidacionReparacionAsync(reparacionDTO);
            return Json(new { ok = resultado.Item1, mensaje = resultado.Item2, data = resultado.Item3 });
        }

        [HttpPost]
        public JsonResult ConsultarReparacionPorId(int _id)
        {
            ReparacionDTO resultado = new ReparacionValidacion().ConsultarReparacionPorId(_id);
            return Json(resultado);
        }
    }
}
