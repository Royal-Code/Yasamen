namespace RoyalCode.Razor.Layouts.Models;

/// <summary>
/// Service to load menu items.
/// </summary>
public interface IMenuLoader
{
    /// <summary>
    /// Loads the menu items.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<IEnumerable<MenuItem>> LoadMenuItemsAsync(CancellationToken cancellationToken = default);
}
