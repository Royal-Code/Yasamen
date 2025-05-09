namespace RoyalCode.Yasamen.Services.Infrastructure.Performers;

/// <summary>
/// <para>
///     Performer of Loader.
/// </para>
/// <para>
///     This is an internal interface to perform entity (or data model) loading.
/// </para>
/// </summary>
/// <typeparam name="TModel">The data model.</typeparam>
internal interface ILoaderPerformer<TModel>
{
    /// <summary>
    /// <para>
    ///     Load all entities (data models).
    /// </para>
    /// </summary>
    /// <param name="token">The cancellation token.</param>
    /// <returns>The list of data models.</returns>
    Task<IReadOnlyList<TModel>> LoadAsync(CancellationToken token = default);
}

/// <summary>
/// <para>
///     Performer of Loader.
/// </para>
/// <para>
///     This is an internal interface to perform entity (or data model) loading.
/// </para>
/// </summary>
/// <typeparam name="TModel">The data model.</typeparam>
internal interface ILoaderPerformer<TModel, TFilter>
{
    /// <summary>
    /// <para>
    ///     Load all entities (data models).
    /// </para>
    /// </summary>
    /// <param name="filter">The filter.</param>
    /// <param name="token">The cancellation token.</param>
    /// <returns>The list of data models.</returns>
    Task<IReadOnlyList<TModel>> LoadAsync(TFilter filter, CancellationToken token = default);
}