using RickAndMorty.Api.Client.DataAccess.Contracts.CrossCutting;

namespace RickAndMorty.Api.Client.DataAccess.Contracts.Episodes
{
    internal interface IEpisodeService
    {
        Task<EpisodeDto?> GetAsync(int id);
        Task<IEnumerable<EpisodeDto>?> GetSeveralAsync(params int[] ids);
        Task<Paginated<EpisodeDto>?> GetAllAsync(int page = 1);
        Task<Paginated<EpisodeDto>?> GetByFilterAsync(EpisodeFilter filter);
    }
}
