using RickAndMorty.Api.Client.DataAccess.Contracts.Exceptions;
using RickAndMorty.Api.Client.DataAccess.Contracts.CrossCutting;

namespace RickAndMorty.Api.Client.DataAccess.Contracts.Characters
{
    public interface ICharacterRepository
    {
        /// <summary>
        /// Returns a character, based on the given filter
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="DataAccessException"></exception>
        Task<CharacterDto?> GetAsync(int id);

        /// <summary>
        /// Returns a list of characters, based on the given filter
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="DataAccessException"></exception>
        Task<IEnumerable<CharacterDto>?> GetSeveralAsync(params int[] ids);

        /// <summary>
        /// Returns a paginated list of characters, based on the given filter
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="DataAccessException"></exception>
        Task<Paginated<CharacterDto>?> GetAllAsync(int page = 1);

        /// <summary>
        /// Returns a paginated list of characters, based on the given filter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="DataAccessException"></exception>
        Task<Paginated<CharacterDto>?> GetByFilterAsync(CharacterFilter filter);
    }
}
