using RoyalCode.Yasamen.Services.Performers;

namespace RoyalCode.Yasamen.Services.Internal;

internal class LoaderPerfomer<TModel, TService> : ILoaderPerformer<TModel>
    where TModel : class
{
    private readonly TService service;
    private readonly LoaderDelegate<TService, TModel> loaderDelegate;

    public LoaderPerfomer(TService service, LoaderDelegate<TService, TModel> loaderDelegate)
    {
        this.service = service;
        this.loaderDelegate = loaderDelegate;
    }

    public Task<IEnumerable<TModel>> LoadAsync(CancellationToken token = default)
        => loaderDelegate(service, token);
}

internal delegate Task<IEnumerable<TModel>> LoaderDelegate<TService, TModel>(TService service, CancellationToken cancellationToken = default);