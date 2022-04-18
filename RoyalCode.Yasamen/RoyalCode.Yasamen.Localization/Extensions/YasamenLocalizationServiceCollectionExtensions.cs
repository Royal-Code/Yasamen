using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Localization;
using RoyalCode.Yasamen.Localization;

namespace Microsoft.Extensions.DependencyInjection;

public static class YasamenLocalizationServiceCollectionExtensions
{
    public static void AddYasamenLocalization(this IServiceCollection services)
    {
        services.TryAddTransient(sp => sp.GetRequiredService<IStringLocalizerFactory>().Create(typeof(Resources)));
    }
}