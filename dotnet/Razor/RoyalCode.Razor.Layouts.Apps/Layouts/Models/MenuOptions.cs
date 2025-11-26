namespace RoyalCode.Razor.Layouts.Models;

/// <summary>
/// Options to build a menu.
/// </summary>
public class MenuOptions
{
    /// <summary>
    /// The menu items to include in the menu.
    /// </summary>
    public ICollection<MenuItem> MenuItems { get; } = [];

    /// <summary>
    /// URL to load the menu items from.
    /// </summary>
    public string? MenuUrl { get; set; }

    /// <summary>
    /// <para>
    ///     Gets or sets the function used to deserialize an HTTP response into a collection of menu items.
    /// </para>
    /// </summary>
    /// <remarks>
    ///     Assign a delegate that takes an <see cref="HttpResponseMessage"/> and returns an 
    ///     <see cref="IEnumerable{MenuItem}"/> representing the parsed menu items.
    ///     <br />    
    ///     The deserializer will be invoked when loading menu items from the specified <see cref="MenuUrl"/>,
    ///     and the status code of the response is successful.
    /// </remarks>
    public Func<HttpResponseMessage, IEnumerable<MenuItem>>? Deserializer { get; set; }
}
