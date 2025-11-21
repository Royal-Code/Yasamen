using RoyalCode.Razor.Internal.OffCanvas;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Extensions for registering off-canvas services.
/// </summary>
public static class OffCanvasServiceCollectionExtensions
{
    /// <summary>
    /// Adds off-canvas services to the service collection.
    /// </summary>
    /// <param name="services">The service collection to add off-canvas services to.</param>
    /// <returns>The same instance of <paramref name="services"/> for chaining.</returns>
    public static IServiceCollection AddYasamenOffCanvas(this IServiceCollection services)
    {
        services.AddScoped<OffCanvasService>();
        return services;
    }
}
