using Web.Models.Aplicacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Servicio
{
    public class ServicioDominio
    {
        public async Task<bool> CrearEmpleado(EmpleadoDTO empleadoDTO)
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

        public async Task<bool> CrearDependencia(DependenciaDTO dependenciaDTO)
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

        public async Task<bool> CrearClase(ClaseDTO claseDTO)
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

        public async Task<bool> CrearMarca(MarcaDTO marcaDTO)
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

        public async Task<bool> CrearModelo(ModeloDTO modeloDTO)
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

        public async Task<List<DependenciaDTO>> ConsultarDependencias()
        {
            try
            {
                //var client = new RestClient("https://rickandmortyapi.com/api/character");
                //var request = new RestRequest(Method.GET);
                //IRestResponse response = client.Execute(request);
                //return JsonConvert.DeserializeObject<bool>(response.Content);
                return new List<DependenciaDTO>();
            }
            catch (Exception ex)
            {
                return new List<DependenciaDTO>();
            }
        }

        public async Task<List<ClaseDTO>> ConsultarClases()
        {
            try
            {
                //var client = new RestClient("https://rickandmortyapi.com/api/character");
                //var request = new RestRequest(Method.GET);
                //IRestResponse response = client.Execute(request);
                //return JsonConvert.DeserializeObject<bool>(response.Content);
                return new List<ClaseDTO>();
            }
            catch (Exception ex)
            {
                return new List<ClaseDTO>();
            }
        }

        public async Task<List<MarcaDTO>> ConsultarMarcas()
        {
            try
            {
                //var client = new RestClient("https://rickandmortyapi.com/api/character");
                //var request = new RestRequest(Method.GET);
                //IRestResponse response = client.Execute(request);
                //return JsonConvert.DeserializeObject<bool>(response.Content);
                return new List<MarcaDTO>();
            }
            catch (Exception ex)
            {
                return new List<MarcaDTO>();
            }
        }

        public async Task<List<ModeloDTO>> ConsultarModelos()
        {
            try
            {
                //var client = new RestClient("https://rickandmortyapi.com/api/character");
                //var request = new RestRequest(Method.GET);
                //IRestResponse response = client.Execute(request);
                //return JsonConvert.DeserializeObject<bool>(response.Content);
                return new List<ModeloDTO>();
            }
            catch (Exception ex)
            {
                return new List<ModeloDTO>();
            }
        }

    }
}
