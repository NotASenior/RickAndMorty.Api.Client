using System.ComponentModel;

namespace RickAndMorty.Api.Client.Domain.Entities.Characters
{
    public enum CharacterStatus
    {
        [Description("alive")]
        Alive,
        [Description("dead")]
        Dead,
        [Description("unknown")]
        Unknown
    }
}
