using RickAndMorty.Api.Client.DataAccess.Contracts.CrossCutting;

namespace RickAndMorty.Api.Client.DataAccess.Contracts.Characters
{
    public class CharacterDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Status { get; set; }
        public string? Species { get; set; }
        public string? Type { get; set; }
        public string? Gender { get; set; }
        public NameUrlDto? Origin { get; set; }
        public NameUrlDto? Location { get; set; }
        public string? Image { get; set; }
        public List<string>? Episode { get; set; }
        public string? Url { get; set; }
        public DateTime? Created { get; set; }
    }
}
