using System.Text.Json.Serialization;

namespace RickAndMorty.Api.Client.DataAccess.Contracts.Episodes
{
    public class EpisodeDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        [JsonPropertyName("air_date")]
        public string? AirDate { get; set; }
        public string? Episode { get; set; }
        public List<string>? Characters { get; set; }
        public string? Url { get; set; }
        public DateTime Created { get; set; }
    }
}
