namespace RickAndMorty.Api.Client.DataAccess.Contracts.Exceptions
{
    public class DataAccessException : Exception
    {
        public DataAccessException(string message, Exception ex) : base(message, ex)
        { 
        }
    }
}
