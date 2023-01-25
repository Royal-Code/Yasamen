namespace RoyalCode.Yasamen.Services.Infrastructure.Performers;

/// <summary>
/// <para>
///     Performer of Finder.
/// </para>
/// <para>
///     This is an internal interface to perform the search for entities (data models) through a filter,
///     which is usually the identity (id).
/// </para>
/// </summary>
/// <typeparam name="TModel">The data model.</typeparam>
/// <typeparam name="TFilter">The filter to find the model.</typeparam>
public interface IFinderPerformer<TModel, in TFilter>
    where TModel : class
{
    /// <summary>
    /// <para>
    ///     Search by data model from a filter.
    /// </para>
    /// </summary>
    /// <param name="filter">The filter to find the model.</param>
    /// <param name="token">The cancellation token.</param>
    /// <returns>The data model or null if not found.</returns>
    Task<TModel?> FindAsync(TFilter filter, CancellationToken token = default);
}