using Microsoft.AspNetCore.Components;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace RoyalCode.Yasamen.Forms.Components;

/// <summary>
/// A component for input of <see cref="Nullable"/> <see cref="DateOnly"/> values.
/// </summary>
public sealed class NDateOnlyField : DateFieldBase<DateOnly?>
{
    protected override string FieldType => "date";

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        if (ParsingErrorPattern.IsMissing())
            ParsingErrorPattern = "The {0} field must be a \"yyyy-MM-dd\".";
    }

    protected override string? FormatValue(DateOnly? value)
    {
        if (value == null)
            return null;
        return BindConverter.FormatValue(value, "yyyy-MM-dd", CultureInfo.InvariantCulture);
    }

    protected override bool TryParseValue(
        string? value,
        [MaybeNullWhen(false), NotNullWhen(true)] out DateOnly? result,
        [NotNullWhen(false)] out string? errorMessage)
    {
        if (BindConverter.TryConvertTo(value, CultureInfo.InvariantCulture, out DateOnly converted))
        {
            result = converted;
            errorMessage = null;
            return true;
        }
        else
        {
            result = null;
            errorMessage = GetInvalidInputErrorMessage();
            return false;
        }
    }
}