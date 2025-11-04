using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using RoyalCode.Razor.Animations;
using RoyalCode.Razor.Styles;

namespace RoyalCode.Razor.Components;

/// <summary>
/// <para>
///     Represents a reusable UI button component for Blazor applications.
/// </para>
/// </summary>
/// <remarks>
/// <para>
///     The <see cref="Button"/> component renders a styled HTML <c>&lt;button&gt;</c> element 
///     (or behaves like one) whose visual appearance and behavior are configured through its parameters.
/// </para>
/// <para>
///     It supports:
/// </para>
/// <list type="bullet">
///     <item><description>A required textual <see cref="Label"/> and optional <see cref="ChildContent"/> fragment.</description></item>
///     <item><description>Size, theme and outline variations via <see cref="Size"/>, <see cref="Style"/> and <see cref="Outline"/>.</description></item>
///     <item><description>Optional icon (with optional animation) shown before or after the label.</description></item>
///     <item><description>Disabled and active visual states.</description></item>
///     <item><description>Block display for full‑width layout.</description></item>
///     <item><description>Navigation support via <see cref="NavigateTo"/> (executed after <see cref="OnClick"/>).</description></item>
/// </list>
/// <para>
///     If <see cref="Disabled"/> is true, click handling and navigation are suppressed.
/// </para>
/// </remarks>
public partial class Button
{
    /// <summary>
    /// The Blazor navigation manager used to perform client-side navigation when <see cref="NavigateTo"/> is set.
    /// </summary>
    [Inject]
    private NavigationManager Navigator { get; set; } = null!;

    /// <summary>
    /// Gets a reference to the underlying HTML element. Set through the component markup via <c>@ref</c>.
    /// </summary>
    public ElementReference Reference { get; private set; }

    /// <summary>
    /// Required display text for the button when no <see cref="ChildContent"/> overrides the content.
    /// </summary>
    [Parameter, EditorRequired]
    public string Label { get; set; } = null!;

    /// <summary>
    /// Optional custom content replacing the default label output. Can include markup and other components.
    /// </summary>
    [Parameter]
    public RenderFragment ChildContent { get; set; } = null!;

    /// <summary>
    /// Specifies the semantic button type (<c>button</c>, <c>submit</c>, or <c>reset</c>).
    /// </summary>
    [Parameter]
    public ButtonTypes Type { get; set; }

    /// <summary>
    /// Visual theme style applied to the button (e.g., Primary, Secondary, Danger).
    /// </summary>
    [Parameter]
    public Themes Style { get; set; }

    /// <summary>
    /// Size variant applied to the button to control padding and font sizing.
    /// </summary>
    [Parameter]
    public Sizes Size { get; set; }

    /// <summary>
    /// Optional icon enumeration value to render an icon alongside the label/content.
    /// </summary>
    [Parameter]
    public Enum? Icon { get; set; }

    /// <summary>
    /// Optional animation fragment applied to the icon, enabling animated icon effects.
    /// </summary>
    [Parameter]
    public AnimationFragment? IconAnimation { get; set; }

    /// <summary>
    /// When true, renders the button using outline style rather than filled background.
    /// </summary>
    [Parameter]
    public bool Outline { get; set; }

    /// <summary>
    /// When true, makes the button span the full width of its container (block display).
    /// </summary>
    [Parameter]
    public bool Block { get; set; }

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
    /// When true, renders the icon after (to the right of) the label/content instead of before it.
    /// </summary>
    [Parameter]
    public bool UseIconAtEnd { get; set; }

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
    /// Optional relative or absolute URI to navigate to after a successful click (unless <see cref="Disabled"/>).
    /// </summary>
    [Parameter]
    public string? NavigateTo { get; set; }

    /// <summary>
    /// Callback invoked on user click before navigation occurs. Not invoked when <see cref="Disabled"/> is true.
    /// </summary>
    [Parameter]
    public EventCallback<MouseEventArgs> OnClick { get; set; }

    /// <summary>
    /// Internal click handler coordinating disabled state, custom click callback, and optional navigation.
    /// </summary>
    /// <param name="args">Mouse event arguments from the Blazor runtime.</param>
    private async Task ClickHandler(MouseEventArgs args)
    {
        if (Disabled)
            return;

        if (OnClick.HasDelegate)
            await OnClick.InvokeAsync(args);

        if (!string.IsNullOrEmpty(NavigateTo))
            Navigator.NavigateTo(NavigateTo);
    }
}