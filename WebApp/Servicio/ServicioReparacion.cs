using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using WebApp.Models.Aplicacion;

namespace WebApp.Servicio
{
    public class ServicioReparacion
    {
        private string urlServicio = Environment.GetEnvironmentVariable("ServicesRepair") != null ? Environment.GetEnvironmentVariable("ServicesRepair") : "http://34.136.161.82/";

        public ReparacionDTO CrearReparacion(ReparacionDTO reparacionDTO)
        {
            try
            {
                var client = new RestClient($"{urlServicio}repair/reparation");
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                var body = JsonConvert.SerializeObject(reparacionDTO);
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                ReparacionDTO resultado = JsonConvert.DeserializeObject<ReparacionDTO>(response.Content);
                return resultado;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ReparacionDTO ActualizarReparacion(ReparacionDTO reparacionDTO)
        {
            try
            {
                var client = new RestClient($"{urlServicio}repair/reparation");
                var request = new RestRequest(Method.PUT);
                request.AddHeader("Content-Type", "application/json");
                var body = JsonConvert.SerializeObject(reparacionDTO);
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                ReparacionDTO resultado = JsonConvert.DeserializeObject<ReparacionDTO>(response.Content);
                return resultado;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<ReparacionDTO> ConsultarReparaciones()
        {
            try
            {
                var client = new RestClient($"{urlServicio}repair/reparations");
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                return JsonConvert.DeserializeObject<List<ReparacionDTO>>(response.Content);
            }
            catch (Exception ex)
            {
                return new List<ReparacionDTO>();
            }
        }

        public ReparacionDTO ConsultarReparacion(int _id)
        {
            try
            {
                var client = new RestClient($"{urlServicio}repair/reparation/{_id}");
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                return JsonConvert.DeserializeObject<ReparacionDTO>(response.Content);
            }
            catch (Exception ex)
            {
                return new ReparacionDTO();
            }
        }

    }
}
