using RickAndMorty.Api.Client.CrossCutting.Extensions;
using RickAndMorty.Api.Client.DataAccess.Contracts.Episodes;
using RickAndMorty.Api.Client.DataAccess.Contracts.CrossCutting;
using RickAndMorty.Api.Client.DataAccess.Contracts.Static;

namespace RickAndMorty.Api.Client.DataAccess.Episodes
{
    public class EpisodeService : IEpisodeService
    {
        private readonly IRestClientWrapper _restClient;

        public EpisodeService(IRestClientWrapper restClient)
        {
            _restClient = restClient;
        }

        public Task<Paginated<EpisodeDto>?> GetAllAsync(int page = 1)
        {
            string url = $"{Constants.Endpoints.Episode}{Constants.Endpoints.Page}{page}";

            return _restClient.GetAsync<Paginated<EpisodeDto>>(url);
        }

        public Task<EpisodeDto?> GetAsync(int id)
        {
            if (id == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            string url = $"{Constants.Endpoints.Episode}{id}";

            return _restClient.GetAsync<EpisodeDto>(url);
        }

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
