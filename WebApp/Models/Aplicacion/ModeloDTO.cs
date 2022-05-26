using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Models.Aplicacion
{
    public class ModeloDTO
    {
        public int MODELO_ID { get; set; }
        public int MARCA_ID { get; set; }
        public string NOMBRE { get; set; }
        public int VIDA_UTIL { get; set; }
        public bool VIGENTE { get; set; }
    }
}
