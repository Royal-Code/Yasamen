using Microsoft.AspNetCore.Components;
using RoyalCode.Razor.Styles;

namespace RoyalCode.Razor.Layouts;

/// <summary>
/// <para>
///     Represents a layout container component that organizes its child elements in a structured layout.
/// </para>
/// <para>
///     The layout can be configured to use different types (e.g., grid, flex) and sizes (e.g., default, fluid).
/// </para>
/// <para>
///     Define the layout type using the <see cref="Type"/> property with the enum <see cref="LayoutTypes"/>.
///     The default layout type is <see cref="LayoutTypes.Grid"/>.
/// </para>
/// <para>
///     Define the layout size using the <see cref="Size"/> property with the enum <see cref="LayoutSizes"/>.
///     The value <see cref="LayoutSizes.Default"/> can be used for layouts that adapt to all devices,
///     or specific sizes like <see cref="LayoutSizes.Tablet"/>, <see cref="LayoutSizes.Laptop"/>,
///     and <see cref="LayoutSizes.Desktop"/> for a defined number of columns (size).
/// </para>
/// <para>
///     The <see cref="Height"/> property can be used to set the height of child elements within the container.
///     Use <see cref="Col"/> components as children of the <see cref="Container"/> to create a responsive layout.
///     If the <see cref="Height"/> property is not set, it defaults to <see cref="SpacingSize.Medium"/>.
/// </para>
/// </summary>
public partial class Container
{
    /// <summary>
    /// The layout type. Default is <see cref="LayoutTypes.Grid"/>.
    /// </summary>
    [Parameter]
    public LayoutTypes Type { get; set; } = LayoutTypes.Grid;

    /// <summary>
    /// The layout size. Default is <see cref="LayoutSizes.Default"/>, which adapts to all devices.
    /// </summary>
    [Parameter]
    public LayoutSizes Size { get; set; } = LayoutSizes.Default;

    /// <summary>
    /// The height of child elements within the container. Default is <see cref="SpacingSize.Medium"/>.
    /// </summary>
    [Parameter]
    public SpacingSize? Height { get; set; }

    /// <summary>
    /// The content to be rendered inside the container. It typically includes <see cref="Col"/> components.
    /// </summary>
    [Parameter]
    public RenderFragment ChildContent { get; set; } = default!;

    /// <summary>
    /// Additional CSS classes to apply to the container for custom styling.
    /// </summary>
    [Parameter]
    public string? AdditionalClasses { get; set; }

    /// <summary>
    /// Additional attributes that will be applied to the container's outermost HTML element.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public IDictionary<string, object>? AdditionalAttributes { get; set; }

    /// <summary>
    /// A context object that provides layout configuration to child components.
    /// </summary>
    public sealed class ContainerContext
    {
        /// <summary>
        /// The container layout type.
        /// </summary>
        public LayoutTypes Type { get; set; }

        /// <summary>
        /// The container layout size.
        /// </summary>
        public LayoutSizes Sizes { get; set; }

        /// <summary>
        /// The height of child elements within the container.
        /// </summary>
        public SpacingSize? Height { get; set; }
    }
}
