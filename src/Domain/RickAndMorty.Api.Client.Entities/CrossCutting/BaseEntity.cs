namespace RickAndMorty.Api.Client.Domain.Entities.CrossCutting
{
    internal class BaseEntity : BasicEntity
    {
        public DateTime? CreatedAt { get; set; }
    }
}
