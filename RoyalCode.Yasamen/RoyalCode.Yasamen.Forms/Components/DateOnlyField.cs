using Microsoft.AspNetCore.Components;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace RoyalCode.Yasamen.Forms.Components;

public sealed class DateOnlyField : DateFieldBase<DateOnly>
{
    protected override string FieldType => "date";

    protected override string? FormatValue(DateOnly value)
    {
        if (value == default)
            return null;
        return BindConverter.FormatValue(value, "yyyy-MM-dd", CultureInfo.InvariantCulture);
    }

    protected override bool TryParseValue(
        string? value,
        [MaybeNullWhen(false), NotNullWhen(true)] out DateOnly result,
        [NotNullWhen(false)] out string? errorMessage)
    {
        if (BindConverter.TryConvertTo(value, CultureInfo.InvariantCulture, out result))
        {
            errorMessage = null;
            return true;
        }
        else
        {
            errorMessage = string.IsNullOrWhiteSpace(ParsingErrorMessage)
                ? string.Format(CultureInfo.InvariantCulture,
                    $"The {{0}} field must be a \"yyyy-MM-dd\".", FieldLabel)
                : ParsingErrorMessage;

            return false;
        }
    }
}