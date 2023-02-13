namespace RickAndMorty.Api.Client.DataAccess.Contracts.CrossCutting
{
    public interface IRestClientWrapper
    {
        Task<T?> GetAsync<T>(string url);
    }
}
