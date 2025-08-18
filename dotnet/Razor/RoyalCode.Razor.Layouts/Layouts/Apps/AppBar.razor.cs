using Microsoft.AspNetCore.Components;
using RoyalCode.Razor.Styles;

namespace RoyalCode.Razor.Layouts.Apps;

public partial class AppBar
{
    /// <summary>
    /// The height of the app bar. Defaults to LargerX2 (48px).
    /// </summary>
    [Parameter]
    public SpacingSize Size { get; set; } = SpacingSize.LargerX2;

    /// <summary>
    /// The content to be rendered inside the container at the start section.
    /// </summary>
    [Parameter]
    public RenderFragment StartContent { get; set; } = EmptyFragment.Delegate;

    /// <summary>
    /// The content to be rendered inside the container at the center section.
    /// </summary>
    [Parameter]
    public RenderFragment CenterContent { get; set; } = EmptyFragment.Delegate;

    /// <summary>
    /// The content to be rendered inside the container at the end section.
    /// </summary>
    [Parameter]
    public RenderFragment EndContent { get; set; } = EmptyFragment.Delegate;

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
}
