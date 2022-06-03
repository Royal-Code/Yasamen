using Microsoft.AspNetCore.Components;

namespace RoyalCode.Yasamen.Icons.Factory;

/// <summary>
/// Icon content factory.
/// </summary>
public interface IIconContentFactory
{
    /// <summary>
    /// Gets the RenderFragment of an icon's content.
    /// </summary>
    /// <param name="iconKind">Type of icon, informed in the component in which the icon will be rendered.</param>
    /// <param name="AdditionalClasses">Additional classes that must be included into the icon.</param>
    /// <param name="AdditionalAttributes">Additional html attributes for the icon.</param>
    /// <returns>A <see cref="RenderFragment"/> for rendering the icon.</returns>
    RenderFragment GetFragment(Enum iconKind, string? AdditionalClasses, Dictionary<string, object>? AdditionalAttributes);
}
