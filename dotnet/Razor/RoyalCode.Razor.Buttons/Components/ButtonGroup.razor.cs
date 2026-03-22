using Microsoft.AspNetCore.Components;
using RoyalCode.Razor.Commons.Extensions;
using RoyalCode.Razor.Internal.Buttons;
using RoyalCode.Razor.Styles;

namespace RoyalCode.Razor.Components;

/// <summary>
/// Groups related <see cref="Button"/> and <see cref="IconButton"/> instances with shared defaults.
/// </summary>
public partial class ButtonGroup
{
    private string? additionalAttributeClasses;
    private string? effectiveAriaLabel;
    private Dictionary<string, object>? unmatchedAttributes;

    private ButtonGroupContext GroupContext => new()
    {
        Style = Style,
        Size = Size,
        Disabled = Disabled,
    };

    private string Classes => "ya-btn-group"
        .AddClass(Orientation == ButtonGroupOrientation.Horizontal, "ya-btn-group-horizontal", "ya-btn-group-vertical")
        .AddClass(Disabled, "ya-btn-group-disabled")
        .AddClass(additionalAttributeClasses)
        .AddClass(AdditionalClasses);

    private string? EffectiveAriaLabel => effectiveAriaLabel;

    private Dictionary<string, object>? UnmatchedAttributes => unmatchedAttributes;

    /// <summary>
    /// Buttons rendered inside the group.
    /// </summary>
    [Parameter, EditorRequired]
    public RenderFragment ChildContent { get; set; } = null!;

    /// <summary>
    /// Defines whether the grouped buttons are laid out horizontally or vertically.
    /// </summary>
    [Parameter]
    public ButtonGroupOrientation Orientation { get; set; }

    /// <summary>
    /// Default theme inherited by child buttons that keep <see cref="Themes.Default"/>.
    /// </summary>
    [Parameter]
    public Themes Style { get; set; }

    /// <summary>
    /// Default size inherited by child buttons that keep <see cref="Sizes.Default"/>.
    /// </summary>
    [Parameter]
    public Sizes Size { get; set; }

    /// <summary>
    /// Disables every supported child button in the group.
    /// </summary>
    [Parameter]
    public bool Disabled { get; set; }

    /// <summary>
    /// Accessible name for the group.
    /// </summary>
    [Parameter]
    public string? AriaLabel { get; set; }

    /// <summary>
    /// Additional CSS class names appended to the root group element.
    /// </summary>
    [Parameter]
    public string? AdditionalClasses { get; set; }

    /// <summary>
    /// Captures unmatched HTML attributes and applies them to the root group element.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object>? AdditionalAttributes { get; set; }

    /// <inheritdoc />
    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        var clonedAttributes = AdditionalAttributes is null
            ? null
            : new Dictionary<string, object>(AdditionalAttributes);

        additionalAttributeClasses = clonedAttributes.ExtractClass();

        var ariaLabel = AriaLabel.IsPresent()
            ? AriaLabel
            : clonedAttributes.Extract("aria-label", string.Empty);

        effectiveAriaLabel = ariaLabel.IsPresent() ? ariaLabel : null;
        unmatchedAttributes = clonedAttributes is { Count: > 0 } ? clonedAttributes : null;
    }
}
