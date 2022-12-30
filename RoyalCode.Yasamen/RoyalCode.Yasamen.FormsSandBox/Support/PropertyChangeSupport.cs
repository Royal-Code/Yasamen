using Microsoft.AspNetCore.Components.Forms;
using RoyalCode.Yasamen.Commons;

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
/// <para>
///     Each model that will be edited has a <see cref="ModelContext{TModel}"/> and, for each context,
///     there will be a <see cref="PropertyChangeSupport"/>.
///     If there are nested contexts, 
///     each nested context will have a model for editing and its <see cref="PropertyChangeSupport"/>.
///     Just as the hierarchy of contexts is controlled, so will the hierarchy of <see cref="PropertyChangeSupport"/>.
/// </para>
/// </summary>
public sealed class PropertyChangeSupport
{
    private readonly ChangeSupportCollection changeSupports;
    private Dictionary<string, object>? properties;
    private PropertyChangeSupport? parent;

    /// <summary>
    /// Creates new <see cref="PropertyChangeSupport"/> without parent.
    /// </summary>
    public PropertyChangeSupport() 
    {
        changeSupports = new();
    }

    /// <summary>
    /// Creates new <see cref="PropertyChangeSupport"/> with the parent.
    /// </summary>
    /// <param name="parent">The <see cref="PropertyChangeSupport"/> parent of this.</param>
    public PropertyChangeSupport(PropertyChangeSupport parent)
    {
        this.parent = parent;
        changeSupports = new(parent);
    }

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
        Tracer.Write<PropertyChangeSupport>("PropertyHasChanged", $"Begin Field: {fieldIdentifier.FieldName}");
        
        foreach (var support in changeSupports.Filter<TProperty>(fieldIdentifier))
        {
            support.PropertyHasChanged(fieldIdentifier, oldValue, newValue);
        }
        
        parent?.PropertyHasChanged(fieldIdentifier, oldValue, newValue);
        
        Tracer.Write<PropertyChangeSupport>("PropertyHasChanged", $"End Field: {fieldIdentifier.FieldName}");
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
}