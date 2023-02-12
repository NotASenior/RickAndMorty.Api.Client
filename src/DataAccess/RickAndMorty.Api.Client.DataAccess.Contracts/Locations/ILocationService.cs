using RickAndMorty.Api.Client.DataAccess.Contracts.CrossCutting;
using RickAndMorty.Api.Client.DataAccess.Contracts.Static;

namespace RickAndMorty.Api.Client.DataAccess.Contracts.Locations
{
    internal interface ILocationService
    {
        LocationDto Get(int id);
        IEnumerable<LocationDto> GetSeveral(params int[] ids);
        Paginated<LocationDto> GetAll(int skip = 0, int take = Constants.Pagination.Take);
        Paginated<LocationDto> GetByFilter(LocationFilter filter);
    }
}
