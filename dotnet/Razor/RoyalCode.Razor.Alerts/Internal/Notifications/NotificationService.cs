using RoyalCode.Razor.Styles;

namespace RoyalCode.Razor.Internal.Notifications;

/// <summary>
/// A service for managing notifications.
/// </summary>
public class NotificationService
{
    private readonly Dictionary<Placements, List<NotificationItem>> notifications = [];

    /// <summary>
    /// A read-only dictionary of notifications grouped by their placements.
    /// </summary>
    public IReadOnlyDictionary<Placements, List<NotificationItem>> Notifications => notifications;

    internal NotificationOutlet? Outlet { get; set; }

    internal async Task Add(NotificationItem notificationItem)
    {
        if (notifications.TryGetValue(notificationItem.Placement, out List<NotificationItem>? value))
            if (notificationItem.Placement.IsBottom())
                value.Insert(0, notificationItem);
            else
                value.Add(notificationItem);
        else
            notifications[notificationItem.Placement] = [notificationItem];

        if (Outlet is not null)
            await Outlet.StateHasChangedAsync();
    }

    internal async Task Remove(NotificationItem notificationItem)
    {
        if (notifications.TryGetValue(notificationItem.Placement, out List<NotificationItem>? value))
            value.Remove(notificationItem);

        if (Outlet is not null)
            await Outlet.StateHasChangedAsync();
    }
}
