using Web.Models.Aplicacion;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Servicio
{
    public class ServicioActivo
    {
        public async Task<bool> CrearActivo(ActivoDTO activoDTO)
        {
            try
            {
                //var client = new RestClient("https://rickandmortyapi.com/api/character");
                //var request = new RestRequest(Method.GET);
                //IRestResponse response = client.Execute(request);
                //return JsonConvert.DeserializeObject<bool>(response.Content);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<ActivoDTO>> ConsultarActivos()
        {
            try
            {
                //var client = new RestClient("https://rickandmortyapi.com/api/character");
                //var request = new RestRequest(Method.GET);
                //IRestResponse response = client.Execute(request);
                //return JsonConvert.DeserializeObject<bool>(response.Content);
                return new List<ActivoDTO>();
            }
            catch (Exception ex)
            {
                return new List<ActivoDTO>();
            }
        }


        public async Task<ActivoDTO> ConsultarActivoPorId(int _id)
        {
            try
            {
                //var client = new RestClient("https://rickandmortyapi.com/api/character");
                //var request = new RestRequest(Method.GET);
                //IRestResponse response = client.Execute(request);
                //return JsonConvert.DeserializeObject<bool>(response.Content);
                return new ActivoDTO();
            }
            catch (Exception ex)
            {
                return new ActivoDTO();
            }
        }

    }
}
