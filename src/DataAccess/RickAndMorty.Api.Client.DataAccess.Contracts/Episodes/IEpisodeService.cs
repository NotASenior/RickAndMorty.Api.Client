using RickAndMorty.Api.Client.DataAccess.Contracts.CrossCutting;
using RickAndMorty.Api.Client.DataAccess.Contracts.Static;

namespace RickAndMorty.Api.Client.DataAccess.Contracts.Episodes
{
    internal interface IEpisodeService
    {
        EpisodeDto Get(int id);
        IEnumerable<EpisodeDto> GetSeveral(params int[] ids);
        Paginated<EpisodeDto> GetAll(int skip = 0, int take = Constants.Pagination.Take);
        Paginated<EpisodeDto> GetByFilter(EpisodeFilter filter);
    }
}
