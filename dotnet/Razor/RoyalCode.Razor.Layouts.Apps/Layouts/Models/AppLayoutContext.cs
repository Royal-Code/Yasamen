using Microsoft.AspNetCore.Components;
using RoyalCode.Razor.Commons.Layout;
using RoyalCode.Razor.Layouts.Apps;
using RoyalCode.Razor.Styles;

namespace RoyalCode.Razor.Layouts.Models;

/// <summary>
/// Layout context for App Layouts, see more <see cref="ILayoutContext"/>.
/// Used to provide layout size and references to layout parts.
/// The <see cref="AppLayout"/> component will populate this context and cascade it to its children.
/// </summary>
public sealed class AppLayoutContext : ILayoutContext
{
    /// <inheritdoc />
    public SpacingSize? TopSize { get; internal set; }
    
    /// <inheritdoc />
    public SpacingSize? FooterSize { get; internal set; }
    
    /// <inheritdoc />
    public SpacingSize? LeftMenuSize { get; internal set; }

    /// <inheritdoc />
    public SpacingSize? RightMenuSize { get; internal set; }

    /// <inheritdoc />
    public ElementReference LayoutReference { get; internal set; }

    /// <inheritdoc />
    public ElementReference HeaderReference { get; internal set; }

    /// <inheritdoc />
    public ElementReference MainReference { get; internal set; }

    /// <inheritdoc />
    public ElementReference FooterReference { get; internal set; }

    /// <inheritdoc />
    public ElementReference LeftMenuReference { get; internal set; }

    /// <inheritdoc />
    public ElementReference RightMenuReference { get; internal set; }
}
