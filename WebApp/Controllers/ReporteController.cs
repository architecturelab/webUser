using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApp.Models.Aplicacion;
using WebApp.Servicio;

namespace WebApp.Controllers
{
    [Authorize]
    public class ReporteController : Controller
    {
        public IActionResult Index()
        {
            List<ActivoDTO> listaActivos = new ServicioActivo().ConsultarActivos();
            List<WorkFlowDTO> listaTickets = new ServicioWorkFlow().ConsultarWorkFlows();

            #region Stock Disponible OK

            float totalElementosDisponibles = listaActivos.Count(x => x.estado == "Disponible" || x.estado == null);
            float totalElementos = listaActivos.Count;
            float total1 = (totalElementosDisponibles / totalElementos) * 100;

            ViewBag.TotalElementosDisponibles = totalElementosDisponibles;
            ViewBag.TotalElementos = totalElementos;
            ViewBag.Resultado1 = total1;

            #endregion

            #region Stock Descartados OK

            float totalDescartados = listaActivos.Count(x => x.estado == "Descartado");
            float totalElementosConTicket = listaTickets.GroupBy(x => x.activoId).Count();
            float total2 = (totalDescartados / totalElementosConTicket) * 100;

            ViewBag.TotalDescartados = totalDescartados;
            ViewBag.TotalElementosConTicket = totalElementosConTicket;
            ViewBag.Resultado2 = total2;

            #endregion

            #region Oportunidad en Tiempo de Ejecución OK

            float NumerodeViabilidadesenmenosde7dias = listaTickets.Where(x => x.fechaReparacion >= DateTime.Now.AddDays(-7) && (x.estado == "Disponible" || x.estado == "Descartado")).Count();
            float NumerodeTickets = listaTickets.Count(x => x.fechaReparacion >= DateTime.Now.AddDays(-7));
            float total3 = (NumerodeViabilidadesenmenosde7dias / NumerodeTickets) * 100;

            ViewBag.NumerodeViabilidadesenmenosde7dias = NumerodeViabilidadesenmenosde7dias;
            ViewBag.NumerodeTickets = NumerodeTickets;
            ViewBag.Resultado3 = total3;

            #endregion

            #region Nivel de Obsolescencia Tecnológica OK

            float totalElementosCon20VidaUtiloMenos = listaActivos.Where(x => x.fechaFinalGarantia <= DateTime.Now.AddDays(-30)).Count();
            float total4 = (totalElementosCon20VidaUtiloMenos / totalElementosDisponibles) * 100;

            ViewBag.TotalElementosCon20VidaUtiloMenos = totalElementosCon20VidaUtiloMenos;
            ViewBag.Resultado4 = total4;

            #endregion

            #region Tasa de retorno de equipos reparados​ OK

            float NumerodeElementosDescartados = listaTickets.Count(x => x.estado == "Descartado");
            float NumerodeElementosReparados = listaTickets.Count(x => x.estado == "Disponible");
            float total5 = (NumerodeElementosDescartados / NumerodeElementosReparados) * 100;

            ViewBag.NumerodeElementosDescartados = NumerodeElementosDescartados;
            ViewBag.NumerodeElementosReparados = NumerodeElementosReparados;
            ViewBag.Resultado5 = total5;

            #endregion

            #region Costo de reposiciones por obsolescencia OK

            float totalElementosBienesObsoletos = listaActivos.Where(x => x.fechaFinalGarantia <= DateTime.Now).Count();
            float total6 = (totalElementosBienesObsoletos / totalElementosDisponibles) * 100;

            ViewBag.totalElementosBienesObsoletos = totalElementosBienesObsoletos;
            ViewBag.Resultado6 = total6;

            #endregion

            return View();
        }
    }
}
