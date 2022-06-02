using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Models.Aplicacion
{
    public class DiagnosticoDTO
    {
        public int diagnosticId { get; set; } 
        public int activoId { get; set; } 
        public string descripcion { get; set; } 
        public bool? apto { get; set; } 
        public bool? reparacion { get; set; } 
        public string usuarioCreacion { get; set; } 
        public DateTime fechaCreacion { get; set; } 
        public string usuarioModifica { get; set; } 
        public DateTime? fechaModifica { get; set; }

        #region Transformaciones

        public string fechaCreacionStr { get => this.fechaCreacion.ToShortDateString(); }

        #endregion
    }
}
