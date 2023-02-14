using RickAndMorty.Api.Client.DataAccess.Contracts.Exceptions;
using RickAndMorty.Api.Client.DataAccess.Contracts.CrossCutting;

namespace RickAndMorty.Api.Client.DataAccess.Contracts.Episodes
{
    public interface IEpisodeRepository
    {
        /// <summary>
        /// Returns an episode, based on the given filter
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></excep
        Task<EpisodeDto?> GetAsync(int id);

        /// <summary>
        /// Returns a list of episodes, based on the given filter
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="DataAccessException"></exception>
        Task<IEnumerable<EpisodeDto>?> GetSeveralAsync(params int[] ids);

        /// <summary>
        /// Returns a list of paginated episodes, based on the given filter
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="DataAccessException"></exception>
        Task<Paginated<EpisodeDto>?> GetAllAsync(int page = 1);

        /// <summary>
        /// Returns a list of paginated episodes, based on the given filter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="DataAccessException"></exception>
        Task<Paginated<EpisodeDto>?> GetByFilterAsync(EpisodeFilter filter);
    }
}
