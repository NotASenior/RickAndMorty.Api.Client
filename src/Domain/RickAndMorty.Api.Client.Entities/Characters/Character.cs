using RickAndMorty.Api.Client.Domain.Entities.CrossCutting;

namespace RickAndMorty.Api.Client.Domain.Entities.Characters
{
    public class Character : BaseEntity
    {
        public CharacterStatus Status { get; set; }
        public string? Species { get; set; }
        public string? Type { get; set; }
        public Gender Gender { get; set; }
        public string? Origin { get; set; }
        public int OriginId { get; set; }
        public string? Location { get; set; }
        public int LocationId { get; set; }
        public string? ImageUrl { get; set; }
        public IEnumerable<int>? Episodes { get; set; }
    }
}
