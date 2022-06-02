using System;
using System.Collections.Generic;

namespace WebApp.Models.Aplicacion
{
    public class WorkFlowDTO
    {
        public int ticketId { get; set; }
        public int activoId { get; set; }
        public string estado { get; set; }
        public int? diagnosticoId { get; set; }
        public int? evaluacionId { get; set; }
        public int? reparacionId { get; set; }
        public DateTime? fechaDiagnostico { get; set; }
        public DateTime? fechaEvaluacion { get; set; }
        public DateTime? fechaReparacion { get; set; }
        public DateTime? fechaCierre { get; set; }
        public string usuarioCreacion { get; set; }
        public DateTime fechaCreacion { get; set; }
        public string usuarioModifica { get; set; }

        public List<DiagnosticoDTO> Diagnosticos { get; set; }
        public List<EvaluacionDTO> Evaluaciones { get; set; }
        public List<ReparacionDTO> Reparaciones { get; set; }

    }
}
