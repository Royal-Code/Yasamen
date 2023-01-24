using RoyalCode.Yasamen.Services.Performers;

namespace RoyalCode.Yasamen.Services.Internal;

internal class FinderPerformerService<TModel, TFilter> : IFinderPerformerService<TModel>
    where TModel : class
{
    private readonly IFinderPerformer<TModel, TFilter> finder;

    public FinderPerformerService(IFinderPerformer<TModel, TFilter> finder)
    {
        this.finder = finder ?? throw new ArgumentNullException(nameof(finder));
    }

    public async Task<TModel?> PerformAsync(object filter, CancellationToken cancellationToken)
    {
        return await finder.FindAsync((TFilter)filter, cancellationToken);
    }
}
