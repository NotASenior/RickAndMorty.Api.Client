using RestSharp;
using RickAndMorty.Api.Client.DataAccess.Contracts.CrossCutting;
using RickAndMorty.Api.Client.DataAccess.Contracts.Exceptions;

namespace RickAndMorty.Api.Client.DataAccess.CrossCutting
{
    public class RestClientWrapper : IRestClientWrapper
    {
        /// <summary>
        /// Makes a GET request to a given URL
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        /// <exception cref="DataAccessException"></exception>
        public Task<T?> GetAsync<T>(string url)
        {
            var service = new RestClient(url);

            try
            {
                return service.GetAsync<T>(new RestRequest());
            }
            catch (Exception ex)
            {
                // TODO log
                throw new DataAccessException(url, ex);
            }
        }
    }
}
