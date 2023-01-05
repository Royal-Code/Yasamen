using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using RoyalCode.OperationResult;
using RoyalCode.Yasamen.Commons;
using RoyalCode.Yasamen.Commons.Extensions;
using RoyalCode.Yasamen.Forms.Messages;
using RoyalCode.Yasamen.Forms.Support;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Reflection;

namespace RoyalCode.Yasamen.Forms;

public partial class FieldBase<TValue> : ComponentBase, IDisposable
{
    private Action messagesChangedDelegate;
    private IMessageListener? messageListener;
    private bool initialized;
    private Type? nullableUnderlyingType;
    private bool settingNewValue;
    private PropertyInfo? propertyInfo;
    private string? fieldLabel;
    private string? fieldName;
    private string? fieldId;
    private ChangeSupport? changeSupport;

    public FieldBase()
    {
        messagesChangedDelegate = OnMessagesChanged;
    }
    
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
    /// The change support name. If not informed the <see cref="FieldIdentifier.FieldName"/> will be used.
    /// </summary>
    [Parameter]
    public string? ChangeSupport { get; set; }

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

    private string? enteredValue;
        
    protected virtual string? CurrentValueAsString
    {
        get => IsInvalid && enteredValue is not null ? enteredValue : FormatValue(Value);
        set
        {
            TValue? oldValue = Value;
            string? originalInput = value;
            Tracer.Write("FieldBase", "SetValue", value ?? "null");

            settingNewValue = true;

            var editorMessages = ModelContext.EditorMessages;
            editorMessages.Clear(FieldIdentifier);
            
            if (TryParseValue(value, out var newValue, out var error))
            {
                enteredValue = null;
                IsInvalid = false;
            }
            else
            {
                IsInvalid = true;
                enteredValue = originalInput;
                editorMessages.Add(FieldIdentifier, ResultMessage.Error(error!, FieldIdentifier.FieldName));
                
                settingNewValue = false;
                return;
            }
            
            var formattedValue = FormatValue(newValue);
            if (formattedValue != originalInput)
            {
                Tracer.Write("FieldBase", "SetValue", "Formatting value, entered {0}, formatted {1}", originalInput!, formattedValue!);

                if (!TryParseValue(formattedValue, out newValue, out error))
                {
                    IsInvalid = true;
                    enteredValue = originalInput;
                    editorMessages.Add(FieldIdentifier.Model, ResultMessage.Error(error!, FieldIdentifier.FieldName));

                    Tracer.Write("FieldBase", "SetValue", "Cannot parse formatted value");
                    settingNewValue = false;
                    return;
                }
            }
            
            var hasChanged = !EqualityComparer<TValue>.Default.Equals(oldValue, newValue);
            if (hasChanged)
            {
                Tracer.Write("FieldBase", "SetValue", $"PropertyChanged, Field: {FieldIdentifier}, {oldValue}, {newValue}");
                
                _ = ValueChanged.InvokeAsync(newValue);
                ModelContext.PropertyChangeSupport.PropertyHasChanged(FieldIdentifier, oldValue, newValue);
            }
            else
            {
                Tracer.Write("FieldBase", "SetValue", $"Not Changed, Field: {FieldIdentifier}, {oldValue}, {newValue}");
            }

            settingNewValue = false;
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

    protected virtual void OnMessagesChanged()
    {
        if (settingNewValue)
            return;

        var oldIsInvalid = IsInvalid;
        IsInvalid = messageListener?.Messages.HasErrors ?? false;
        if (oldIsInvalid != IsInvalid)
            StateHasChanged();
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

                messageListener = ModelContext.EditorMessages.CreateListener(FieldIdentifier, Name);
                messageListener.ListenChanges(messagesChangedDelegate);

                changeSupport = ModelContext.PropertyChangeSupport.GetChangeSupport(ChangeSupport ?? FieldIdentifier.FieldName);
                changeSupport.Initialize(FieldIdentifier, Value);
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
        messageListener?.Dispose();
        changeSupport?.Reset();

        Dispose(true);
    }

    protected virtual void Dispose(bool disposing) { }
}
