using Newtonsoft.Json;
using RestSharp;
using System;
using WebApp.Models.Aplicacion;

namespace WebApp.Servicio
{
    public class ServicioRickMorty
    {
        public RickMortyDTO Consultar()
        {
            try
            {
                var client = new RestClient("https://rickandmortyapi.com/api/character");
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                return JsonConvert.DeserializeObject<RickMortyDTO>(response.Content);
            }
            catch (Exception)
            {
                return new RickMortyDTO();
            }
        }
    }
}
