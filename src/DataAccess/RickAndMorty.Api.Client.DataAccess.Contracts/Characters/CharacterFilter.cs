using RickAndMorty.Api.Client.Domain.Entities.Characters;

namespace RickAndMorty.Api.Client.DataAccess.Contracts.Characters
{
    internal class CharacterFilter
    {
        public string? Name { get; set; }
        public CharacterStatus? Status { get; set; }
        public string? Species { get; set; }
        public string? Type { get; set; }
        public Gender? Gender { get; set; }
    }
}
