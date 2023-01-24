using RoyalCode.Yasamen.Services;
using RoyalCode.Yasamen.Services.Internal;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Extensions methods for <see cref="IServiceCollection"/>.
/// </summary>
public static class YasamenDataServiceCollectionExtensions
{

    public static void AddDataServices(this IServiceCollection services)
    {
        services.AddScoped<IDataServicesProvider, DataServicesProvider>();
        services.AddScoped(typeof(FinderPerformerService<,>));

    }
}