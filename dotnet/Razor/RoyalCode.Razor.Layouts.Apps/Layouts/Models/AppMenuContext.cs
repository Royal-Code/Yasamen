using RoyalCode.Razor.Commons.Results;
using RoyalCode.Razor.Components;

namespace RoyalCode.Razor.Layouts.Models;

/// <summary>
/// Provides state and behavior for the application menu, including loading state,
/// current selection, filtering, and favorite toggling.
/// </summary>
/// <remarks>
/// Designed for Blazor WASM layouts to manage menu interactions and UI updates.
/// </remarks>
public class AppMenuContext
{
    private readonly Action stateHasChanged;
    private readonly Func<MenuItem, Task<Message>>? toggleFavoriteAsync;
    private string? lastSearchValue;
    private MenuItem currentMenuItem;
    private MenuItem? filteredMenuItem;

    /// <summary>
    /// Initializes a new instance of the <see cref="AppMenuContext"/> class.
    /// </summary>
    /// <param name="stateHasChanged">Callback to notify the UI about state changes.</param>
    /// <param name="toggleFavoriteAsync">Optional async action to toggle a menu item as favorite.</param>
    public AppMenuContext(Action stateHasChanged, Func<MenuItem, Task<Message>>? toggleFavoriteAsync)
    {
        this.stateHasChanged = stateHasChanged;
        this.toggleFavoriteAsync = toggleFavoriteAsync;
        currentMenuItem = new MenuItem();
    }

    /// <summary>
    /// Gets the root menu item.
    /// </summary>
    public MenuItem? Root { get; private set; }

    /// <summary>
    /// Gets a value indicating whether the menu is currently loading.
    /// </summary>
    public bool IsLoading { get; private set; }

    /// <summary>
    /// Gets a value indicating whether a filter is currently applied.
    /// </summary>
    public bool IsFiltering => filteredMenuItem is not null;

    /// <summary>
    /// Gets the current menu item, considering filter state if active.
    /// </summary>
    public MenuItem CurrentMenuItem => filteredMenuItem ?? currentMenuItem;

    /// <summary>
    /// Gets the exception thrown during menu loading, if any.
    /// </summary>
    public Exception? LoadException { get; private set; }

    /// <summary>
    /// Gets or sets the handler to control the off-canvas menu panel.
    /// </summary>
    public OffCanvasHandler? Handler { get; internal set; }

    /// <summary>
    /// Gets a value indicating whether the menu has been loaded.
    /// </summary>
    public bool IsLoaded => Root is not null;

    /// <summary>
    /// Gets a value indicating whether favorites functionality is enabled.
    /// </summary>
    public bool UseFavorites => toggleFavoriteAsync is not null;

    /// <summary>
    /// Marks the loading process as started and notifies the UI.
    /// </summary>
    public void LoadingStarted()
    {
        IsLoading = true;
        stateHasChanged();
    }

    /// <summary>
    /// Completes the loading process, sets the root and current item, and notifies the UI.
    /// </summary>
    /// <param name="root">The loaded root menu item.</param>
    public void LoadingFinished(MenuItem root)
    {
        Root = root;
        currentMenuItem = root;
        IsLoading = false;
        stateHasChanged();
    }

    /// <summary>
    /// Marks the loading process as failed, stores the exception, and notifies the UI.
    /// </summary>
    /// <param name="ex">The exception thrown during loading.</param>
    public void LoadingFailed(Exception ex)
    {
        IsLoading = false;
        LoadException = ex;
        stateHasChanged();
    }

    /// <summary>
    /// Sets the current menu item and notifies the UI.
    /// </summary>
    /// <param name="menuItem">The menu item to set as current.</param>
    public void SetCurrentMenuItem(MenuItem menuItem)
    {
        currentMenuItem = menuItem;
        stateHasChanged();
    }

    /// <summary>
    /// Toggles the favorite state of a menu item if supported.
    /// </summary>
    /// <param name="menuItem">The target menu item.</param>
    /// <returns>A <see cref="Message"/> indicating the outcome.</returns>
    public async Task<Message> ToggleFavorite(MenuItem menuItem)
    {
        if (toggleFavoriteAsync is not null)
        {
            return await toggleFavoriteAsync(menuItem);
        }

        return Message.Success;
    }

    /// <summary>
    /// Applies a filter to the root menu and updates the current view.
    /// </summary>
    /// <param name="value">The filter query. Clears the filter when null or whitespace.</param>
    public void Filter(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            filteredMenuItem = null;
            lastSearchValue = null;
        }
        else if (value != lastSearchValue && Root is not null)
        {
            var items = Root.Filter(value);
            filteredMenuItem = new MenuItem()
            {
                Type = MenuItemType.Module,
                Children = [.. items]
            };
            lastSearchValue = value;
        }
        stateHasChanged();
    }
}
