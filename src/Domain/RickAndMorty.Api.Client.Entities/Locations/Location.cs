using RickAndMorty.Api.Client.Domain.Entities.CrossCutting;

namespace RickAndMorty.Api.Client.Domain.Entities.Locations
{
    internal class Location : BaseEntity
    {
        public string? Type { get; set; }
        public string? Dimension { get; set; }
        public IEnumerable<int>? Residents { get; set; }
    }
}
