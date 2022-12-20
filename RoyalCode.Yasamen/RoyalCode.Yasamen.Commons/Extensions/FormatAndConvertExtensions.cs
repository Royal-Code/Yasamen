
using Microsoft.AspNetCore.Components;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace RoyalCode.Yasamen.Commons.Extensions;

public static class FormatAndConvertExtensions
{
    public static bool TryParseValueFromString<TValue>(
        this string value,
        [NotNullWhen(true)] out TValue? result)
    {
        return BindConverter.TryConvertTo(value, CultureInfo.CurrentCulture, out result);
    }

    public static string? FormatNumberAsString(this object value, string? format = null)
    {
        if (format is not null && !format.StartsWith('{'))
            format = $"{{0:{format}}}";

        return value switch
        {
            null => null,
            int @int => format is null ? @int.ToString(CultureInfo.CurrentCulture) : string.Format(CultureInfo.CurrentCulture, format, @int),
            decimal @decimal => format is null ? @decimal.ToString(CultureInfo.CurrentCulture) : string.Format(CultureInfo.CurrentCulture, format, @decimal),
            long @long => format is null ? @long.ToString(CultureInfo.CurrentCulture) : string.Format(CultureInfo.CurrentCulture, format, @long),
            short @short => format is null ? @short.ToString(CultureInfo.CurrentCulture) : string.Format(CultureInfo.CurrentCulture, format, @short),
            float @float => format is null ? @float.ToString(CultureInfo.CurrentCulture) : string.Format(CultureInfo.CurrentCulture, format, @float),
            double @double => format is null ? @double.ToString(CultureInfo.CurrentCulture) : string.Format(CultureInfo.CurrentCulture, format, @double),
            _ => throw new InvalidOperationException($"Unsupported type {value.GetType()}"),
        };
    }

    public static string? ToCamelCase(this string? value)
    {
        if (value is null)
            return null;

        return value.Length == 0 || char.IsLower(value[0])
            ? value
            : $"{char.ToLower(value[0])}{value[1..]}";
    }
}
