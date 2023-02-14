using RickAndMorty.Api.Client.DataAccess.Contracts.CrossCutting;
using RickAndMorty.Api.Client.DataAccess.Contracts.Locations;
using RickAndMorty.Api.Client.DataAccess.Contracts.Static;

namespace RickAndMorty.Api.Client.DataAccess.Locations
{
    internal class LocationRepository : ILocationRepository
    {
        private readonly IRestClientWrapper _restClient;

        public LocationRepository(IRestClientWrapper restClient)
        {
            _restClient = restClient;
        }

        public Task<Paginated<LocationDto>?> GetAllAsync(int page = 1)
        {
            string url = $"{Constants.Endpoints.Location}{Constants.Endpoints.Page}{page}";

            return _restClient.GetAsync<Paginated<LocationDto>>(url);
        }

        public Task<LocationDto?> GetAsync(int id)
        {
            if (id == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            string url = $"{Constants.Endpoints.Location}{id}";

            return _restClient.GetAsync<LocationDto>(url);
        }

        public Task<Paginated<LocationDto>?> GetByFilterAsync(LocationFilter filter)
        {
            if (filter is null)
            {
                throw new ArgumentNullException(nameof(filter));
            }

            string filterUrl = GetFilterUrl(filter);

            string url = $"{Constants.Endpoints.Location}?{filterUrl}";

            return _restClient.GetAsync<Paginated<LocationDto>>(url);
        }

        private static string GetFilterUrl(LocationFilter filter)
        {
            string filterUrl = string.Empty;
            if (!string.IsNullOrEmpty(filter.Name))
            {
                filterUrl = AddConcatIfNotEmpty(filterUrl);
                filterUrl = $"{filterUrl}name={filter.Name}";
            }
            if (!string.IsNullOrEmpty(filter.Type))
            {
                filterUrl = AddConcatIfNotEmpty(filterUrl);
                filterUrl = $"{filterUrl}type={filter.Type}";
            }
            if (!string.IsNullOrEmpty(filter.Dimension))
            {
                filterUrl = AddConcatIfNotEmpty(filterUrl);
                filterUrl = $"{filterUrl}dimension={filter.Dimension}";
            }

            return filterUrl;
        }

        private static string AddConcatIfNotEmpty(string filterUrl)
        {
            filterUrl = string.IsNullOrEmpty(filterUrl) ? filterUrl : $"{filterUrl}&";
            return filterUrl;
        }

        public Task<IEnumerable<LocationDto>?> GetSeveralAsync(params int[] ids)
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

            string url = $"{Constants.Endpoints.Location}{idsAsString}";

            return _restClient.GetAsync<IEnumerable<LocationDto>>(url);
        }
    }
}
