using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using RoyalCode.Yasamen.Commons;
using RoyalCode.Yasamen.Commons.Extensions;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Reflection;

namespace RoyalCode.Yasamen.Forms;

public partial class FieldBase<TValue> : ComponentBase, IDisposable
{
    //private readonly EventHandler<ValidationStateChangedEventArgs> _validationStateChangedHandler;
    //private bool _previousParsingAttemptFailed;
    
    private bool initialized;
    private Type? nullableUnderlyingType;
    private bool settingFormattedCurrentValue;
    private PropertyInfo? propertyInfo;
    private string? fieldLabel;
    private string? fieldName;
    private string? fieldId;

    /// <summary>
    /// Gets the associated <see cref="ModelContext{TModel}"/>.
    /// This property is uninitialized if the input does not have a parent <see cref="ModelEditor{TModel}"/>.
    /// </summary>
    protected IModelContext ModelContext { get; set; } = default!;

    /// <summary>
    /// Gets the <see cref="FieldIdentifier"/> for the bound value.
    /// </summary>
    protected FieldIdentifier FieldIdentifier { get; set; }

    /// <summary>
    /// It informs you if the value is invalid and the <c>aria-invalid</c> html attribute should be shown.
    /// </summary>
    protected bool IsInvalid { get; private set; } = false;

    /// <summary>
    /// <para>
    ///     Label that will be displayed for the field.
    /// </para>
    /// <para>
    ///     If the <see cref="Label"/> is not set,
    ///     the value will be retrieved from the <see cref="DisplayNameAttribute"/> of the property.
    ///     <br />
    ///     When the <see cref="DisplayNameAttribute"/> is not set, the property name will be used.
    ///     <br />
    ///     When the property can not be found, the <see cref="FieldIdentifier.FieldName"/> will be used.
    /// </para>
    /// <para>
    ///     This property should be used by components that inherit <see cref="FieldBase{TValue}"/>.
    /// </para>
    /// </summary>
    protected string FieldLabel => fieldLabel ??= FieldPropertyInfo?.GetDefaultDisplayName() ?? FieldIdentifier.FieldName;

    /// <summary>
    /// <para>
    ///     Name for the field input.
    /// </para>
    /// <para>
    ///     If the <see cref="Name"/> is not set, the <see cref="FieldIdentifier.FieldName"/> will be used.
    /// </para>
    /// <para>
    ///     This property should be used by components that inherit <see cref="FieldBase{TValue}"/>.
    /// </para>
    /// </summary>
    protected string FieldName => fieldName ??= FieldIdentifier.FieldName;

    /// <summary>
    /// <para>
    ///     Id for the field input.
    /// </para>
    /// <para>
    ///     If the <see cref="Id"/> is not set, an ID will be generated using the <see cref="ModelContext"/> and
    ///     the <see cref="FieldName"/>.
    /// </para>
    /// <para>
    ///     This property should be used by components that inherit <see cref="FieldBase{TValue}"/>.
    /// </para>
    /// </summary>
    protected string FieldId => fieldId ??= $"{ModelContext.GetModelNameIdentifier()}.{FieldName}";

    /// <summary>
    /// Context received by the <see cref="ModelEditor{TModel}"/>.
    /// </summary>
    [CascadingParameter]
    private IModelContext? CascadedContext { get; set; }

    /// <summary>
    /// Status of parent components that can load models.
    /// </summary>
    [CascadingParameter]
    public IModelLoadingState? ModelLoadingState { get; set; }

    /// <summary>
    /// Label that will be displayed for the field.
    /// </summary>
    [Parameter]
    public string? Label { get; set; }

    /// <summary>
    /// Name for the field input.
    /// </summary>
    [Parameter]
    public string? Name { get; set; }

    /// <summary>
    /// The html id for the field.
    /// </summary>
    [Parameter]
    public string? Id { get; set; }

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
    [Parameter] public EventCallback<TValue> ValueChanged { get; set; }

    /// <summary>
    /// Gets or sets an expression that identifies the bound value.
    /// </summary>
    [Parameter] public Expression<Func<TValue>>? ValueExpression { get; set; }

    /// <summary>
    /// Gets or sets a collection of additional attributes that will be applied to the created element.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }

    protected PropertyInfo? FieldPropertyInfo
    {
        get
        {
            propertyInfo ??= FieldIdentifier.Model.GetType().GetProperty(FieldIdentifier.FieldName);
            return propertyInfo;
        }
    }

    protected virtual string? CurrentValueAsString
    {
        get => FormatValue(Value);
        set
        {
            if (settingFormattedCurrentValue)
            {
                return;
            }

            TValue? oldValue = Value;
            string? originalInput = value;
            Tracer.Write("FieldBase", "SetValue", value ?? "null");

            var parsed = ParseAndSetValue(value);
            if (!parsed)
                return;

            var formattedValue = FormatValue(Value);

            if (formattedValue != originalInput)
            {
                settingFormattedCurrentValue = true;
                try
                {
                    ParseAndSetValue(formattedValue);
                }
                finally
                {
                    settingFormattedCurrentValue = false;
                }

                Tracer.Write("FieldBase", "SetValue", "Value Formatted");
            }

            
            var hasChanged = !EqualityComparer<TValue>.Default.Equals(oldValue, Value);
            if (hasChanged)
            {
                _ = ValueChanged.InvokeAsync(Value);

                // Disparar evento de alteração
            }

            //if (PropertyChangedSupport is not null && !EqualityComparer<TValue>.Default.Equals(oldValue, Value))
            //{
            //    Tracer.Write("FieldBase", "SetValue", $"PropertyChanged, Field: {FieldIdentifier}, {oldValue}, {Value}");
            //    PropertyChangedSupport.PropertyHasChanged(FieldIdentifier, oldValue, Value);
            //}
        }
    }

    protected bool ParseAndSetValue(string? newValue)
    {
        // remover mensagens para a propriedade.
        
        if (TryParseValue(newValue, out var result, out var error))
        {
            Value = result;
            IsInvalid = false;
            
            return true;
        }
        else
        {
            IsInvalid = true;
            // TODO: atribuir mensagem de erro
            return false;
        }
    }

    protected virtual string? FormatValue(TValue? value) => value?.ToString();

    protected virtual bool TryParseValue(string? value,
        [NotNullWhen(true), MaybeNullWhen(false)] out TValue result,
        [NotNullWhen(false)] out string? errorMessage)
    {
        var parsed = BindConverter.TryConvertTo(value, null, out result);

        errorMessage = parsed is false
            ? "Invalid input" 
            : null;

        return parsed;
    }

    /// <inheritdoc />
    public override Task SetParametersAsync(ParameterView parameters)
    {
        parameters.SetParameterProperties(this);

        if (!initialized)
        {
            if (ValueExpression == null)
            {
                throw new InvalidOperationException($"{GetType()} requires a value for the 'ValueExpression' " +
                    $"parameter. Normally this is provided automatically when using 'bind-Value'.");
            }

            FieldIdentifier = FieldIdentifier.Create(ValueExpression);

            if (CascadedContext is not null)
            {
                ModelContext = CascadedContext;

                // add property listener no lugar de state change listener
                //EditContext.OnValidationStateChanged += _validationStateChangedHandler;
            }

            nullableUnderlyingType = Nullable.GetUnderlyingType(typeof(TValue));
            initialized = true;
        }
        else if (CascadedContext != ModelContext)
        {
            throw new InvalidOperationException(
                $"{GetType()} does not support changing the {nameof(ModelContext<object>)} dynamically.");
        }

        if (ModelContext is null)
            throw new InvalidOperationException(
                $"The Field of type {GetType()} requires a cascading parameter of type {nameof(ModelContext<object>)},"
                + $" for example you can use {GetType()} inside an {nameof(ModelEditor<object>)}.");

        if (Label is not null)
            fieldLabel = Label;
        if (Name is not null)
            fieldName = Name;
        if (Id is not null)
            fieldId = Id;
        
        return base.SetParametersAsync(ParameterView.Empty);
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
