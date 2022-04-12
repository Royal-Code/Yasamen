using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Linq.Expressions;
using System.Reflection;


namespace RoyalCode.Yasamen.Forms;

public abstract class FormFieldBase<TValue> : InputBase<TValue>
{
    private static readonly Func<InputBase<TValue>, FieldIdentifier> getFieldIdentifier;
    
    static FormFieldBase()
    {
        var property = typeof(InputBase<TValue>)
            .GetTypeInfo()
            .GetDeclaredProperty(nameof(FieldIdentifier))!;

        var valueParameter = Expression.Parameter(typeof(InputBase<TValue>), "value");
        var memberAccess = Expression.MakeMemberAccess(valueParameter, property);

        getFieldIdentifier = Expression.Lambda<Func<InputBase<TValue>, FieldIdentifier>>(memberAccess, valueParameter)
            .Compile();
    }

    private EventHandler<ValidationStateChangedEventArgs> validationHandler;
    private PropertyInfo? propertyInfo;
    private string? defaultDisplayName;
    private bool settingFormattedCurrentValue;
    private PropertyChangedSupport propertyChangedSupport;

    public FormFieldBase()
    {
        validationHandler = OnValidationStateChangedHandler;
    }

    [Parameter]
    public string? ChangeSupport { get; set; }

    [CascadingParameter]
    public PropertyChangedSupport? PropertyChangedSupport { get; set; }

    //[CascadingParameter]
    //public ISharedFieldState SharedFieldState { get; set; }

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

            base.CurrentValueAsString = value;
            var formattedValue = FormatValueAsString(CurrentValue);

            if (formattedValue != CurrentValueAsString)
            {
                settingFormattedCurrentValue = true;
                base.CurrentValueAsString = formattedValue;
                settingFormattedCurrentValue = false;
            }

            if (propertyChangedSupport is not null && !EqualityComparer<TValue>.Default.Equals(oldValue, Value))
            {
                Console.WriteLine($"PropertyChanged, Field: {FieldIdentifier}, {oldValue}, {Value}");
                propertyChangedSupport.PropertyHasChanged(FieldIdentifier, oldValue, Value);
            }
        }
    }

    public new FieldIdentifier FieldIdentifier => getFieldIdentifier(this);

    public PropertyInfo FieldPropertyInfo
    {
        get
        {
            if (propertyInfo is null)
            {
                var fieldId = FieldIdentifier;
                propertyInfo = fieldId.Model.GetType().GetProperty(fieldId.FieldName)!;
            }
            return propertyInfo;
        }
    }

    internal string DefaultDisplayName => defaultDisplayName ??= FieldPropertyInfo.GetDefaultDisplayName();

    private void OnValidationStateChangedHandler(object? sender, EventArgs eventArgs)
    {
        IsInvalid = EditContext.GetValidationMessages(FieldIdentifier).Any();
        StateHasChanged();
    }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        EditContext.OnValidationStateChanged += validationHandler;

        IsInvalid = EditContext.GetValidationMessages(FieldIdentifier).Any();

        propertyChangedSupport = EditContext.TryGetItem<PropertyChangedSupport>();

        if (propertyChangedSupport is not null)
        {
            propertyChangedHandler = propertyChangedSupport.On<TValue>(FieldIdentifier).Handle(PropertyChangedHandler);
        }
    }

    protected override void Dispose(bool disposing)
    {
        EditContext.OnValidationStateChanged -= validationHandler;

        base.Dispose(disposing);
    }
}
