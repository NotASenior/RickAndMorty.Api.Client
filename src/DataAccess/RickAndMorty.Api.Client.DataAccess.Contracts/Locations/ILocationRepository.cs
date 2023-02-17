using RickAndMorty.Api.Client.DataAccess.Contracts.CrossCutting;
using RickAndMorty.Api.Client.DataAccess.Contracts.Exceptions;

namespace RickAndMorty.Api.Client.DataAccess.Contracts.Locations
{
    public interface ILocationRepository
    {
        /// <summary>
        /// Returns a location, based on the given filter
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="DataAccessException"></exception>
        Task<LocationDto?> GetAsync(int id);

        /// <summary>
        /// Returns a list of locations, based on the given filter
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="DataAccessException"></exception>
        Task<IEnumerable<LocationDto>?> GetSeveralAsync(params int[] ids);

        /// <summary>
        /// Returns a paginated list of locations, based on the given filter
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="DataAccessException"></exception>
        Task<Paginated<LocationDto>?> GetAllAsync(int page = 1);

        /// <summary>
        /// Returns a paginated list of locations, based on the given filter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="DataAccessException"></exception>
        Task<Paginated<LocationDto>?> GetByFilterAsync(LocationFilter filter);
    }
}
