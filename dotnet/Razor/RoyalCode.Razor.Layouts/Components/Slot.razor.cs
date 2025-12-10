using Microsoft.AspNetCore.Components;
using RoyalCode.Razor.Styles;
using static RoyalCode.Razor.Components.Container;

namespace RoyalCode.Razor.Components;

/// <summary>
/// <para>
///     Represents a responsive slot component that adjusts its span and height based on screen size and configuration.
/// </para>
/// <para>
///     Use the <see cref="Slot"/> component as a child of the <see cref="Container"/> component to create a responsive layout.
/// </para>
/// </summary>
/// <remarks>
///     The <see cref="Slot"/> component allows specifying the number of columns (span) it occupies for different
///     screen sizes, as well as its height. 
///     <br />
///     The default span is 4 columns, and the default height is 8 units.
///     <br />    
///     Optional properties for specific screen sizes (e.g., <see cref="TabletSpan"/>, <see cref="LaptopSpan"/>,
///     <see cref="DesktopSpan"/>) can be used to override the default span for those screen sizes.
/// </remarks>
public partial class Slot
{
    private LayoutTypes type = LayoutTypes.Grid;
    private LayoutSizes size = LayoutSizes.Default;
    private SpacingSize height = SpacingSize.Medium;

    /// <summary>
    /// Number of columns the component will occupy. Default 4.
    /// </summary>
    [Parameter]
    public int Span { get; set; } = 4;

    /// <summary>
    /// Optional, number of columns the component will occupy on small screens. Default 0.
    /// </summary>
    [Parameter]
    public int TabletSpan { get; set; }

    /// <summary>
    /// Optional, number of columns the component will occupy on medium screens. Default 0.
    /// </summary>
    [Parameter]
    public int LaptopSpan { get; set; }

    /// <summary>
    /// Optional, number of columns the component will occupy on large screens. Default 0.
    /// </summary>
    [Parameter]
    public int DesktopSpan { get; set; }

    /// <summary>
    /// Component height. When not initialized, uses context height or Medium as default.
    /// </summary>
    [Parameter]
    public SpacingSize? Height { get; set; }

    /// <summary>
    /// Conteúdo interno.
    /// </summary>
    [Parameter]
    public RenderFragment ChildContent { get; set; } = default!;

    /// <summary>
    /// Classses de estilo passadas para o elemento mais externo do componente.
    /// </summary>
    [Parameter]
    public string? AdditionalClasses { get; set; }

    /// <summary>
    /// Gets or sets a collection of additional attributes that will be applied to the created element.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }

    /// <summary>
    /// Layout context.
    /// </summary>
    [CascadingParameter]
    private ContainerContext? Context { get; set; }

    /// <summary>
    /// Inicializes the component and sets the layout type, size and height based on the context.
    /// </summary>
    protected override void OnParametersSet()
    {
        if (Context is not null)
        {
            type = Context.Type;
            size = Context.Sizes;
            height = Height ?? Context.Height ?? SpacingSize.Medium;
        }

        base.OnParametersSet();
    }
}
