﻿using RoyalCode.Yasamen.Forms.Messages;

namespace RoyalCode.Yasamen.Forms.Components;

public abstract class DateFieldBase<TDate> : InputFieldBase<TDate>
{
    private string? currentInputValue;
    private string? previousInputValue;
    
    private bool isNullable = Nullable.GetUnderlyingType(typeof(TDate)) is not null;

    protected override string? CurrentValueAsString
    {
        get => currentInputValue;
        set => currentInputValue = value;
    }

    protected override void OnParametersSet()
    {
        var formatted = FormatValue(CurrentValue);
        currentInputValue = formatted;

        base.OnParametersSet();
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

        if (isNullable && string.IsNullOrWhiteSpace(currentInputValue))
        {
            previousInputValue = currentInputValue;
            IsInvalid = false;
            CurrentValue = default!;
            return;
        }

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
