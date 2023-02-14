using RickAndMorty.Api.Client.CrossCutting.Extensions;
using RickAndMorty.Api.Client.DataAccess.Contracts.Characters;
using RickAndMorty.Api.Client.DataAccess.Contracts.CrossCutting;
using RickAndMorty.Api.Client.DataAccess.Contracts.Static;

namespace RickAndMorty.Api.Client.DataAccess.Characters
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly IRestClientWrapper _restClient;

        public CharacterRepository(IRestClientWrapper restClient)
        {
            _restClient = restClient;
        }

        public Task<Paginated<CharacterDto>?> GetAllAsync(int page = 1)
        {
            string url = $"{Constants.Endpoints.Character}{Constants.Endpoints.Page}{page}";

            return _restClient.GetAsync<Paginated<CharacterDto>>(url);
        }

        public Task<CharacterDto?> GetAsync(int id)
        {
            if (id == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            string url = $"{Constants.Endpoints.Character}{id}";
            
            return _restClient.GetAsync<CharacterDto>(url);
        }

        public Task<Paginated<CharacterDto>?> GetByFilterAsync(CharacterFilter filter)
        {
            if (filter is null)
            {
                throw new ArgumentNullException(nameof(filter));
            }

            string filterUrl = GetFilterUrl(filter);

            string url = $"{Constants.Endpoints.Character}?{filterUrl}";

            return _restClient.GetAsync<Paginated<CharacterDto>>(url);
        }

        private static string GetFilterUrl(CharacterFilter filter)
        {
            string filterUrl = string.Empty;
            if (filter.Status is not null)
            {
                filterUrl = AddConcatIfNotEmpty(filterUrl);
                filterUrl = $"{filterUrl}status={filter.Status.Description()}";
            }
            if (filter.Gender is not null)
            {
                filterUrl = AddConcatIfNotEmpty(filterUrl);
                filterUrl = $"{filterUrl}gender={filter.Gender.Description()}";
            }
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
            if (!string.IsNullOrEmpty(filter.Species))
            {
                filterUrl = AddConcatIfNotEmpty(filterUrl);
                filterUrl = $"{filterUrl}species={filter.Species}";
            }

            return filterUrl;
        }

        private static string AddConcatIfNotEmpty(string filterUrl)
        {
            filterUrl = string.IsNullOrEmpty(filterUrl) ? filterUrl : $"{filterUrl}&";
            return filterUrl;
        }

        public Task<IEnumerable<CharacterDto>?> GetSeveralAsync(params int[] ids)
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

            string url = $"{Constants.Endpoints.Character}{idsAsString}";

            return _restClient.GetAsync<IEnumerable<CharacterDto>>(url);
        }
    }
}
