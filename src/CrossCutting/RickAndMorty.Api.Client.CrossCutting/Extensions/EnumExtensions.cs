using System.ComponentModel;

namespace RickAndMorty.Api.Client.CrossCutting.Extensions
{
    public static class EnumExtensions
    {
        public static string GetCustomDescription(object enumObject)
        {
            if (enumObject is null)
            {
                return string.Empty;
            }

            var field = enumObject.GetType().GetField(enumObject!.ToString()!);
            if (field is null)
            {
                return string.Empty;
            }

            var attributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return (attributes.Length > 0) ? attributes[0].Description : enumObject!.ToString()!;
        }

        public static string Description(this Enum value)
        {
            return GetCustomDescription(value);
        }
    }
}
