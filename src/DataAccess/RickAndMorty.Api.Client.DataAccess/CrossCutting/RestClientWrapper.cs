using RestSharp;
using RickAndMorty.Api.Client.DataAccess.Contracts.CrossCutting;

namespace RickAndMorty.Api.Client.DataAccess.CrossCutting
{
    public class RestClientWrapper : IRestClientWrapper
    {
        public Task<T?> GetAsync<T>(string url)
        {
            var service = new RestClient(url);
            
            return service.GetAsync<T>(new RestRequest());
        }
    }
}
