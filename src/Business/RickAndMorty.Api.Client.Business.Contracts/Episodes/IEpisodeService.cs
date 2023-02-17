using RickAndMorty.Api.Client.DataAccess.Contracts.CrossCutting;
using RickAndMorty.Api.Client.DataAccess.Contracts.Episodes;
using RickAndMorty.Api.Client.DataAccess.Contracts.Exceptions;
using RickAndMorty.Api.Client.Domain.Entities.Episodes;

namespace RickAndMorty.Api.Client.Business.Contracts.Episodes
{
    public interface IEpisodeService
    {
        /// <summary>
        /// Returns an episode, based on the given filter
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></excep
        Task<Episode?> GetAsync(int id);

        /// <summary>
        /// Returns a list of episodes, based on the given filter
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="DataAccessException"></exception>
        Task<IEnumerable<Episode>?> GetSeveralAsync(params int[] ids);

        /// <summary>
        /// Returns a list of paginated episodes, based on the given filter
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="DataAccessException"></exception>
        Task<Paginated<Episode>?> GetAllAsync(int page = 1);

        /// <summary>
        /// Returns a list of paginated episodes, based on the given filter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="DataAccessException"></exception>
        Task<Paginated<Episode>?> GetByFilterAsync(EpisodeFilter filter);
    }
}
