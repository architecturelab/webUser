﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Models.Aplicacion
{
    public class DependenciaDTO
    {
        public int dependenciaId { get; set; }
        public string nombre { get; set; }
        public string vigente { get; set; } = "SI";
    }
}
