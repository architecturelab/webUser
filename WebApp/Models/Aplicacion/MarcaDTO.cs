﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Models.Aplicacion
{
    public class MarcaDTO
    {
        public int MARCA_ID { get; set; }
        public int CLASE_ID { get; set; }
        public string NOMBRE { get; set; }
        public bool VIGENTE { get; set; }
    }
}
