namespace RickAndMorty.Api.Client.Domain.Entities.Episodes
{
    internal class Episode
    {
        public DateTime? AirDate { get; set; }
        public string? Code { get; set; }
        public IEnumerable<int>? Characters { get; set; }
    }
}
