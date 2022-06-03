using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using WebApp.Models.Aplicacion;

namespace WebApp.Servicio
{
    public class ServicioActivo
    {
        private string urlServicio = Environment.GetEnvironmentVariable("ServicesInventory") != null ? Environment.GetEnvironmentVariable("ServicesInventory") : "http://104.197.60.202/";

        public bool CrearActivo(ActivoDTO activoDTO)
        {
            try
            {
                var client = new RestClient($"{urlServicio}inventory/item");
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

        public bool ActualizarActivo(ActivoDTO activoDTO)
        {
            try
            {
                var client = new RestClient($"{urlServicio}inventory/item");
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

        public List<ActivoDTO> ConsultarActivos()
        {
            try
            {
                var client = new RestClient($"{urlServicio}inventory/items-plain");
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                return JsonConvert.DeserializeObject<List<ActivoDTO>>(response.Content);
            }
            catch (Exception ex)
            {
                return new List<ActivoDTO>();
            }
        }

        public ActivoDTO ConsultarActivo(int _id)
        {
            try
            {
                var client = new RestClient($"{urlServicio}inventory/item/{_id}");
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
