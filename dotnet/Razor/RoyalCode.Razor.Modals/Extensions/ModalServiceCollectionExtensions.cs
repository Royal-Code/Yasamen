using RoyalCode.Razor.Internal.Modals;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Extensions for registering modal services.
/// </summary>
public static class ModalServiceCollectionExtensions
{
    /// <summary>
    /// Adds modal services to the service collection.
    /// </summary>
    /// <param name="services">The service collection to add modal services to.</param>
    /// <returns>The same instance of <paramref name="services"/> for chaining.</returns>
    public static IServiceCollection AddYasamenModal(this IServiceCollection services)
    {
        services.AddScoped<ModalService>();
        return services;
    }
}
