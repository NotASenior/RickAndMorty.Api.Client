using RickAndMorty.Api.Client.DataAccess.Contracts.CrossCutting;

namespace RickAndMorty.Api.Client.DataAccess.Contracts.Characters
{
    public interface ICharacterService
    {
        Task<CharacterDto?> GetAsync(int id);
        Task<IEnumerable<CharacterDto>?> GetSeveralAsync(params int[] ids);
        Task<Paginated<CharacterDto>?> GetAllAsync(int page = 1);
        Task<Paginated<CharacterDto>?> GetByFilterAsync(CharacterFilter filter);
    }
}
