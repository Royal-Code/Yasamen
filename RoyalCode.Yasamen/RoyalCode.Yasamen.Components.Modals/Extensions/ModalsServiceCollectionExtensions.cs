using RoyalCode.Yasamen.Components.Internal;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Extensions for adding modals services to the <see cref="IServiceCollection"/>.
/// </summary>
public static class ModalsServiceCollectionExtensions
{
    /// <summary>
    /// Adds the <see cref="ModalService"/> to the <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services"></param>
    public static void AddYasamenModal(this IServiceCollection services)
    {
        services.AddScoped<ModalService>();
    }
}
