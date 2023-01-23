namespace RoyalCode.Yasamen.Services.Internal;

[Obsolete("Está sendo usado o IDataServicesProvider e ModelFinder")
internal class InternalFinder<TModel, TFilter, TService> : IFinder<TModel, TFilter>
    where TModel: class
{
    private readonly TService service;
    private readonly FinderDelegate<TService, TFilter, TModel> finderDelegate;

    public InternalFinder(TService service, FinderDelegate<TService, TFilter, TModel> finderDelegate)
    {
        this.service = service;
        this.finderDelegate = finderDelegate;
    }

    public Task<TModel?> FindAsync(TFilter filter, CancellationToken token = default) =>
        finderDelegate(service, filter, token);
    
}

internal delegate Task<TModel?> FinderDelegate<TService, TFilter, TModel>(TService model, TFilter filter, CancellationToken token);