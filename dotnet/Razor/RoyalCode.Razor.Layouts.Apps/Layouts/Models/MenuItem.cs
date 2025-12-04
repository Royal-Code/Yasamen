using System.Text.Json.Serialization;

namespace RoyalCode.Razor.Layouts.Models;

/// <summary>
/// Represents a menu item in the application menu.
/// </summary>
public class MenuItem
{
    /// <summary>
    /// A unique identifier for the menu item.
    /// </summary>
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// The display text of the menu item.
    /// </summary>
    public string Text { get; set; } = string.Empty;
    
    /// <summary>
    /// The URL the menu item points to.
    /// </summary>
    public string Url { get; set; } = string.Empty;

    /// <summary>
    /// The type of the menu item.
    /// </summary>
    public MenuItemType Type { get; set; } = MenuItemType.Link;

    /// <summary>
    /// Gets or sets a value indicating whether the item is marked as a favorite.
    /// </summary>
    public bool IsFavorite { get; set; }

    /// <summary>
    /// The parent menu item, if any.
    /// </summary>
    public MenuItem? Parent { get; set; }

    /// <summary>
    /// The child menu items.
    /// </summary>
    public IReadOnlyList<MenuItem> Children { get; set; } = [];

    /// <summary>
    /// Determines whether the menu item is a leaf node (i.e., has no children).
    /// </summary>
    [JsonIgnore]
    public bool IsLeaf => Children.Count == 0;

    /// <summary>
    /// Try to find a menu item by its unique identifier.
    /// </summary>
    /// <param name="id">A unique identifier of the menu item to find.</param>
    /// <returns>The found menu item or null if not found.</returns>
    public MenuItem? Find(string id)
    {
        if (id == Id)
            return this;

        foreach (var child in Children)
        {
            var item = child.Find(id);
            if (item is not null)
                return item;
        }

        return null;
    }

    /// <summary>
    /// Filter the menu items based on the specified value.
    /// </summary>
    /// <param name="value">The value to filter by.</param>
    /// <returns>An enumerable collection of filtered menu items.</returns>
    public IEnumerable<MenuItem> Filter(string value)
    {
        if (Type == MenuItemType.Link && ContainsText(value))
            yield return this;

        foreach (var child in Children)
        {
            var filteredChildren = child.Filter(value);
            foreach (var item in filteredChildren)
            {
                yield return item;
            }
        }
    }

    /// <summary>
    /// Verifies if the menu item text contains the specified value.
    /// </summary>
    /// <param name="value">The value to search for.</param>
    /// <returns>True if the text contains the value; otherwise, false.</returns>
    public bool ContainsText(string value)
    {
        return Text is not null && Text.Contains(value, StringComparison.InvariantCultureIgnoreCase);
    }

    /// <summary>
    /// Sets the parent reference for all child menu items recursively.
    /// </summary>
    public void SetParentForChildren()
    {
        foreach (var child in Children)
        {
            child.Parent = this;
            child.SetParentForChildren();
        }
    }
}

/// <summary>
/// The type of the menu item.
/// </summary>
public enum MenuItemType
{
    /// <summary>
    /// Represents a link menu item.
    /// </summary>
    Link,
    
    /// <summary>
    /// Represents a divider menu item.
    /// </summary>
    Divider,

    /// <summary>
    /// Represents a module menu item, typically used for grouping other items.
    /// </summary>
    Module,
}