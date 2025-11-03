using Microsoft.AspNetCore.Components;
using RoyalCode.Razor.Icons.Factory;

namespace RoyalCode.Razor.Icons;

/// <summary>
/// Utility class for rendering icons.
/// </summary>
public static class IconRender
{
    /// <summary>
    /// Gets the RenderFragment for the specified icon kind.
    /// </summary>
    /// <param name="kind">The enum value representing the icon kind.</param>
    /// <param name="classes">Optional CSS classes to apply to the icon.</param>
    /// <param name="attrs">Optional additional attributes to apply to the icon.</param>
    /// <returns>The RenderFragment representing the icon.</returns>
    public static RenderFragment Fragment(Enum kind, string? classes = null, Dictionary<string, object>? attrs = null)
    {
        var factory = IconContentFactories.Get(kind.GetType());
        var iconFragment = factory.GetFragment(kind) ?? WellKnownIcons.NoIconFragment;
        var renderFragment = iconFragment(classes, attrs);
        return renderFragment;
    }
}
