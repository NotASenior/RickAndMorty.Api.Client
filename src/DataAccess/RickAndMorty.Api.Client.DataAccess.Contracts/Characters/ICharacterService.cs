using RickAndMorty.Api.Client.DataAccess.Contracts.CrossCutting;
using RickAndMorty.Api.Client.DataAccess.Contracts.Static;

namespace RickAndMorty.Api.Client.DataAccess.Contracts.Characters
{
    internal interface ICharacterService
    {
        CharacterDto Get(int id);
        IEnumerable<CharacterDto> GetSeveral(params int[] ids);
        Paginated<CharacterDto> GetAll(int skip = 0, int take = Constants.Pagination.Take);
        Paginated<CharacterDto> GetByFilter(CharacterFilter filter);
    }
}
