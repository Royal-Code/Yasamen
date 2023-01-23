namespace RoyalCode.Yasamen.Services.Internal;

internal class FinderServiceExecutor<TModel, TFilter> : IFinderServiceExecutor<TModel>
    where TModel : class
{
    private readonly IFinder<TModel, TFilter> finder;

    public FinderServiceExecutor(IFinder<TModel, TFilter> finder)
    {
        this.finder = finder ?? throw new ArgumentNullException(nameof(finder));
    }

    public async Task<TModel?> ExecuteAsync(object filter, CancellationToken cancellationToken)
    {
        return await finder.FindAsync((TFilter)filter, cancellationToken);
    }
}
