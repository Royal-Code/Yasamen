using RoyalCode.Yasamen.Services.Infrastructure.Performers;

namespace RoyalCode.Yasamen.Services.Infrastructure.Internal;

internal class NamedLoaderPerformer<TModel, TService> : INamedLoaderPerformer<TModel>
    where TModel : class
{
    private readonly TService service;

    public NamedLoaderPerformer(TService service)
    {
        this.service = service;
    }

    public Task<IReadOnlyList<TModel>> LoadAsync(string name, CancellationToken token = default)
    {
        var loaderDelegate = NamedLoaders.GetDelegate(name, typeof(TModel));
        if (loaderDelegate is not LoaderDelegate<TService, TModel> loader)
            throw new InvalidOperationException($"Loader for {typeof(TModel).Name} with name {name} not found");

        return loader(service, token);
    }
}

internal class NamedLoaderPerformer<TModel, TFilter, TService> : INamedLoaderPerformer<TModel, TFilter>
    where TModel : class
{
    private readonly TService service;

    public NamedLoaderPerformer(TService service)
    {
        this.service = service;
    }

    public Task<IReadOnlyList<TModel>> LoadAsync(string name, TFilter filter, CancellationToken token = default)
    {
        var loaderDelegate = NamedLoaders.GetDelegate(name, typeof(TModel), typeof(TFilter));
        if (loaderDelegate is not LoaderDelegate<TService, TFilter, TModel> loader)
            throw new InvalidOperationException($"Loader for {typeof(TModel).Name} with name {name} not found");

        return loader(service, filter, token);
    }
}