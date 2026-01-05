namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Extensions for adding the NotificationService to the service collection.
/// </summary>
public static class AlertServiceCollectionExtensions
{
    /// <summary>
    /// Adds the NotificationService to the service collection.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddYasamenNotification(this IServiceCollection services)
    {
        services.AddScoped<RoyalCode.Razor.Internal.Notifications.NotificationService>();
        services.AddScoped<RoyalCode.Razor.Components.Notify>();
        return services;
    }
}
