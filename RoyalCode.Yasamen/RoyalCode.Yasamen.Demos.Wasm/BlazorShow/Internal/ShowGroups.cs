namespace RoyalCode.Yasamen.Demos.Wasm.BlazorShow.Internal;

/// <summary>
/// <para>
///     A collection of <see cref="Group"/> of <see cref="IShowDescription"/>.
/// </para>
/// </summary>
public class ShowGroups
{
    /// <summary>
    /// Creates the groups for the show descriptions of the catalog.
    /// </summary>
    /// <param name="catalog">The show catalog.</param>
    public ShowGroups(ICatalog catalog)
    {
        Groups = catalog.ShowDescriptions
            .GroupBy(x => x.Group ?? string.Empty)
            .Select(x => new Group(x.Key, x))
            .ToList();
    }

    /// <summary>
    /// All show descriptions groups.
    /// </summary>
    public IEnumerable<Group> Groups { get; }
}
