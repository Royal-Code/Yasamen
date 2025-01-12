using Microsoft.AspNetCore.Components;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace RoyalCode.Yasamen.Forms.Components;

public sealed class DateTimeOffsetField : DateFieldBase<DateTimeOffset>
{
    protected override string FieldType => Format.ToHtmlDateType();

    [Parameter]
    public DateTimeFormat Format { get; set; }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        if (ParsingErrorPattern.IsMissing())
            ParsingErrorPattern = $"The {{0}} field must be a \"{Format.ToHtmlFormat()}\".";
    }

    protected override string? FormatValue(DateTimeOffset value)
    {
        if (value == default)
            return null;
        return BindConverter.FormatValue(value, Format.ToHtmlFormat(), CultureInfo.InvariantCulture);
    }

    protected override bool TryParseValue(
        string? value,
        [MaybeNullWhen(false), NotNullWhen(true)] out DateTimeOffset result,
        [NotNullWhen(false)] out string? errorMessage)
    {
        if (BindConverter.TryConvertTo(value, CultureInfo.InvariantCulture, out result))
        {
            errorMessage = null;
            return true;
        }
        else
        {
            errorMessage = GetInvalidInputErrorMessage();
            return false;
        }
    }
}