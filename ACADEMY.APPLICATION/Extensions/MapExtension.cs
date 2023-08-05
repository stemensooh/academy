using ACADEMY.DOMAIN.Interfaces;

namespace ACADEMY.APPLICATION.Extensions
{
    public static class MapExtension
    {
        public static int? ToNullableInt(this string valor)
        {
            return int.TryParse(valor, out int i) ? i : null;
        }

        public static DateTime? ToNullableDateTime(this string valor)
        {
            return DateTime.TryParse(valor, out DateTime i) ? i : null;
        }

    }
}