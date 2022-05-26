using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Models.Aplicacion
{
    public class ResponsableDTO
    {
        public int RESPONSABLE_ID { get; set; }
        public int ACTIVO_ID { get; set; }
        public int IDENTIFICACION { get; set; }
        public DateTime FECHA_ASIGNACION { get; set; }
        public DateTime? FECHA_DESASIGNACION { get; set; }
        public string OBSERVACION { get; set; }
        public string USUARIO_CREACION { get; set; }
        public DateTime FECHA_CREACION { get; set; }
        public string USUARIO_MODIFICA { get; set; }
        public DateTime? FECHA_MODIFICA { get; set; }
    }
}
