using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Models.Aplicacion
{
    public class EvaluacionDTO
    {
        public int evaluationId { get; set; }
        public int activoId { get; set; }
        public string descripcion { get; set; }
        public bool? decision { get; set; }
        public string usuarioCreacion { get; set; }
        public DateTime fechaCreacion { get; set; }
        public string usuarioModifica { get; set; }
        public DateTime? fechaModifica { get; set; }

        #region Transformaciones

        public string fechaCreacionStr { get => this.fechaCreacion.ToShortDateString(); }

        #endregion
    }
}
