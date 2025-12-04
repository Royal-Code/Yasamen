using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace RoyalCode.Razor.Components;

/// <summary>
/// <para>
///     Description of a breadcrumb item.
/// </para>
/// </summary>
public class BreadcrumbDescription
{
    private Func<BreadcrumbDescription, Task>? currentClickHandler;

    /// <summary>
    /// Creates a new instance of <see cref="BreadcrumbDescription"/>.
    /// </summary>
    public BreadcrumbDescription()
    {
        MouseCallback = EventCallback.Factory.Create<MouseEventArgs>(this, async (e) =>
        {
            if (currentClickHandler != null)
            {
                await currentClickHandler(this);
            }
        });
    }

    /// <summary>
    /// Description text.
    /// </summary>
    public required string Description { get; init; }

    /// <summary>
    /// Link, URL. Optional. When set, the breadcrumb item will redirect to this link when clicked.
    /// </summary>
    public string? HRef { get; init; }

    /// <summary>
    /// A state object that will be passed to the callback handler when the breadcrumb item is clicked.
    /// </summary>
    public object? State { get; set; }


    internal EventCallback<MouseEventArgs> MouseCallback { get; }

    internal void SetClickHandler(Func<BreadcrumbDescription, Task> clickHandler)
    {
        currentClickHandler = clickHandler;
    }
}
