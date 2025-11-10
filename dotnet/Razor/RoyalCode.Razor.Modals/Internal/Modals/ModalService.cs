namespace RoyalCode.Razor.Internal.Modals;

/// <summary>
/// <para>
///     A service to manage modal interactions.
/// </para>
/// <para>
///     This service allows adding, removing, opening, and closing modal items.
///     It keeps track of the currently opened modals and ensures that only one modal is open at a time.
/// </para>
/// <para>
///     As a service, it is intended to be a singleton per web application, 
///     typically registered in the dependency injection container as a scoped service,
///     because on WASM it will work like singleton, and on server-side it will be scoped per user session.
/// </para>
/// </summary>
public sealed class ModalService
{
    private readonly List<ModalItem> items = [];
    private readonly List<ModalItem> openedItems = [];

    /// <summary>
    /// An ordered read-only list of modal items, representing the modals managed by the service (opened).
    /// </summary>
    public IReadOnlyList<ModalItem> Items => items;

    /// <summary>
    /// The ModalOutlet component associated with this service.
    /// </summary>
    internal ModalOutlet? Outlet { get; set; }

    /// <summary>
    /// Adds a modal item. This will create a SectionOutlet for the modal item.
    /// </summary>
    /// <param name="item">The modal item to be added.</param>
    public void Add(ModalItem item)
    {
        items.Add(item);
        Outlet?.StateHasChanged();
    }

    /// <summary>
    /// Removes a modal item. The SectionOutlet associated with the modal item will be removed.
    /// </summary>
    /// <param name="item">The modal item to be removed.</param>
    public void Remove(ModalItem item)
    {
        items.Remove(item);
        Outlet?.StateHasChanged();
    }

    /// <summary>
    /// Check if any modal is currently opened.
    /// </summary>
    public bool IsOpen { get; private set; }

    /// <summary>
    /// <para>
    ///     Open a specific modal.
    /// </para>
    /// <para>
    ///     If a modal is already opened, it will be closed before opening the new modal.
    /// </para>
    /// </summary>
    /// <param name="item">A modal item to be opened.</param>
    /// <returns>A task that represents the asynchronous operation, finishing when the modal is opened.</returns>
    public async Task OpenAsync(ModalItem item)
    {
        IsOpen = true;

        if (Outlet is not null)
            await Outlet.StateHasChangedAsync();

        var openedItem = openedItems.LastOrDefault();
        if (openedItem is not null)
        {
            if (Outlet is not null)
            {
                await Outlet.RunAsync(async () =>
                {
                    openedItem.IsOpen = false;
                    await openedItem.StateHasChangedAsync();
                    Outlet.StateHasChanged();

                    openedItems.Add(item);
                    item.IsOpen = true;
                    await item.StateHasChangedAsync();
                    Outlet.StateHasChanged();
                });
            }
        }
        else
        {
            openedItems.Add(item);
            item.IsOpen = true;
            await item.StateHasChangedAsync();
            Outlet?.StateHasChanged();
        }
    }

    /// <summary>
    /// Close the currently opened modal.
    /// </summary>
    /// <returns></returns>
    public Task CloseAsync()
    {
        var openedItem = openedItems.LastOrDefault();
        if (openedItem is null)
            return Task.CompletedTask;

        return CloseAsync(openedItem);
    }

    /// <summary>
    /// Close a specific modal item. If there was a previously opened modal, it will be reopened.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public async Task CloseAsync(ModalItem item)
    {
        var openedItem = openedItems.LastOrDefault();
        if (openedItem is null)
            return;

        openedItems.Remove(item);
        if (openedItem != item)
            return;

        var nextOpenedItem = openedItems.LastOrDefault();

        if (nextOpenedItem is not null)
        {
            if (Outlet is not null)
            {
                await Outlet.RunAsync(async () =>
                {
                    openedItem.IsOpen = false;
                    await openedItem.StateHasChangedAsync();
                    Outlet.StateHasChanged();

                    nextOpenedItem.IsOpen = true;
                    await nextOpenedItem.StateHasChangedAsync();
                    Outlet.StateHasChanged();
                });
            }
        }
        else
        {
            openedItem.IsOpen = false;
            await openedItem.StateHasChangedAsync();
            Outlet?.StateHasChanged();

            IsOpen = false;
            if (Outlet is not null)
                await Outlet.StateHasChangedAsync();
        }
    }

    /// <summary>
    /// <para>
    ///     Executes the action for the backdrop.
    /// </para>
    /// <para>
    ///     If the last opened item is closeable, it will be closed.
    /// </para>
    /// </summary>
    /// <returns></returns>
    public Task BackdropActionAsync()
    {
        var openedItem = openedItems.LastOrDefault();
        return openedItem?.Closeable is true ? CloseAsync(openedItem) : Task.CompletedTask;
    }
}

