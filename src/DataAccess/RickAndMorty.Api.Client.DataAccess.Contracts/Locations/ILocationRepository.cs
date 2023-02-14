using RickAndMorty.Api.Client.DataAccess.Contracts.CrossCutting;

namespace RickAndMorty.Api.Client.DataAccess.Contracts.Locations
{
    internal interface ILocationRepository
    {
        Task<LocationDto?> Get(int id);
        Task<IEnumerable<LocationDto?>> GetSeveralAsync(params int[] ids);
        Task<Paginated<LocationDto>?> GetAllAsync(int page = 1);
        Task<Paginated<LocationDto>?> GetByFilterAsync(LocationFilter filter);
    }
}
