using RickAndMorty.Api.Client.DataAccess.Contracts.Characters;
using RickAndMorty.Api.Client.DataAccess.Contracts.Exceptions;
using RickAndMorty.Api.Client.DataAccess.Contracts.CrossCutting;
using RickAndMorty.Api.Client.Domain.Entities.Characters;

namespace RickAndMorty.Api.Client.Business.Contracts.Characters
{
    public interface ICharacterService
    {
        /// <summary>
        /// Returns a character, based on the given filter
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="DataAccessException"></exception>
        Task<Character?> GetAsync(int id);

        /// <summary>
        /// Returns a list of characters, based on the given filter
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="DataAccessException"></exception>
        Task<IEnumerable<Character>?> GetSeveralAsync(params int[] ids);

        /// <summary>
        /// Returns a paginated list of characters, based on the given filter
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="DataAccessException"></exception>
        Task<Paginated<Character>?> GetAllAsync(int page = 1);

        /// <summary>
        /// Returns a paginated list of characters, based on the given filter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="DataAccessException"></exception>
        Task<Paginated<Character>?> GetByFilterAsync(CharacterFilter filter);
    }
}
