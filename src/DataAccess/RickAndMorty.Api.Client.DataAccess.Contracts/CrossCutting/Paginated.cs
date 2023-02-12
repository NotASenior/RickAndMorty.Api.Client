namespace RickAndMorty.Api.Client.DataAccess.Contracts.CrossCutting
{
    public class Paginated<T>
    {
        public Pagination? Info { get; set; }
        public List<T>? Results { get; set; }
    }
}
