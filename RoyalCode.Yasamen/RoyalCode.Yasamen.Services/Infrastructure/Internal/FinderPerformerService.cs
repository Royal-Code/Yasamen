using RoyalCode.Yasamen.Services.Infrastructure.Performers;

namespace RoyalCode.Yasamen.Services.Infrastructure.Internal;

/// <inheritdoc />
internal class FinderPerformerService<TModel, TFilter> : IFinderPerformerService<TModel>
    where TModel : class
{
    private readonly IFinderPerformer<TModel, TFilter> finder;

    /// <summary>
    /// Creates a new instance of <see cref="FinderPerformerService{TModel, TFilter}"/>.
    /// </summary>
    /// <param name="finder">The finder performer.</param>
    /// <exception cref="ArgumentNullException">If <paramref name="finder"/> is null.</exception>
    public FinderPerformerService(IFinderPerformer<TModel, TFilter> finder)
    {
        this.finder = finder ?? throw new ArgumentNullException(nameof(finder));
    }

    /// <inheritdoc />
    public async Task<TModel?> PerformAsync(object filter, CancellationToken cancellationToken)
    {
        return await finder.FindAsync((TFilter)filter, cancellationToken);
    }
}
