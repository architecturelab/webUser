using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Models.Aplicacion
{
    public class WorkFlowDTO
    {
        public int TICKET_ID { get; set; }
        public int ACTIVO_ID { get; set; }
        public string ESTADO { get; set; }
        public int? DIAGNOSTICO_ID { get; set; }
        public int? EVALUACION_ID { get; set; }
        public int? REPARACION_ID { get; set; }
        public DateTime? FECHA_DIAGNOSTICO { get; set; }
        public DateTime? FECHA_EVALUACION { get; set; }
        public DateTime? FECHA_REPARACION { get; set; }
        public DateTime? FECHA_CIERRE { get; set; }
        public string USUARIO_CREACION { get; set; }
        public DateTime FECHA_CREACION { get; set; }
        public string USUARIO_MODIFICA { get; set; }
        public DateTime? FECHA_MODIFICA { get; set; }
    }
}
