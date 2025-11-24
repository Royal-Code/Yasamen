using RoyalCode.Razor.Commons.Results;

namespace RoyalCode.Razor.Layouts.Models;

public class AppMenuContext
{
    private readonly Action stateHasChanged;
    private readonly Func<MenuItem, Task<Message>>? toggleFavoriteAsync;
    private string? lastSearchValue;
    private MenuItem currentMenuItem;
    private MenuItem? filteredMenuItem;

    public AppMenuContext(Action stateHasChanged, Func<MenuItem, Task<Message>>? toggleFavoriteAsync)
    {
        this.stateHasChanged = stateHasChanged;
        this.toggleFavoriteAsync = toggleFavoriteAsync;
        currentMenuItem = new MenuItem();
    }

    public MenuItem? Root { get; private set; }

    public bool IsLoading { get; private set; }

    public MenuItem CurrentMenuItem => filteredMenuItem ?? currentMenuItem;

    public bool IsLoaded => Root is not null;

    public bool UseFavorites => toggleFavoriteAsync is not null;

    public void LoadingStarted()
    {
        IsLoading = true;
        stateHasChanged();
    }

    public void LoadingFinished(MenuItem root, MenuItem currentMenuItem)
    {
        Root = root;
        this.currentMenuItem = currentMenuItem;
        IsLoading = false;
        stateHasChanged();
    }

    public void SetCurrentMenuItem(MenuItem menuItem)
    {
        currentMenuItem = menuItem;
        stateHasChanged();
    }

    public async Task<Message> ToggleFavorite(MenuItem menuItem)
    {
        if (toggleFavoriteAsync is not null)
        {
            return await toggleFavoriteAsync(menuItem);
        }

        return Message.Success;
    }

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
                Children = [.. items]
            };
            lastSearchValue = value;
        }
        stateHasChanged();
    }
}
