using RoyalCode.Yasamen.Services.Infrastructure.Internal;
using System.Collections.Immutable;

namespace RoyalCode.Yasamen.Services;

public static class ModelLoaderExtensions
{
    public static IModelLoader<TModel> ToModelLoader<TModel>(this IEnumerable<TModel> models)
    {
        return new ModelLoader<TModel>(models.ToImmutableList());
    }
}
