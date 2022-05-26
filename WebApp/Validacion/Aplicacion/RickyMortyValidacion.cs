using Web.Models.Aplicacion;
using Web.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Validacion.Aplicacion
{
    public class RickyMortyValidacion
    {
        public RickMortyDTO Consultar()
        {
            return new ServicioRickMorty().Consultar();
        }
    }
}
