using RickAndMorty.Api.Client.DataAccess.Contracts.Exceptions;

namespace RickAndMorty.Api.Client.DataAccess.Contracts.CrossCutting
{
    public interface IRestClientWrapper
    {
        /// <summary>
        /// Makes a GET request to a given URL
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        /// <exception cref="DataAccessException"></exception>
        Task<T?> GetAsync<T>(string url);
    }
}
