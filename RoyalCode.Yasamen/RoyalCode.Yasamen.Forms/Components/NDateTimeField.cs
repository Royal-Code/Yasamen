﻿using Microsoft.AspNetCore.Components;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace RoyalCode.Yasamen.Forms.Components;

public sealed class NDateTimeField : DateFieldBase<DateTime?>
{
    protected override string FieldType => Format.ToHtmlDateType();

    [Parameter]
    public DateTimeFormat Format { get; set; }

    protected override string? FormatValue(DateTime? value)
    {
        if (value == default)
            return null;
        return BindConverter.FormatValue(value, Format.ToHtmlFormat(), CultureInfo.InvariantCulture);
    }

    protected override bool TryParseValue(
        string? value,
        [MaybeNullWhen(false), NotNullWhen(true)] out DateTime? result,
        [NotNullWhen(false)] out string? errorMessage)
    {
        if (BindConverter.TryConvertTo(value, CultureInfo.InvariantCulture, out DateTime converted))
        {
            result = converted;
            errorMessage = null;
            return true;
        }
        else
        {
            result = null;
            var msgFormat = string.IsNullOrWhiteSpace(ParsingErrorMessage)
                ? "The {0} field must be a \"{1}\"."
                : ParsingErrorMessage;

            errorMessage = string.Format(CultureInfo.InvariantCulture, msgFormat, FieldLabel, Format.ToHtmlFormat());

            return false;
        }
    }
}