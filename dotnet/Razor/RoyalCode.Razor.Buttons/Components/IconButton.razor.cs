using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using RoyalCode.Razor.Animations;
using RoyalCode.Razor.Icons.Factory;
using RoyalCode.Razor.Styles;

namespace RoyalCode.Razor.Components;

public partial class IconButton
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
    public Enum Icon { get; set; } = null!;

    /// <summary>
    /// Optional animation fragment applied to the icon, enabling animated icon effects.
    /// </summary>
    [Parameter]
    public AnimationFragment? IconAnimation { get; set; }

    /// <summary>
    /// Optional icon fragment to render custom icon content within the button.
    /// </summary>
    [Parameter]
    public IconFragment? IconFragment { get; set; }

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

    protected override void OnParametersSet()
    {
        // Validate that either Icon or IconFragment is set, but not both.
        if (Icon is null && IconFragment is null)
        {
            throw new InvalidOperationException("IconButton requires either 'Icon' or 'IconFragment' to be set.");
        }
    }
}
