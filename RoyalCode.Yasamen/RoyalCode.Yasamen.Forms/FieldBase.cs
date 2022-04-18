using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Linq.Expressions;
using System.Reflection;
using RoyalCode.Yasamen.Commons;
using RoyalCode.Yasamen.Commons.Extensions;
using RoyalCode.Yasamen.Forms.Support;

namespace RoyalCode.Yasamen.Forms;

public abstract class FieldBase<TValue> : InputBase<TValue>
{
    private static readonly Func<InputBase<TValue>, FieldIdentifier> getFieldIdentifier;
    
    static FieldBase()
    {
        var property = typeof(InputBase<TValue>)
            .GetTypeInfo()
            .GetDeclaredProperty(nameof(FieldIdentifier))!;

        var valueParameter = Expression.Parameter(typeof(InputBase<TValue>), "value");
        var memberAccess = Expression.MakeMemberAccess(valueParameter, property);

        getFieldIdentifier = Expression.Lambda<Func<InputBase<TValue>, FieldIdentifier>>(memberAccess, valueParameter)
            .Compile();
    }

    private readonly EventHandler<ValidationStateChangedEventArgs> validationHandler;
    
    private PropertyInfo? propertyInfo;
    private string? defaultDisplayName;
    private ChangeSupport? changeSupport;
    private bool settingFormattedCurrentValue;
    
    protected FieldBase()
    {
        validationHandler = OnValidationStateChangedHandler;
    }

    [Parameter]
    public string? ChangeSupport { get; set; }

    [CascadingParameter]
    public PropertyChangeSupport? PropertyChangedSupport { get; set; }

    [CascadingParameter]
    public IModelLoadingState? ModelLoadingState { get; set; }

    public bool IsInvalid { get; private set; }

    protected new string? CurrentValueAsString
    {
        get => base.CurrentValueAsString;
        set
        {
            if (settingFormattedCurrentValue)
            {
                return;
            }

            TValue? oldValue = Value;
            Tracer.Write("FieldBase", "SetValue", value ?? "null");
            
            base.CurrentValueAsString = value;
            var formattedValue = FormatValueAsString(CurrentValue);

            if (formattedValue != CurrentValueAsString)
            {
                settingFormattedCurrentValue = true;
                base.CurrentValueAsString = formattedValue;
                settingFormattedCurrentValue = false;
                
                Tracer.Write("FieldBase", "SetValue", "Value Formatted");
            }

            if (PropertyChangedSupport is not null && !EqualityComparer<TValue>.Default.Equals(oldValue, Value))
            {
                Tracer.Write("FieldBase", "SetValue", $"PropertyChanged, Field: {FieldIdentifier}, {oldValue}, {Value}");
                PropertyChangedSupport.PropertyHasChanged(FieldIdentifier, oldValue, Value);
            }
        }
    }

    public new FieldIdentifier FieldIdentifier => getFieldIdentifier(this);

    protected PropertyInfo FieldPropertyInfo
    {
        get
        {
            if (propertyInfo is not null)
                return propertyInfo;
            
            var fieldId = FieldIdentifier;
            return fieldId.Model.GetType().GetProperty(fieldId.FieldName)!;
        }
    }

    internal string DefaultDisplayName => defaultDisplayName ??= FieldPropertyInfo.GetDefaultDisplayName();

    private void OnValidationStateChangedHandler(object? sender, EventArgs eventArgs)
    {
        IsInvalid = EditContext.GetValidationMessages(FieldIdentifier).Any();
        StateHasChanged();
    }

    protected override void OnInitialized()
    {
        Tracer.Write("FieldBase", "OnInitialized", "Begin");
        
        base.OnInitialized();

        EditContext.OnValidationStateChanged += validationHandler;

        if (ChangeSupport is not null && PropertyChangedSupport is not null)
        {
            changeSupport = PropertyChangedSupport.GetChangeSupport(ChangeSupport);
            changeSupport.Initialize(FieldIdentifier, Value);
        }
        
        Tracer.Write("FieldBase", "OnInitialized", "End");
    }
    
    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        IsInvalid = EditContext.GetValidationMessages(FieldIdentifier).Any();
    }

    protected override void Dispose(bool disposing)
    {
        Tracer.Write("FieldBase", "Dispose", "Begin");
        
        EditContext.OnValidationStateChanged -= validationHandler;
        changeSupport?.Reset();
        base.Dispose(disposing);
        
        Tracer.Write("FieldBase", "Dispose", "End");
    }
}
