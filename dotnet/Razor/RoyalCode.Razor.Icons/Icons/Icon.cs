using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using RoyalCode.Razor.Icons.Factory;

namespace RoyalCode.Razor.Icons;

/// <summary>
/// Renders an icon based on the provided <see cref="Kind"/> enum value.
/// </summary>
public class Icon : ComponentBase
{
    /// <summary>
    /// The kind of icon to render.
    /// </summary>
    [Parameter, EditorRequired]
    public Enum Kind { get; set; }

    /// <summary>
    /// Additional CSS classes to apply to the icon.
    /// </summary>
    [Parameter]
    public string? AdditionalClasses { get; set; }

    /// <summary>
    /// Additional attributes to be splatted onto the underlying SVG element.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object>? AdditionalAttributes { get; set; }

    /// <summary>
    /// Renders the icon based on the provided <see cref="Kind"/>.
    /// </summary>
    /// <param name="builder">The render tree builder.</param>
    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        IconFragment? iconFragment = null;
        if (Kind is not null)
        {
            var factory = IconContentFactories.Get(Kind.GetType());
            iconFragment = factory.GetFragment(Kind); // returns IconFragment delegate
        }
        iconFragment ??= WellKnownIcons.NoIconFragment;

        var renderFragment = iconFragment(AdditionalClasses, AdditionalAttributes);
        renderFragment(builder);
    }
}
