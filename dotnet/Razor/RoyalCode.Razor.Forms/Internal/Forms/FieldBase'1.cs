using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace RoyalCode.Razor.Internal.Forms;

/// <summary>
/// Base class for form fields.
/// </summary>
/// <typeparam name="TValue">The type of the value.</typeparam>
public abstract class FieldBase<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TValue> : FieldBase
{
    private readonly EventHandler<ValidationStateChangedEventArgs>? validationStateChangedHandler;

    private string? enteredValue;
    private TValue? currentValue;
    private bool initialized;

    /// <summary>
    /// Creates a new instance of the component.
    /// </summary>
    protected FieldBase()
    {
        // every time the validation state changes, we need to update the validation message for this field
        validationStateChangedHandler = (sender, eventArgs) =>
        {
            var messages = EditContext.GetValidationMessages(FieldIdentifier);
            ValidationErrorMessage = messages.FirstOrDefault();
        };
    }

    /// <summary>
    /// Gets or sets the value of the input. This should be used with two-way binding.
    /// </summary>
    /// <example>
    /// @bind-Value="model.PropertyName"
    /// </example>
    [Parameter]
    public TValue? Value { get; set; }

    /// <summary>
    /// Gets or sets a callback that updates the bound value.
    /// </summary>
    [Parameter]
    public EventCallback<TValue> ValueChanged { get; set; }

    /// <summary>
    /// Gets or sets an expression that identifies the bound value.
    /// </summary>
    [Parameter]
    public Expression<Func<TValue>>? ValueExpression { get; set; }

    /// <summary>
    /// Gets or sets a callback for listening to changes on the input element.
    /// </summary>
    [Parameter]
    public EventCallback<TValue> OnChange { get; set; }

    /// <summary>
    /// Internal additional CSS classes, for inheritance.
    /// </summary>
    protected string? InternalAdditionalClasses { get; set; }

    /// <summary>
    /// Current value for binding.
    /// </summary>
    protected TValue? CurrentValue
    {
        get => currentValue;
        set
        {
            var hasChanged = !EqualityComparer<TValue>.Default.Equals(Value, value);
            if (hasChanged)
            {
                ParseError = null;
                UpdateValidationMessageStore();

                currentValue = value;
                _ = ValueChanged.InvokeAsync(value);
                EditContext?.NotifyFieldChanged(FieldIdentifier);
                OnAfterValueChanged(value);
                OnChange.InvokeAsync(value);
            }
        }
    }

    /// <summary>
    /// Current value as string. Can be used for binding to input elements.
    /// </summary>
    protected virtual string? CurrentValueAsString
    {
        get => IsInvalid && enteredValue is not null ? enteredValue : FormatValue(currentValue);
        set
        {
            TValue? oldValue = Value;
            string? originalInput = value;

            ParseError = null;
            UpdateValidationMessageStore();

            if (TryParseValue(value, out var newValue, out var error))
            {
                enteredValue = null;
            }
            else
            {
                enteredValue = originalInput;
                ParseError = error;
                UpdateValidationMessageStore();

                return;
            }

            var formattedValue = FormatValue(newValue);
            if (formattedValue != originalInput && !TryParseValue(formattedValue, out newValue, out error))
            {
                enteredValue = originalInput;
                ParseError = error;
                UpdateValidationMessageStore();

                return;
            }

            var hasChanged = !EqualityComparer<TValue>.Default.Equals(oldValue, newValue);
            if (hasChanged)
            {
                currentValue = newValue;
                _ = ValueChanged.InvokeAsync(newValue);
                EditContext?.NotifyFieldChanged(FieldIdentifier);
                OnAfterValueChanged(newValue);
                OnChange.InvokeAsync(newValue);
            }
        }
    }

    /// <inheritdoc />
    protected override string FieldValueAsString => CurrentValueAsString ?? string.Empty;

    /// <summary>
    /// Formats the value as a string.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    protected virtual string? FormatValue(TValue? value) => value?.ToString();

    /// <summary>
    /// Parses the input value for the data type.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="result"></param>
    /// <param name="errorMessage"></param>
    /// <returns></returns>
    protected virtual bool TryParseValue(string? value,
        [NotNullWhen(true), MaybeNullWhen(false)] out TValue result,
        [NotNullWhen(false)] out string? errorMessage)
    {
        bool parsed;
        if (typeof(TValue) == typeof(bool))
        {
            parsed = bool.TryParse(value, out var boolResult);
            result = parsed ? (TValue)(object)boolResult : default!;
        }
        else
        {
            parsed = BindConverter.TryConvertTo(value, null, out result);
        }

        errorMessage = !parsed
            ? GetInvalidInputErrorMessage(value)
            : null;

        return parsed;
    }

    /// <summary>
    /// Called after the value has been changed.
    /// </summary>
    /// <param name="newValue"></param>
    protected virtual void OnAfterValueChanged(TValue? newValue) { }

    /// <inheritdoc />
    public override async Task SetParametersAsync(ParameterView parameters)
    {
        parameters.SetParameterProperties(this);

        currentValue = Value;

        await base.SetParametersAsync(ParameterView.Empty);

        if (!initialized)
        {
            if (ValueExpression is not null)
            {
                FieldIdentifier = FieldIdentifier.Create(ValueExpression);
                if (EditContext is not null)
                {
                    EditContext.Properties[FieldIdentifier] = this;
                    EditContext.OnValidationStateChanged += validationStateChangedHandler;
                }
            }

            initialized = true;
        }

        UpdateValidationMessageStore();
    }

    /// <summary>
    /// Removes EditContext settings on dispose.
    /// </summary>
    /// <param name="disposing"></param>
    /// <returns></returns>
    protected override ValueTask DisposeAsync(bool disposing)
    {
        if (EditContext is not null && ValueExpression is not null)
        {
            EditContext.Properties.Remove(FieldIdentifier);
            EditContext.OnValidationStateChanged -= validationStateChangedHandler;
        }

        return base.DisposeAsync(disposing);
    }
}
