using Web.Models.Aplicacion;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using WebApp.Models.General;

namespace Web.Servicio
{
    public class ServicioActivo
    {
        public async Task<bool> CrearActivo(ActivoDTO activoDTO)
        {
            try
            {
                var client = new RestClient($"{Environment.GetEnvironmentVariable("ServicesInventory")}inventory/item");
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                var body = JsonConvert.SerializeObject(activoDTO);
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                ActivoDTO resultado = JsonConvert.DeserializeObject<ActivoDTO>(response.Content);

                if (resultado.itemId != 0)
                    return true;
                else return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> ActualizarActivo(ActivoDTO activoDTO)
        {
            try
            {
                var client = new RestClient($"{Environment.GetEnvironmentVariable("ServicesInventory")}inventory/item");
                var request = new RestRequest(Method.PUT);
                request.AddHeader("Content-Type", "application/json");
                var body = JsonConvert.SerializeObject(activoDTO);
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                ActivoDTO resultado = JsonConvert.DeserializeObject<ActivoDTO>(response.Content);

                if (resultado.itemId != 0)
                    return true;
                else return false;
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
                var client = new RestClient($"{Environment.GetEnvironmentVariable("ServicesInventory")}inventory/items-plain");
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                return JsonConvert.DeserializeObject<List<ActivoDTO>>(response.Content);
            }
            catch (Exception ex)
            {
                return new List<ActivoDTO>();
            }
        }


        public async Task<ActivoDTO> ConsultarActivo(int _id)
        {
            try
            {
                var client = new RestClient($"{Environment.GetEnvironmentVariable("ServicesInventory")}inventory/item/{_id}");
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                return JsonConvert.DeserializeObject<ActivoDTO>(response.Content);
            }
            catch (Exception ex)
            {
                return new ActivoDTO();
            }
        }

    }
}
