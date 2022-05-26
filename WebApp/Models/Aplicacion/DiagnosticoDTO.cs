﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Models.Aplicacion
{
    public class DiagnosticoDTO
    {
        public int DIAGNOSTICO_ID { get; set; } 
        public int ACTIVO_ID { get; set; } 
        public string DESCRIPCION { get; set; } 
        public bool APTO { get; set; } 
        public bool REPARACION { get; set; } 
        public string USUARIO_CREACION { get; set; } 
        public DateTime FECHA_CREACION { get; set; } 
        public string USUARIO_MODIFICA { get; set; } 
        public DateTime? FECHA_MODIFICA { get; set; } 
    }
}
