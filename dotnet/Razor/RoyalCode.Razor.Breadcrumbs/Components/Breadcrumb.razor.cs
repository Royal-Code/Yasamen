using Microsoft.AspNetCore.Components;

namespace RoyalCode.Razor.Components;

/// <summary>
/// The breadcrumb component.
/// </summary>
public partial class Breadcrumb
{
    /// <summary>
    /// <para>
    ///     A render fragment for the drop menu items.
    /// </para>
    /// <para>
    ///     When this parameter is set, a dropdown menu button will be rendered in the start of the breadcrumb.
    /// </para>
    /// </summary>
    [Parameter]
    public RenderFragment MenuItems { get; set; } = EmptyFragment.Delegate;

    /// <summary>
    /// The breadcrumb items.
    /// </summary>
    [Parameter]
    public RenderFragment Items { get; set; } = EmptyFragment.Delegate;

    /// <summary>
    /// Additional CSS class names appended to the generated button classes.
    /// </summary>
    [Parameter]
    public string? AdditionalClasses { get; set; }

    /// <summary>
	/// Gets or sets a collection of additional attributes that will be added to the generated a element.
	/// </summary>
	[Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }
}
