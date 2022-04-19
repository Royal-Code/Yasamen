namespace RoyalCode.Yasamen.Services.Internal;

internal class InternalFinder<TModel, TFilter>: IFinder<TModel, TFilter>
    where TModel: class
{
    private readonly TModel model;
    private readonly FinderDelegate finderDelegate;

    public InternalFinder(TModel model, FinderDelegate finderDelegate)
    {
        this.model = model;
        this.finderDelegate = finderDelegate;
    }

    public Task<TModel?> FindAsync(TFilter filter, CancellationToken token = default) =>
        finderDelegate(model, filter, token);
    
    internal delegate Task<TModel?> FinderDelegate(TModel model, TFilter filter, CancellationToken token);
}