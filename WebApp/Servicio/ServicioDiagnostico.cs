using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using WebApp.Models.Aplicacion;

namespace WebApp.Servicio
{
    public class ServicioDiagnostico
    {
        private string urlServicio = Environment.GetEnvironmentVariable("ServicesDiagnostic") != null ? Environment.GetEnvironmentVariable("ServicesDiagnostic") : "http://34.69.117.231/";

        public DiagnosticoDTO CrearDiagnostico(DiagnosticoDTO diagnosticoDTO)
        {
            try
            {
                var client = new RestClient($"{urlServicio}diagnostics/diagnostic");
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                var body = JsonConvert.SerializeObject(diagnosticoDTO);
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                DiagnosticoDTO resultado = JsonConvert.DeserializeObject<DiagnosticoDTO>(response.Content);
                return resultado;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DiagnosticoDTO ActualizarDiagnostico(DiagnosticoDTO diagnosticoDTO)
        {
            try
            {
                var client = new RestClient($"{urlServicio}diagnostics/diagnostic");
                var request = new RestRequest(Method.PUT);
                request.AddHeader("Content-Type", "application/json");
                var body = JsonConvert.SerializeObject(diagnosticoDTO);
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                DiagnosticoDTO resultado = JsonConvert.DeserializeObject<DiagnosticoDTO>(response.Content);
                return resultado;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<DiagnosticoDTO> ConsultarDiagnosticos()
        {
            try
            {
                var client = new RestClient($"{urlServicio}diagnostics/diagnostics");
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                return JsonConvert.DeserializeObject<List<DiagnosticoDTO>>(response.Content);
            }
            catch (Exception ex)
            {
                return new List<DiagnosticoDTO>();
            }
        }

        public DiagnosticoDTO ConsultarDiagnostico(int _id)
        {
            try
            {
                var client = new RestClient($"{urlServicio}diagnostics/diagnostic/{_id}");
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                return JsonConvert.DeserializeObject<DiagnosticoDTO>(response.Content);
            }
            catch (Exception ex)
            {
                return new DiagnosticoDTO();
            }
        }

    }
}
