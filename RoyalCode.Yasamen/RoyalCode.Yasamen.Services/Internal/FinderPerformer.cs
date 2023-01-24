using RoyalCode.Yasamen.Services.Performers;

namespace RoyalCode.Yasamen.Services.Internal;

internal class FinderPerformer<TModel, TFilter, TService> : IFinderPerformer<TModel, TFilter>
    where TModel: class
{
    private readonly TService service;
    private readonly FinderDelegate<TService, TFilter, TModel> finderDelegate;

    public FinderPerformer(TService service, FinderDelegate<TService, TFilter, TModel> finderDelegate)
    {
        this.service = service;
        this.finderDelegate = finderDelegate;
    }

    public Task<TModel?> FindAsync(TFilter filter, CancellationToken token = default) =>
        finderDelegate(service, filter, token);
    
}

internal delegate Task<TModel?> FinderDelegate<TService, TFilter, TModel>(TService model, TFilter filter, CancellationToken token);