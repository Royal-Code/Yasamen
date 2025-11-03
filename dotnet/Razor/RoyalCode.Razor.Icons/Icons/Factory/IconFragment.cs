using Microsoft.AspNetCore.Components;

namespace RoyalCode.Razor.Icons.Factory;

/// <summary>
/// Represents a method that generates a Blazor render fragment for an icon,
/// optionally applying additional CSS classes and HTML attributes.
/// </summary>
/// <param name="additionalClasses">
///     Optional CSS classes to append to the icon's class attribute.
///     May be null or empty if no extra classes are needed.
/// </param>
/// <param name="additionalAttributes">
///     An optional dictionary of additional HTML attributes to apply to the icon element.
///     Keys are attribute names and values are attribute values. 
///     May be null if no extra attributes are required.
/// </param>
/// <returns>
///     A RenderFragment that renders the icon with the specified classes and attributes.
/// </returns>
public delegate RenderFragment IconFragment(
    string? additionalClasses = null, 
    Dictionary<string, object>? additionalAttributes = null);
