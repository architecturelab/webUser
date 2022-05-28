using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Models.Aplicacion
{
    public class ActivoDTO
    {
        public int itemId { get; set; }
        public int claseId { get; set; }
        public int marcaId { get; set; }
        public int modeloId { get; set; }
        public string serial { get; set; }
        public string fechaIngreso { get; set; }
        public string fechaFinalGarantia { get; set; }
        public double valor { get; set; }
        public string fechaBaja { get; set; }
        //public string estado { get; set; }
        //public string observacion { get; set; }
        public int dependenciaId { get; set; }

        public List<WorkFlowDTO> TICKETS { get; set; }
        public List<DiagnosticoDTO> DIAGNOSTICOS { get; set; }
        public List<ReparacionDTO> REPARACIONES { get; set; }
        public List<EvaluacionDTO> EVALUACIONES { get; set; }
    }
}
