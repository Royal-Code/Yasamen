using Microsoft.AspNetCore.Components.Forms;

namespace RoyalCode.Yasamen.Forms.Support;

internal sealed class IncludeChangeSupport<TProperty, TIncludedProperty> : IIncludeChangeSupport
{
    private readonly ChangeSupport includedChangeSupport;
    private readonly Func<TProperty, TIncludedProperty> includedHandler;

    public IncludeChangeSupport(
        ChangeSupport includedChangeSupport,
        Func<TProperty, TIncludedProperty> includedHandler)
    {
        this.includedChangeSupport = includedChangeSupport;
        this.includedHandler = includedHandler;
    }

    public void Initialize<TValue>(FieldIdentifier identifier, TValue initialValue)
    {
        if (initialValue is not TProperty propertyInitialValue) 
            return;
        
        var includedInitialValue = includedHandler(propertyInitialValue);
        includedChangeSupport.Initialize(identifier, includedInitialValue);
    }

    public void Reset()
    {
        includedChangeSupport.Reset();
    }

    public void PropertyHasChanged<TValue>(FieldIdentifier field, TValue oldValue, TValue newValue)
    {
        if (typeof(TValue) != typeof(TProperty))
            return;

        TIncludedProperty? oldIncludedValue = default;
        TIncludedProperty? newIncludedValue = default;
        
        if (oldValue is not null && oldValue is TProperty propertyOldValue)
            oldIncludedValue = includedHandler(propertyOldValue);
        
        if (newValue is not null && newValue is TProperty propertyNewValue)
            newIncludedValue = includedHandler(propertyNewValue);

        includedChangeSupport.PropertyHasChanged(field, oldIncludedValue, newIncludedValue);
    }
}