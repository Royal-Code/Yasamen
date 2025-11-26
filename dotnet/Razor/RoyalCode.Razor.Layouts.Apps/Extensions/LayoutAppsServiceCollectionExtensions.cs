using Microsoft.Extensions.Options;
using RoyalCode.Razor.Layouts.Models;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Extension methods for registering layout apps services in an <see cref="IServiceCollection"/>.
/// </summary>
public static class LayoutAppsServiceCollectionExtensions
{
    /// <summary>
    /// Adds the Yasamen menu services to the service collection.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The same instance of <paramref name="services"/> for chaining.</returns>
    public static IServiceCollection AddYasamenMenu(this IServiceCollection services)
    {
        // configure and register MenuOptions
        services.AddOptions<MenuOptions>().BindConfiguration("Menu");

        // register MenuLoader and configure the HttpClient
        services.AddHttpClient("menu-loader")
            .AuthorizeWithAuthenticationState()
            .AddTypedClient<IMenuLoader>((client, sp) =>
            {
                var options = sp.GetRequiredService<IOptions<MenuOptions>>();
                return new HttpMenuLoader(client, options.Value);
            });

        services.AddScoped<MenuService>();
        return services;
    }

    /// <summary>
    /// Configures a custom deserializer for the Yasamen menu.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="deserializer">The deserializer function.</param>
    /// <returns>The same instance of <paramref name="services"/> for chaining.</returns>
    public static IServiceCollection ConfigureYasamenMenuDeserializer(this IServiceCollection services,
        Func<HttpResponseMessage, IEnumerable<MenuItem>> deserializer)
    {
        services.Configure<MenuOptions>(options =>
        {
            options.Deserializer = deserializer;
        });
        return services;
    }

    public static IServiceCollection ConfigureMenuItems(this IServiceCollection services,
        params MenuItem[] menuItems)
    {
        ArgumentNullException.ThrowIfNull(menuItems);

        services.Configure<MenuOptions>(options =>
        {
            for (int i = 0; i < menuItems.Length; i++)
            {
                options.MenuItems.Add(menuItems[i]);
            }
        });

        return services;
    }
}
