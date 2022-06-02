using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Models.Aplicacion;

namespace WebApp.Servicio
{
    public class ServicioWorkFlow
    {
        public async Task<bool> CrearWorkFlow(WorkFlowDTO workFlowDTO)
        {
            try
            {
                var client = new RestClient($"{Environment.GetEnvironmentVariable("ServicesWorkFlow")}workflow/ticket");
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                var body = JsonConvert.SerializeObject(workFlowDTO);
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                WorkFlowDTO resultado = JsonConvert.DeserializeObject<WorkFlowDTO>(response.Content);

                if (resultado.ticketId != 0)
                    return true;
                else return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> ActualizarWorkFlow(WorkFlowDTO workFlowDTO)
        {
            try
            {
                var client = new RestClient($"{Environment.GetEnvironmentVariable("ServicesWorkFlow")}workflow/ticket");
                var request = new RestRequest(Method.PUT);
                request.AddHeader("Content-Type", "application/json");
                var body = JsonConvert.SerializeObject(workFlowDTO);
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                WorkFlowDTO resultado = JsonConvert.DeserializeObject<WorkFlowDTO>(response.Content);

                if (resultado.ticketId != 0)
                    return true;
                else return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<WorkFlowDTO>> ConsultarWorkFlows()
        {
            try
            {
                var client = new RestClient($"{Environment.GetEnvironmentVariable("ServicesWorkFlow")}workflow/tickets");
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                return JsonConvert.DeserializeObject<List<WorkFlowDTO>>(response.Content);
            }
            catch (Exception ex)
            {
                return new List<WorkFlowDTO>();
            }
        }

        public async Task<WorkFlowDTO> ConsultarWorkFlow(int _id)
        {
            try
            {
                var client = new RestClient($"{Environment.GetEnvironmentVariable("ServicesWorkFlow")}workflow/ticket/{_id}");
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                return JsonConvert.DeserializeObject<WorkFlowDTO>(response.Content);
            }
            catch (Exception ex)
            {
                return new WorkFlowDTO();
            }
        }

    }
}
