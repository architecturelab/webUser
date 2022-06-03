using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using WebApp.Models.Aplicacion;

namespace WebApp.Servicio
{
    public class ServicioDominio
    {
        private string urlServicio = Environment.GetEnvironmentVariable("ServicesInventory") != null ? Environment.GetEnvironmentVariable("ServicesInventory") : "http://104.197.60.202/";

        public bool CrearEmpleado(EmpleadoDTO empleadoDTO)
        {
            try
            {
                var client = new RestClient($"{urlServicio}inventory/type");
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

        public bool ActualizarEmpleado(EmpleadoDTO empleadoDTO)
        {
            try
            {
                var client = new RestClient($"{urlServicio}inventory/type");
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

        public bool CrearDependencia(DependenciaDTO dependenciaDTO)
        {
            try
            {
                var client = new RestClient($"{urlServicio}inventory/dependency");
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

        public bool ActualizarDependencia(DependenciaDTO dependenciaDTO)
        {
            try
            {
                var client = new RestClient($"{urlServicio}inventory/dependency");
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

        public bool CrearClase(ClaseDTO claseDTO)
        {
            try
            {
                var client = new RestClient($"{urlServicio}inventory/type");
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

        public bool ActualizarClase(ClaseDTO claseDTO)
        {
            try
            {
                var client = new RestClient($"{urlServicio}inventory/type");
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

        public bool CrearMarca(MarcaDTO marcaDTO)
        {
            try
            {
                var client = new RestClient($"{urlServicio}inventory/brand");
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

        public bool ActualizarMarca(MarcaDTO marcaDTO)
        {
            try
            {
                var client = new RestClient($"{urlServicio}inventory/brand");
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

        public bool CrearModelo(ModeloDTO modeloDTO)
        {
            try
            {
                var client = new RestClient($"{urlServicio}inventory/model");
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

        public bool ActualizarModelo(ModeloDTO modeloDTO)
        {
            try
            {
                var client = new RestClient($"{urlServicio}inventory/model");
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

        public List<EmpleadoDTO> ConsultarEmpleados()
        {
            try
            {
                //var client = new RestClient("https://rickandmortyapi.com/api/character");
                //var request = new RestRequest(Method.GET);
                //IRestResponse response = client.Execute(request);
                //return JsonConvert.DeserializeObject<bool(response.Content);
                return new List<EmpleadoDTO>();
            }
            catch (Exception ex)
            {
                return new List<EmpleadoDTO>();
            }
        }

        public DependenciaDTO ConsultarDependencia(int _id)
        {
            try
            {
                var client = new RestClient($"{urlServicio}inventory/dependency/{_id}");
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                return JsonConvert.DeserializeObject<DependenciaDTO>(response.Content);
            }
            catch (Exception ex)
            {
                return new DependenciaDTO();
            }
        }

        public List<DependenciaDTO> ConsultarDependencias()
        {
            try
            {
                var client = new RestClient($"{urlServicio}inventory/dependencies");
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                return JsonConvert.DeserializeObject<List<DependenciaDTO>>(response.Content);
            }
            catch (Exception ex)
            {
                return new List<DependenciaDTO>();
            }
        }

        public ClaseDTO ConsultarClase(int _id)
        {
            try
            {
                var client = new RestClient($"{urlServicio}inventory/type/{_id}");
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                return JsonConvert.DeserializeObject<ClaseDTO>(response.Content);

            }
            catch (Exception ex)
            {
                return new ClaseDTO();
            }
        }

        public List<ClaseDTO> ConsultarClases()
        {
            try
            {
                var client = new RestClient($"{urlServicio}inventory/types");
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                return JsonConvert.DeserializeObject<List<ClaseDTO>>(response.Content);
            }
            catch (Exception ex)
            {
                return new List<ClaseDTO>();
            }
        }

        public MarcaDTO ConsultarMarca(int _id)
        {
            try
            {
                var client = new RestClient($"{urlServicio}inventory/brand/{_id}");
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                return JsonConvert.DeserializeObject<MarcaDTO>(response.Content);
            }
            catch (Exception ex)
            {
                return new MarcaDTO();
            }
        }

        public List<MarcaDTO> ConsultarMarcas()
        {
            try
            {
                var client = new RestClient($"{urlServicio}inventory/brands");
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                return JsonConvert.DeserializeObject<List<MarcaDTO>>(response.Content);
            }
            catch (Exception ex)
            {
                return new List<MarcaDTO>();
            }
        }

        public ModeloDTO ConsultarModelo(int _id)
        {
            try
            {
                var client = new RestClient($"{urlServicio}inventory/model/{_id}");
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                return JsonConvert.DeserializeObject<ModeloDTO>(response.Content);
            }
            catch (Exception ex)
            {
                return new ModeloDTO();
            }
        }

        public List<ModeloDTO> ConsultarModelos()
        {
            try
            {
                var client = new RestClient($"{urlServicio}inventory/models");
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
