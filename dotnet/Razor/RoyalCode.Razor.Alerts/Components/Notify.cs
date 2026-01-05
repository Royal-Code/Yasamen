using RoyalCode.Razor.Internal.Notifications;
using RoyalCode.Razor.Styles;

namespace RoyalCode.Razor.Components;

/// <summary>
/// A service for displaying notifications.
/// </summary>
public class Notify
{
    private readonly NotificationService notificationService;

    /// <summary>
    /// Creates a new instance of the Notify service.
    /// </summary>
    /// <param name="notificationService"></param>
    public Notify(NotificationService notificationService)
    {
        this.notificationService = notificationService;
    }

    /// <summary>
    /// Shows a notification.
    /// </summary>
    /// <param name="notificationItem">The notification item to show.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task ShowAsync(NotificationItem notificationItem)
    {
        await notificationService.Add(notificationItem);
    }

    /// <summary>
    /// Shows a notification with the specified theme, text, and details.
    /// </summary>
    /// <param name="theme">The theme of the notification.</param>
    /// <param name="text">The main text of the notification.</param>
    /// <param name="details">Additional details for the notification.</param>
    /// <param name="configure">An optional action to configure the notification item.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public Task ShowAsync(Themes theme, string text, string? details = null, Action<NotificationItem>? configure = null)
    {
        int timerSeconds;

        if (details is null)
            timerSeconds = 8;
        else if (details.Length < 20)
            timerSeconds = 12;
        else
            timerSeconds = 8 + details.Length / 5;

        var notificationItem = new NotificationItem
        {
            Theme = theme,
            Text = text,
            Details = details,
            Timer = TimeSpan.FromSeconds(timerSeconds)
        };
        configure?.Invoke(notificationItem);
        return ShowAsync(notificationItem);
    }

    /// <summary>
    /// Shows a primary themed notification.
    /// </summary>
    /// <param name="text">The main text of the notification.</param>
    /// <param name="details">Additional details for the notification.</param>
    /// <param name="configure">An optional action to configure the notification item.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public Task Primary(string text, string? details = null, Action<NotificationItem>? configure = null)
    {
        return ShowAsync(Themes.Primary, text, details, configure);
    }

    /// <summary>
    /// Shows a secondary themed notification.
    /// </summary>
    /// <param name="text">The main text of the notification.</param>
    /// <param name="details">Additional details for the notification.</param>
    /// <param name="configure">An optional action to configure the notification item.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public Task Secondary(string text, string? details = null, Action<NotificationItem>? configure = null)
    {
        return ShowAsync(Themes.Secondary, text, details, configure);
    }

    /// <summary>
    /// Shows a tertiary themed notification.
    /// </summary>
    /// <param name="text">The main text of the notification.</param>
    /// <param name="details">Additional details for the notification.</param>
    /// <param name="configure">An optional action to configure the notification item.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public Task Tertiary(string text, string? details = null, Action<NotificationItem>? configure = null)
    {
        return ShowAsync(Themes.Tertiary, text, details, configure);
    }

    /// <summary>
    /// Shows an info themed notification.
    /// </summary>
    /// <param name="text">The main text of the notification.</param>
    /// <param name="details">Additional details for the notification.</param>
    /// <param name="configure">An optional action to configure the notification item.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public Task Info(string text, string? details = null, Action<NotificationItem>? configure = null)
    {
        return ShowAsync(Themes.Info, text, details, configure);
    }

    /// <summary>
    /// Shows a highlight themed notification.
    /// </summary>
    /// <param name="text">The main text of the notification.</param>
    /// <param name="details">Additional details for the notification.</param>
    /// <param name="configure">An optional action to configure the notification item.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public Task Highlight(string text, string? details = null, Action<NotificationItem>? configure = null)
    {
        return ShowAsync(Themes.Highlight, text, details, configure);
    }

    /// <summary>
    /// Shows a success themed notification.
    /// </summary>
    /// <param name="text">The main text of the notification.</param>
    /// <param name="details">Additional details for the notification.</param>
    /// <param name="configure">An optional action to configure the notification item.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public Task Success(string text, string? details = null, Action<NotificationItem>? configure = null)
    {
        return ShowAsync(Themes.Success, text, details, configure);
    }

    /// <summary>
    /// Shows a warning themed notification.
    /// </summary>
    /// <param name="text">The main text of the notification.</param>
    /// <param name="details">Additional details for the notification.</param>
    /// <param name="configure">An optional action to configure the notification item.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public Task Warning(string text, string? details = null, Action<NotificationItem>? configure = null)
    {
        return ShowAsync(Themes.Warning, text, details, configure);
    }

    /// <summary>
    /// Shows an alert themed notification.
    /// </summary>
    /// <param name="text">The main text of the notification.</param>
    /// <param name="details">Additional details for the notification.</param>
    /// <param name="configure">An optional action to configure the notification item.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public Task Alert(string text, string? details = null, Action<NotificationItem>? configure = null)
    {
        return ShowAsync(Themes.Alert, text, details, configure);
    }

    /// <summary>
    /// Shows a danger themed notification.
    /// </summary>
    /// <param name="text">The main text of the notification.</param>
    /// <param name="details">Additional details for the notification.</param>
    /// <param name="configure">An optional action to configure the notification item.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public Task Danger(string text, string? details = null, Action<NotificationItem>? configure = null)
    {
        return ShowAsync(Themes.Danger, text, details, configure);
    }

    /// <summary>
    /// Shows a light themed notification.
    /// </summary>
    /// <param name="text">The main text of the notification.</param>
    /// <param name="details">Additional details for the notification.</param>
    /// <param name="configure">An optional action to configure the notification item.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public Task Light(string text, string? details = null, Action<NotificationItem>? configure = null)
    {
        return ShowAsync(Themes.Light, text, details, configure);
    }

    /// <summary>
    /// Shows a dark themed notification.
    /// </summary>
    /// <param name="text">The main text of the notification.</param>
    /// <param name="details">Additional details for the notification.</param>
    /// <param name="configure">An optional action to configure the notification item.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public Task Dark(string text, string? details = null, Action<NotificationItem>? configure = null)
    {
        return ShowAsync(Themes.Dark, text, details, configure);
    }
}

