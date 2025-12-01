using Microsoft.AspNetCore.Components;
using RoyalCode.Razor.Animations;
using RoyalCode.Razor.Styles;

namespace RoyalCode.Razor.Components;

/// <summary>
/// Component that combines a button with a drop-down menu functionality.
/// </summary>
public partial class DropButton
{
    #region Button Properties

    /// <summary>
    /// Required display text for the button when no <see cref="ButtonContent"/> overrides the content.
    /// </summary>
    [Parameter]
    public string Label { get; set; } = null!;

    /// <summary>
    /// Optional custom content replacing the default label output. Can include markup and other components.
    /// </summary>
    [Parameter]
    public RenderFragment ButtonContent { get; set; } = null!;

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
    /// Additional CSS class names appended to the generated button classes.
    /// </summary>
    [Parameter]
    public string? ButtonAdditionalClasses { get; set; }

    #endregion

    #region Drop Properties

    /// <summary>
    /// The drop handler.
    /// </summary>
    [Parameter]
    public DropHandler? Handler { get; set; }

    /// <summary>
	/// Drop direction.
    /// </summary>
    [Parameter]
    public Directions Direction { get; set; } = Directions.Down;

    /// <summary>
	/// Drop alignment.
    /// </summary>
    [Parameter]
    public Positions Align { get; set; } = Positions.Start;

    /// <summary>
    /// Largura mínima para o menu do drop.
    /// </summary>
    [Parameter]
    public Sizes? MinWidth { get; set; }

    /// <summary>
    /// Tipo do conteúdo do menu, lista ou não definido.
    /// </summary>
    [Parameter]
    public DropContentType ContentType { get; set; }

    /// <summary>
    /// Comportamento de fechamento do menu.
    /// </summary>
    [Parameter]
    public DropCloseBehavior CloseBehavior { get; set; }

    /// <summary>
    /// Atributo <c>title</c> do elemento de dropdown.
    /// </summary>
    [Parameter]
    public string? Title { get; set; }

    /// <summary>
    /// Triggered when the drop is opened.
    /// </summary>
    [Parameter]
    public EventCallback<DropEventArgs> OnOpened { get; set; }

    /// <summary>
    /// Triggered when the drop is closed.
    /// </summary>
    [Parameter]
    public EventCallback<DropEventArgs> OnClosed { get; set; }

    /// <summary>
    /// Drop additional CSS classes.
    /// </summary>
    [Parameter]
    public string? DropAdditionalClasses { get; set; }

    #endregion

    /// <summary>
    /// The menu of the drop component.
    /// </summary>
    [Parameter]
    public RenderFragment ChildContent { get; set; }

    /// <summary>
    /// The menu of the drop component.
    /// </summary>
    [Parameter]
    public RenderFragment DropMenu 
    {
        get => ChildContent;
        set => ChildContent = value;
    }

    /// <summary>
    /// When true, displays a loading indicator on the button.
    /// </summary>
    [Parameter]
    public bool Loading { get; set; }

    /// <summary>
    /// Captures unmatched HTML attributes and applies them to the root button element (e.g., data-* attributes).
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object>? AdditionalAttributes { get; set; }
}
