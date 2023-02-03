using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using RoyalCode.OperationResult;
using RoyalCode.Yasamen.Commons;
using RoyalCode.Yasamen.Forms.Messages;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace RoyalCode.Yasamen.Forms.Components;

public class DateOnlyField : InputFieldBase<DateOnly>
{
    protected override string FieldType => "date";
    private string? currentInputValue;
    private string? previousInputValue;

    protected override string? CurrentValueAsString
    {
        get => currentInputValue;
        set => currentInputValue = value;
    }

    protected override void OnParametersSet()
    {
        currentInputValue = FormatValue(Value);
        previousInputValue = currentInputValue;
        base.OnParametersSet();
    }

    protected override string? FormatValue(DateOnly value)
    {
        if (value == default)
            return null;
        var formatted = BindConverter.FormatValue(value, "yyyy-MM-dd", CultureInfo.InvariantCulture);

        Console.WriteLine($"FormatValue: {value}, formatted: {formatted}.");

        return formatted;
    }

    protected override bool TryParseValue(
        string? value,
        [MaybeNullWhen(false), NotNullWhen(true)] out DateOnly result,
        [NotNullWhen(false)] out string? errorMessage)
    {
        if (BindConverter.TryConvertTo(value, CultureInfo.InvariantCulture, out result))
        {
            Console.WriteLine($"Parsed value: {value}, result: {result}.");

            errorMessage = null;
            return true;
        }
        else
        {
            Console.WriteLine($"Parse error value: {value}, result: {result}.");

            errorMessage = string.IsNullOrWhiteSpace(ParsingErrorMessage)
                ? string.Format(CultureInfo.InvariantCulture,
                    $"The {{0}} field must be a \"yyyy-MM-dd\".", FieldLabel)
                : ParsingErrorMessage;

            return false;
        }
    }

    protected override void OnBlur()
    {
        if (previousInputValue != currentInputValue)
            UpdateValue();
        
        base.OnBlur();
    }

    private void UpdateValue()
    {
        var editorMessages = ModelContext.EditorMessages;
        editorMessages.Clear(FieldIdentifier);
        
        if (TryParseValue(currentInputValue, out var newValue, out var error))
        {
            IsInvalid = false;
        }
        else
        {
            IsInvalid = true;
            editorMessages.Add(FieldIdentifier, ResultMessage.Error(error!, FieldIdentifier.FieldName));
            return;
        }

        previousInputValue = currentInputValue;
        CurrentValue = newValue;
    }
}
