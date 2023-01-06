using System.Linq.Expressions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using RoyalCode.Yasamen.Commons;
using RoyalCode.Yasamen.Forms.Support;

namespace RoyalCode.Yasamen.Forms;

public sealed class PropertySupport<TValue> : ComponentBase, IDisposable
{
    private TValue? value;
    private bool initialized;
    private FieldIdentifier fieldIdentifier;
    private PropertySupported<TValue> propertySupported = null!;
    private ChangeSupport changeSupport = null!;

    // TODO: Futuramente é necessário estudar o uso desse componente.
    // TODO: Se for mantido a existência, será necessário ver os usos,
    // TODO: pois o value deve ser um auto-property.
    [Parameter]
    public TValue? Value 
    { 
        get => value;
        set => SetValue(value);
    }

    [Parameter]
    public EventCallback<TValue>? ValueChanged { get; set; }

    [Parameter]
    public Expression<Func<TValue>>? ValueExpression { get; set; }
    
    [Parameter]
    public string Name { get; set; } = null!;
    
    [Parameter, EditorRequired]
    public string ChangeSupport { get; set; } = null!;

    [CascadingParameter] 
    public IModelContext ModelContext { get; set; } = null!;
    
    internal void SetValue(TValue? value)
    {
        Tracer.Write("PropertySupport", "SetValue", "Begin");
        
        var old = this.value;
        this.value = value;
        if (initialized && !EqualityComparer<TValue>.Default.Equals(old, this.value))
        {
            Tracer.Write("PropertySupport", "SetValue", $"Value has changed, Field: {fieldIdentifier.FieldName}");

            ModelContext.PropertyChangeSupport.PropertyHasChanged<TValue>(fieldIdentifier, old, this.value);
            var task = ValueChanged?.InvokeAsync((TValue?)this.value);
            if (task is not null && !task.IsCompleted)
                task.GetAwaiter().GetResult();

            StateHasChanged();
        }
        
        Tracer.Write("PropertySupport", "SetValue", "End");
    }
    
    protected override void OnInitialized()
    {
        Tracer.Write("PropertySupport", "OnInitialized", "Begin");
        
        if (ModelContext is null)
            throw new InvalidOperationException($"{GetType()} requires a cascading parameter of type IModelContext." + 
                " For example, you can use " + GetType().FullName + " inside a ModelEditor.");
        
        if (string.IsNullOrWhiteSpace(ChangeSupport))
            throw new ArgumentNullException(nameof(ChangeSupport));

        if (string.IsNullOrWhiteSpace(Name))
        {
            if (ValueExpression is null)
                throw new InvalidOperationException($"{GetType()} requires the parameter 'Name' or 'ValueExpression'." +
                    "For example, you can bind the property 'Value' or set the property 'Name'.");
            
            fieldIdentifier = FieldIdentifier.Create(ValueExpression);
            propertySupported = ModelContext.PropertyChangeSupport.Property<TValue>(fieldIdentifier.FieldName);
            Name = fieldIdentifier.FieldName;
        }
        else
        {
            propertySupported = ModelContext.PropertyChangeSupport.Property<TValue>(Name);
            fieldIdentifier = new FieldIdentifier(propertySupported, "Value");
        }

        propertySupported.Initialize(this);
        changeSupport = ModelContext.PropertyChangeSupport.GetChangeSupport(ChangeSupport);
        changeSupport.Initialize(fieldIdentifier, value);
            
        initialized = true;
        base.OnInitialized();
        
        Tracer.Write("PropertySupport", "OnInitialized", "End");
    }

    public void Dispose()
    {
        Tracer.Write("PropertySupport", "Dispose", "Begin");
        
        propertySupported.Reset();
        changeSupport.Reset();
        
        Tracer.Write("PropertySupport", "Dispose", "End");
    }
}