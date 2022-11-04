using Microsoft.Extensions.Options;
using RoyalCode.Yasamen.Demos.Wasm.BlazorShow;
using RoyalCode.Yasamen.Demos.Wasm.BlazorShow.Internal;
using System.Diagnostics.CodeAnalysis;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// <para>
///     Extensions for <see cref="IServiceCollection"/>.
/// </para>
/// </summary>
public static class BlazorShowServiceCollectionExtensions
{
    /// <summary>
    /// <para>
    ///     Add and configure the catalog of show componentes to the <see cref="IServiceCollection"/>.
    /// </para>
    /// </summary>
    /// <param name="services">The service collection</param>
    /// <param name="configureShowCatalog">Action to configure the show catalog.</param>
    /// <returns>
    ///     The same <paramref name="services"/> instance so that multiple calls can be chained.
    /// </returns>
    public static IServiceCollection AddBlazorShow(this IServiceCollection services,
        Action<ICatalogBuilder> configureShowCatalog)
    {
        if(!services.TryFindCatalog(out var catalog))
        {
            catalog = new Catalog();
            services.AddSingleton<ICatalog>(catalog);
            services.AddSingleton<ShowGroups>();
            services.AddSingleton(sp => sp.GetRequiredService<IOptions<BlazorShowOptions>>().Value);
        }

        var builder = new CatalogBuilder(catalog);
        configureShowCatalog(builder);

        return services;
    }
    
    private static bool TryFindCatalog(this IServiceCollection services, [NotNullWhen(true)] out Catalog? catalog)
    {
        var serviceDescriptor = services.FirstOrDefault(sd => sd.ServiceType == typeof(ICatalog));
        if (serviceDescriptor != null)
        {
            catalog = (Catalog)serviceDescriptor.ImplementationInstance!;
            return true;
        }
        else
        {
            catalog = null;
            return false;
        }
    }
}
