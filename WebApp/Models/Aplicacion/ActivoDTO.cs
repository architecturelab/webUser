using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Models.Aplicacion
{
    public class ActivoDTO
    {
        public int ACTIVO_ID { get; set; }
        public int CLASE_ID { get; set; }
        public int MARCA_ID { get; set; }
        public int MODELO_ID { get; set; }
        public string SERIAL { get; set; }
        public DateTime FECHA_INGRESO { get; set; }
        public DateTime FECHA_FINAL_GARANTIA { get; set; }
        public double VALOR { get; set; }
        public DateTime FECHA_BAJA { get; set; }
        public string ESTADO { get; set; }
        public string OBSERVACION { get; set; }
        public int DEPENDENCIA_ID { get; set; }
        public string USUARIO_CREACION { get; set; }
        public DateTime FECHA_CREACION { get; set; }
        public string USUARIO_MODIFICA { get; set; }
        public DateTime? FECHA_MODIFICA { get; set; }

        public List<WorkFlowDTO> TICKETS { get; set; }
        public List<DiagnosticoDTO> DIAGNOSTICOS { get; set; }
        public List<ReparacionDTO> REPARACIONES { get; set; }
        public List<EvaluacionDTO> EVALUACIONES { get; set; }
    }
}
