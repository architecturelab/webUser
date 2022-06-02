using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Models.Aplicacion
{
    public class EmpleadoDTO
    {
        public int EMPLEADO_ID { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDOS { get; set; }
        public int IDENTIFICACION { get; set; }
        public string CORREO { get; set; }
        public string AREA { get; set; }
        public bool VIGENTE { get; set; }
    }
}
