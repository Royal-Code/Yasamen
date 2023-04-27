namespace RoyalCode.Yasamen.Services.Infrastructure.Performers;

/// <summary>
/// <para>
///     Performer of a named Loader.
/// </para>
/// <para>
///     This is an internal interface to perform entity (or data model) loading.
/// </para>
/// </summary>
/// <typeparam name="TModel">The data model.</typeparam>
internal interface INamedLoaderPerformer<TModel>
{
    /// <summary>
    /// <para>
    ///     Load all entities (data models).
    /// </para>
    /// </summary>
    /// <param name="name">The name of the loader.</param>
    /// <param name="token">The cancellation token.</param>
    /// <returns>The list of data models.</returns>
    Task<IEnumerable<TModel>> LoadAsync(string name, CancellationToken token = default);
}


/// <summary>
/// <para>
///     Performer of a named Loader.
/// </para>
/// <para>
///     This is an internal interface to perform entity (or data model) loading.
/// </para>
/// </summary>
/// <typeparam name="TModel">The data model.</typeparam>
internal interface INamedLoaderPerformer<TModel, TFilter>
{
    /// <summary>
    /// <para>
    ///     Load all entities (data models).
    /// </para>
    /// </summary>
    /// <param name="filter">The filter.</param>
    /// <param name="token">The cancellation token.</param>
    /// <returns>The list of data models.</returns>
    Task<IEnumerable<TModel>> LoadAsync(string name, TFilter filter, CancellationToken token = default);
}