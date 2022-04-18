using Microsoft.AspNetCore.Components.Forms;

namespace RoyalCode.Yasamen.Forms.Support;

/// <summary>
/// <para>
///     The <see cref="PropertyChangeSupport"/> serves to configure and manage the state-change
///     sharing between different components.
/// </para>
/// <para>
///     This class stores and manages several <see cref="ChangeSupport"/>,
///     through which the state change events of a component are sent to others who want to observe them.
/// </para>
/// </summary>
public class PropertyChangeSupport
{
    private readonly ChangeSupportCollection changeSupports = new();
    private Dictionary<string, object>? properties;
    private PropertyChangeSupport? parent;
    
    /// <summary>
    /// <para>
    ///     Gets a <see cref="ChangeSupport"/> for a given name.
    /// </para>
    /// <para>
    ///     The same instance is always returned for the same name.
    /// </para>
    /// </summary>
    /// <param name="name">Name of the support for change.</param>
    /// <returns>An instance of <see cref="ChangeSupport"/>.</returns>
    public ChangeSupport GetChangeSupport(string? name = null) => changeSupports.GetChangeSupport(name);
    
    /// <summary>
    /// <para>
    ///     Notifies observers/listeners that there has been a change of state of a property.
    /// </para>
    /// </summary>
    /// <typeparam name="TProperty">The changed property type.</typeparam>
    /// <param name="fieldIdentifier">Identifier of the changed property.</param>
    /// <param name="oldValue">Old property value.</param>
    /// <param name="newValue">New property value.</param>
    public void PropertyHasChanged<TProperty>(FieldIdentifier fieldIdentifier, TProperty oldValue, TProperty newValue)
    {
        foreach (var support in changeSupports.Filter<TProperty>(fieldIdentifier))
        {
            support.PropertyHasChanged(fieldIdentifier, oldValue, newValue);
        }
        
        parent?.PropertyHasChanged(fieldIdentifier, oldValue, newValue);
    }
    
    public PropertySupported<TValue> Property<TValue>(string name)
    {
        properties ??= new();
        if (properties.TryGetValue(name, out var obj))
        {
            if (obj is not PropertySupported<TValue> supported)
                throw new InvalidOperationException($"The property with name '{name}' has other type them ('{typeof(TValue).Name}')");

            return supported;
        }
        else
        {
            var supported = new PropertySupported<TValue>(this);
            properties.Add(name, supported);
            return supported;
        }
    }

    internal void SetParent(PropertyChangeSupport parent)
    {
        this.parent = parent;
        changeSupports.SetParentPropertyChangeSupport(parent);
    }

    // public override bool Equals(object? obj)
    // {
    //     return obj is PropertyChangeSupport support &&
    //            EqualityComparer<ChangeSupportCollection>.Default.Equals(changeSupports, support.changeSupports) &&
    //            EqualityComparer<Dictionary<string, object>?>.Default.Equals(properties, support.properties) &&
    //            EqualityComparer<PropertyChangeSupport?>.Default.Equals(parent, support.parent);
    // }
    //
    // public override int GetHashCode()
    // {
    //     return HashCode.Combine(changeSupports, properties, parent);
    // }
}