using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using RoyalCode.Razor.Icons.Factory;

namespace RoyalCode.Razor.Icons;

/// <summary>
/// Renders an icon based on the provided <see cref="Kind"/> enum value.
/// </summary>
public class Icon : ComponentBase
{
    private Enum? lastKind;
    private IconFragment? lastFragment;

    /// <summary>
    /// The kind of icon to render.
    /// </summary>
    /// <remarks>
    ///     Only one of <see cref="Kind"/> or <see cref="Fragment"/> should be set.
    /// </remarks>
    [Parameter]
    public Enum? Kind { get; set; }

    /// <summary>
    /// The icon fragment to render.
    /// </summary>
    /// <remarks>
    ///     Only one of <see cref="Kind"/> or <see cref="Fragment"/> should be set.
    /// </remarks>
    [Parameter]
    public IconFragment? Fragment { get; set; }

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
    /// Validates parameters to ensure only one of <see cref="Kind"/> or <see cref="Fragment"/> is set.
    /// </summary>
    /// <exception cref="InvalidOperationException"></exception>
    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        if (Kind != null && Fragment != null)
        {
            throw new InvalidOperationException("Cannot set both 'Kind' and 'Fragment' parameters. Please set only one.");
        }
    }

    /// <summary>
    /// Renders the icon based on the provided <see cref="Kind"/>.
    /// </summary>
    /// <param name="builder">The render tree builder.</param>
    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        IconFragment? iconFragment = null;
        if (Kind is not null)
        {
            if (lastKind != Kind)
            {
                lastKind = Kind;
                var factory = IconContentFactories.Get(Kind.GetType());
                lastFragment = factory.GetFragment(Kind);
            }
            iconFragment = lastFragment;
        }
        else if (Fragment != null)
        {
            iconFragment = Fragment;
        }

        iconFragment ??= WellKnownIcons.NoIconFragment;

        var renderFragment = iconFragment(AdditionalClasses, AdditionalAttributes);
        renderFragment(builder);
    }
}
