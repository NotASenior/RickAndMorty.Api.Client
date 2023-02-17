using RickAndMorty.Api.Client.Domain.Entities.CrossCutting;

namespace RickAndMorty.Api.Client.Domain.Entities.Episodes
{
    public class Episode : BaseEntity
    {
        public DateTime? AirDate { get; set; }
        public string? Code { get; set; }
        public IEnumerable<int>? Characters { get; set; }
    }
}
