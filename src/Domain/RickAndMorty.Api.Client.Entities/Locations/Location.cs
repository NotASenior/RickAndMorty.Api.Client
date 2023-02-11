using RickAndMorty.Api.Client.Entities.CrossCutting;

namespace RickAndMorty.Api.Client.Entities.Locations
{
    internal class Location : BaseEntity
    {
        public string? Type { get; set; }
        public string? Dimension { get; set; }
        public IEnumerable<int>? Residents { get; set; }
    }
}
