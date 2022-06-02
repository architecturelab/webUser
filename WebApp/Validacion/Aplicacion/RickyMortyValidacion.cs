using WebApp.Models.Aplicacion;
using WebApp.Servicio;

namespace WebApp.Validacion.Aplicacion
{
    public class RickyMortyValidacion
    {
        public RickMortyDTO Consultar()
        {
            return new ServicioRickMorty().Consultar();
        }
    }
}
