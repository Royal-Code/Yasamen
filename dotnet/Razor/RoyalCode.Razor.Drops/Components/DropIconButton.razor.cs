using Microsoft.AspNetCore.Components;
using RoyalCode.Razor.Animations;
using RoyalCode.Razor.Icons.Factory;
using RoyalCode.Razor.Styles;

namespace RoyalCode.Razor.Components;

/// <summary>
/// Componente de botão com ícone e dropdown.
/// </summary>
public partial class DropIconButton
{
    #region Icon Properties

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
    /// IconButton additional CSS classes.
    /// </summary>
    [Parameter]
    public string? IconAdditionalClasses { get; set; }

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
    public Directions Direction { get; set; }

    /// <summary>
	/// Drop alignment.
    /// </summary>
    [Parameter]
    public Positions Align { get; set; }

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
    /// Conteúdo interno.
    /// </summary>
    [Parameter]
    public RenderFragment ChildContent { get; set; } = default!;

    /// <summary>
    /// Se se deve renderizar um efeito de carregando no lugar do ícone.
    /// </summary>
    [Parameter]
    public bool Loading { get; set; }

    /// <summary>
    /// Captures unmatched HTML attributes and applies them to the root button element (e.g., data-* attributes).
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object>? AdditionalAttributes { get; set; }
}
