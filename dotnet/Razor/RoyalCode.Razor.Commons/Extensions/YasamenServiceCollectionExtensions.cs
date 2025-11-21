using RoyalCode.Razor.Commons.Modules;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Extension methods for adding Yasamen services to the service collection.
/// </summary>
public static class YasamenServiceCollectionExtensions
{
    /// <summary>
    /// Adds Yasamen common services to the service collection.
    /// </summary>
    /// <param name="services">The service collection to add the services to.</param>
    /// <returns>The same instance of <paramref name="services"/> for chaining.</returns>
    public static IServiceCollection AddYasamenCommons(this IServiceCollection services)
    {
        services.AddTransient<RippleJs>();
        services.AddTransient<ElementJs>();

        return services;
    }
}
