using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using RoyalCode.Razor.Styles;

namespace RoyalCode.Razor.Components;

public partial class FieldAction
{
    /// <summary>
    /// Required display text for the button when no <see cref="ChildContent"/> overrides the content.
    /// </summary>
    [Parameter]
    public string Label { get; set; } = null!;

    /// <summary>
    /// Optional custom content replacing the default label output. Can include markup and other components.
    /// </summary>
    [Parameter]
    public RenderFragment ChildContent { get; set; } = null!;

    /// <summary>
    /// Visual theme style applied to the button (e.g., Primary, Secondary, Danger).
    /// </summary>
    [Parameter]
    public Themes Style { get; set; } = Themes.Tertiary;

    /// <summary>
    /// Optional icon enumeration value to render an icon alongside the label/content.
    /// </summary>
    [Parameter]
    public Enum? Icon { get; set; }

    /// <summary>
    /// <para>
    ///     The position of the icon relative to the label/content (before or after).
    /// </para>
    /// <para>
    ///     The <see cref="Positions.Center"/> value is not valid for this parameter and will default to <see cref="Positions.Start"/>.
    /// </para>
    /// </summary>
    [Parameter]
    public Positions IconPosition { get; set; }

    /// <summary>
    /// When true, renders the button using outline style rather than filled background.
    /// </summary>
    [Parameter]
    public bool Outline { get; set; }

    /// <summary>
    /// Indicates an active visual state (typically highlighted) for the button.
    /// </summary>
    [Parameter]
    public bool Active { get; set; }

    /// <summary>
    /// Disables the button, preventing click events and navigation when true.
    /// </summary>
    [Parameter]
    public bool Disabled { get; set; }

    /// <summary>
    /// Additional CSS class names appended to the generated button classes.
    /// </summary>
    [Parameter]
    public string? AdditionalClasses { get; set; }

    /// <summary>
    /// Captures unmatched HTML attributes and applies them to the root button element (e.g., data-* attributes).
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object>? AdditionalAttributes { get; set; }

    /// <summary>
    /// Callback invoked on user click before navigation occurs. Not invoked when <see cref="Disabled"/> is true.
    /// </summary>
    [Parameter]
    public EventCallback<MouseEventArgs> OnClick { get; set; }
}
