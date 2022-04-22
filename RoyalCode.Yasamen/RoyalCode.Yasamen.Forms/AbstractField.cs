using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using RoyalCode.Yasamen.Forms.Support;
using System.Linq.Expressions;

namespace RoyalCode.Yasamen.Forms;

public class AbstractField<TValue>
{
    [Parameter]
    public TValue? Value { get; set; }

    //
    // Summary:
    //     Gets or sets a callback that updates the bound value.
    [Parameter]
    public EventCallback<TValue> ValueChanged { get; set; }

    //
    // Summary:
    //     Gets or sets an expression that identifies the bound value.
    [Parameter]
    public Expression<Func<TValue>>? ValueExpression { get; set; }

    [CascadingParameter]
    public PropertyChangeSupport? PropertyChangeSupport { get; set; }

    protected FieldIdentifier FieldIdentifier { get; private set; }

    //
    // Summary:
    //     Gets or sets the current value of the input.
    protected TValue? CurrentValue
    {
        get
        {
            return Value;
        }
        set
        {
            if (!EqualityComparer<TValue>.Default.Equals(value, Value))
            {
                var old = Value;
                Value = value;
                ValueChanged.InvokeAsync(Value);
                PropertyChangeSupport?.PropertyHasChanged(FieldIdentifier, old, value);
            }
        }
    }

    //
    // Summary:
    //     Gets or sets the current value of the input, represented as a string.
    protected string? CurrentValueAsString
    {
        get
        {
            return FormatValueAsString(CurrentValue);
        }
        set
        {
            _parsingValidationMessages?.Clear();

            bool flag;
            TValue result;
            string validationErrorMessage;

            if (_nullableUnderlyingType != null && string.IsNullOrEmpty(value))
            {
                flag = false;
                CurrentValue = default(TValue);
            }
            else if (TryParseValueFromString(value, out result, out validationErrorMessage))
            {
                flag = false;
                CurrentValue = result;
            }
            else
            {
                flag = true;
                if (_parsingValidationMessages == null)
                {
                    _parsingValidationMessages = new ValidationMessageStore(EditContext);
                }

                ValidationMessageStore parsingValidationMessages = _parsingValidationMessages;
                FieldIdentifier fieldIdentifier = FieldIdentifier;
                parsingValidationMessages.Add(in fieldIdentifier, validationErrorMessage);
                EditContext editContext = EditContext;
                fieldIdentifier = FieldIdentifier;
                editContext.NotifyFieldChanged(in fieldIdentifier);
            }

            if (flag || _previousParsingAttemptFailed)
            {
                EditContext.NotifyValidationStateChanged();
                _previousParsingAttemptFailed = flag;
            }
        }
    }
}
