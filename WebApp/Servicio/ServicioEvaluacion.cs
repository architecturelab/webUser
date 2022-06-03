using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using WebApp.Models.Aplicacion;

namespace WebApp.Servicio
{
    public class ServicioEvaluacion
    {
        private string urlServicio = Environment.GetEnvironmentVariable("ServicesEvaluation") != null ? Environment.GetEnvironmentVariable("ServicesEvaluation") : "http://34.72.46.9/";

        public EvaluacionDTO CrearEvaluacion(EvaluacionDTO evaluacionDTO)
        {
            try
            {
                var client = new RestClient($"{urlServicio}evaluations/evaluation");
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                var body = JsonConvert.SerializeObject(evaluacionDTO);
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                EvaluacionDTO resultado = JsonConvert.DeserializeObject<EvaluacionDTO>(response.Content);
                return resultado;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public EvaluacionDTO ActualizarEvaluacion(EvaluacionDTO evaluacionDTO)
        {
            try
            {
                var client = new RestClient($"{urlServicio}evaluations/evaluation");
                var request = new RestRequest(Method.PUT);
                request.AddHeader("Content-Type", "application/json");
                var body = JsonConvert.SerializeObject(evaluacionDTO);
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                EvaluacionDTO resultado = JsonConvert.DeserializeObject<EvaluacionDTO>(response.Content);
                return resultado;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<EvaluacionDTO> ConsultarEvaluaciones()
        {
            try
            {
                var client = new RestClient($"{urlServicio}evaluations/evaluations");
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                return JsonConvert.DeserializeObject<List<EvaluacionDTO>>(response.Content);
            }
            catch (Exception ex)
            {
                return new List<EvaluacionDTO>();
            }
        }

        public EvaluacionDTO ConsultarEvaluacion(int _id)
        {
            try
            {
                var client = new RestClient($"{urlServicio}evaluations/evaluation/{_id}");
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                return JsonConvert.DeserializeObject<EvaluacionDTO>(response.Content);
            }
            catch (Exception ex)
            {
                return new EvaluacionDTO();
            }
        }

    }
}
