using RickAndMorty.Api.Client.DataAccess.Contracts.CrossCutting;

namespace RickAndMorty.Api.Client.DataAccess.Contracts.Locations
{
    public interface ILocationRepository
    {
        Task<LocationDto?> GetAsync(int id);
        Task<IEnumerable<LocationDto?>> GetSeveralAsync(params int[] ids);
        Task<Paginated<LocationDto>?> GetAllAsync(int page = 1);
        Task<Paginated<LocationDto>?> GetByFilterAsync(LocationFilter filter);
    }
}
