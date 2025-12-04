using Microsoft.Extensions.Options;

namespace RoyalCode.Razor.Layouts.Models;

/// <summary>
/// <para>
///     Provides functionality for loading and accessing the application's menu structure 
///     using configurable options and a menu loader.
/// </para>
/// </summary>
/// <remarks>
///     The menu is loaded using the specified <see cref="IMenuLoader"/> implementation and menu options.
///     The root menu item is cached after the initial load to improve performance.
///     If a menu URL is not configured in <see cref="MenuOptions.MenuUrl"/>, 
///     static menu items from <see cref="MenuOptions.MenuItems"/> are used instead.
///     This class is thread-safe for concurrent calls to <see cref="GetMenuAsync"/>.
/// </remarks>
public sealed class MenuService
{
    private readonly MenuOptions options;
    private readonly IMenuLoader menuLoader;

    private MenuItem? menuItem;

    /// <summary>
    /// Creates a new instance of <see cref="MenuService"/>.
    /// </summary>
    /// <param name="options"></param>
    /// <param name="menuLoader"></param>
    public MenuService(IOptions<MenuOptions> options, IMenuLoader menuLoader)
    {
        this.options = options.Value;
        this.menuLoader = menuLoader;
    }

    /// <summary>
    /// <para>
    ///     Gets the menu asynchronously.
    /// </para>
    /// </summary>
    /// <remarks>
    ///     The root menu item is cached after the first load.
    ///     For loading the menu, the configured <see cref="IMenuLoader"/> is used.
    ///     If none <see cref="MenuOptions.MenuUrl"/> is set, the static menu items defined
    ///     in the <see cref="MenuOptions.MenuItems"/> collection are used.
    /// </remarks>    
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>
    ///     The root <see cref="MenuItem"/> representing the menu.
    /// </returns>
    /// <exception cref="HttpRequestException">
    ///     Thrown when the menu cannot be loaded.
    /// </exception>
    public ValueTask<MenuItem> GetMenuAsync(CancellationToken cancellationToken = default)
    {
        if (menuItem != null)
            return ValueTask.FromResult(menuItem);

        return LoadMenuAsync(cancellationToken);
    }

    private async ValueTask<MenuItem> LoadMenuAsync(CancellationToken cancellationToken)
    {
        var menuItems = await menuLoader.LoadMenuItemsAsync(cancellationToken);
        var root = new MenuItem
        {
            Id = "ya-root-menu",
            Text = "Menu",
            Type = MenuItemType.Module,
            Children = [.. menuItems]
        };

        foreach (var item in options.MenuItems)
        {
            var parent = root.Find(item.Id);
            if (parent != null)
                parent.Children = [..parent.Children, .. item.Children];
            else
                root.Children = [..root.Children, item];
        }

        root.SetParentForChildren();

        menuItem = root;
        return root;
    }
}