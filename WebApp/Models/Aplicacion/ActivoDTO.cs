using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Models.Aplicacion
{
    public class ActivoDTO
    {
        public int itemId { get; set; }
        public int claseId { get; set; }
        public int marcaId { get; set; }
        public int modeloId { get; set; }
        public string serial { get; set; }
        public DateTime? fechaIngreso { get; set; }
        public DateTime? fechaFinalGarantia { get; set; }
        public double valor { get; set; }
        public DateTime? fechaBaja { get; set; }
        public string estado { get; set; }
        public string observacion { get; set; }
        public int dependenciaId { get; set; }
        public string usuarioCreacion { get; set; }
        public DateTime? fechaCreacion { get; set; }
        public string usuarioModifica { get; set; }

        #region Transformaciones

        public string fechaIngresoStr { get => this.fechaIngreso != null ? this.fechaIngreso.Value.ToShortDateString() : ""; }
        public string fechaFinalGarantiaStr { get => this.fechaFinalGarantia != null ? this.fechaFinalGarantia.Value.ToShortDateString() : ""; }
        public string clase { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public string dependencia { get; set; }

        #endregion

        public List<WorkFlowDTO> WorkFlows { get; set; }

    }
}
