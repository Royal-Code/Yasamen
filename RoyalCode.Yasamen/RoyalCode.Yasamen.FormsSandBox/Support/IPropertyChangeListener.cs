using Microsoft.AspNetCore.Components.Forms;

namespace RoyalCode.Yasamen.Forms.Support;

/// <summary>
/// <para>
///     Used internally by <see cref="ChangeSupport"/> to manage the observers of state changes.
/// </para>
/// </summary>
public interface IPropertyChangeListener
{
    /// <summary>
    /// Notifies that the property has changed.
    /// </summary>
    /// <typeparam name="TProperty">The changed property type.</typeparam>
    /// <param name="fieldIdentifier">Identifier of the changed property.</param>
    /// <param name="oldValue">Old property value.</param>
    /// <param name="newValue">New property value.</param>
    void PropertyHasChanged<TProperty>(FieldIdentifier fieldIdentifier, TProperty oldValue, TProperty newValue);
}

/// <summary>
/// <para>
///     Used internally by <see cref="ChangeSupport"/> to manage the observers of state changes.
/// </para>
/// </summary>
/// <typeparam name="TProperty">The changed property type.</typeparam>
public interface IPropertyChangeListener<in TProperty> : IPropertyChangeListener
{
    /// <summary>
    /// Notifies that the property has changed.
    /// </summary>
    /// <param name="fieldIdentifier">Identifier of the changed property.</param>
    /// <param name="oldValue">Old property value.</param>
    /// <param name="newValue">New property value.</param>
    void PropertyHasChanged(FieldIdentifier fieldIdentifier, TProperty oldValue, TProperty newValue);
}