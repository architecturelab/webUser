using Newtonsoft.Json;
using RestSharp;
using System;
using Web.Models.Aplicacion;

namespace Web.Servicio
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
