namespace WebApp.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.Extensions.Configuration;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using WebApp.Models.Aplicacion;
    using WebApp.Validacion.Aplicacion;
    using WebApp.Validacion.General;

    [Authorize]
    public class ActivoController : Controller
    {
        private readonly IConfiguration _configuration;

        public ActivoController(IConfiguration configuration)
        {
           _configuration = configuration;  
        }

        [HttpGet]
        [Authorize(Roles = "Administrador,Almacenista")]
        public async Task<IActionResult> BandejaActivos()
        {
            ViewBag.VALOR1 = _configuration.GetValue<string>("ServicesInventory");
            ViewBag.VALOR2 = _configuration.GetValue<string>("User");
            ViewBag.VALOR3 = _configuration.GetValue<string>("ASPNETCORE_ENVIRONMENT");
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
            items.Add(new SelectListItem { Text = "Descartado", Value = "Descartado" });
            items.Add(new SelectListItem { Text = "Diagnostico", Value = "Diagnostico" });
            items.Add(new SelectListItem { Text = "Reparación", Value = "Reparación" });
            items.Add(new SelectListItem { Text = "Evaluación", Value = "Evaluación" });

            ViewBag.ESTADO = new SelectList(items, "Text", "Value");

            return View();
        }

        [HttpPost]
        public async Task<JsonResult> CrearActivo(ActivoDTO activoDTO)
        {
            GestionClaims claim = new GestionClaims(User);
            activoDTO.usuarioCreacion = $"{claim.Nombres} {claim.Apellidos}";
            activoDTO.fechaCreacion = System.DateTime.Now;

            (bool, string) resultado = await new ActivoValidacion().ValidacionActivoAsync(activoDTO);
            return Json(new { ok = resultado.Item1, mensaje = resultado.Item2 });
        }

        [HttpPost]
        public async Task<JsonResult> ActualizarActivo(ActivoDTO activoDTO)
        {
            GestionClaims claim = new GestionClaims(User);
            activoDTO.usuarioModifica = $"{claim.Nombres} {claim.Apellidos}";

            (bool, string) resultado = await new ActivoValidacion().ValidacionActivoActualizarAsync(activoDTO);
            return Json(new { ok = resultado.Item1, mensaje = resultado.Item2 });
        }

        [HttpGet]
        [Authorize(Roles = "Administrador,Diagnosticador,Evaluaciones,Reparaciones")]
        public async Task<IActionResult> DetalleGestionActivo(int _id)
        {

            var resultado = await new ActivoValidacion().ConsultarActivoPorId(_id);
            resultado.WorkFlows = (await new WorkFlowValidacion().ConsultarWorkFlows()).Where(x => x.activoId == _id).ToList(); 

            ViewBag.CLASE = new SelectList(await new DominioValidacion().ConsultarClases(), "claseId", "nombre", resultado.claseId);
            ViewBag.MARCA = new SelectList(await new DominioValidacion().ConsultarMarcas(), "marcaId", "nombre", resultado.marcaId);
            ViewBag.MODELO = new SelectList(await new DominioValidacion().ConsultarModelos(), "modeloId", "nombre", resultado.modeloId);
            ViewBag.DEPENDENCIA = new SelectList(await new DominioValidacion().ConsultarDependencias(), "dependenciaId", "nombre", resultado.dependenciaId);

            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "Disponible", Value = "Disponible" });
            items.Add(new SelectListItem { Text = "Descartado", Value = "Descartado" });
            items.Add(new SelectListItem { Text = "Diagnostico", Value = "Diagnostico" });
            items.Add(new SelectListItem { Text = "Reparación", Value = "Reparación" });
            items.Add(new SelectListItem { Text = "Evaluación", Value = "Evaluación" });

            ViewBag.ESTADO = new SelectList(items, "Text", "Value", resultado.estado);

            List<SelectListItem> items2 = new List<SelectListItem>();
            items2.Add(new SelectListItem { Text = "SI", Value = "SI" });
            items2.Add(new SelectListItem { Text = "NO", Value = "NO" });
            ViewBag.DESICION = new SelectList(items2, "Text", "Value");

            return View(resultado);
        }
    }
}
