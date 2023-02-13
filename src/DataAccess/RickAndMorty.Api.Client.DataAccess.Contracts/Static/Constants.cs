namespace RickAndMorty.Api.Client.DataAccess.Contracts.Static
{
    public static class Constants
    {
        public static class Endpoints
        {
            public const string Base = "https://rickandmortyapi.com/api";
            public const string Page = "?page=";
            public const string Character = $"{Base}/character/";
            public const string Episode = $"{Base}/episode/";
            public const string Location = $"{Base}/location/";
        }
    }
}
