using Microsoft.AspNetCore.Components.Forms;

namespace RoyalCode.Yasamen.Forms.Support;

/// <summary>
/// Delegate to observe/listen to changes in form field properties.
/// </summary>
/// <typeparam name="TProperty">Property type.</typeparam>
/// <param name="field">Identifier of the changed property.</param>
/// <param name="oldValue">Old property value.</param>
/// <param name="newValue">New property value.</param>
public delegate void PropertyChangedHandler<in TProperty>(FieldIdentifier field, TProperty? oldValue, TProperty? newValue);

/// <summary>
/// Delegate to observe/listen to changes in form field properties.
/// </summary>
/// <typeparam name="TProperty">Property type.</typeparam>
/// <param name="model">Model that generated the event.</param>
/// <param name="newValue">New property value.</param>
public delegate void PropertyChangedModelValueHandler<in TProperty>(object model, TProperty? newValue);

/// <summary>
/// Delegate to observe/listen to changes in form field properties.
/// </summary>
/// <typeparam name="TProperty">Property type.</typeparam>
/// <param name="newValue">New property value.</param>
public delegate void PropertyChangedValueHandler<in TProperty>(TProperty? newValue);

/// <summary>
/// Delegate to observe/listen to changes in form field properties.
/// </summary>
/// <param name="field">Identifier of the changed property.</param>
/// <param name="oldValue">Old property value.</param>
/// <param name="newValue">New property value.</param>
public delegate void AnyPropertyChangedHandler(FieldIdentifier field, object? oldValue, object? newValue);

/// <summary>
/// Delegate to observe/listen to changes in form field properties.
/// </summary>
public delegate void PropertyChangedHandler();