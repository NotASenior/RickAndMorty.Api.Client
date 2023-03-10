using RickAndMorty.Api.Client.DataAccess.Contracts.Episodes;
using RickAndMorty.Api.Client.DataAccess.Contracts.CrossCutting;
using RickAndMorty.Api.Client.DataAccess.Contracts.Static;
using RickAndMorty.Api.Client.DataAccess.Contracts.Exceptions;

namespace RickAndMorty.Api.Client.DataAccess.Episodes
{
    public class EpisodeRepository : IEpisodeRepository
    {
        private readonly IRestClientWrapper _restClient;

        public EpisodeRepository(IRestClientWrapper restClient)
        {
            _restClient = restClient;
        }

        /// <summary>
        /// Returns a list of paginated episodes, based on the given filter
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="DataAccessException"></exception>
        public Task<Paginated<EpisodeDto>?> GetAllAsync(int page = 1)
        {
            if (page <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(page));
            }

            string url = $"{Constants.Endpoints.Episode}{Constants.Endpoints.Page}{page}";

            return _restClient.GetAsync<Paginated<EpisodeDto>>(url);
        }

        /// <summary>
        /// Returns an episode, based on the given filter
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="DataAccessException"></exception>
        public Task<EpisodeDto?> GetAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            string url = $"{Constants.Endpoints.Episode}{id}";

            return _restClient.GetAsync<EpisodeDto>(url);
        }

        /// <summary>
        /// Returns a list of paginated episodes, based on the given filter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="DataAccessException"></exception>
        public Task<Paginated<EpisodeDto>?> GetByFilterAsync(EpisodeFilter filter)
        {
            if (filter is null)
            {
                throw new ArgumentNullException(nameof(filter));
            }

            string filterUrl = GetFilterUrl(filter);

            string url = $"{Constants.Endpoints.Episode}?{filterUrl}";

            return _restClient.GetAsync<Paginated<EpisodeDto>>(url);
        }

        private static string GetFilterUrl(EpisodeFilter filter)
        {
            string filterUrl = string.Empty;
            if (!string.IsNullOrEmpty(filter.Code))
            {
                filterUrl = AddConcatIfNotEmpty(filterUrl);
                filterUrl = $"{filterUrl}code={filter.Code}";
            }
            if (!string.IsNullOrEmpty(filter.Name))
            {
                filterUrl = AddConcatIfNotEmpty(filterUrl);
                filterUrl = $"{filterUrl}name={filter.Name}";
            }

            return filterUrl;
        }

        private static string AddConcatIfNotEmpty(string filterUrl)
        {
            filterUrl = string.IsNullOrEmpty(filterUrl) ? filterUrl : $"{filterUrl}&";
            return filterUrl;
        }

        /// <summary>
        /// Returns a list of episodes, based on the given filter
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="DataAccessException"></exception>
        public Task<IEnumerable<EpisodeDto>?> GetSeveralAsync(params int[] ids)
        {
            if (ids is null)
            {
                throw new ArgumentNullException(nameof(ids));
            }

            bool hasZero = ids.Any(x => x == 0);
            if (hasZero)
            {
                throw new ArgumentOutOfRangeException(nameof(ids));
            }

            string idsAsString = string.Join(',', ids);

            string url = $"{Constants.Endpoints.Episode}{idsAsString}";

            return _restClient.GetAsync<IEnumerable<EpisodeDto>>(url);
        }
    }
}
