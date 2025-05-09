using RoyalCode.Yasamen.Services.Infrastructure.Performers;

namespace RoyalCode.Yasamen.Services.Infrastructure.Internal;

internal class LoaderPerformer<TModel, TService> : ILoaderPerformer<TModel>
    where TModel : class
{
    private readonly TService service;
    private readonly LoaderDelegate<TService, TModel> loaderDelegate;

    public LoaderPerformer(TService service, LoaderDelegate<TService, TModel> loaderDelegate)
    {
        this.service = service;
        this.loaderDelegate = loaderDelegate;
    }

    public Task<IReadOnlyList<TModel>> LoadAsync(CancellationToken token = default)
        => loaderDelegate(service, token);
}

internal class LoaderPerformer<TModel, TFilter, TService> : ILoaderPerformer<TModel, TFilter>
    where TModel : class
{
    private readonly TService service;
    private readonly LoaderDelegate<TService, TFilter, TModel> loaderDelegate;

    public LoaderPerformer(TService service, LoaderDelegate<TService, TFilter, TModel> loaderDelegate)
    {
        this.service = service;
        this.loaderDelegate = loaderDelegate;
    }

    public Task<IReadOnlyList<TModel>> LoadAsync(TFilter filter, CancellationToken token = default)
        => loaderDelegate(service, filter, token);
}

internal delegate Task<IReadOnlyList<TModel>> LoaderDelegate<TService, TModel>(TService service, CancellationToken cancellationToken = default);
internal delegate Task<IReadOnlyList<TModel>> LoaderDelegate<TService, TFilter, TModel>(TService service, TFilter filter, CancellationToken cancellationToken = default);