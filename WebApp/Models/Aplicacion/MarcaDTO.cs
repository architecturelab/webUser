using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Models.Aplicacion
{
    public class MarcaDTO
    {
        public int marcaId { get; set; }
        public string vidaUtil { get; set; }
        public string nombre { get; set; }
        public string vigente { get; set; } = "SI";
    }
}
