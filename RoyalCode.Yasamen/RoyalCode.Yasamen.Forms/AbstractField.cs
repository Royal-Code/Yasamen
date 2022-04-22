using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using RoyalCode.Yasamen.Forms.Support;
using System.Linq.Expressions;

namespace RoyalCode.Yasamen.Forms;

public abstract class AbstractField<TValue>
{
    protected static readonly bool IsnullableUnderlyingType = Nullable.GetUnderlyingType(typeof(TValue)) is not null;

    private ValidationMessageStore? messageStore;

    /// <summary>
    /// <para>
    ///     The value of the field.
    /// </para>
    /// <para>
    ///     Used to set the initial value or bind.
    /// </para>
    /// </summary>
    [Parameter]
    public TValue? Value { get; set; }

    /// <summary>
    /// A callback that updates the bound value.
    /// </summary>
    [Parameter]
    public EventCallback<TValue> ValueChanged { get; set; }

    /// <summary>
    /// An expression that identifies the bound value.
    /// </summary>
    [Parameter]
    public Expression<Func<TValue>>? ValueExpression { get; set; }

    /// <summary>
    /// <para>
    ///     The name that identifies the field.
    /// </para>
    /// <para>
    ///     If this property is not setted, the value will be used from the <see cref="FieldIdentifier"/>.
    /// </para>
    /// <para>
    ///     The <see cref="Name"/> or the <see cref="ValueExpression"/> must be informed.
    /// </para>
    /// </summary>
    [Parameter]
    public string? Name { get; set; }

    /// <summary>
    /// The property change support for notify other components when the <see cref="Value"/> of this field changes.
    /// </summary>
    [CascadingParameter]
    public PropertyChangeSupport? PropertyChangeSupport { get; set; }

    /// <summary>
    /// The field identifier, created from the <see cref="ValueExpression"/> or from the <see cref="Name"/>. 
    /// </summary>
    protected FieldIdentifier FieldIdentifier { get; private set; }

    //
    // Summary:
    //     Gets or sets the current value of the input.
    protected TValue? CurrentValue
    {
        get => Value;
        set
        {
            if (EqualityComparer<TValue>.Default.Equals(value, Value))
                return;

            var old = Value;
            Value = value;
            ValueChanged.InvokeAsync(Value);
            PropertyChangeSupport?.PropertyHasChanged(FieldIdentifier, old, value);
        }
    }

    /// <summary>
    /// The current value of the input, represented as a string.
    /// </summary>
    protected string? CurrentValueAsString
    {
        get => FormatValueAsString(CurrentValue);
        set
        {
            messageStore?.Clear();

            bool hasParseError;

            if (IsnullableUnderlyingType && string.IsNullOrEmpty(value))
            {
                hasParseError = false;
                CurrentValue = default;
            }
            else if (TryParseValueFromString(value, out var result, out var validationErrorMessage))
            {
                hasParseError = false;
                CurrentValue = result;
            }
            else
            {
                hasParseError = true;

                messageStore ??= new ValidationMessageStore(EditContext);

                messageStore.Add(FieldIdentifier, validationErrorMessage);
                EditContext editContext = EditContext;
                editContext.NotifyFieldChanged(FieldIdentifier);
            }

            if (hasParseError || _previousParsingAttemptFailed)
            {
                EditContext.NotifyValidationStateChanged();
                _previousParsingAttemptFailed = hasParseError;
            }
        }
    }

    /// <summary>
    /// <para>
    ///     Formats the value as a string.
    /// </para>
    /// <para>
    ///     Derived classes can override this to determine the formating used for <see cref="CurrentValueAsString"/>.
    /// </para>
    /// <para>
    ///     By default, the <see cref="object.ToString"/> method is used over the <paramref name="value"/> parameter.
    /// </para>
    /// </summary>
    /// <param name="value">The value to format.</param>
    /// <returns>A string representation of the value.</returns>
    protected virtual string? FormatValueAsString(TValue? value) => value?.ToString();

    /// <summary>
    /// <para>
    ///     Parses a string to create an instance of <typeparamref name="TValue"/>.
    /// </para>
    /// <para>
    ///     Derived classes can override this to change how <see cref="CurrentValueAsString"/>
    ///     interprets incoming values.
    /// </para>
    /// </summary>
    /// <param name="value">The string value to be parsed.</param>
    /// <param name="result">An instance of <typeparamref name="TValue"/>.</param>
    /// <param name="validationErrorMessage">
    ///     If the value could not be parsed, provides a validation error message.
    /// </param>
    /// <returns>
    ///     True if the value could be parsed; otherwise false.
    /// </returns>
    protected abstract bool TryParseValueFromString(
        string? value,
        [MaybeNullWhen(false)] out TValue result,
        [NotNullWhen(false)] out string? validationErrorMessage);
}