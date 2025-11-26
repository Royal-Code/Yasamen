namespace RoyalCode.Razor.Layouts.Models;

/// <summary>
/// <para>
///     Default implementation of <see cref="IMenuLoader"/> that loads menu items via HTTP, 
///     using the provided <see cref="MenuOptions"/> and the <see cref="MenuOptions.MenuUrl"/> property.
/// </para>
/// <para>
///     When the <see cref="MenuOptions.MenuUrl"/> is not set, it returns the static menu items defined
///     in the <see cref="MenuOptions.MenuItems"/> collection.
/// </para>
/// </summary>
public sealed class HttpMenuLoader : IMenuLoader
{
    private readonly HttpClient httpClient;
    private readonly MenuOptions options;

    /// <summary>
    /// Creates a new instance of <see cref="HttpMenuLoader"/>.
    /// </summary>
    /// <param name="httpClient"></param>
    /// <param name="options"></param>
    public HttpMenuLoader(HttpClient httpClient, MenuOptions options)
    {
        this.httpClient = httpClient;
        this.options = options;
    }

    /// <summary>
    /// Asynchronously loads the collection of menu items from the configured menu URL or returns empty collection.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>
    ///     A task that represents the asynchronous operation.
    ///     The task result contains an enumerable collection of loaded menu items.
    /// </returns>
    public async Task<IEnumerable<MenuItem>> LoadMenuItemsAsync(CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(options.MenuUrl))
            return [];

        var response = await httpClient.GetAsync(options.MenuUrl, cancellationToken);
        response.EnsureSuccessStatusCode();

        if (options.Deserializer != null)
        {
            return options.Deserializer(response);
        }

        var list = await response.UnzipFromJsonAsync(MenuJsonContext.Default.IReadOnlyListMenuItem, cancellationToken);
        return list ?? [];
    }
}