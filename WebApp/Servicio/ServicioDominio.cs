using Web.Models.Aplicacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using WebApp.Models.General;

namespace Web.Servicio
{
    public class ServicioDominio
    {
        public async Task<bool> CrearEmpleado(EmpleadoDTO empleadoDTO)
        {
            try
            {
                var client = new RestClient($"{Environment.GetEnvironmentVariable("ServicesInventory")}inventory/type");
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                var body = JsonConvert.SerializeObject(empleadoDTO);
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                EmpleadoDTO resultado = JsonConvert.DeserializeObject<EmpleadoDTO>(response.Content);

                if (resultado.EMPLEADO_ID != 0)
                    return true;
                else return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> ActualizarEmpleado(EmpleadoDTO empleadoDTO)
        {
            try
            {
                var client = new RestClient($"{Environment.GetEnvironmentVariable("ServicesInventory")}inventory/type");
                var request = new RestRequest(Method.PUT);
                request.AddHeader("Content-Type", "application/json");
                var body = JsonConvert.SerializeObject(empleadoDTO);
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                EmpleadoDTO resultado = JsonConvert.DeserializeObject<EmpleadoDTO>(response.Content);

                if (resultado.EMPLEADO_ID != 0)
                    return true;
                else return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> CrearDependencia(DependenciaDTO dependenciaDTO)
        {
            try
            {
                var client = new RestClient($"{Environment.GetEnvironmentVariable("ServicesInventory")}inventory/dependency");
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                var body = JsonConvert.SerializeObject(dependenciaDTO);
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                DependenciaDTO resultado = JsonConvert.DeserializeObject<DependenciaDTO>(response.Content);

                if (resultado.dependenciaId != 0)
                    return true;
                else return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> ActualizarDependencia(DependenciaDTO dependenciaDTO)
        {
            try
            {
                var client = new RestClient($"{Environment.GetEnvironmentVariable("ServicesInventory")}inventory/dependency");
                var request = new RestRequest(Method.PUT);
                request.AddHeader("Content-Type", "application/json");
                var body = JsonConvert.SerializeObject(dependenciaDTO);
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                DependenciaDTO resultado = JsonConvert.DeserializeObject<DependenciaDTO>(response.Content);

                if (resultado.dependenciaId != 0)
                    return true;
                else return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> CrearClase(ClaseDTO claseDTO)
        {
            try
            {
                var client = new RestClient($"{Environment.GetEnvironmentVariable("ServicesInventory")}inventory/type");
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                var body = JsonConvert.SerializeObject(claseDTO);
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                ClaseDTO resultado = JsonConvert.DeserializeObject<ClaseDTO>(response.Content);

                if (resultado.claseId != 0)
                    return true;
                else return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> ActualizarClase(ClaseDTO claseDTO)
        {
            try
            {
                var client = new RestClient($"{Environment.GetEnvironmentVariable("ServicesInventory")}inventory/type");
                var request = new RestRequest(Method.PUT);
                request.AddHeader("Content-Type", "application/json");
                var body = JsonConvert.SerializeObject(claseDTO);
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                ClaseDTO resultado = JsonConvert.DeserializeObject<ClaseDTO>(response.Content);

                if (resultado.claseId != 0)
                    return true;
                else return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> CrearMarca(MarcaDTO marcaDTO)
        {
            try
            {
                var client = new RestClient($"{Environment.GetEnvironmentVariable("ServicesInventory")}inventory/brand");
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                var body = JsonConvert.SerializeObject(marcaDTO);
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                MarcaDTO resultado = JsonConvert.DeserializeObject<MarcaDTO>(response.Content);

                if (resultado.marcaId != 0)
                    return true;
                else return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> ActualizarMarca(MarcaDTO marcaDTO)
        {
            try
            {
                var client = new RestClient($"{Environment.GetEnvironmentVariable("ServicesInventory")}inventory/brand");
                var request = new RestRequest(Method.PUT);
                request.AddHeader("Content-Type", "application/json");
                var body = JsonConvert.SerializeObject(marcaDTO);
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                MarcaDTO resultado = JsonConvert.DeserializeObject<MarcaDTO>(response.Content);

                if (resultado.marcaId != 0)
                    return true;
                else return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> CrearModelo(ModeloDTO modeloDTO)
        {
            try
            {
                var client = new RestClient($"{Environment.GetEnvironmentVariable("ServicesInventory")}inventory/model");
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                var body = JsonConvert.SerializeObject(modeloDTO);
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                ModeloDTO resultado = JsonConvert.DeserializeObject<ModeloDTO>(response.Content);

                if (resultado.modeloId != 0)
                    return true;
                else return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> ActualizarModelo(ModeloDTO modeloDTO)
        {
            try
            {
                var client = new RestClient($"{Environment.GetEnvironmentVariable("ServicesInventory")}inventory/model");
                var request = new RestRequest(Method.PUT);
                request.AddHeader("Content-Type", "application/json");
                var body = JsonConvert.SerializeObject(modeloDTO);
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                ModeloDTO resultado = JsonConvert.DeserializeObject<ModeloDTO>(response.Content);

                if (resultado.modeloId != 0)
                    return true;
                else return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<EmpleadoDTO>> ConsultarEmpleados()
        {
            try
            {
                //var client = new RestClient("https://rickandmortyapi.com/api/character");
                //var request = new RestRequest(Method.GET);
                //IRestResponse response = client.Execute(request);
                //return JsonConvert.DeserializeObject<bool>(response.Content);
                return new List<EmpleadoDTO>();
            }
            catch (Exception ex)
            {
                return new List<EmpleadoDTO>();
            }
        }

        public async Task<DependenciaDTO> ConsultarDependencia(int _id)
        {
            try
            {
                var client = new RestClient($"{Environment.GetEnvironmentVariable("ServicesInventory")}inventory/dependency/{_id}");
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                return JsonConvert.DeserializeObject<DependenciaDTO>(response.Content);
            }
            catch (Exception ex)
            {
                return new DependenciaDTO();
            }
        }

        public async Task<List<DependenciaDTO>> ConsultarDependencias()
        {
            try
            {
                var client = new RestClient($"{Environment.GetEnvironmentVariable("ServicesInventory")}inventory/dependencies");
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                return JsonConvert.DeserializeObject<List<DependenciaDTO>>(response.Content);
            }
            catch (Exception ex)
            {
                return new List<DependenciaDTO>();
            }
        }

        public async Task<ClaseDTO> ConsultarClase(int _id)
        {
            try
            {
                var client = new RestClient($"{Environment.GetEnvironmentVariable("ServicesInventory")}inventory/brand/{_id}");
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                return JsonConvert.DeserializeObject<ClaseDTO>(response.Content);
            }
            catch (Exception ex)
            {
                return new ClaseDTO();
            }
        }

        public async Task<List<ClaseDTO>> ConsultarClases()
        {
            try
            {
                var client = new RestClient("http://34.122.37.103/inventory/types");
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                return JsonConvert.DeserializeObject<List<ClaseDTO>>(response.Content);
            }
            catch (Exception ex)
            {
                return new List<ClaseDTO>();
            }
        }

        public async Task<MarcaDTO> ConsultarMarca(int _id)
        {
            try
            {
                var client = new RestClient($"{Environment.GetEnvironmentVariable("ServicesInventory")}inventory/brand/{_id}");
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                return JsonConvert.DeserializeObject<MarcaDTO>(response.Content);
            }
            catch (Exception ex)
            {
                return new MarcaDTO();
            }
        }

        public async Task<List<MarcaDTO>> ConsultarMarcas()
        {
            try
            {
                var client = new RestClient("http://34.122.37.103/inventory/brands");
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                return JsonConvert.DeserializeObject<List<MarcaDTO>>(response.Content);
            }
            catch (Exception ex)
            {
                return new List<MarcaDTO>();
            }
        }

        public async Task<ModeloDTO> ConsultarModelo(int _id)
        {
            try
            {
                var client = new RestClient($"{Environment.GetEnvironmentVariable("ServicesInventory")}inventory/model/{_id}");
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                return JsonConvert.DeserializeObject<ModeloDTO>(response.Content);
            }
            catch (Exception ex)
            {
                return new ModeloDTO();
            }
        }

        public async Task<List<ModeloDTO>> ConsultarModelos()
        {
            try
            {
                var client = new RestClient("http://34.122.37.103/inventory/models");
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                return JsonConvert.DeserializeObject<List<ModeloDTO>>(response.Content);
            }
            catch (Exception ex)
            {
                return new List<ModeloDTO>();
            }
        }

    }
}
