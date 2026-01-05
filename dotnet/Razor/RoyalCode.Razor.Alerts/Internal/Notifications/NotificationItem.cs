using Microsoft.AspNetCore.Components;
using RoyalCode.Razor.Styles;

namespace RoyalCode.Razor.Internal.Notifications;

/// <summary>
/// A notification item, which represents a single notification to be displayed in the outlet.
/// </summary>
public class NotificationItem
{
    /// <summary>
    /// The theme of the notification.
    /// </summary>
    public Themes Theme { get; set; } = Themes.Default;

    /// <summary>
    /// The placement of the notification.
    /// </summary>
    public Placements Placement { get; set; } = Placements.TopEnd;

    /// <summary>
    /// The text of the notification.
    /// </summary>
    public required string Text { get; set; }

    /// <summary>
    /// Optional details for the notification.
    /// </summary>
    public string? Details { get; set; }

    /// <summary>
    /// Determines whether to show the icon for the notification.
    /// </summary>
    public bool Icon { get; set; } = true;

    /// <summary>
	/// A timer after which the notification will close automatically.
	/// </summary>
    public TimeSpan? Timer { get; set; }

    /// <summary>
    /// Close the notification when it is clicked.
    /// </summary>
    public bool CloseOnClick { get; set; } = false;

    /// <summary>
    /// Whether the notification can be closed manually. It will show a close button.
    /// </summary>
    public bool Closeable { get; set; } = true;

    /// <summary>
    /// Event callback triggered when the notification is closed.
    /// </summary>
    public EventCallback OnClose { get; set; }

    /// <summary>
    /// Event callback triggered when the notification is opened.
    /// </summary>
    public EventCallback OnOpen { get; set; }
}
