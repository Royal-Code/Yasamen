using RoyalCode.Yasamen.Services.Infrastructure.Performers;

namespace RoyalCode.Yasamen.Services.Infrastructure.Internal;

/// <summary>
/// <para>
///     This is an internal service to help the <see cref="IFinderPerformer{TModel, TFilter}"/> perform.
/// </para>
/// </summary>
/// <typeparam name="TModel"></typeparam>
internal interface IFinderPerformerService<TModel>
    where TModel : class
{
    /// <summary>
    /// Perform the find.
    /// </summary>
    /// <param name="filter">The filter used to find the model.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The model found or null.</returns>
    Task<TModel?> PerformAsync(object filter, CancellationToken cancellationToken);
}
