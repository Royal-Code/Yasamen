using Microsoft.AspNetCore.Components.Sections;

namespace RoyalCode.Yasamen.Components.Internal;

/// <summary>
/// <para>
///     A service to manage modal interactions.
/// </para>
/// </summary>
public sealed class ModalService
{
    private readonly List<ModalItem> items = [];
    private readonly List<ModalItem> openedItems = [];

    public IReadOnlyList<ModalItem> Items => items;

    internal ModalOutlet? Outlet { get; set; }

    public void Add(ModalItem item)
    {
        items.Add(item);
        Outlet?.StateHasChanged();
    }

    public void Remove(ModalItem item)
    {
        items.Remove(item);
        Outlet?.StateHasChanged();
    }

    public bool IsOpen { get; private set; }

    public async Task OpenAsync(ModalItem item)
    {
        IsOpen = true;
        Outlet?.StateHasChanged();

        var openedItem = openedItems.LastOrDefault();
        if (openedItem is not null)
        {
            await Task.Run(async () =>
            {
                openedItem.IsOpen = false;
                await openedItem.StateHasChangedAsync();

                openedItems.Add(item);
                item.IsOpen = true;
                await item.StateHasChangedAsync();
            });
        }
        else
        {
            openedItems.Add(item);
            item.IsOpen = true;
            await item.StateHasChangedAsync();
        }
    }

    public Task CloseAsync()
    {
        var openedItem = openedItems.LastOrDefault();
        if (openedItem is null)
            return Task.CompletedTask;

        return CloseAsync(openedItem);
    }

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
            await Task.Run(async () =>
            {
                openedItem.IsOpen = false;
                await openedItem.StateHasChangedAsync();
                nextOpenedItem.IsOpen = true;
                await nextOpenedItem.StateHasChangedAsync();
            });
        }
        else
        {
            openedItem.IsOpen = false;
            await openedItem.StateHasChangedAsync();
            IsOpen = false;
            Outlet?.StateHasChanged();
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

/// <summary>
/// <para>
///     Represents a modal item.
/// </para>
/// <para>
///     Modal item is used by <see cref="ModalService"/> and <see cref="ModalOutlet"/> 
///     to create <see cref="SectionOutlet"/> for each modal.
/// </para>
/// </summary>
public sealed class ModalItem
{
    /// <summary>
    /// Creates a new instance of <see cref="ModalItem"/>.
    /// </summary>
    /// <param name="id">The modal identifier. Required to identify the modal. Must be unique.</param>
    /// <param name="stateHasChangedAsync">The action to invoke when the state of the modal has changed.</param>
    public ModalItem(string id, Func<Task> stateHasChangedAsync)
    {
        Id = id;
        StateHasChangedAsync = stateHasChangedAsync;
    }

    /// <summary>
    /// <para>
    ///     Gets the value indicating whether the modal is open.
    /// </para>
    /// <para>
    ///     The set accessor is internal to allow the <see cref="ModalService"/> to control the state.
    /// </para>
    /// </summary>
    public bool IsOpen { get; internal set; }

    /// <summary>
    /// The modal identifier. Required to identify the modal. Must be unique.
    /// </summary>
    public string Id { get; }

    /// <summary>
    /// Determines whether the modal can be closed by clicking the backdrop or pressing the escape key.
    /// </summary>
    public bool Closeable { get; set; } = true;

    /// <summary>
    /// The action to invoke when the state of the modal has changed.
    /// </summary>
    public Func<Task> StateHasChangedAsync { get; }
}