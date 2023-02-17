using RickAndMorty.Api.Client.DataAccess.Contracts.CrossCutting;
using RickAndMorty.Api.Client.DataAccess.Contracts.Locations;
using RickAndMorty.Api.Client.DataAccess.Contracts.Exceptions;
using RickAndMorty.Api.Client.Domain.Entities.Locations;

namespace RickAndMorty.Api.Client.Business.Contracts.Locations
{
    public interface ILocationService
    {
        /// <summary>
        /// Returns a location, based on the given filter
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="DataAccessException"></exception>
        Task<Location?> GetAsync(int id);

        /// <summary>
        /// Returns a list of locations, based on the given filter
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="DataAccessException"></exception>
        Task<IEnumerable<Location>?> GetSeveralAsync(params int[] ids);

        /// <summary>
        /// Returns a paginated list of locations, based on the given filter
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="DataAccessException"></exception>
        Task<Paginated<Location>?> GetAllAsync(int page = 1);

        /// <summary>
        /// Returns a paginated list of locations, based on the given filter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="DataAccessException"></exception>
        Task<Paginated<Location>?> GetByFilterAsync(LocationFilter filter);
    }
}
